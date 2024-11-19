namespace HmsnoorBackend.Dtos;

public class UserAccountGetDto
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    // Hide to public
    // public string Password { get; set; } = null!;

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
