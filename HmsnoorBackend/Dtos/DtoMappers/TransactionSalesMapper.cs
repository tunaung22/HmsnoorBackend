using System;
using HmsnoorBackend.Models;

namespace HmsnoorBackend.Dtos.DtoMappers;

public class TransactionSalesMapper
{
    public static List<TransactionSalesGetDto> ToGetDto(List<TransactionSale> invoiceList)
    {
        return invoiceList.Select(ToGetDto).ToList(); 
    }

    public static TransactionSale ToEntity(TransactionSalesGetDto dto)
    {
        return new TransactionSale
        {
            SalesType = dto.SalesType,
            InvoiceNo = dto.InvoiceNo,
            InvoiceDate = dto.InvoiceDate,
            VoucherNo = dto.VoucherNo,
            Currency = dto.Currency,
            ReceivableType = dto.ReceivableType,
            RegistrationNo = dto.RegistrationNo,
            Remark = dto.Remark,
            Total = dto.Total,
            DiscountPers = dto.DiscountPers,
            DiscountAmt = dto.DiscountAmt,
            TaxPers = dto.TaxPers,
            TaxAmount = dto.TaxAmount,
            ServicePers = dto.ServicePers,
            ServiceAmount = dto.ServiceAmount,
            NetAmount = dto.NetAmount,
            CashierId = dto.CashierId,
            CreateUserId = dto.CreateUserId,
            CreateDate = dto.CreateDate,
            ModifyUserId = dto.ModifyUserId,
            ModifyDate = dto.ModifyDate,
            PaidDate = dto.PaidDate,
            ServiceTaxPers = dto.ServiceTaxPers,
            ServiceTaxAmount = dto.ServiceTaxAmount,
            IsPaidBill = dto.IsPaidBill,
            MemberCardNo = dto.MemberCardNo,
            StaffName = dto.StaffName,
            CashPaymentDollar = dto.CashPaymentDollar,
            CashPaymentKs = dto.CashPaymentKs,
            CardPaymentDollar = dto.CardPaymentDollar,
            CardPaymentKs = dto.CardPaymentKs,
            RemainDollar = dto.RemainDollar,
            RemainKs = dto.RemainKs,
            RefundDollar = dto.RefundDollar,
            RefundKs = dto.RefundKs,
            CardNo = dto.CardNo,
            CardType = dto.CardType,
            BankChargesDollar = dto.BankChargesDollar,
            BankChargesKs = dto.BankChargesKs,
            BottleCharges = dto.BottleCharges,
        };
    }

    public static TransactionSale ToEntity(TransactionSalesCreateDto dto)
    {
        return new TransactionSale
        {
            SalesType = dto.SalesType,
            InvoiceNo = dto.InvoiceNo,
            InvoiceDate = dto.InvoiceDate,
            VoucherNo = dto.VoucherNo,
            Currency = dto.Currency,
            ReceivableType = dto.ReceivableType,
            RegistrationNo = dto.RegistrationNo,
            Remark = dto.Remark,
            Total = dto.Total,
            DiscountPers = dto.DiscountPers,
            DiscountAmt = dto.DiscountAmt,
            TaxPers = dto.TaxPers,
            TaxAmount = dto.TaxAmount,
            ServicePers = dto.ServicePers,
            ServiceAmount = dto.ServiceAmount,
            NetAmount = dto.NetAmount,
            CashierId = dto.CashierId,
            CreateUserId = dto.CreateUserId,
            CreateDate = dto.CreateDate,
            ModifyUserId = dto.ModifyUserId,
            ModifyDate = dto.ModifyDate,
            PaidDate = dto.PaidDate,
            ServiceTaxPers = dto.ServiceTaxPers,
            ServiceTaxAmount = dto.ServiceTaxAmount,
            IsPaidBill = dto.IsPaidBill,
            MemberCardNo = dto.MemberCardNo,
            StaffName = dto.StaffName,
            CashPaymentDollar = dto.CashPaymentDollar,
            CashPaymentKs = dto.CashPaymentKs,
            CardPaymentDollar = dto.CardPaymentDollar,
            CardPaymentKs = dto.CardPaymentKs,
            RemainDollar = dto.RemainDollar,
            RemainKs = dto.RemainKs,
            RefundDollar = dto.RefundDollar,
            RefundKs = dto.RefundKs,
            CardNo = dto.CardNo,
            CardType = dto.CardType,
            BankChargesDollar = dto.BankChargesDollar,
            BankChargesKs = dto.BankChargesKs,
            BottleCharges = dto.BottleCharges,
        };
    }
    public static TransactionSalesGetDto ToGetDto(TransactionSale e)
    {
        return new TransactionSalesGetDto
        {
            SalesType = e.SalesType,
            InvoiceNo = e.InvoiceNo,
            InvoiceDate = e.InvoiceDate,
            VoucherNo = e.VoucherNo,
            Currency = e.Currency,
            ReceivableType = e.ReceivableType,
            RegistrationNo = e.RegistrationNo,
            Remark = e.Remark,
            Total = e.Total,
            DiscountPers = e.DiscountPers,
            DiscountAmt = e.DiscountAmt,
            TaxPers = e.TaxPers,
            TaxAmount = e.TaxAmount,
            ServicePers = e.ServicePers,
            ServiceAmount = e.ServiceAmount,
            NetAmount = e.NetAmount,
            CashierId = e.CashierId,
            CreateUserId = e.CreateUserId,
            CreateDate = e.CreateDate,
            ModifyUserId = e.ModifyUserId,
            ModifyDate = e.ModifyDate,
            PaidDate = e.PaidDate,
            ServiceTaxPers = e.ServiceTaxPers,
            ServiceTaxAmount = e.ServiceTaxAmount,
            IsPaidBill = e.IsPaidBill,
            MemberCardNo = e.MemberCardNo,
            StaffName = e.StaffName,
            CashPaymentDollar = e.CashPaymentDollar,
            CashPaymentKs = e.CashPaymentKs,
            CardPaymentDollar = e.CardPaymentDollar,
            CardPaymentKs = e.CardPaymentKs,
            RemainDollar = e.RemainDollar,
            RemainKs = e.RemainKs,
            RefundDollar = e.RefundDollar,
            RefundKs = e.RefundKs,
            CardNo = e.CardNo,
            CardType = e.CardType,
            BankChargesDollar = e.BankChargesDollar,
            BankChargesKs = e.BankChargesKs,
            BottleCharges = e.BottleCharges,
        };

    }
}
