namespace Finance.Application.Bank.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;
    using Dapper;
    using Domain.Core;
    using Dto;

    public class GetBankAccountQuery
        : IQuery<IList<GetBankAccountDto>>
    {
    }

    public class GetCreditorQueryHandler
        : IQueryHandler<GetBankAccountQuery, IList<GetBankAccountDto>>
    {
        private static string ConnectionString => Environment.GetEnvironmentVariable("ConnectionStrings__FinanceConnectionString");

        public async Task<IList<GetBankAccountDto>> HandleAsync(GetBankAccountQuery args)
        {
            var sql = @"
                    select
	                    id,
                        accountnumber

                    from bankaccount";

            using (var connection = new SqlConnection(ConnectionString))
            {
                var result = await connection
                    .QueryAsync<GetBankAccountDto>(sql);

                return result.ToList();
            }
        }
    }
}