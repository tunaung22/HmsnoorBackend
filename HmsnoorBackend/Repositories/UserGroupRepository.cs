using HmsnoorBackend.Data;
using HmsnoorBackend.Data.Models;
using HmsnoorBackend.Exceptions;
using HmsnoorBackend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HmsnoorBackend.Repositories;

public class UserGroupRepository : IUserGroupRepository
{
    private readonly HmsnoorDbContext _context;

    public UserGroupRepository(HmsnoorDbContext context)
    {
        _context = context;
    }


    public async Task<int> Save(UserGroup model)
    {
        _context.UserGroups.Add(model);
        var query = await _context.SaveChangesAsync();

        return query;
    }

    public async Task<int> UpdateById(string groupName, UserGroup model)
    {
        var query = await FindById(groupName).FirstOrDefaultAsync();
        if (query != null)
        {
            _context.Entry(query).State = EntityState.Modified;
            query.Description = model.Description;
            query.Inactive = model.Inactive;
            query.CreateUserId = model.CreateUserId;
            query.ModifyUserId = model.ModifyUserId;
            query.CreateUserDate = model.CreateUserDate;
            query.ModifyUserDate = model.ModifyUserDate;
            query.Fo = model.Fo;
            query.SaleService = model.SaleService;
            query.Restaurant = model.Restaurant;
            query.Account = model.Account;
            query.Setup = model.Setup;
            query.UserAdmin = model.UserAdmin;
            query.Setting = model.Setting;
            query.Store = model.Store;

            return await _context.SaveChangesAsync();
        }

        throw new HmsUserGroupNotFoundException("User Group not exist.");
    }

    public async Task<int> UpdateGroupName(string groupName, string newGroupName)
    {
        var query = await FindById(groupName).FirstOrDefaultAsync();
        if (query != null)
        {
            _context.Entry(query).State = EntityState.Modified;
            query.UserGroupName = newGroupName;

            return await _context.SaveChangesAsync();
        }

        throw new HmsUserGroupNotFoundException("User Group not exist.");
    }

    public async Task<int> DeleteById(string groupName)
    {
        var query = await FindById(groupName).FirstOrDefaultAsync();
        if (query != null)
        {
            _context.UserGroups.Remove(query);
            return await _context.SaveChangesAsync();
        }

        throw new HmsUserGroupNotFoundException("User Group not exist.");
    }

    public IQueryable<UserGroup> FindById(string groupName)
    {
        var query = _context.UserGroups
            .Where(m => m.UserGroupName == groupName)
            .Select(m => new UserGroup
            {
                UserGroupName = m.UserGroupName,
                Description = m.Description,
                Inactive = m.Inactive,
                CreateUserId = m.CreateUserId,
                ModifyUserId = m.ModifyUserId,
                CreateUserDate = m.CreateUserDate,
                ModifyUserDate = m.ModifyUserDate,
                Fo = m.Fo,
                SaleService = m.SaleService,
                Restaurant = m.Restaurant,
                Account = m.Account,
                Setup = m.Setup,
                UserAdmin = m.UserAdmin,
                Setting = m.Setting,
                Store = m.Store,
            });

        return query;
    }
    public IQueryable<UserGroup> FindAll()
    {
        var query = _context.UserGroups
            .OrderBy(m => m.UserGroupName)
            .Select(m => new UserGroup
            {
                UserGroupName = m.UserGroupName,
                Description = m.Description,
                Inactive = m.Inactive,
                CreateUserId = m.CreateUserId,
                ModifyUserId = m.ModifyUserId,
                CreateUserDate = m.CreateUserDate,
                ModifyUserDate = m.ModifyUserDate,
                Fo = m.Fo,
                SaleService = m.SaleService,
                Restaurant = m.Restaurant,
                Account = m.Account,
                Setup = m.Setup,
                UserAdmin = m.UserAdmin,
                Setting = m.Setting,
                Store = m.Store,
            });

        return query;
    }
}

