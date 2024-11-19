using HmsnoorBackend.Data.Models;

namespace HmsnoorBackend.Dtos.DtoMappers;

public class UserGroupMapper
{

    public static List<UserGroupGetDto> ToGetDtoList(List<UserGroup> accountList)
    {
        return accountList.Select(ToGetDto).ToList();
    }

    public static UserGroupGetDto ToGetDto(UserGroup model)
    {
        return new UserGroupGetDto
        {
            UserGroupName = model.UserGroupName,
            Description = model.Description,
            Inactive = model.Inactive,
            CreateUserId = model.CreateUserId,
            ModifyUserId = model.ModifyUserId,
            CreateUserDate = model.CreateUserDate,
            ModifyUserDate = model.ModifyUserDate,
            Fo = model.Fo,
            SaleService = model.SaleService,
            Restaurant = model.Restaurant,
            Account = model.Account,
            Setup = model.Setup,
            UserAdmin = model.UserAdmin,
            Setting = model.Setting,
            Store = model.Store,
        };

    }

    public static UserGroup ToEntity(UserGroupGetDto dto)
    {
        return new UserGroup
        {
            UserGroupName = dto.UserGroupName,
            Description = dto.Description,
            Inactive = dto.Inactive,
            CreateUserId = dto.CreateUserId,
            ModifyUserId = dto.ModifyUserId,
            CreateUserDate = dto.CreateUserDate,
            ModifyUserDate = dto.ModifyUserDate,
            Fo = dto.Fo,
            SaleService = dto.SaleService,
            Restaurant = dto.Restaurant,
            Account = dto.Account,
            Setup = dto.Setup,
            UserAdmin = dto.UserAdmin,
            Setting = dto.Setting,
            Store = dto.Store,
        };
    }

    public static UserGroup ToEntity(UserGroupCreateDto dto)
    {
        return new UserGroup
        {
            UserGroupName = dto.UserGroupName,
            Description = dto.Description,
            Inactive = dto.Inactive,
            CreateUserId = dto.CreateUserId,
            ModifyUserId = dto.ModifyUserId,
            CreateUserDate = dto.CreateUserDate,
            ModifyUserDate = dto.ModifyUserDate,
            Fo = dto.Fo,
            SaleService = dto.SaleService,
            Restaurant = dto.Restaurant,
            Account = dto.Account,
            Setup = dto.Setup,
            UserAdmin = dto.UserAdmin,
            Setting = dto.Setting,
            Store = dto.Store,
        };
    }

    public static UserGroup ToEntity(UserGroupUpdateDto dto)
    {
        return new UserGroup
        {
            UserGroupName = dto.UserGroupName,
            Description = dto.Description,
            Inactive = dto.Inactive,
            CreateUserId = dto.CreateUserId,
            ModifyUserId = dto.ModifyUserId,
            CreateUserDate = dto.CreateUserDate,
            ModifyUserDate = dto.ModifyUserDate,
            Fo = dto.Fo,
            SaleService = dto.SaleService,
            Restaurant = dto.Restaurant,
            Account = dto.Account,
            Setup = dto.Setup,
            UserAdmin = dto.UserAdmin,
            Setting = dto.Setting,
            Store = dto.Store,
        };
    }
}
