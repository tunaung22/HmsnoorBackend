using HmsnoorBackend.Data.Models;

namespace HmsnoorBackend.Repositories.Interfaces;

public interface IUserGroupRepository
{
    Task<int> Save(UserGroup model);
    Task<int> UpdateById(string groupName, UserGroup model);
    // Task<int> UpdateByGroupName(string groupName, UserGroup model);
    Task<int> UpdateGroupName(string groupName, string newGroupName);
    Task<int> DeleteById(string groupName);
    // Task<int> DeleteByUsername(string username);
    IQueryable<UserGroup> FindById(string groupName);
    // IQueryable<UserGroup> FindByUsername(string username);
    IQueryable<UserGroup> FindAll();
}
