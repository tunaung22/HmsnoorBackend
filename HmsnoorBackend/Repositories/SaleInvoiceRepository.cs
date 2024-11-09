using HmsnoorBackend.Data;
using HmsnoorBackend.Dtos;
using HmsnoorBackend.Dtos.DtoMappers;
using HmsnoorBackend.Middlewares.Exceptions;
using HmsnoorBackend.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace HmsnoorBackend.Repositories;

public class SaleInvoiceRepository : ISaleInvoiceRepository
{

    private readonly HmsnoorDbContext _context;
    private readonly ISaleItemRepository _saleItemsRepo;

    public SaleInvoiceRepository(HmsnoorDbContext context, ISaleItemRepository saleItemsRepo)
    {
        _context = context;
        _saleItemsRepo = saleItemsRepo;
    }

    public IQueryable<TransactionSale> FindAll()
    {
        var query = _context.TransactionSales
            .OrderBy(e => e.InvoiceNo)
            .Select(e => new TransactionSale
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
            });

        return query;
    }

    // public async Task<TransactionSale?> FindByIdAsync(string invoiceNo)
    // {
    //     var query = await _context.TransactionSales
    //         .Where(e => e.InvoiceNo == invoiceNo)
    //         .FirstOrDefaultAsync();

    //     return query;
    // }

    public IQueryable<TransactionSale?> FindById(string invoiceNo)
    {
        var query = _context.TransactionSales
            .Where(e => e.InvoiceNo == invoiceNo);

        return query;
    }

    public async Task<int> SaveAsync(TransactionSale entity)
    {
        _context.TransactionSales.Add(entity);

        return await _context.SaveChangesAsync();
    }

    /*
     * Update Sale Invoice by Id
     * - invoice number will not be updated, use [update invoice] method instead
     */
    public async Task<bool> UpdateByIdAsync(string invoiceNo, TransactionSale entity)
    {
        // var query = await FindByIdAsync(invoiceNo);
        var query = await FindById(invoiceNo).FirstOrDefaultAsync();
        if (query != null)
        {
            _context.Entry(query).State = EntityState.Modified;

            // query.InvoiceNo = entity.InvoiceNo;
            query.SalesType = entity.SalesType;
            query.InvoiceDate = entity.InvoiceDate;
            query.VoucherNo = entity.VoucherNo;
            query.Currency = entity.Currency;
            query.ReceivableType = entity.ReceivableType;
            query.RegistrationNo = entity.RegistrationNo;
            query.Remark = entity.Remark;
            query.Total = entity.Total;
            query.DiscountPers = entity.DiscountPers;
            query.DiscountAmt = entity.DiscountAmt;
            query.TaxPers = entity.TaxPers;
            query.TaxAmount = entity.TaxAmount;
            query.ServicePers = entity.ServicePers;
            query.ServiceAmount = entity.ServiceAmount;
            query.NetAmount = entity.NetAmount;
            query.CashierId = entity.CashierId;
            query.CreateUserId = entity.CreateUserId;
            query.CreateDate = entity.CreateDate;
            query.ModifyUserId = entity.ModifyUserId;
            query.ModifyDate = entity.ModifyDate;
            query.PaidDate = entity.PaidDate;
            query.ServiceTaxPers = entity.ServiceTaxPers;
            query.ServiceTaxAmount = entity.ServiceTaxAmount;
            query.IsPaidBill = entity.IsPaidBill;
            query.MemberCardNo = entity.MemberCardNo;
            query.StaffName = entity.StaffName;
            query.CashPaymentDollar = entity.CashPaymentDollar;
            query.CashPaymentKs = entity.CashPaymentKs;
            query.CardPaymentDollar = entity.CardPaymentDollar;
            query.CardPaymentKs = entity.CardPaymentKs;
            query.RemainDollar = entity.RemainDollar;
            query.RemainKs = entity.RemainKs;
            query.RefundDollar = entity.RefundDollar;
            query.RefundKs = entity.RefundKs;
            query.CardNo = entity.CardNo;
            query.CardType = entity.CardType;
            query.BankChargesDollar = entity.BankChargesDollar;
            query.BankChargesKs = entity.BankChargesKs;
            query.BottleCharges = entity.BottleCharges;

            var row = await _context.SaveChangesAsync();
            if (row > 0)
            {
                return true;
            }

            throw new DbUpdateException();
        }
        throw new HmsSaleInvoiceNotFoundException(invoiceNo);
    }

    public async Task<bool> UpdateInvoiceNoAsync(string invoiceNo, string newInvoiceNo)
    {
        var query = await FindById(invoiceNo).FirstOrDefaultAsync();
        if (query != null)
        {
            _context.Entry(query).State = EntityState.Modified;

            query.InvoiceNo = newInvoiceNo;
            var row = await _context.SaveChangesAsync();
            if (row > 0)
            {
                return true;
            }

            throw new DbUpdateException();
        }

        throw new HmsSaleInvoiceNotFoundException(invoiceNo);
    }

    public async Task<bool> DeleteByIdAsync(string invoiceNo)
    {
        var query = await FindById(invoiceNo).FirstOrDefaultAsync();
        if (query != null)
        {
            _context.TransactionSales.Remove(query);
            await _context.SaveChangesAsync();

            return true;
        }

        throw new HmsSaleInvoiceNotFoundException(invoiceNo);
    }





    // =============== OBSOLETED =============================================
    /*
     * Create Transaction Sale with Transaction Sale Items
     * Execute inside a Transaction
     * Rollback if one transaction failed.
     */
    [Obsolete("This method is deprecated. Use service method instead.", false)]
    public async Task<InvoiceWithItemsGetDto> CreateTransactionSaleMasterAsync(InvoiceWithItemsCreateDto dtoParam)
    {
        // TransactionSalesMasterGetDto result = new TransactionSalesMasterGetDto();
        InvoiceWithItemsGetDto master;

        var transaction = _context.Database.BeginTransaction();
        try
        {
            // ========== save to database ========================================

            // SaleMasterCreate Dto -> Sale Entity
            TransactionSale sale = TransactionSalesMasterMapper.ToEntity(dtoParam);
            await _context.TransactionSales.AddAsync(sale);

            if (dtoParam.SaleItems.Count > 0)
            {
                foreach (InvoiceItemCreateDto saleItem in dtoParam.SaleItems)
                {
                    // SaleMasterCreate Dto -> SaleItem Entity
                    var saleItemEntity = SaleInvoiceItemMapper.ToEntity(saleItem);
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
                    InvoiceGetDto invoiceDto = SaleInvoiceMapper.ToGetDto(saleInvoice);

                    List<TransactionSalesItem> saleItems = await _saleItemsRepo.GetAllSalesItemByInvoiceNoAsync(dtoParam.InvoiceNo);

                    if (saleItems.Count > 0)
                    {
                        List<InvoiceItemGetDto> itemsDtoList = SaleInvoiceItemMapper.ToGetDto(saleItems);
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
    [Obsolete("This method is deprecated. Use service method instead.", false)]
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
    [Obsolete("This method is deprecated. Use service method instead.", false)]
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
    [Obsolete("This method is deprecated. Use service method instead.", false)]
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
