using HmsnoorBackend.Dtos;
using HmsnoorBackend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace HmsnoorBackend.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ItemCategoriesController : ControllerBase
    {
        private readonly IItemCategoryService _itemCategoryService;

        public ItemCategoriesController(IItemCategoryService itemCategoryService)
        {
            _itemCategoryService = itemCategoryService;
        }

        [HttpPost("v1/categories")]
        [ProducesResponseType<ItemCategoryGetDto>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Create_ItemCategory_Async([FromBody] ItemCategoryCreateDto requestBody)
        {
            if (requestBody != null)
            {
                var result = await _itemCategoryService.Save_ItemCategory_Async(requestBody);
                var uri = Url.Action(nameof(Create_ItemCategory_Async), new { id = result.ItemCategoryId });

                return Created(uri, result);
            }

            return BadRequest("Invalid request body");
        }

        [HttpPatch("v1/categories")]
        [ProducesResponseType<ItemCategoryGetDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update_Category_ById_Async(
            string categoryId,
            ItemCategoryUpdateDto requestBody)
        {
            if (!categoryId.IsNullOrEmpty())
            {
                ItemCategoryGetDto updatedCategoryDto = await _itemCategoryService.Update_ItemCategory_Async(categoryId, requestBody);
                return Ok(updatedCategoryDto);
            }

            return BadRequest();
        }

        [HttpDelete("v1/categories")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete_Category_ById_Async(string categoryId)
        {
            if (!categoryId.IsNullOrEmpty())
            {
                if (await _itemCategoryService.Delete_ItemCategory_Async(categoryId))
                {
                    return NoContent();
                }

                // throw new HmsItemCategoryDeleteFailedException($"Failed at deleting item category {categoryId}");
                throw new Exception("Failed at deleting item category");
            }

            throw new ArgumentException("Invalid arguement for currency id");
        }

        [HttpGet("v1/categories/{categoryId}")]
        [ProducesResponseType<ItemCategoryGetDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get_Currency_byId_Async(string categoryId)
        {
            if (!categoryId.IsNullOrEmpty())
            {
                ItemCategoryGetDto? result = await _itemCategoryService
                    .Find_ById_Async(categoryId);
                if (result != null)
                {
                    return Ok(result);
                }

                return NotFound();
            }

            throw new ArgumentException("Invalid arguement for currency id");
        }

        [HttpGet("v1/categories")]
        [ProducesResponseType<IEnumerable<ItemCategoryGetDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get_AllCategories_Async()
        {
            var result = await _itemCategoryService
                .FindAll_ItemCategory_Async();
            return Ok(result);
        }
    }
}
