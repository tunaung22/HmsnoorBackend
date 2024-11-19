using HmsnoorBackend.Data.Models;

namespace HmsnoorBackend.Dtos.DtoMappers;

public class TransactionSalesMasterMapper
{

    // public static TransactionSalesMasterGetDto ToGetDto(TransactionSalesGetDto dto)
    // {
    //     return new TransactionSalesMasterGetDto
    //     {
    //         SalesType = dto.SalesType,
    //         InvoiceNo = dto.InvoiceNo,
    //         InvoiceDate = dto.InvoiceDate,
    //         VoucherNo = dto.VoucherNo,
    //         Currency = dto.Currency,
    //         ReceivableType = dto.ReceivableType,
    //         RegistrationNo = dto.RegistrationNo,
    //         Remark = dto.Remark,
    //         Total = dto.Total,
    //         DiscountPers = dto.DiscountPers,
    //         DiscountAmt = dto.DiscountAmt,
    //         TaxPers = dto.TaxPers,
    //         TaxAmount = dto.TaxAmount,
    //         ServicePers = dto.ServicePers,
    //         ServiceAmount = dto.ServiceAmount,
    //         NetAmount = dto.NetAmount,
    //         CashierId = dto.CashierId,
    //         CreateUserId = dto.CreateUserId,
    //         CreateDate = dto.CreateDate,
    //         ModifyUserId = dto.ModifyUserId,
    //         ModifyDate = dto.ModifyDate,
    //         PaidDate = dto.PaidDate,
    //         ServiceTaxPers = dto.ServiceTaxPers,
    //         ServiceTaxAmount = dto.ServiceTaxAmount,
    //         IsPaidBill = dto.IsPaidBill,
    //         MemberCardNo = dto.MemberCardNo,
    //         StaffName = dto.StaffName,
    //         CashPaymentDollar = dto.CashPaymentDollar,
    //         CashPaymentKs = dto.CashPaymentKs,
    //         CardPaymentDollar = dto.CardPaymentDollar,
    //         CardPaymentKs = dto.CardPaymentKs,
    //         RemainDollar = dto.RemainDollar,
    //         RemainKs = dto.RemainKs,
    //         RefundDollar = dto.RefundDollar,
    //         RefundKs = dto.RefundKs,
    //         CardNo = dto.CardNo,
    //         CardType = dto.CardType,
    //         BankChargesDollar = dto.BankChargesDollar,
    //         BankChargesKs = dto.BankChargesKs,
    //         BottleCharges = dto.BottleCharges
    //     };
    // }




    // public static TransactionSalesMasterGetDto ToMasterGetDto(TransactionSale entity)
    // {
    //     var result = new TransactionSalesMasterGetDto
    //     {
    //         SalesType = inv.SalesType,
    //         InvoiceNo = inv.InvoiceNo,
    //         InvoiceDate = inv.InvoiceDate,
    //         VoucherNo = inv.VoucherNo,
    //         Currency = inv.Currency,
    //         ReceivableType = inv.ReceivableType,
    //         RegistrationNo = inv.RegistrationNo,
    //         Remark = inv.Remark,
    //         Total = inv.Total,
    //         DiscountPers = inv.DiscountPers,
    //         DiscountAmt = inv.DiscountAmt,
    //         TaxPers = inv.TaxPers,
    //         TaxAmount = inv.TaxAmount,
    //         ServicePers = inv.ServicePers,
    //         ServiceAmount = inv.ServiceAmount,
    //         NetAmount = inv.NetAmount,
    //         CashierId = inv.CashierId,
    //         CreateUserId = inv.CreateUserId,
    //         CreateDate = inv.CreateDate,
    //         ModifyUserId = inv.ModifyUserId,
    //         ModifyDate = inv.ModifyDate,
    //         PaidDate = inv.PaidDate,
    //         ServiceTaxPers = inv.ServiceTaxPers,
    //         ServiceTaxAmount = inv.ServiceTaxAmount,
    //         IsPaidBill = inv.IsPaidBill,
    //         MemberCardNo = inv.MemberCardNo,
    //         StaffName = inv.StaffName,
    //         CashPaymentDollar = inv.CashPaymentDollar,
    //         CashPaymentKs = inv.CashPaymentKs,
    //         CardPaymentDollar = inv.CardPaymentDollar,
    //         CardPaymentKs = inv.CardPaymentKs,
    //         RemainDollar = inv.RemainDollar,
    //         RemainKs = inv.RemainKs,
    //         RefundDollar = inv.RefundDollar,
    //         RefundKs = inv.RefundKs,
    //         CardNo = inv.CardNo,
    //         CardType = inv.CardType,
    //         BankChargesDollar = inv.BankChargesDollar,
    //         BankChargesKs = inv.BankChargesKs,
    //         BottleCharges = inv.BottleCharges,
    //         SaleItems = [],
    //     };
    // }


    // Master DTO -> Sale Invoice Entity (**wihtout SaleItems)
    public static TransactionSale ToEntity(InvoiceWithItemsCreateDto dto)
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

