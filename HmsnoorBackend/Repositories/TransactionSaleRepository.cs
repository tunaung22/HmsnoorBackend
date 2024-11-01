using System;
using HmsnoorBackend.Data;
using HmsnoorBackend.Dtos;
using HmsnoorBackend.Dtos.DtoMappers;
using HmsnoorBackend.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace HmsnoorBackend.Repositories;

public class TransactionSaleRepository : ITransactionSaleRepository
{

    private readonly HmsnoorDbContext _context;
    private readonly ITransactionSalesItemRepository _saleItemsRepo;

    public TransactionSaleRepository(HmsnoorDbContext ctx, ITransactionSalesItemRepository saleItemsRepo)
    {
        _context = ctx;
        _saleItemsRepo = saleItemsRepo;
    }

    public async Task<TransactionSalesMasterGetDto> CreateTransactionSaleMasterAsync(TransactionSalesMasterCreateDto dtoParam)
    {
        // TransactionSalesMasterGetDto result = new TransactionSalesMasterGetDto();
        TransactionSalesMasterGetDto master;

        var transaction = _context.Database.BeginTransaction();
        try
        {
            // ========== save to database ========================================

            // SaleMasterCreate Dto -> Sale Entity
            TransactionSale sale = TransactionSalesMasterMapper.ToEntity(dtoParam);
            await _context.TransactionSales.AddAsync(sale);

            if (dtoParam.SaleItems.Count > 0)
            {
                foreach (TransactionSalesItemCreateDto saleItem in dtoParam.SaleItems)
                {
                    // SaleMasterCreate Dto -> SaleItem Entity
                    var saleItemEntity = TransactionSalesItemMapper.ToEntity(saleItem);
                    await _context.TransactionSalesItems.AddAsync(saleItemEntity);
                }
            }
            var savedQuery = await _context.SaveChangesAsync();


            // ========== if saved succeed, fetch from database ====================
            if (savedQuery > 0)
            {
                var saleInvoice = await GetTransactionSaleByInvoiceNo(dtoParam.InvoiceNo);
                if (saleInvoice != null)
                {
                    // get: invoice dto
                    // get: item dto
                    // merge: invoice dto + item dto
                    TransactionSalesGetDto invoiceDto = TransactionSalesMapper.ToGetDto(saleInvoice);

                    List<TransactionSalesItem> saleItems = await _saleItemsRepo.GetAllSalesItemByInvoiceNoAsync(dtoParam.InvoiceNo);

                    if (saleItems.Count > 0)
                    {
                        List<TransactionSalesItemGetDto> itemsDtoList = TransactionSalesItemMapper.ToGetDto(saleItems);
                        master = TransactionSalesMasterMapper.MergeTransactionSaleAndTransactionSaleItemsDto(invoiceDto, itemsDtoList);
                    }
                    else
                    {
                        master = TransactionSalesMasterMapper.MergeTransactionSaleAndTransactionSaleItemsDto(invoiceDto, null);
                    }

                    return master;
                }
                // else: fetch invoice failed!!!!
                // throw: exception
                throw new Exception("etch invoice failed!");
            }
            throw new Exception("Save failed???");
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<TransactionSale> CreateTransactionSale(TransactionSale data)
    {
        // var invoiceEntity = TransactionSalesMapper.ToEntity(data);
        await _context.TransactionSales
                .AddAsync(data);
        var invoice = await _context.SaveChangesAsync();

        if (invoice > 0)
        {
            var createdInvoice = await _context.TransactionSales
                .Where(i => i.InvoiceNo == data.InvoiceNo)
                .Select(i => new TransactionSale
                {
                    InvoiceNo = i.InvoiceNo,

                })
                .SingleAsync();
            if (createdInvoice != null)
            {
                return createdInvoice;
            }
            throw new Exception("Unable to fetch created Transaction Sale");
        }
        throw new Exception("Save Transaction Sale failed.");
    }

    public async Task<TransactionSale> GetTransactionSaleByInvoiceNo(string invoiceNo)
    {
        try
        {
            var saleInvoice = await _context.TransactionSales
                .Where(i => i.InvoiceNo == invoiceNo)
                .FirstOrDefaultAsync();
            // TransactionSalesGetDto result = TransactionSalesMapper.ToGetDto(saleInvoice!);
            if (saleInvoice != null)
            {
                return saleInvoice;
            }
            throw new Exception("Unable to find Transaction Sale by invoice number");

        }
        catch (System.Exception)
        {
            throw;
        }

    }

    public async Task<List<TransactionSale>> GetAllTransactionSalesAsync(string salesType)
    {
        Log.Information("TransactionSaleRepository, salesType param: {type}", salesType);
        try
        {
            var q = _context.TransactionSales
                .Where(i => i.SalesType == salesType)
                .Select(i => new TransactionSale
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
                });
            var invoiceList = await q.ToListAsync();

            // var result = TransactionSalesMapper.ToGetDto(invoiceList);
            return invoiceList;
        }
        catch (System.Exception e)
        {
            Log.Error("TransactionSaleRepository exception: {0}", e);
            throw;
        }
    }


}
