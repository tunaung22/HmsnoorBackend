using HmsnoorBackend.Data;
using HmsnoorBackend.Dtos;
using HmsnoorBackend.Dtos.DtoMappers;
using HmsnoorBackend.Middlewares.Exceptions;
using HmsnoorBackend.Data.Models;
using Microsoft.EntityFrameworkCore;
using HmsnoorBackend.Interfaces.Repositories;
using HmsnoorBackend.Interfaces.Services;

namespace HmsnoorBackend.Services;

public class SaleInvoiceService : ISaleInvoiceService
{
    private readonly HmsnoorDbContext _context;
    private readonly ILogger<SaleInvoiceService> _logger;
    private readonly ISaleInvoiceRepository _invoiceRepo;
    private readonly ISaleItemRepository _invoiceItemRepo;

    public SaleInvoiceService(
        HmsnoorDbContext context,
        ILogger<SaleInvoiceService> logger,
        ISaleInvoiceRepository invoiceRepo,
        ISaleItemRepository invoiceItemRepo)
    {
        _context = context;
        _logger = logger;
        _invoiceRepo = invoiceRepo;
        _invoiceItemRepo = invoiceItemRepo;
    }


    // =============== Invoice + Sale Items ==================================================
    /// <summary>
    /// Find All Invoices (Invoice + Invoice Items)
    /// ** can be filter by Sale Type
    /// </summary>
    /// <returns></returns>
    public async Task<List<InvoiceWithItemsGetDto>> FindAll_Invoice_Async(string? saleType)
    {
        List<InvoiceWithItemsGetDto> invoices = [];

        try
        {
            List<TransactionSale> invoiceQuery = saleType
                == null
                ? await _invoiceRepo.FindAll().ToListAsync()
                : await _invoiceRepo.FindAll()
                    .Where(i => i.SalesType == saleType)
                    .ToListAsync();
            // if (saleType == null) { invoiceQuery = await _invoiceRepo.FindAll().ToListAsync(); } else { invoiceQuery = await _invoiceRepo.FindAll().Where(i => i.SalesType == saleType).ToListAsync(); }

            // if no record, RETURN
            if (invoiceQuery.Count == 0)
                return invoices;

            // var invoiceList = TransactionSalesMapper.ToGetDto(query);
            var invoiceList = SaleInvoiceMapper.ToGetDto(invoiceQuery);
            foreach (var invoice in invoiceList)
            {
                // Construct Invoice Items
                List<InvoiceItemGetDto> items = [];
                List<TransactionSalesItem> itemsList = await _invoiceItemRepo
                                        .FindManyByInvoiceNo(invoice.InvoiceNo)
                                        .ToListAsync();

                foreach (TransactionSalesItem item in itemsList)
                {
                    var i = SaleInvoiceItemMapper.ToGetDto(item);
                    items.Add(i);
                }
                // Add to (invoices) List
                // invoices = invoice + invoice items
                // InvoiceWithItemsGetDto MergeToInvoiceWithItemsGetDto(invoice, List<InvoiceItemGetDto>);
                invoices.Add(new InvoiceWithItemsGetDto
                {
                    SalesType = invoice.SalesType,
                    InvoiceNo = invoice.InvoiceNo,
                    InvoiceDate = invoice.InvoiceDate,
                    VoucherNo = invoice.VoucherNo,
                    Currency = invoice.Currency,
                    ReceivableType = invoice.ReceivableType,
                    RegistrationNo = invoice.RegistrationNo,
                    Remark = invoice.Remark,
                    Total = invoice.Total,
                    DiscountPers = invoice.DiscountPers,
                    DiscountAmt = invoice.DiscountAmt,
                    TaxPers = invoice.TaxPers,
                    TaxAmount = invoice.TaxAmount,
                    ServicePers = invoice.ServicePers,
                    ServiceAmount = invoice.ServiceAmount,
                    NetAmount = invoice.NetAmount,
                    CashierId = invoice.CashierId,
                    CreateUserId = invoice.CreateUserId,
                    CreateDate = invoice.CreateDate,
                    ModifyUserId = invoice.ModifyUserId,
                    ModifyDate = invoice.ModifyDate,
                    PaidDate = invoice.PaidDate,
                    ServiceTaxPers = invoice.ServiceTaxPers,
                    ServiceTaxAmount = invoice.ServiceTaxAmount,
                    IsPaidBill = invoice.IsPaidBill,
                    MemberCardNo = invoice.MemberCardNo,
                    StaffName = invoice.StaffName,
                    CashPaymentDollar = invoice.CashPaymentDollar,
                    CashPaymentKs = invoice.CashPaymentKs,
                    CardPaymentDollar = invoice.CardPaymentDollar,
                    CardPaymentKs = invoice.CardPaymentKs,
                    RemainDollar = invoice.RemainDollar,
                    RemainKs = invoice.RemainKs,
                    RefundDollar = invoice.RefundDollar,
                    RefundKs = invoice.RefundKs,
                    CardNo = invoice.CardNo,
                    CardType = invoice.CardType,
                    BankChargesDollar = invoice.BankChargesDollar,
                    BankChargesKs = invoice.BankChargesKs,
                    BottleCharges = invoice.BottleCharges,
                    SaleItems = items
                });
            }

            return invoices;
        }
        catch (System.Exception)
        {
            // log
            throw;
        }
    }


