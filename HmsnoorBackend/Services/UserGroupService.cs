using HmsnoorBackend.Data.Models;
using HmsnoorBackend.Dtos;
using HmsnoorBackend.Dtos.DtoMappers;
using HmsnoorBackend.Exceptions;
using HmsnoorBackend.Repositories.Interfaces;
using HmsnoorBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HmsnoorBackend.Services;

public class UserGroupService : IUserGroupService
{
    private readonly ILogger<UserGroupService> _logger;
    private readonly IUserGroupRepository _userGroupRepository;

    public UserGroupService(
        ILogger<UserGroupService> logger,
        IUserGroupRepository repo)
    {
        _logger = logger;
        _userGroupRepository = repo;
    }


    public async Task<UserGroupGetDto> Save_UserGroup_Async(UserGroupCreateDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        try
        {
            UserGroup userGroup = UserGroupMapper.ToEntity(dto);
            int count = await _userGroupRepository.Save(userGroup);

            if (count > 0)
                return await Find_UserGroup_ById_Async(dto.UserGroupName);

            throw new HmsUserGroupSaveFailedException($"User group with name [{dto.UserGroupName}] create failed.");
        }
        catch (System.Exception e)
        {
            _logger.LogError("Exception at Service {name}: {e}",
                nameof(Save_UserGroup_Async),
                e);
            throw;
        }
    }

    public async Task<UserGroupGetDto> Update_GroupName_Async(string groupName,
                                                        string newGroupName)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(groupName);
        ArgumentNullException.ThrowIfNullOrEmpty(newGroupName);

        try
        {
            var userGroup = await _userGroupRepository
                           .FindById(groupName)
                           .SingleOrDefaultAsync();

            if (userGroup != null)
            {
                int count = await _userGroupRepository.UpdateGroupName(groupName, newGroupName);
                if (count > 0)
                    return UserGroupMapper.ToGetDto(userGroup);

                throw new HmsUserGroupNotFoundException($"User group with name [{groupName}] not found.");
            }
            throw new HmsUserGroupNotFoundException($"User group with name [{groupName}] not found.");
        }
        catch (System.Exception e)
        {
            _logger.LogError("Exception at Service {name}: {e}",
                nameof(Update_GroupName_Async),
                e);
            throw;
        }
    }

    public async Task<UserGroupGetDto> Update_UserGroup_Async(string groupName,
                                                        UserGroupUpdateDto dto)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(groupName);
        ArgumentNullException.ThrowIfNull(dto);

        try
        {
            var userGroup = await _userGroupRepository
                .FindById(groupName)
                .SingleOrDefaultAsync();

            if (userGroup != null)
            {
                int count = await _userGroupRepository.UpdateById(groupName, userGroup);
                if (count > 0)
                    return UserGroupMapper.ToGetDto(userGroup);

                throw new HmsUserGroupNotFoundException($"User group with name [{groupName}] not found.");
            }

            throw new HmsUserGroupNotFoundException($"User group with name [{groupName}] not found.");
        }
        catch (System.Exception e)
        {
            _logger.LogError("Exception at Service {name}: {e}",
                nameof(Update_UserGroup_Async),
                e);
            throw;
        }
    }

    public async Task<UserGroupGetDto> Delete_UserGroup_ById_Async(string groupName)
    {
        try
        {
            var userGroup = await _userGroupRepository
                      .FindById(groupName)
                      .SingleOrDefaultAsync();
            if (userGroup != null)
            {
                int count = await _userGroupRepository.DeleteById(groupName);
                if (count > 0)
                    return UserGroupMapper.ToGetDto(userGroup);

                throw new HmsUserGroupDeleteFailedException();
            }

            throw new HmsUserGroupNotFoundException($"User group [${groupName}] does not exist.");
        }
        catch (System.Exception e)
        {
            _logger.LogError("Exception at Service {name}: {e}",
                nameof(Delete_UserGroup_ById_Async),
                e);
            throw;
        }


    }

    public async Task<UserGroupGetDto> Find_UserGroup_ById_Async(string groupName)
    {
        try
        {
            var userGroup = await _userGroupRepository
                       .FindById(groupName)
                       .SingleOrDefaultAsync();
            if (userGroup != null)
                return UserGroupMapper.ToGetDto(userGroup);

            throw new HmsUserGroupNotFoundException($"User group [${groupName}] does not exist.");
        }
        catch (System.Exception e)
        {
            _logger.LogError("Exception at Service {name}: {e}",
                nameof(Find_UserGroup_ById_Async),
                e);
            throw;
        }


    }

    public async Task<List<UserGroupGetDto>> FindAll_UserGroups_Async()
    {
        try
        {
            var userGroups = await _userGroupRepository.FindAll().ToListAsync();
            return UserGroupMapper.ToGetDtoList(userGroups);
        }
        catch (System.Exception e)
        {
            _logger.LogError("Exception at Service {name}: {e}",
                nameof(FindAll_UserGroups_Async),
                e);
            throw;
        }
    }
}


