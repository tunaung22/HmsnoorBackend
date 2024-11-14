namespace HmsnoorBackend.Dtos;

public class CurrencyCreateDto
{
    public int CurrencyId { get; set; }
    public string CurrencyDescription { get; set; } = null!;
    public string? CurrencyNotation { get; set; }
}
