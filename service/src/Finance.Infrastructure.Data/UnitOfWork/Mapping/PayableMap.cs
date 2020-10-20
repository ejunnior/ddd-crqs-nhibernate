namespace Infrastructure.Data.UnitOfWork.Mapping
{
    using System;
    using Domain.Treasury.Aggregates.BankPostingAggregate;
    using Domain.Treasury.Aggregates.BillAggregate;
    using FluentNHibernate.Mapping;
    using NHibernate.Mapping;

    internal class PayableMap : SubclassMap<Payable>
    {
        internal PayableMap()
        {
            Table("Payables");

            References(payable => payable.Vendor)
                .ForeignKey("FK_PAYA_VEND_01")
                .Column("VendorId")
                .Not
                .Nullable();

            References(payable => payable.BankAccount)
                .ForeignKey("FK_PAYA_BAAC_01")
                .Column("BankAccountId")
                .Not
                .Nullable();

            References(payable => payable.Cateogry)
                .ForeignKey("FK_PAYA_CATE_01")
                .Column("CategoryId")
                .Not
                .Nullable();
        }
    }
}