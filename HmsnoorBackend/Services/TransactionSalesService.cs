using System;
using System.Collections;
using System.Transactions;
using HmsnoorBackend.Dtos;
using HmsnoorBackend.Dtos.DtoMappers;
using HmsnoorBackend.Models;
using HmsnoorBackend.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace HmsnoorBackend.Services;

public class TransactionSalesService : ITransactionSalesService
{

    private readonly ITransactionSaleRepository _salesRepo;
    private readonly ITransactionSalesItemRepository _itemsRepo;

    public TransactionSalesService(ITransactionSaleRepository saleRepository, ITransactionSalesItemRepository itemsRepo)
    {
        _salesRepo = saleRepository;
        _itemsRepo = itemsRepo;
    }

    public async Task<TransactionSalesMasterGetDto> CreateTransactionSaleMasterAsync(TransactionSalesMasterCreateDto dto)
    {
        var result = await _salesRepo.CreateTransactionSaleMasterAsync(dto);
        return result;
    }

    public async Task<TransactionSalesMasterGetDto> CreateSaleInvoiceWithItemsAsync(TransactionSalesMasterCreateDto dto)
    {
         var result = await _salesRepo.CreateTransactionSaleMasterAsync(dto);
        return result;
    }


    public async Task<List<TransactionSalesMasterGetDto>> GetSaleInvoiceWithItemsBySalesTypeAsync(string salesType)
    {
        List<TransactionSalesMasterGetDto> result = [];

        List<TransactionSale> saleInvoicesList = await _salesRepo.GetAllTransactionSalesAsync(salesType);

        if (saleInvoicesList != null)
        {
            foreach (var invoice in saleInvoicesList)
            {
                var invoiceDto = TransactionSalesMapper.ToGetDto(invoice);

                var saleItemsList = await _itemsRepo.GetAllSalesItemByInvoiceNoAsync(invoice.InvoiceNo);
                if (saleItemsList != null)
                {
                    var salesItemDtoList = TransactionSalesItemMapper.ToGetDto(saleItemsList);

                    result.Add(TransactionSalesMasterMapper.MergeTransactionSaleAndTransactionSaleItemsDto(invoiceDto, salesItemDtoList));
                }
                else
                {
                    result.Add(TransactionSalesMasterMapper.MergeTransactionSaleAndTransactionSaleItemsDto(invoiceDto, null));
                }
            }
        }
        return result;
    }

    public async Task<List<TransactionSalesMasterGetDto>> GetTransactionSalesMasterBySalesTypeAsync(string salesType)
    {
        var saleInvoicesList = await _salesRepo.GetAllTransactionSalesAsync(salesType);
        // Manual mapping
        List<TransactionSalesMasterGetDto> resultList = [];

        foreach (var i in saleInvoicesList)
        {
            var itemsForCurrentInvoiceNo = await _itemsRepo.GetAllSalesItemByInvoiceNoAsync(i.InvoiceNo);
            TransactionSalesMasterGetDto invoiceMaster = new()
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
                SaleItems = TransactionSalesItemMapper.ToGetDto(itemsForCurrentInvoiceNo),
            };
            resultList.Add(invoiceMaster);
        }

        return resultList;
    }

    public async Task<List<TransactionSalesGetDto>> GetTransactionSalesBySalesTypeAsync(string salesType)
    {
        try
        {
            var saleInvoices = await _salesRepo.GetAllTransactionSalesAsync(salesType);
            var result = TransactionSalesMapper.ToGetDto(saleInvoices);
            return result;
        }
        catch (System.Exception)
        {
            throw new Exception("Unable to fetch Transaction Sales.");
        }
    }







    // public TransactionSalesGetDto SaveTransactionSale(TransactionSalesMasterCreateDto dto)
    // {
    //     throw new NotImplementedException();
    // }
}