    public static InvoiceWithItemsGetDto MergeTransactionSaleAndTransactionSaleItemsDto(
                                InvoiceGetDto invoiceDto,
                                List<InvoiceItemGetDto>? itemDtoList)
    {
        if (itemDtoList == null || itemDtoList.Count == 0)
        {
            return new InvoiceWithItemsGetDto
            {
                SalesType = invoiceDto.SalesType,
                InvoiceNo = invoiceDto.InvoiceNo,
                InvoiceDate = invoiceDto.InvoiceDate,
                VoucherNo = invoiceDto.VoucherNo,
                Currency = invoiceDto.Currency,
                ReceivableType = invoiceDto.ReceivableType,
                RegistrationNo = invoiceDto.RegistrationNo,
                Remark = invoiceDto.Remark,
                Total = invoiceDto.Total,
                DiscountPers = invoiceDto.DiscountPers,
                DiscountAmt = invoiceDto.DiscountAmt,
                TaxPers = invoiceDto.TaxPers,
                TaxAmount = invoiceDto.TaxAmount,
                ServicePers = invoiceDto.ServicePers,
                ServiceAmount = invoiceDto.ServiceAmount,
                NetAmount = invoiceDto.NetAmount,
                CashierId = invoiceDto.CashierId,
                CreateUserId = invoiceDto.CreateUserId,
                CreateDate = invoiceDto.CreateDate,
                ModifyUserId = invoiceDto.ModifyUserId,
                ModifyDate = invoiceDto.ModifyDate,
                PaidDate = invoiceDto.PaidDate,
                ServiceTaxPers = invoiceDto.ServiceTaxPers,
                ServiceTaxAmount = invoiceDto.ServiceTaxAmount,
                IsPaidBill = invoiceDto.IsPaidBill,
                MemberCardNo = invoiceDto.MemberCardNo,
                StaffName = invoiceDto.StaffName,
                CashPaymentDollar = invoiceDto.CashPaymentDollar,
                CashPaymentKs = invoiceDto.CashPaymentKs,
                CardPaymentDollar = invoiceDto.CardPaymentDollar,
                CardPaymentKs = invoiceDto.CardPaymentKs,
                RemainDollar = invoiceDto.RemainDollar,
                RemainKs = invoiceDto.RemainKs,
                RefundDollar = invoiceDto.RefundDollar,
                RefundKs = invoiceDto.RefundKs,
                CardNo = invoiceDto.CardNo,
                CardType = invoiceDto.CardType,
                BankChargesDollar = invoiceDto.BankChargesDollar,
                BankChargesKs = invoiceDto.BankChargesKs,
                BottleCharges = invoiceDto.BottleCharges,
            };

        }

        return new InvoiceWithItemsGetDto
        {
            SalesType = invoiceDto.SalesType,
            InvoiceNo = invoiceDto.InvoiceNo,
            InvoiceDate = invoiceDto.InvoiceDate,
            VoucherNo = invoiceDto.VoucherNo,
            Currency = invoiceDto.Currency,
            ReceivableType = invoiceDto.ReceivableType,
            RegistrationNo = invoiceDto.RegistrationNo,
            Remark = invoiceDto.Remark,
            Total = invoiceDto.Total,
            DiscountPers = invoiceDto.DiscountPers,
            DiscountAmt = invoiceDto.DiscountAmt,
            TaxPers = invoiceDto.TaxPers,
            TaxAmount = invoiceDto.TaxAmount,
            ServicePers = invoiceDto.ServicePers,
            ServiceAmount = invoiceDto.ServiceAmount,
            NetAmount = invoiceDto.NetAmount,
            CashierId = invoiceDto.CashierId,
            CreateUserId = invoiceDto.CreateUserId,
            CreateDate = invoiceDto.CreateDate,
            ModifyUserId = invoiceDto.ModifyUserId,
            ModifyDate = invoiceDto.ModifyDate,
            PaidDate = invoiceDto.PaidDate,
            ServiceTaxPers = invoiceDto.ServiceTaxPers,
            ServiceTaxAmount = invoiceDto.ServiceTaxAmount,
            IsPaidBill = invoiceDto.IsPaidBill,
            MemberCardNo = invoiceDto.MemberCardNo,
            StaffName = invoiceDto.StaffName,
            CashPaymentDollar = invoiceDto.CashPaymentDollar,
            CashPaymentKs = invoiceDto.CashPaymentKs,
            CardPaymentDollar = invoiceDto.CardPaymentDollar,
            CardPaymentKs = invoiceDto.CardPaymentKs,
            RemainDollar = invoiceDto.RemainDollar,
            RemainKs = invoiceDto.RemainKs,
            RefundDollar = invoiceDto.RefundDollar,
            RefundKs = invoiceDto.RefundKs,
            CardNo = invoiceDto.CardNo,
            CardType = invoiceDto.CardType,
            BankChargesDollar = invoiceDto.BankChargesDollar,
            BankChargesKs = invoiceDto.BankChargesKs,
            BottleCharges = invoiceDto.BottleCharges,
            SaleItems = itemDtoList
        };

    }
}

