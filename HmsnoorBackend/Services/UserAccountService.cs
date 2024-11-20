using HmsnoorBackend.Data;
using HmsnoorBackend.Data.Models;
using HmsnoorBackend.Dtos;
using HmsnoorBackend.Dtos.DtoMappers;
using HmsnoorBackend.Exceptions;
using HmsnoorBackend.Repositories.Interfaces;
using HmsnoorBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HmsnoorBackend.Services;

public class UserAccountService : IUserAccountService
{
    private readonly ILogger<UserAccount> _logger;
    private readonly HmsnoorDbContext _context;
    private readonly IUserAccountRepository _userAccountRepository;

    public UserAccountService(
        ILogger<UserAccount> logger,
        HmsnoorDbContext context,
        IUserAccountRepository repo)
    {
        _logger = logger;
        _context = context;
        _userAccountRepository = repo;
    }


    public async Task<UserAccountGetDto> Save_UserAccount_Async(UserAccountCreateDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        try
        {
            UserAccount user = UserAccountMapper.ToEntity(dto);
            int count = await _userAccountRepository.Save(user);

            if (count > 0)
                return await Find_UserAccount_ByUsername_Async(dto.UserName!);

            // UserAccount? createdUser = await _userAccountRepository
            //     .FindById(dto.UserId).FirstOrDefaultAsync();
            // if (createdUser != null)
            //     return UserAccountMapper.ToGetDto(createdUser);
            // throw new HmsUserAccountNotFoundException($"User account with username [{dto.UserName}] not found.");

            throw new HmsUserAccountSaveFailedException($"User account with username [{dto.UserName}] create failed.");
        }
        catch (System.Exception e)
        {
            _logger.LogError("Exception at Service {name}: {e}",
                nameof(Save_UserAccount_Async),
                e);
            throw;
        }

    }

    public async Task<UserAccountGetDto> Update_UserAccount_Async(int userId,
        UserAccountUpdateDto dto)
    {
        ArgumentNullException.ThrowIfNull(userId);
        ArgumentNullException.ThrowIfNull(dto);

        try
        {
            var user = await _userAccountRepository
                .FindById(userId)
                .SingleOrDefaultAsync();
            if (user != null)
            {
                int count = await _userAccountRepository.UpdateById(userId, user);
                if (count > 0)
                    return UserAccountMapper.ToGetDto(user);

                throw new HmsUserAccountUpdateFailedException($"User account with id [{userId}] update failed.");
            }

            throw new HmsUserAccountNotFoundException($"User accoun with id [{userId}] not found.");
        }
        catch (System.Exception e)
        {
            _logger.LogError("Exception at Service {name}: {e}",
                nameof(Save_UserAccount_Async),
                e);
            throw;
        }

    }

    public async Task<UserAccountGetDto> Delete_UserAccount_ById_Async(int userId)
    {
        ArgumentNullException.ThrowIfNull(userId);

        try
        {
            var user = await _userAccountRepository
                        .FindById(userId)
                        .SingleOrDefaultAsync();
            if (user != null)
            {
                var count = await _userAccountRepository.DeleteById(userId);
                if (count > 0)
                    return UserAccountMapper.ToGetDto(user);

                throw new HmsUserAccountDeleteFailedException();
            }

            throw new HmsUserAccountNotFoundException($"User accoun with id [{userId}] not found.");
        }
        catch (System.Exception e)
        {
            _logger.LogError("Exception at Service {name}: {e}",
                nameof(Save_UserAccount_Async),
                e);
            throw;
        }

    }

    public async Task<UserAccountGetDto> Find_UserAccount_ById_Async(int userId)
    {
        ArgumentNullException.ThrowIfNull(userId);

        try
        {
            var user = await _userAccountRepository
                        .FindById(userId)
                        .SingleOrDefaultAsync();
            if (user != null)
            {
                UserAccountGetDto userDto = UserAccountMapper.ToGetDto(user);

                return userDto;
            }

            throw new HmsUserAccountNotFoundException($"User account with id [{userId}] not found.");
        }
        catch (System.Exception e)
        {
            _logger.LogError("Exception at Service {name}: {e}",
                nameof(Find_UserAccount_ById_Async),
                e);
            throw;
        }

    }

    public async Task<UserAccountGetDto> Find_UserAccount_ByUsername_Async(string username)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(username);

        try
        {
            var user = await _userAccountRepository
                        .FindByUsername(username)
                        .SingleOrDefaultAsync();
            if (user != null)
            {
                UserAccountGetDto userDto = UserAccountMapper.ToGetDto(user);

                return userDto;
            }

            throw new HmsUserAccountNotFoundException($"User account with username [{username}] not found.");
        }
        catch (System.Exception e)
        {
            _logger.LogError("Exception at Service {name}: {e}",
                nameof(Find_UserAccount_ByUsername_Async),
                e);
            throw;
        }

    }

    public async Task<List<UserAccountGetDto>> FindAll_UserAccounts_Async()
    {
        try
        {
            var users = await _userAccountRepository.FindAll().ToListAsync();

            return UserAccountMapper.ToGetDtoList(users);
        }
        catch (System.Exception e)
        {
            _logger.LogError("Exception at Service {name}: {e}",
                                nameof(FindAll_UserAccounts_Async),
                                e);
            throw;
        }
    }
}

