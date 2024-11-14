namespace HmsnoorBackend.Dtos;

public class InvoiceGetDto
{

    public string SalesType { get; set; } = null!;
    public string InvoiceNo { get; set; } = null!;
    public DateOnly InvoiceDate { get; set; }
    public string? VoucherNo { get; set; } = null;
    public int Currency { get; set; } = 1;
    public string ReceivableType { get; set; } = null!;
    public string? RegistrationNo { get; set; } = null;
    public string? Remark { get; set; } = null;
    public decimal Total { get; set; }
    public decimal DiscountPers { get; set; }
    public decimal DiscountAmt { get; set; }
    public decimal TaxPers { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal ServicePers { get; set; }
    public decimal ServiceAmount { get; set; }
    public decimal NetAmount { get; set; }
    public string CashierId { get; set; } = null!;
    public int CreateUserId { get; set; }
    public DateTime CreateDate { get; set; }
    public int? ModifyUserId { get; set; } = null;
    public DateTime? ModifyDate { get; set; } = null;
    public DateOnly? PaidDate { get; set; } = null;
    public decimal ServiceTaxPers { get; set; }
    public decimal ServiceTaxAmount { get; set; }
    public bool? IsPaidBill { get; set; }
    public string? MemberCardNo { get; set; }
    public string? StaffName { get; set; }
    public decimal CashPaymentDollar { get; set; }
    public decimal CashPaymentKs { get; set; }
    public decimal CardPaymentDollar { get; set; }
    public decimal CardPaymentKs { get; set; }
    public decimal RemainDollar { get; set; }
    public decimal RemainKs { get; set; }
    public decimal RefundDollar { get; set; }
    public decimal RefundKs { get; set; }
    public string? CardNo { get; set; }
    public string? CardType { get; set; }
    public decimal BankChargesDollar { get; set; }
    public decimal BankChargesKs { get; set; }
    public decimal BottleCharges { get; set; }


}
