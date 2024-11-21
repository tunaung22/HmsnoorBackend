using System;
using Castle.Core.Logging;
using FluentAssertions;
using HmsnoorBackend.Controllers;
using HmsnoorBackend.Dtos;
using HmsnoorBackend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace HmsnoorBackend.UnitTests.Controllers;

public class SalesControllerTests
{

    private readonly Mock<ILogger<SalesController>> _logger;
    private readonly SalesController _controller;
    private readonly Mock<ISaleInvoiceService> _mockTransactionSalesService;

    public SalesControllerTests()
    {
        _mockTransactionSalesService = new Mock<ISaleInvoiceService>();
        _logger = new Mock<ILogger<SalesController>>();
        _controller = new SalesController(
            _logger.Object,
            _mockTransactionSalesService.Object);
    }

    [Fact]
    public async Task GetAllSales_Should_Return_OkWithListOfSalesInvoicesAndItems()
    {
        // Arrange
        var salesType = "Minibar";
        List<InvoiceWithItemsGetDto> invoiceList = [
            new InvoiceWithItemsGetDto
            {
                SalesType = "Minibar",
                InvoiceNo = "M20240513005",
                InvoiceDate = DateOnly.Parse("2024-05-13"),
                VoucherNo = "1001",
                Currency = 1,
                ReceivableType = "Cash",
                RegistrationNo = "2024123456",
                Remark = "test",
                Total = decimal.Parse("13000.0000"),
                DiscountPers = decimal.Parse("0.0000"),
                DiscountAmt = decimal.Parse("0.0000"),
                TaxPers = decimal.Parse("0.0000"),
                TaxAmount = decimal.Parse("0.0000"),
                ServicePers = decimal.Parse("0.0000"),
                ServiceAmount = decimal.Parse("0.0000"),
                NetAmount = decimal.Parse("13000.0000"),
                CashierId = "noor",
                CreateUserId = 1111,
                CreateDate = DateTime.Parse("2024-06-23 19:35:16.000"),
                ModifyUserId = 1111,
                ModifyDate = null,
                PaidDate = DateOnly.Parse("2024-05-13"),
                ServiceTaxPers = decimal.Parse("0.0000"),
                ServiceTaxAmount = decimal.Parse("0.0000"),
                IsPaidBill = true,
                MemberCardNo = "111222333",
                StaffName = "ABC",
                CashPaymentDollar = decimal.Parse("0.0000"),
                CashPaymentKs = decimal.Parse("13000.000"),
                CardPaymentDollar = decimal.Parse("0.0000"),
                CardPaymentKs = decimal.Parse("0.0000"),
                RemainDollar = decimal.Parse("0.0000"),
                RemainKs = decimal.Parse("0.0000"),
                RefundDollar = decimal.Parse("0.0000"),
                RefundKs = decimal.Parse("0.0000"),
                CardNo = null,
                CardType = null,
                BankChargesDollar = decimal.Parse("0.0000"),
                BankChargesKs = decimal.Parse("0.0000"),
                BottleCharges = decimal.Parse("0.0000"),
                SaleItems = [
                    new () {
                        InvoiceNo = "M20240720003",
                        ItemNo = "M005",
                        ItemName = "M005",
                        Price = decimal.Parse("3000.0000"),
                        Quantity = decimal.Parse("2.0000"),
                        Amount = decimal.Parse("6000.0000"),
                    },
                    new () {
                        InvoiceNo = "M20240720003",
                        ItemNo = "M006",
                        ItemName = "M006",
                        Price = decimal.Parse("1000.0000"),
                        Quantity = decimal.Parse("1.0000"),
                        Amount = decimal.Parse("1000.0000"),
                    },
                    new () {
                        InvoiceNo = "M20240720003",
                        ItemNo = "M007",
                        ItemName = "M007",
                        Price = decimal.Parse("3000.0000"),
                        Quantity = decimal.Parse("2.0000"),
                        Amount = decimal.Parse("6000.0000"),
                    }
                ]
            },
            new InvoiceWithItemsGetDto
            {
                SalesType = "Minibar",
                InvoiceNo = "M20240707003",
                InvoiceDate = DateOnly.Parse("2024-07-07"),
                VoucherNo = "405",
                Currency = 1,
                ReceivableType = "Cash",
                RegistrationNo = null,
                Remark = null,
                Total = decimal.Parse("1000.0000"),
                DiscountPers = decimal.Parse("0.0000"),
                DiscountAmt = decimal.Parse("0.0000"),
                TaxPers = decimal.Parse("0.0000"),
                TaxAmount = decimal.Parse("0.0000"),
                ServicePers = decimal.Parse("0.0000"),
                ServiceAmount = decimal.Parse("0.0000"),
                NetAmount = decimal.Parse("1000.0000"),
                CashierId = "juu",
                CreateUserId = 7152,
                CreateDate = DateTime.Parse("2024-07-07 11:06:32.000"),
                ModifyUserId = null,
                ModifyDate = null,
                PaidDate = DateOnly.Parse("2024-07-07"),
                ServiceTaxPers = decimal.Parse("0.0000"),
                ServiceTaxAmount = decimal.Parse("0.0000"),
                IsPaidBill = true,
                MemberCardNo = string.Empty,
                StaffName = string.Empty,
                CashPaymentDollar = decimal.Parse("0.0000"),
                CashPaymentKs = decimal.Parse("1000.000"),
                CardPaymentDollar = decimal.Parse("0.0000"),
                CardPaymentKs = decimal.Parse("0.0000"),
                RemainDollar = decimal.Parse("0.0000"),
                RemainKs = decimal.Parse("0.0000"),
                RefundDollar = decimal.Parse("0.0000"),
                RefundKs = decimal.Parse("0.0000"),
                CardNo = string.Empty,
                CardType = string.Empty,
                BankChargesDollar = decimal.Parse("0.0000"),
                BankChargesKs = decimal.Parse("0.0000"),
                BottleCharges = decimal.Parse("0.0000"),
                SaleItems = [
                    new () {
                        InvoiceNo = "M20240707003",
                        ItemNo = "M006",
                        ItemName = "M006",
                        Price = decimal.Parse("1000.0000"),
                        Quantity = decimal.Parse("1.0000"),
                        Amount = decimal.Parse("1000.0000"),
                    }
                ]
            },
        ];
        _mockTransactionSalesService.Setup(s => s.FindAll_Invoice_Async(salesType))
            .Returns(Task.FromResult(invoiceList));

        // Setup
        var result = (OkObjectResult)_controller.Get_All_(salesType);

        // Assert
        result.Should().NotBeNull();
        result.StatusCode.Should().Be(200);
        result.Value.Should().BeEquivalentTo(invoiceList);
    }

}
