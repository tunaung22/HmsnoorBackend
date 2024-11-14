namespace HmsnoorBackend.Dtos;

public class CurrencyGetDto
{
    public int CurrencyId { get; set; }
    public string CurrencyDescription { get; set; } = null!;
    public string? CurrencyNotation { get; set; }
}
