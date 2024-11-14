using HmsnoorBackend.Models;

namespace HmsnoorBackend.Dtos.DtoMappers;

public static class UserAccountMapper
{
    public static List<UserAccountGetDto> ToGetDtoList(List<UserAccount> accountList)
    {
        return accountList.Select(ToGetDto).ToList();
    }

    public static UserAccountGetDto ToGetDto(UserAccount model)
    {
        return new UserAccountGetDto
        {
            UserId = model.UserId,
            UserName = model.UserName,
            Password = model.Password,
            UserGroup = model.UserGroup,
            Remark = model.Remark,
            IsInsert = model.IsInsert,
            IsUpdate = model.IsUpdate,
            IsDelete = model.IsDelete,
            Inactive = model.Inactive,
            CreateUserId = model.CreateUserId,
            ModifyUserId = model.ModifyUserId,
            CreateUserDate = model.CreateUserDate,
            ModifyUserDate = model.ModifyUserDate,
        };

    }

    public static UserAccount ToEntity(UserAccountGetDto dto)
    {
        return new UserAccount
        {
            UserId = dto.UserId,
            UserName = dto.UserName,
            Password = dto.Password,
            UserGroup = dto.UserGroup,
            Remark = dto.Remark,
            IsInsert = dto.IsInsert,
            IsUpdate = dto.IsUpdate,
            IsDelete = dto.IsDelete,
            Inactive = dto.Inactive,
            CreateUserId = dto.CreateUserId,
            ModifyUserId = dto.ModifyUserId,
            CreateUserDate = dto.CreateUserDate,
            ModifyUserDate = dto.ModifyUserDate,
        };
    }

    public static UserAccount ToEntity(UserAccountCreateDto dto)
    {
        return new UserAccount
        {
            UserId = dto.UserId,
            UserName = dto.UserName,
            Password = dto.Password,
            UserGroup = dto.UserGroup,
            Remark = dto.Remark,
            IsInsert = dto.IsInsert,
            IsUpdate = dto.IsUpdate,
            IsDelete = dto.IsDelete,
            Inactive = dto.Inactive,
            CreateUserId = dto.CreateUserId,
            ModifyUserId = dto.ModifyUserId,
            CreateUserDate = dto.CreateUserDate,
            ModifyUserDate = dto.ModifyUserDate,
        };
    }

    public static UserAccount ToEntity(UserAccountUpdateDto dto)
    {
        return new UserAccount
        {
            // UserId = dto.UserId,
            // UserName = dto.UserName,
            // Password = dto.Password,
            // UserGroup = dto.UserGroup,
            Remark = dto.Remark,
            IsInsert = dto.IsInsert,
            IsUpdate = dto.IsUpdate,
            IsDelete = dto.IsDelete,
            Inactive = dto.Inactive,
            CreateUserId = dto.CreateUserId,
            ModifyUserId = dto.ModifyUserId,
            CreateUserDate = dto.CreateUserDate,
            ModifyUserDate = dto.ModifyUserDate,
        };
    }

}
