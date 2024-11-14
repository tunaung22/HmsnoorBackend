namespace HmsnoorBackend.Data.Models;

public partial class UserAccount
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string Password { get; set; } = null!;

    public string UserGroup { get; set; } = null!;

    public string? Remark { get; set; }

    public bool? IsInsert { get; set; }

    public bool? IsUpdate { get; set; }

    public bool? IsDelete { get; set; }

    public bool? Inactive { get; set; }

    public int? CreateUserId { get; set; }

    public int? ModifyUserId { get; set; }

    public DateTime? CreateUserDate { get; set; }

    public DateTime? ModifyUserDate { get; set; }
}
