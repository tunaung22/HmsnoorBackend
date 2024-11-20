using HmsnoorBackend.Data.Models;

namespace HmsnoorBackend.Repositories.Interfaces;

public interface IUserAccountRepository
{
    Task<int> Save(UserAccount model);
    Task<int> UpdateById(int userId, UserAccount model);
    Task<int> UpdateUsername(int userId, string newUsername);
    Task<int> DeleteById(int userId);
    IQueryable<UserAccount> FindById(int userId);
    IQueryable<UserAccount> FindByUsername(string username);
    IQueryable<UserAccount> FindAll();

    // IQueryable<UserAccount> FindByUsername(string username);
    // Task<int> SaveAsync(UserAccount model);
    // Task<int> UpdateById(int userId, UserAccount model);
    // Task<int> UpdateByUsername(int userId, UserAccount model);
    // Task<int> UpdateUsername(int userId, string newUsername);
    // Task<int> DeleteById(int userId);
    // Task<int> DeleteByUsername(string username);
}
