using HmsnoorBackend.Dtos;

namespace HmsnoorBackend.Services.Interfaces;

public interface IUserAccountService
{
    Task<UserAccountGetDto> Save_UserAccount_Async(UserAccountCreateDto dto);
    Task<UserAccountGetDto> Update_UserAccount_Async(int userId,
                                                    UserAccountUpdateDto dto);
    Task<UserAccountGetDto> Delete_UserAccount_ById_Async(int userId);
    Task<UserAccountGetDto> Find_UserAccount_ById_Async(int userId);
    Task<UserAccountGetDto> Find_UserAccount_ByUsername_Async(string username);
    Task<List<UserAccountGetDto>> FindAll_UserAccounts_Async();
}
