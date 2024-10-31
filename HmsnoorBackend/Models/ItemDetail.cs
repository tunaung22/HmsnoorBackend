using System;
using System.Collections.Generic;

namespace HmsnoorBackend.Models;

// TODOs: Generated using Scaffolding from existing database.
// ** needs reviews
public partial class ItemDetail
{
    public int Id { get; set; }

    public string ItemNo { get; set; } = null!;

    public int CurrencyId { get; set; }

    public decimal Price { get; set; }

    public string ItemType { get; set; } = null!;
}
