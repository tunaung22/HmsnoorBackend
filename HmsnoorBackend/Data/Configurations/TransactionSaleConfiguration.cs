using HmsnoorBackend.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HmsnoorBackend.Data.Configurations;

public class TransactionSaleConfiguration : IEntityTypeConfiguration<TransactionSale>
{
    public void Configure(EntityTypeBuilder<TransactionSale> builder)
    {
        builder.ToTable("TransactionSales");
        builder.HasKey(e => e.InvoiceNo);

        builder.Property(e => e.SalesType)
            .HasColumnName("SalesType")
            .HasColumnType("nvarchar(100)")
            .HasMaxLength(100);

        builder.Property(e => e.InvoiceNo)
            .HasColumnName("InvoiceNo")
            .HasColumnType("nvarchar(20)")
            .HasMaxLength(20);

        builder.Property(e => e.InvoiceDate)
            .HasColumnName("InvoiceDate")
            .HasColumnType("date");

        builder.Property(e => e.VoucherNo)
            .HasColumnName("VoucherNo")
            .HasColumnType("nvarchar(20)")
            .HasMaxLength(20);

        builder.Property(e => e.Currency)
            .HasColumnName("Currency")
            .HasColumnType("int")
            .HasMaxLength(4);

        builder.Property(e => e.ReceivableType)
            .HasColumnName("ReceivableType")
            .HasColumnType("nvarchar(10)")
            .HasMaxLength(10);

        builder.Property(e => e.RegistrationNo)
            .HasColumnName("RegistrationNo")
            .HasColumnType("nvarchar(20)")
            .HasMaxLength(20);

        builder.Property(e => e.Remark)
            .HasColumnName("Remark")
            .HasColumnType("nvarchar(max)");

        builder.Property(e => e.Total)
            .HasColumnName("Total")
            .HasColumnType("money");

        builder.Property(e => e.DiscountPers)
            .HasColumnName("DiscountPers")
            .HasColumnType("money");

        builder.Property(e => e.DiscountAmt)
            .HasColumnName("DiscountAmt")
            .HasColumnType("money");

        builder.Property(e => e.TaxPers)
            .HasColumnName("TaxPers")
            .HasColumnType("money");

        builder.Property(e => e.TaxAmount)
            .HasColumnName("TaxAmount")
            .HasColumnType("money");

        builder.Property(e => e.ServicePers)
            .HasColumnName("ServicePers")
            .HasColumnType("money");

        builder.Property(e => e.ServiceAmount)
            .HasColumnName("ServiceAmount")
            .HasColumnType("money");

        builder.Property(e => e.NetAmount)
            .HasColumnName("NetAmount")
            .HasColumnType("money");

        builder.Property(e => e.CashierId)
            .HasColumnName("CashierId")
            .HasColumnType("nvarchar(20)")
            .HasMaxLength(20);

        builder.Property(e => e.CreateUserId)
            .HasColumnName("CreateUserId")
            .HasColumnType("int")
            .HasMaxLength(4);

        builder.Property(e => e.CreateDate)
            .HasColumnName("CreateDate")
            .HasColumnType("datetime");

        builder.Property(e => e.ModifyUserId)
            .HasColumnName("ModifyUserId")
            .HasColumnType("int")
            .HasMaxLength(10);

        builder.Property(e => e.ModifyDate)
            .HasColumnName("ModifyDate")
            .HasColumnType("datetime");

        builder.Property(e => e.PaidDate)
            .HasColumnName("PaidDate")
            .HasColumnType("date");

        builder.Property(e => e.ServiceTaxPers)
            .HasColumnName("ServiceTaxPers")
            .HasColumnType("money");

        builder.Property(e => e.ServiceTaxAmount)
            .HasColumnName("ServiceTaxAmount")
            .HasColumnType("money");

        builder.Property(e => e.IsPaidBill)
            .HasColumnName("isPaidBill")
            .HasColumnType("bit");


        builder.Property(e => e.MemberCardNo)
            .HasColumnName("MemberCardNo")
            .HasColumnType("nvarchar(100)")
            .HasMaxLength(100);

        builder.Property(e => e.StaffName)
            .HasColumnName("StaffName")
            .HasColumnType("nvarchar(500)")
            .HasMaxLength(500);

        builder.Property(e => e.CashPaymentDollar)
            .HasColumnName("CashPaymentDollar")
            .HasColumnType("money");

        builder.Property(e => e.CashPaymentKs)
            .HasColumnName("CashPaymentKS")
            .HasColumnType("money");

        builder.Property(e => e.CardPaymentDollar)
            .HasColumnName("CardPaymentDollar")
            .HasColumnType("money");

        builder.Property(e => e.CardPaymentKs)
            .HasColumnName("CardPaymentKS")
            .HasColumnType("money");

        builder.Property(e => e.RemainDollar)
            .HasColumnName("RemainDollar")
            .HasColumnType("money");

        builder.Property(e => e.RemainKs)
            .HasColumnName("RemainKS")
            .HasColumnType("money");

        builder.Property(e => e.RefundDollar)
            .HasColumnName("RefundDollar")
            .HasColumnType("money");

        builder.Property(e => e.RefundKs)
            .HasColumnName("RefundKS")
            .HasColumnType("money");

        builder.Property(e => e.CardNo)
            .HasColumnName("CardNo")
            .HasColumnType("nvarchar(500)")
            .HasMaxLength(500);

        builder.Property(e => e.CardType)
            .HasColumnName("CardType")
            .HasColumnType("nvarchar(500)")
            .HasMaxLength(500);

        builder.Property(e => e.BankChargesDollar)
            .HasColumnName("BankChargesDollar")
            .HasColumnType("money");

        builder.Property(e => e.BankChargesKs)
            .HasColumnName("BankChargesKS")
            .HasColumnType("money");

        builder.Property(e => e.BottleCharges)
            .HasColumnName("BottleCharges")
            .HasColumnType("money");

    }
}
