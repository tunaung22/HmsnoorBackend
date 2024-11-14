namespace HmsnoorBackend.Data.Models;

// TODOs: Generated using Scaffolding from existing database.
// ** needs reviews
public partial class Guest
{
    public int GuestId { get; set; }

    public int InitialId { get; set; }

    public string? FirstName { get; set; }

    public string? FamilyName { get; set; }

    public string Name { get; set; } = null!;

    public string Nrc { get; set; } = null!;

    public DateTime? Dob { get; set; }

    public string? FatherName { get; set; }

    public string? Occupation { get; set; }

    public string? Address { get; set; }

    public int? CountryId { get; set; }

    public string? Phone { get; set; }

    public string Gender { get; set; } = null!;

    public string? Email { get; set; }

    public string? Remark { get; set; }

    public string? VisaNo { get; set; }

    public DateOnly? VisaExpireDate { get; set; }

    public bool? IsLocal { get; set; }

    public string? Coa { get; set; }
}
