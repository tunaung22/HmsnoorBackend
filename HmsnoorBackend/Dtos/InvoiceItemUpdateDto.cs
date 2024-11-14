namespace HmsnoorBackend.Dtos;

public class InvoiceItemUpdateDto
{
    // public string InvoiceNo { get; set; } = null!;

    // public string ItemNo { get; set; } = null!;

    public string ItemName { get; set; } = null!;

    public decimal Price { get; set; }

    public decimal Quantity { get; set; }

    public decimal Amount { get; set; }

}
