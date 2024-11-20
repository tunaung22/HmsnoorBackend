using HmsnoorBackend.Dtos;
using HmsnoorBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HmsnoorBackend.Controllers;

[Route("api")]
[ApiController]
public class UserGroupController : ControllerBase
{
    private readonly ILogger<UserGroupController> _logger;
    private readonly IUserGroupService _userGroupService;

    public UserGroupController(
        ILogger<UserGroupController> logger,
        IUserGroupService userGroupService
    )
    {
        _logger = logger;
        _userGroupService = userGroupService;
    }

    [HttpPost("/v1/users/groups")]
    [ProducesResponseType<UserGroupGetDto>(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create_UserGroup_Async([FromBody] UserGroupCreateDto requestBody)
    {
        if (requestBody != null)
        {
            var createdUserGroup = await _userGroupService.Save_UserGroup_Async(requestBody);
            if (createdUserGroup != null)
            {
                var uri = Url.Action(nameof(Create_UserGroup_Async), new { id = createdUserGroup.UserGroupName });

                return Created(uri, createdUserGroup);
            }

            throw new Exception("Create user group failed.");
        }

        return BadRequest();
    }

    [HttpPatch("/v1/users/groups/{groupName}")]
    [ProducesResponseType<UserGroupGetDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Update_UserGroup_Async(string groupName, [FromBody] UserGroupUpdateDto requestBody)
    {
        if (string.IsNullOrEmpty(groupName))
            // throw new ArgumentNullException("Argument groupName is required.");
            return BadRequest("Argument groupName is required.");

        var updatedUserGroup = await _userGroupService.Update_UserGroup_Async(groupName, requestBody);

        if (updatedUserGroup != null)
            return Ok(updatedUserGroup);

        throw new Exception("Update user group failed.");
    }

    [HttpDelete("/v1/users/groups/{groupName}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Delete_UserGroup_Async(string groupName)
    {
        if (string.IsNullOrEmpty(groupName))
            // throw new ArgumentNullException("Argument groupName is required.");
            return BadRequest("Argument groupName is required.");

        var deletedUserGroupName = await _userGroupService.Delete_UserGroup_ById_Async(groupName);

        if (deletedUserGroupName != null)
            return NoContent();

        throw new Exception("Delete failed");
    }

    [HttpGet("/v1/users/groups/{groupName}")]
    [ProducesResponseType<UserGroupGetDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get_UserGroup_ById_Async(string groupName)
    {
        if (string.IsNullOrEmpty(groupName))
            // throw new ArgumentNullException("Argument groupName is required.");
            return BadRequest("Argument groupName is required.");

        var userGroup = await _userGroupService.Find_UserGroup_ById_Async(groupName);

        if (userGroup != null)
            return Ok(userGroup);

        return NotFound();
    }

    [HttpGet("/v1/users/groups")]
    [ProducesResponseType<IEnumerable<UserGroupGetDto>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get_All_Async()
    {
        var userGroups = await _userGroupService.FindAll_UserGroups_Async();

        return Ok(userGroups);
    }

}
