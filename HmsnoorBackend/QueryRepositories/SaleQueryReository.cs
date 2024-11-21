using System;
using HmsnoorBackend.Data;
using HmsnoorBackend.Dtos;
using HmsnoorBackend.QueryRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HmsnoorBackend.QueryRepositories;

public class SaleQueryReository : ISaleQueryRepository
{
    private readonly HmsnoorDbContext _context;

    public SaleQueryReository(HmsnoorDbContext context)
    {
        _context = context;
    }


    public IQueryable<InvoiceWithItemsGetDto> FindAllWithdetails()
    {
        var query = _context.TransactionSales
            .OrderBy(i => i.InvoiceNo)
            .ThenBy(i => i.InvoiceDate)
            .ThenBy(i => i.SalesType)
            .Join(_context.TransactionSalesItems,
                i => i.InvoiceNo, iD => iD.InvoiceNo,
                (i, iD) => new InvoiceWithItemsGetDto
                {
                    SalesType = i.SalesType,
                    InvoiceNo = i.InvoiceNo,
                    InvoiceDate = i.InvoiceDate,
                    VoucherNo = i.VoucherNo,
                    Currency = i.Currency,
                    ReceivableType = i.ReceivableType,
                    RegistrationNo = i.RegistrationNo,
                    Remark = i.Remark,
                    Total = i.Total,
                    DiscountPers = i.DiscountPers,
                    DiscountAmt = i.DiscountAmt,
                    TaxPers = i.TaxPers,
                    TaxAmount = i.TaxAmount,
                    ServicePers = i.ServicePers,
                    ServiceAmount = i.ServiceAmount,
                    NetAmount = i.NetAmount,
                    CashierId = i.CashierId,
                    CreateUserId = i.CreateUserId,
                    CreateDate = i.CreateDate,
                    ModifyUserId = i.ModifyUserId,
                    ModifyDate = i.ModifyDate,
                    PaidDate = i.PaidDate,
                    ServiceTaxPers = i.ServiceTaxPers,
                    ServiceTaxAmount = i.ServiceTaxAmount,
                    IsPaidBill = i.IsPaidBill,
                    MemberCardNo = i.MemberCardNo,
                    StaffName = i.StaffName,
                    CashPaymentDollar = i.CashPaymentDollar,
                    CashPaymentKs = i.CashPaymentKs,
                    CardPaymentDollar = i.CardPaymentDollar,
                    CardPaymentKs = i.CardPaymentKs,
                    RemainDollar = i.RemainDollar,
                    RemainKs = i.RemainKs,
                    RefundDollar = i.RefundDollar,
                    RefundKs = i.RefundKs,
                    CardNo = i.CardNo,
                    CardType = i.CardType,
                    BankChargesDollar = i.BankChargesDollar,
                    BankChargesKs = i.BankChargesKs,
                    BottleCharges = i.BottleCharges,
                    SaleItems = new List<InvoiceItemGetDto>
                    {
                        new()
                        {
                            InvoiceNo = iD.InvoiceNo,
                            ItemNo = iD.ItemNo,
                            ItemName = iD.ItemName!,
                            Price = iD.Price,
                            Quantity = iD.Quantity,
                            Amount = iD.Amount
                        }
                    }
                }
            );

        return query;
    }
}
