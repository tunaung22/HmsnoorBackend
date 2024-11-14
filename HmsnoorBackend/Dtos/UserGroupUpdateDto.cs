namespace HmsnoorBackend.Dtos;

public class UserGroupUpdateDto
{
    public string UserGroupName { get; set; } = null!;

    public string? Description { get; set; }

    public bool? Inactive { get; set; }

    public int? CreateUserId { get; set; }

    public int? ModifyUserId { get; set; }

    public DateTime? CreateUserDate { get; set; }

    public DateTime? ModifyUserDate { get; set; }

    public bool? Fo { get; set; }

    public bool? SaleService { get; set; }

    public bool? Restaurant { get; set; }

    public bool? Account { get; set; }

    public bool? Setup { get; set; }

    public bool? UserAdmin { get; set; }

    public bool? Setting { get; set; }

    public bool? Store { get; set; }

}
