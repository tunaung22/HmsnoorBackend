using System;
using FluentAssertions;
using HmsnoorBackend.Controllers;
using HmsnoorBackend.Dtos;
using HmsnoorBackend.Models;
using HmsnoorBackend.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace HmsnoorBackend.UnitTests.Controllers;

public class ItemsControllerTests
{
    private readonly Mock<ILogger<ItemsController>> _logger;
    private readonly Mock<IItemService> _mockItemHeaderService;
    private readonly ItemsController _controller;

    public ItemsControllerTests()
    {
        _mockItemHeaderService = new Mock<IItemService>();
        _logger = new Mock<ILogger<ItemsController>>();

        _controller = new ItemsController(
            _logger.Object,
            _mockItemHeaderService.Object);
    }

    [Fact]
    public async Task GetItemsAsync_Should_Return_Ok_With_ListOfItems()
    {
        // Arrange
        var items = new List<ItemWithDetailGetDto>
        {
            new ItemWithDetailGetDto
            {
                ItemNo="R001", ItemName="Chicken Fries", ItemType = "Restaurant",
                ItemCategory="Food",  MItemName="ကြက်ကြော် 10000",
                ItemDetails = new List<ItemDetailGetDto>
                {
                    new() {
                        Id = 1,
                        ItemType = "Restaurant",
                        ItemNo = "R001",
                        CurrencyId = 1,
                        Price = 8000
                    },
                      new() {
                        Id = 2,
                        ItemType = "Restaurant",
                        ItemNo = "R001",
                        CurrencyId = 1,
                        Price = 10000
                    },
                }
            }
        };

        // new () { ItemNo="D001", ItemName="Pillow", ItemType = "Damage", ItemCategory="Damage",  MItemName="ခေါင်းအုံး 20000" },
        // new () { ItemNo="L001", ItemName="Long Gyi ", ItemType = "Laundry", ItemCategory="Laundry",  MItemName="5000" }
        // _mockItemHeaderService.Setup(s => s.GetAllItemHeadersAsync())
        // .ReturnsAsync(items);


        // Act
        // var result = await _controller.GetAllItemHeaders();
        // var okResult = result as OkObjectResult;
        var result = (OkObjectResult)await _controller.GetAllItemHeaders();


        // Assert
        result.Should().NotBeNull();
        result.StatusCode.Should().Be(200);
        result.Value.Should().BeEquivalentTo(items);

    }


    [Fact]
    public async Task GetItemHeaderByItemNo_Should_Return_OkWithItem_WhenItemExists()
    {
        // Arrange
        var itemType = "Restaurant";
        var itemNo = "R001";
        var expected = new ItemGetDto
        {
            ItemNo = "R001",
            ItemName = "Chicken Fries",
            ItemType = "Restaurant",
            ItemCategory = "Food",
            MItemName = "ကြက်ကြော် 10000"
        };

        _mockItemHeaderService.Setup(s => s.FindItemByIdAsync(itemType, itemNo))
            .ReturnsAsync(expected);

        // Setup
        var result = (OkObjectResult)await _controller.GetItemHeaderByItemNo(itemNo);

        // Assert
        result.Should().NotBeNull();
        result.StatusCode.Should().Be(200);
        result.Value.Should().BeEquivalentTo(expected);
    }

    // [Fact]
    // public async Task GetItemHeaderByItemNo_Should_Return_NotFound_WhenDoesNotExist()
    // {
    //     // Arrange
    //     var itemNo = "NonExistingItemNo";
    //     _mockItemHeaderService.Setup(s => s.GetItemHeaderByItemNoAsync(itemNo))
    //         .ReturnsAsync((ItemHeaderGetDto?)null);

    //     // Setup
    //     var result = (NotFoundResult)await _controller.GetItemHeaderByItemNo(itemNo);

    //     // Assert
    // }

}
