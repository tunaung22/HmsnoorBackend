using System;
using HmsnoorBackend.Dtos;

namespace HmsnoorBackend.Services.Interfaces;

public interface IUserGroupService
{
    Task<UserGroupGetDto> Save_UserGroup_Async(UserGroupCreateDto dto);
    Task<UserGroupGetDto> Update_UserGroup_Async(string groupName,
                                                    UserGroupUpdateDto dto);
    Task<UserGroupGetDto> Update_GroupName_Async(string groupName,
                                                    string newGroupName);
    Task<UserGroupGetDto> Delete_UserGroup_ById_Async(string groupName);
    Task<UserGroupGetDto> Find_UserGroup_ById_Async(string groupName);
    Task<List<UserGroupGetDto>> FindAll_UserGroups_Async();
}
