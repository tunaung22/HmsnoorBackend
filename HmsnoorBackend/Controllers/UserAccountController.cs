using HmsnoorBackend.Dtos;
using HmsnoorBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HmsnoorBackend.Controllers;

[Route("api")]
[ApiController]
public class UserAccountController : ControllerBase
{
    private readonly ILogger<UserAccountController> _logger;
    private readonly IUserAccountService _userAccountService;

    public UserAccountController(
        ILogger<UserAccountController> logger,
        IUserAccountService userAccountService
    )
    {
        _logger = logger;
        _userAccountService = userAccountService;
    }

    [HttpPost("/v1/users")]
    [ProducesResponseType<UserAccountGetDto>(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create_UserAccount_Async([FromBody] UserAccountCreateDto requestBody)
    {
        if (requestBody != null)
        {
            var createdUser = await _userAccountService.Save_UserAccount_Async(requestBody);
            if (createdUser != null)
            {
                var uri = Url.Action(nameof(Create_UserAccount_Async), new { id = createdUser.UserId });

                return Created(uri, createdUser);
            }

            throw new Exception("Create user failed.");
        }

        return BadRequest();
    }

    [HttpPatch("/v1/users/{userId}")]
    [ProducesResponseType<UserAccountGetDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]

    public async Task<IActionResult> Update_UserAccount_Async(int userId, [FromBody] UserAccountUpdateDto requestBody)
    {
        var updatedUser = await _userAccountService.Update_UserAccount_Async(userId, requestBody);

        if (updatedUser != null)
            return Ok(updatedUser);

        throw new Exception("Update user failed.");
    }

    [HttpDelete("/v1/users/{userId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Delete_UserAccount_Async(int userId)
    {
        var deletedUserGroupName = await _userAccountService.Delete_UserAccount_ById_Async(userId);

        if (deletedUserGroupName != null)
            return NoContent();

        throw new Exception("Delete failed");
    }

    [HttpGet("/v1/users/{userId}")]
    [ProducesResponseType<UserAccountGetDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get_UserAccount_ById_Async(int userId)
    {
        var user = await _userAccountService.Find_UserAccount_ById_Async(userId);

        if (user != null)
            return Ok(user);

        return NotFound();
    }

    [HttpGet("/v1/users")]
    [ProducesResponseType<IEnumerable<UserAccountGetDto>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get_All_Async()
    {
        var userGroups = await _userAccountService.FindAll_UserAccounts_Async();

        return Ok(userGroups);
    }
}
