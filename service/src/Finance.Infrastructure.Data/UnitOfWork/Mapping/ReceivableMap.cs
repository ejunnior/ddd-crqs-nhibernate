namespace Infrastructure.Data.UnitOfWork.Mapping
{
    using Domain.Treasury.Aggregates.BillAggregate;
    using FluentNHibernate.Mapping;

    internal class ReceivableMap : SubclassMap<Receivable>
    {
        internal ReceivableMap()
        {
            References(receivable => receivable.BankAccount)
                .ForeignKey("FK_RECE_BAAC_01")
                .Column("BankAccountId")
                .Not
                .Nullable();

            References(receivable => receivable.GlAccount)
                .ForeignKey("FK_RECE_GLAC_01")
                .Column("GlAccountId")
                .Not
                .Nullable();

            Table("Receivables");
        }
    }
}