    // /// <summary>
    // /// Find (Invoice) by ID
    // /// </summary>
    // /// <param name="invoiceNo"></param>
    // /// <returns></returns>
    // public async Task<TransactionSale?> FindInvoiceByIdAsync(string invoiceNo)
    // {
    //     ArgumentNullException.ThrowIfNullOrEmpty(invoiceNo);

    //     try
    //     {
    //         var invoice = await _invoiceRepo
    //             .FindById(invoiceNo)
    //             .SingleOrDefaultAsync();

    //         if (invoice != null)
    //         {
    //             return invoice;
    //         }

    //         return null;
    //     }
    //     catch (System.Exception e)
    //     {
    //         _logger.LogError("Exception at Service::FindOneByIdAsync : {e}", e);
    //         throw;
    //     }
    // }


    /// <summary>
    /// Find (Invoice + Invoice Item) by ID (Invoice No)
    /// </summary>
    /// <param name="invoiceNo"></param>
    /// <returns></returns>
    public async Task<InvoiceWithItemsGetDto?> Find_ById_Async(string invoiceNo)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(invoiceNo);

        InvoiceWithItemsGetDto finalResult;

        try
        {
            var invoice = await _invoiceRepo
                .FindById(invoiceNo)
                .SingleOrDefaultAsync();

            if (invoice != null)
            {
                finalResult = new InvoiceWithItemsGetDto
                {
                    SalesType = invoice.SalesType,
                    InvoiceNo = invoice.InvoiceNo,
                    InvoiceDate = invoice.InvoiceDate,
                    VoucherNo = invoice.VoucherNo,
                    Currency = invoice.Currency,
                    ReceivableType = invoice.ReceivableType,
                    RegistrationNo = invoice.RegistrationNo,
                    Remark = invoice.Remark,
                    Total = invoice.Total,
                    DiscountPers = invoice.DiscountPers,
                    DiscountAmt = invoice.DiscountAmt,
                    TaxPers = invoice.TaxPers,
                    TaxAmount = invoice.TaxAmount,
                    ServicePers = invoice.ServicePers,
                    ServiceAmount = invoice.ServiceAmount,
                    NetAmount = invoice.NetAmount,
                    CashierId = invoice.CashierId,
                    CreateUserId = invoice.CreateUserId,
                    CreateDate = invoice.CreateDate,
                    ModifyUserId = invoice.ModifyUserId,
                    ModifyDate = invoice.ModifyDate,
                    PaidDate = invoice.PaidDate,
                    ServiceTaxPers = invoice.ServiceTaxPers,
                    ServiceTaxAmount = invoice.ServiceTaxAmount,
                    IsPaidBill = invoice.IsPaidBill,
                    MemberCardNo = invoice.MemberCardNo,
                    StaffName = invoice.StaffName,
                    CashPaymentDollar = invoice.CashPaymentDollar,
                    CashPaymentKs = invoice.CashPaymentKs,
                    CardPaymentDollar = invoice.CardPaymentDollar,
                    CardPaymentKs = invoice.CardPaymentKs,
                    RemainDollar = invoice.RemainDollar,
                    RemainKs = invoice.RemainKs,
                    RefundDollar = invoice.RefundDollar,
                    RefundKs = invoice.RefundKs,
                    CardNo = invoice.CardNo,
                    CardType = invoice.CardType,
                    BankChargesDollar = invoice.BankChargesDollar,
                    BankChargesKs = invoice.BankChargesKs,
                    BottleCharges = invoice.BottleCharges,
                    SaleItems = []
                };

                var invoiceItems = await _invoiceItemRepo
                    .FindManyByInvoiceNo(invoice.InvoiceNo)
                    .ToListAsync();
                if (invoiceItems != null)
                {
                    finalResult.SaleItems = SaleInvoiceItemMapper.ToGetDto(invoiceItems);
                }

                return finalResult;
            }

            return null;
        }
        catch (System.Exception e)
        {
            _logger.LogError("Exception at Service::FindOneByIdAsync : {e}", e);
            throw;
        }
    }

    // public  async Task<List<InvoiceItemGetDto>?> FindInvoiceItemById(string invoiceNo)
    // {


    // }


    /// <summary>
    /// Save (Invoice), INVOICE ONLY.
    /// ** DO WE REALLY NEED THIS??
    /// ** PURPOSE: when we only need to save invoice without invoic items
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<InvoiceGetDto> SaveSingleInvoice_Async(InvoiceCreateDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        try
        {
            var createdInvoice = await _invoiceRepo
                .SaveAsync(SaleInvoiceMapper.ToEntity(dto));

            if (createdInvoice > 0)
            {
                // Refetch
                var query = await _invoiceRepo.FindById(dto.InvoiceNo)
                                                .SingleOrDefaultAsync();
                if (query != null)
                {
                    return SaleInvoiceMapper.ToGetDto(query);
                }

                throw new Exception("Exception occured at refetching newly created invoice.");
            }

            throw new Exception("Exception at creating new invoice.");
        }
        catch (System.Exception e)
        {
            _logger.LogError("Exception at Service::SaveInvoiceOnlyAsync : {e}", e);
            throw;
        }
    }



    /// <summary>
    /// Save (Invoice + Invoice Items)
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<InvoiceWithItemsGetDto> SaveInvoice_Async(
                                                InvoiceWithItemsCreateDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        await using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var createdInvoice = await _invoiceRepo
                .SaveAsync(SaleInvoiceMapper.ToEntity(dto));

            SaleInvoiceItemMapper.ToCreateDto(dto).ForEach(async item =>
            {
                var effectedRow = await _invoiceItemRepo.SaveAsync(
                SaleInvoiceItemMapper.ToEntity(item)
                );
                if (effectedRow == 0)
                    throw new Exception("Insert process for Item failed");
            });
            //    foreach(var item in SaleInvoiceItemMapper.ToCreateDto(dto))
            //    {
            //     var q= await _invoiceItemRepo.SaveAsync(
            //         SaleInvoiceItemMapper.ToEntity(item)
            //     );
            //    }


            // ===== QUERY newly created items =====
            // Sale Invoice
            var newInvoice = await _invoiceRepo
                .FindById(dto.InvoiceNo)
                .SingleOrDefaultAsync();
            if (newInvoice == null)
                throw new Exception("Fetching for the newly created Invoice failed");
            // Sale Invoice Items
            var newInvoiceItemsList = await _invoiceItemRepo
                .FindManyByInvoiceNo(newInvoice.InvoiceNo)
                .ToListAsync();

            var finalResult = new InvoiceWithItemsGetDto
            {
                InvoiceNo = newInvoice.InvoiceNo,
                InvoiceDate = newInvoice.InvoiceDate,
                VoucherNo = newInvoice.VoucherNo,
                Currency = newInvoice.Currency,
                ReceivableType = newInvoice.ReceivableType,
                RegistrationNo = newInvoice.RegistrationNo,
                Remark = newInvoice.Remark,
                Total = newInvoice.Total,
                DiscountPers = newInvoice.DiscountPers,
                DiscountAmt = newInvoice.DiscountAmt,
                TaxPers = newInvoice.TaxPers,
                TaxAmount = newInvoice.TaxAmount,
                ServicePers = newInvoice.ServicePers,
                ServiceAmount = newInvoice.ServiceAmount,
                NetAmount = newInvoice.NetAmount,
                CashierId = newInvoice.CashierId,
                CreateUserId = newInvoice.CreateUserId,
                CreateDate = newInvoice.CreateDate,
                ModifyUserId = newInvoice.ModifyUserId,
                ModifyDate = newInvoice.ModifyDate,
                PaidDate = newInvoice.PaidDate,
                ServiceTaxPers = newInvoice.ServiceTaxPers,
                ServiceTaxAmount = newInvoice.ServiceTaxAmount,
                IsPaidBill = newInvoice.IsPaidBill,
                MemberCardNo = newInvoice.MemberCardNo,
                StaffName = newInvoice.StaffName,
                CashPaymentDollar = newInvoice.CashPaymentDollar,
                CashPaymentKs = newInvoice.CashPaymentKs,
                CardPaymentDollar = newInvoice.CardPaymentDollar,
                CardPaymentKs = newInvoice.CardPaymentKs,
                RemainDollar = newInvoice.RemainDollar,
                RemainKs = newInvoice.RemainKs,
                RefundDollar = newInvoice.RefundDollar,
                RefundKs = newInvoice.RefundKs,
                CardNo = newInvoice.CardNo,
                CardType = newInvoice.CardType,
                BankChargesDollar = newInvoice.BankChargesDollar,
                BankChargesKs = newInvoice.BankChargesKs,
                BottleCharges = newInvoice.BottleCharges,
                SaleItems = SaleInvoiceItemMapper.ToGetDto(newInvoiceItemsList)
            };

            await transaction.CommitAsync();
            return finalResult;
        }
        catch (System.Exception e)
        {
            _logger.LogError("Exception at Service::SaveInvoiceAsync : {e}", e);
            await transaction.RollbackAsync();
            throw;
        }
    }

    /// <summary>
    /// Update Invoice No (Invoice No + Invoice Items), ** need to update to both Invoice + Invoice Items
    /// </summary>
    /// <param name="invoiceNo"></param>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<InvoiceWithItemsGetDto> UpdateInvoiceNo_Async(string invoiceNo, string newInvoiceNo)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(invoiceNo);
        ArgumentNullException.ThrowIfNullOrEmpty(newInvoiceNo);

        await using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            // Find Invoice
            var invoiceToUpdate = await _invoiceRepo
                .FindById(invoiceNo)
                .SingleOrDefaultAsync();

            if (invoiceToUpdate == null)
            {
                // log
                // Invoice to Update was Not Found
                throw new Exception();
            }

            // Check InvoiceNo Collision
            var duplicatedInvoice = await _invoiceRepo
                .FindById(newInvoiceNo)
                .SingleOrDefaultAsync();

            // InvoiceNo ALREADY EXIST
            if (duplicatedInvoice != null)
            {
                // log
                // Invoice already exist
                throw new HmsSaleInvoiceConflictException(
                    newInvoiceNo,
                    duplicatedInvoice.InvoiceNo);
            }

            // IF       : Invoice to update  IS FOUND
            // AND      : No Collision       WAS NOT FOUND
            // UPDATE   : InvoiceNo for (Invoice and InvoiceItems)
            bool invoiceUpdated = await _invoiceRepo
                .UpdateInvoiceNoAsync(invoiceNo, newInvoiceNo);
            bool invoiceItemsUpdated = await _invoiceItemRepo
                .UpdateInvoiceNoAsync(invoiceNo, newInvoiceNo);

            if (!invoiceUpdated || !invoiceItemsUpdated)
                // log
                throw new Exception();

            // ===== QUERY newly updated items =====
            var finalResult = await Find_ById_Async(newInvoiceNo);
            // ** finalResult must exist **
            if (finalResult == null)
            {
                // log
                _logger.LogError("Newly update invoice number does not seems to exist or cannot be found.");
                throw new Exception($"Exception: Failed to fetch newly updated invoice number {newInvoiceNo}.");
            }

            await transaction.CommitAsync();

            return finalResult;
        }
        catch (System.Exception e)
        {
            _logger.LogError("Exception at Service::UpdateInvoiceNoAsync : {e}", e);
            await transaction.RollbackAsync();
            throw;
        }
    }

    /// <summary>
    /// Update (Invoice + Invoice Items)
    /// ** Will update to both Invoice and Invoice Items
    /// </summary>
    /// <param name="invoiceNo"></param>
    /// <returns></returns>
    public async Task<InvoiceWithItemsGetDto> UpdateInvoice_ById_Async(
        string invoiceNo,
        InvoiceWithItemsUpdateDto dto)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(invoiceNo);
        ArgumentNullException.ThrowIfNull(dto);

        InvoiceWithItemsGetDto finalResult = new();

        await using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            // find Invoice
            TransactionSale? transactionSale = await _invoiceRepo
                .FindById(invoiceNo)
                .SingleOrDefaultAsync();

            if (transactionSale != null)
            {
                // ** DO WE NEED TO KEEP RECORD OF WHICH ITEM FAILED OR SUCCEED???
                List<bool> updateTracker = [];
                // InvoiceWithItemsUpdateDto => TransactionSale
                var invoice = SaleInvoiceMapper.ToEntity(dto);
                // InvoiceWithItemsUpdateDto => List<TransactionSalesItem>
                var itemList = SaleInvoiceItemMapper.ToEntity(dto);

                // UPDATE Invoice (TransactionSale)
                bool updateInvoiceSucceed = await _invoiceRepo
                    .UpdateByIdAsync(invoiceNo, invoice);
                updateTracker.Add(updateInvoiceSucceed);

                // UPDATE Invoice Items (TransactionSalesItem)
                itemList.ForEach(async item =>
                {
                    bool updateInvoiceItemSucceed = await _invoiceItemRepo
                        .UpdateByIdAsync(item.InvoiceNo, item.ItemNo, item);
                    updateTracker.Add(updateInvoiceItemSucceed);
                });

                if (updateTracker.Contains(false))
                    throw new HmsSaleInvoiceUpdateFailedException();

                // ===== QUERY newly updated items =====
                InvoiceWithItemsGetDto? updatedInvoice = await Find_ById_Async(dto.InvoiceNo);


                if (updatedInvoice == null)
                    throw new HmsSaleInvoiceUpdateFailedException();

                await transaction.CommitAsync();

                return updatedInvoice;
            }

            // TODO::
            // throw new HmsUpdateInvoiceFailedException();
            throw new HmsSaleInvoiceUpdateFailedException();
        }
        catch (System.Exception e)
        {
            _logger.LogError("Exception at Service::UpdateInvoiceAsync : {e}", e);
            await transaction.RollbackAsync();
            throw;
        }
    }

    // /// <summary>
    // /// Delete (Invoice + Invoice Items) by InvoiceNo
    // /// After delete, need to return deleted Invoice Items too or just Invoice ???
    // /// Task<SaleInvoiceGetDto> DeleteInvoiceAsync(string invoiceNo);
    // /// </summary>
    // /// <param name="invoiceNo"></param>
    // /// <returns></returns>
    // public async Task<InvoiceWithItemsGetDto> Delete_ById_Async(string invoiceNo)
    // {
    //     await using var transaction = await _context.Database.BeginTransactionAsync();


    //     try
    //     {
    //         // Delete Invoice
    //         var invoiceDeleted = await _invoiceRepo.DeleteByIdAsync(invoiceNo);
    //         // Delete Invoice Items
    //         var invoiceItemsDeleted = await _invoiceItemRepo.DeleteManyByInvoiceNo(invoiceNo);
    //         if (invoiceDeleted && invoiceItemsDeleted)
    //         {
    //             // ===== QUERY newly updated items =====
    //             InvoiceWithItemsGetDto? deletedInvoice = await Find_ById_Async(invoiceNo);
    //             if (deletedInvoice != null)
    //             {
    //                 await transaction.CommitAsync();
    //                 return deletedInvoice;
    //             }

    //             throw new Exception("Exception at Delete_ById_Async: querying deleted items");
    //         }

    //         throw new Exception("Exception at Delete_ById_Async");
    //     }
    //     catch (System.Exception)
    //     {
    //         await transaction.RollbackAsync();
    //         throw;
    //     }
    // }


    /// <summary>
    /// Delete (Invoice + Invoice Items) by InvoiceNo
    /// After delete, need to return deleted Invoice Items too or just Invoice ???
    /// Task<SaleInvoiceGetDto> DeleteInvoiceAsync(string invoiceNo);
    /// </summary>
    /// <param name="invoiceNo"></param>
    /// <returns></returns>
    public async Task<bool> Delete_ById_Async(string invoiceNo)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(invoiceNo);

        await using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            // Delete Invoice
            var invoiceDeleted = await _invoiceRepo.DeleteByIdAsync(invoiceNo);
            // Delete Invoice Items
            var invoiceItemsDeleted = await _invoiceItemRepo.DeleteManyByInvoiceNo(invoiceNo);

            if (invoiceDeleted && invoiceItemsDeleted)
                return true;

            throw new Exception("Exception at Delete_ById_Async");
        }
        catch (System.Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    /// <summary>
    /// Delete Invoice Items by InvoiceNo
    /// </summary>
    /// <param name="invoiceNo"></param>
    /// <param name=""></param>
    /// <returns></returns>
    public async Task<List<InvoiceItemGetDto>> DeleteAllInvoiceItems_ByInvoiceNo_Async(string invoiceNo)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            // var itemsToDelete = await _invoiceItemRepo.FindManyByInvoiceNo(invoiceNo).ToListAsync();
            var deleteSuccessful = await _invoiceItemRepo.DeleteManyByInvoiceNo(invoiceNo);

            if (deleteSuccessful)
            {
                // ===== QUERY newly updated items =====
                var updatedItems = await _invoiceItemRepo
                    .FindManyByInvoiceNo(invoiceNo)
                    .ToListAsync();


                if (updatedItems.Count > 0)
                {
                    await transaction.CommitAsync();
                    return SaleInvoiceItemMapper.ToGetDto(updatedItems);
                }

                // throw new HmsSaleInvoiceDeleteFailedException();
            }

            // throw new HmsSaleInvoiceDeleteFailedException();
            throw new Exception("Delete Invoice Items failed.");
        }
        catch (System.Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }


    // =============== OBSOLETED =============================================
    [Obsolete("This method is deprecated. Use SaveWithItemsAsync instead.", false)]
    public async Task<InvoiceWithItemsGetDto> CreateTransactionSaleMasterAsync(InvoiceWithItemsCreateDto dto)
    {
        var result = await _invoiceRepo.CreateTransactionSaleMasterAsync(dto);
        return result;
    }
    [Obsolete("This method is deprecated. Use SaveWithItemsAsync instead.", false)]
    public async Task<InvoiceWithItemsGetDto> CreateSaleInvoiceWithItemsAsync(InvoiceWithItemsCreateDto dto)
    {
        var result = await _invoiceRepo.CreateTransactionSaleMasterAsync(dto);
        return result;
    }
    [Obsolete("This method is deprecated. Use FindAllWithItemsByTypeAsync instead.", false)]
    public async Task<List<InvoiceWithItemsGetDto>> GetSaleInvoiceWithItemsBySalesTypeAsync(string salesType)
    {
        List<InvoiceWithItemsGetDto> result = [];

        List<TransactionSale> saleInvoicesList = await _invoiceRepo.GetAllTransactionSalesAsync(salesType);

        if (saleInvoicesList != null)
        {
            foreach (var invoice in saleInvoicesList)
            {
                var invoiceDto = SaleInvoiceMapper.ToGetDto(invoice);

                var saleItemsList = await _invoiceItemRepo.GetAllSalesItemByInvoiceNoAsync(invoice.InvoiceNo);
                if (saleItemsList != null)
                {
                    var salesItemDtoList = SaleInvoiceItemMapper.ToGetDto(saleItemsList);

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
    [Obsolete("This method is deprecated. Use FindAllWithItemsByTypeAsync instead.", false)]
    public async Task<List<InvoiceWithItemsGetDto>> GetTransactionSalesMasterBySalesTypeAsync(string salesType)
    {
        var saleInvoicesList = await _invoiceRepo.GetAllTransactionSalesAsync(salesType);
        // Manual mapping
        List<InvoiceWithItemsGetDto> resultList = [];

        foreach (var i in saleInvoicesList)
        {
            var itemsForCurrentInvoiceNo = await _invoiceItemRepo.GetAllSalesItemByInvoiceNoAsync(i.InvoiceNo);
            InvoiceWithItemsGetDto invoiceMaster = new()
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
                SaleItems = SaleInvoiceItemMapper.ToGetDto(itemsForCurrentInvoiceNo),
            };
            resultList.Add(invoiceMaster);
        }

        return resultList;
    }
    [Obsolete("This method is deprecated. Use FindAllByTypeAsync instead.", false)]
    public async Task<List<InvoiceGetDto>> GetTransactionSalesBySalesTypeAsync(string salesType)
    {
        try
        {
            var saleInvoices = await _invoiceRepo.GetAllTransactionSalesAsync(salesType);
            var result = SaleInvoiceMapper.ToGetDto(saleInvoices);
            return result;
        }
        catch (System.Exception)
        {
            throw new Exception("Unable to fetch Transaction Sales.");
        }
    }




}
