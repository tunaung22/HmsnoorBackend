using HmsnoorBackend.Data;
using HmsnoorBackend.Data.Models;
using HmsnoorBackend.Exceptions;
using HmsnoorBackend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HmsnoorBackend.Repositories;

public class UserAccountRepository : IUserAccountRepository
{
    private readonly HmsnoorDbContext _context;

    public UserAccountRepository(HmsnoorDbContext context)
    {
        _context = context;
    }


    public async Task<int> Save(UserAccount model)
    {
        await _context.AddAsync(model);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> UpdateById(int userId, UserAccount model)
    {
        var query = FindById(userId).SingleOrDefault();
        if (query != null)
        {
            _context.Entry(query).State = EntityState.Modified;

            query.UserId = model.UserId;
            query.UserName = model.UserName;
            query.Password = model.Password;
            query.UserGroup = model.UserGroup;
            query.Remark = model.Remark;
            query.IsInsert = model.IsInsert;
            query.IsUpdate = model.IsUpdate;
            query.IsDelete = model.IsDelete;
            query.Inactive = model.Inactive;
            query.CreateUserId = model.CreateUserId;
            query.ModifyUserId = model.ModifyUserId;
            query.CreateUserDate = model.CreateUserDate;
            query.ModifyUserDate = model.ModifyUserDate;

            return await _context.SaveChangesAsync();
        }

        throw new HmsUserAccountNotFoundException("User Account not exits.");
    }

    public async Task<int> UpdateUsername(int userId, string newUsername)
    {
        var query = FindById(userId).SingleOrDefault();
        if (query != null)
        {
            _context.Entry(query).State = EntityState.Modified;

            query.UserName = newUsername;

            await _context.SaveChangesAsync();
        }

        throw new HmsUserAccountNotFoundException("User Account not exits.");
    }

    public async Task<int> DeleteById(int userId)
    {
        var query = FindById(userId).SingleOrDefault();
        if (query != null)
        {
            _context.UserAccounts.Remove(query);
            return await _context.SaveChangesAsync();
        }

        throw new HmsUserAccountNotFoundException("User Account not exits.");
    }

    public IQueryable<UserAccount> FindById(int userId)
    {
        var query = _context.UserAccounts
            .Where(m => m.UserId == userId)
            .Select(m => new UserAccount
            {
                UserId = m.UserId,
                UserName = m.UserName,
                Password = m.Password,
                UserGroup = m.UserGroup,
                Remark = m.Remark,
                IsInsert = m.IsInsert,
                IsUpdate = m.IsUpdate,
                IsDelete = m.IsDelete,
                Inactive = m.Inactive,
                CreateUserId = m.CreateUserId,
                ModifyUserId = m.ModifyUserId,
                CreateUserDate = m.CreateUserDate,
                ModifyUserDate = m.ModifyUserDate,
            });

        return query;
    }

    public IQueryable<UserAccount> FindByUsername(string username)
    {
        var query = _context.UserAccounts
            .Where(m => m.UserName == username)
            .Select(m => new UserAccount
            {
                UserId = m.UserId,
                UserName = m.UserName,
                Password = m.Password,
                UserGroup = m.UserGroup,
                Remark = m.Remark,
                IsInsert = m.IsInsert,
                IsUpdate = m.IsUpdate,
                IsDelete = m.IsDelete,
                Inactive = m.Inactive,
                CreateUserId = m.CreateUserId,
                ModifyUserId = m.ModifyUserId,
                CreateUserDate = m.CreateUserDate,
                ModifyUserDate = m.ModifyUserDate,
            });

        return query;
    }

    public IQueryable<UserAccount> FindAll()
    {
        var query = _context.UserAccounts
            .OrderBy(m => m.UserName)
            .Select(m => new UserAccount
            {
                UserId = m.UserId,
                UserName = m.UserName,
                Password = m.Password,
                UserGroup = m.UserGroup,
                Remark = m.Remark,
                IsInsert = m.IsInsert,
                IsUpdate = m.IsUpdate,
                IsDelete = m.IsDelete,
                Inactive = m.Inactive,
                CreateUserId = m.CreateUserId,
                ModifyUserId = m.ModifyUserId,
                CreateUserDate = m.CreateUserDate,
                ModifyUserDate = m.ModifyUserDate,
            });

        return query;
    }
}
