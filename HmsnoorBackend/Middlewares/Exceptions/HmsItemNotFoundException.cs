using System;

namespace HmsnoorBackend.Middlewares.Exceptions;

public class HmsItemNotFoundException : KeyNotFoundException
{
    public string? itemNo;
    public string? itemType;
    public string? message;

    public HmsItemNotFoundException() : base("Requested item not found.")
    { }

    public HmsItemNotFoundException(string itemType, string itemNo) : base($"Item with id: [{itemType} {itemNo}] not found. **Note** Make sure the url path to be : /[ItemType]/[ItemNo]/")
    {
        this.itemType = itemType;
        this.itemNo = itemNo;
    }



    // $"Requested item: {itemNo} {itemType} not found."
}
