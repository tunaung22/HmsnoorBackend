using System;
using System.Collections.Generic;

namespace HmsnoorBackend.Models;

public partial class TransactionSale
{
    public string SalesType { get; set; } = null!;

    public string InvoiceNo { get; set; } = null!;

    public DateOnly InvoiceDate { get; set; }

    public string VoucherNo { get; set; } = string.Empty;

    public int Currency { get; set; } = 1;

    public string ReceivableType { get; set; } = string.Empty;

    public string RegistrationNo { get; set; } = string.Empty;

    public string Remark { get; set; } = string.Empty;

    public decimal Total { get; set; } = decimal.Zero;

    public decimal DiscountPers { get; set; } = decimal.Zero;

    public decimal DiscountAmt { get; set; } = decimal.Zero;

    public decimal TaxPers { get; set; } = decimal.Zero;

    public decimal TaxAmount { get; set; } = decimal.Zero;

    public decimal ServicePers { get; set; } = decimal.Zero;

    public decimal ServiceAmount { get; set; } = decimal.Zero;

    public decimal NetAmount { get; set; } = decimal.Zero;

    public string CashierId { get; set; } = string.Empty;

    public int CreateUserId { get; set; }

    public DateTime CreateDate { get; set; }

    public int? ModifyUserId { get; set; }

    public DateTime? ModifyDate { get; set; }

    public DateOnly? PaidDate { get; set; }

    public decimal ServiceTaxPers { get; set; } = decimal.Zero;

    public decimal ServiceTaxAmount { get; set; } = decimal.Zero;

    public bool? IsPaidBill { get; set; }

    public string MemberCardNo { get; set; } = string.Empty;

    public string StaffName { get; set; } = string.Empty;

    public decimal CashPaymentDollar { get; set; } = decimal.Zero;

    public decimal CashPaymentKs { get; set; } = decimal.Zero;

    public decimal CardPaymentDollar { get; set; } = decimal.Zero;

    public decimal CardPaymentKs { get; set; } = decimal.Zero;

    public decimal RemainDollar { get; set; } = decimal.Zero;

    public decimal RemainKs { get; set; } = decimal.Zero;

    public decimal RefundDollar { get; set; } = decimal.Zero;

    public decimal RefundKs { get; set; } = decimal.Zero;

    public string CardNo { get; set; } = string.Empty;

    public string CardType { get; set; } = string.Empty;

    public decimal BankChargesDollar { get; set; } = decimal.Zero;

    public decimal BankChargesKs { get; set; } = decimal.Zero;

    public decimal BottleCharges { get; set; } = decimal.Zero;
}
