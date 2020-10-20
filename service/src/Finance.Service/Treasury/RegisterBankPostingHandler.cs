namespace Finance.Service.Treasury
{
    using CSharpFunctionalExtensions;
    using Domain.Treasury.Aggregates.BankPostingAggregate;
    using MassTransit;
    using System;
    using System.Threading.Tasks;
    using Domain.Bank.Aggregates.BankAccountAggregate;
    using Domain.Creditor.Aggregates.CreditorAggregate;
    using Domain.Treasury.Aggregates.CategoryAggregate;

    public class RegisterBankPostingHandler
        : IConsumer<RegisterBankPostingCommand>
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IBankPostingRepository _bankPostingRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICreditorRepository _creditorRepository;

        public RegisterBankPostingHandler(
            ICreditorRepository creditorRepository,
            IBankAccountRepository bankAccountRepository,
            ICategoryRepository categoryRepository,
            IBankPostingRepository bankPostingRepository)
        {
            _creditorRepository = creditorRepository;
            _bankAccountRepository = bankAccountRepository;
            _categoryRepository = categoryRepository;
            _bankPostingRepository = bankPostingRepository;
        }

        public async Task Consume(ConsumeContext<RegisterBankPostingCommand> context)
        {
            if (!Enum.IsDefined(typeof(BankPostingType), //TODO : Review this code.
                context.Message.Type))
                throw new InvalidOperationException();

            var creditor = await _creditorRepository
                .GetAsync(context.Message.CreditorId);

            var bankAccount = await _bankAccountRepository
                .GetAsync(context.Message.BankAccountId);

            var category = await _categoryRepository
                .GetAsync(context.Message.CategoryId);

            var bankPosting = BankPostingFactory.Create(
                amount: context.Message.Amount,
                dueDate: context.Message.DueDate,
                documentDate: context.Message.DocumentDate,
                documentNumber: context.Message.DocumentNumber,
                creditor: creditor,
                description: context.Message.Description,
                bankAccount: bankAccount,
                category: category,
                paymentDate: context.Message.PaymentDate,
                type: context.Message.Type).Value;

            await _bankPostingRepository
                .AddAsync(bankPosting);
        }
    }
}