namespace Finance.Infrastructure.Data.UnitOfWork
{
    using System.Linq;
    using Core;
    using Domain.Bank.Aggregates.BankAccountAggregate;
    using Domain.Creditor.Aggregates.CreditorAggregate;
    using Domain.Treasury.Aggregates.BankPostingAggregate;
    using Domain.Treasury.Aggregates.CategoryAggregate;

    public interface IFinanceUnitOfWork : IQueryableUnitOfWork
    {
        IQueryable<BankAccount> BankAccount { get; }

        IQueryable<BankPosting> BankPosting { get; }

        IQueryable<Category> Cateogry { get; }

        IQueryable<Creditor> Creditor { get; }
    }
}