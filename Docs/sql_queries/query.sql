-- 
SELECT *
FROM ItemHeader
    INNER JOIN ItemDetail ON ItemHeader.ItemNo = ItemDetail.ItemNo
    INNER JOIN Currency ON ItemDetail.CurrencyId = Currency.CurrencyId
SELECT ItemDetail.ItemNo,
    ItemName,
    ItemCategory,
    ItemDetail.CurrencyId,
    CurrencyDescription,
    CurrencyNotation,
    Price
FROM ItemHeader
    INNER JOIN ItemDetail ON ItemHeader.ItemNo = ItemDetail.ItemNo
    INNER JOIN Currency ON ItemDetail.CurrencyId = Currency.CurrencyId
WHERE ItemHeader.ItemType = 'Restaurant' -- 
SELECT h.ItemNo,
    h.ItemType,
    h.ItemCategory,
    h.ItemName,
    d.CurrencyId,
    c.CurrencyDescription,
    c.CurrencyNotation,
    d.Price
FROM ItemHeader as h
    INNER JOIN ItemDetail as d ON h.ItemNo = d.ItemNo
    INNER JOIN Currency as c ON d.CurrencyId = c.CurrencyId
WHERE h.ItemType = 'Restaurant';
-- 
SELECT ItemNo,
    COUNT(*)
FROM ItemDetail
GROUP BY ItemNo;