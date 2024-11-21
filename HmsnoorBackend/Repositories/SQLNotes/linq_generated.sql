-- FIRST
-- Microsoft.EntityFrameworkCore.Database.Command[20101]
-- Executed DbCommand (23ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT [i].[ItemType],
    [i].[ItemNo],
    [i].[ItemCategory],
    [i].[ItemName],
    [i].[MItemName],
    [t1].[Id],
    [t1].[ItemType],
    [t1].[ItemNo],
    [t1].[Price],
    [t1].[CurrencyId],
    [t1].[CurrencyDescription],
    [t1].[CurrencyNotation],
    [t1].[c]
FROM [ItemHeader] AS [i]
    LEFT JOIN (
        SELECT [i0].[Id],
            [i0].[ItemType],
            [i0].[ItemNo],
            [i0].[Price],
            [t0].[CurrencyId],
            [t0].[CurrencyDescription],
            [t0].[CurrencyNotation],
            [t0].[c]
        FROM [ItemDetail] AS [i0]
            LEFT JOIN (
                SELECT [t].[CurrencyId],
                    [t].[CurrencyDescription],
                    [t].[CurrencyNotation],
                    [t].[c]
                FROM (
                        SELECT [c].[CurrencyId],
                            [c].[CurrencyDescription],
                            [c].[CurrencyNotation],
                            1 AS [c],
                            ROW_NUMBER() OVER(
                                PARTITION BY [c].[CurrencyId]
                                ORDER BY [c].[CurrencyId]
                            ) AS [row]
                        FROM [Currency] AS [c]
                    ) AS [t]
                WHERE [t].[row] <= 1
            ) AS [t0] ON [i0].[CurrencyId] = [t0].[CurrencyId]
    ) AS [t1] ON [i].[ItemType] = [t1].[ItemType]
    AND [i].[ItemNo] = [t1].[ItemNo]
ORDER BY [i].[ItemNo],
    [i].[ItemType],
    [t1].[Id] -- SECOND optimized
    -- Microsoft.EntityFrameworkCore.Database.Command[20101]
    -- Executed DbCommand (6ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT [i].[ItemType],
    [i].[ItemNo],
    [i].[ItemCategory],
    [i].[ItemName],
    [i].[MItemName],
    [i0].[Id],
    [i0].[ItemType],
    [i0].[ItemNo],
    [i0].[Price],
    [t0].[CurrencyId],
    [t0].[CurrencyDescription],
    [t0].[CurrencyNotation],
    [t0].[c]
FROM [ItemHeader] AS [i]
    INNER JOIN [ItemDetail] AS [i0] ON [i].[ItemType] = [i0].[ItemType]
    AND [i].[ItemNo] = [i0].[ItemNo]
    LEFT JOIN (
        SELECT [t].[CurrencyId],
            [t].[CurrencyDescription],
            [t].[CurrencyNotation],
            [t].[c]
        FROM (
                SELECT [c].[CurrencyId],
                    [c].[CurrencyDescription],
                    [c].[CurrencyNotation],
                    1 AS [c],
                    ROW_NUMBER() OVER(
                        PARTITION BY [c].[CurrencyId]
                        ORDER BY [c].[CurrencyId]
                    ) AS [row]
                FROM [Currency] AS [c]
            ) AS [t]
        WHERE [t].[row] <= 1
    ) AS [t0] ON [i0].[CurrencyId] = [t0].[CurrencyId] -- Select ALL Items with Details
SELECT [i].[ItemType],
    [i].[ItemNo],
    [i].[ItemCategory],
    [i].[ItemName],
    [i].[MItemName],
    [i0].[Id],
    [t1].[Id],
    [t1].[ItemType],
    [t1].[ItemNo],
    [t1].[Price],
    [t1].[CurrencyId],
    [t1].[CurrencyDescription],
    [t1].[CurrencyNotation],
    [t1].[c]
FROM [ItemHeader] AS [i]
    INNER JOIN [ItemDetail] AS [i0] ON [i].[ItemType] = [i0].[ItemType]
    AND [i].[ItemNo] = [i0].[ItemNo]
    LEFT JOIN (
        SELECT [i1].[Id],
            [i1].[ItemType],
            [i1].[ItemNo],
            [i1].[Price],
            [t0].[CurrencyId],
            [t0].[CurrencyDescription],
            [t0].[CurrencyNotation],
            [t0].[c]
        FROM [ItemDetail] AS [i1]
            LEFT JOIN (
                SELECT [t].[CurrencyId],
                    [t].[CurrencyDescription],
                    [t].[CurrencyNotation],
                    [t].[c]
                FROM (
                        SELECT [c].[CurrencyId],
                            [c].[CurrencyDescription],
                            [c].[CurrencyNotation],
                            1 AS [c],
                            ROW_NUMBER() OVER(
                                PARTITION BY [c].[CurrencyId]
                                ORDER BY [c].[CurrencyId]
                            ) AS [row]
                        FROM [Currency] AS [c]
                    ) AS [t]
                WHERE [t].[row] <= 1
            ) AS [t0] ON [i1].[CurrencyId] = [t0].[CurrencyId]
    ) AS [t1] ON [i].[ItemType] = [t1].[ItemType]
    AND [i].[ItemNo] = [t1].[ItemNo]
ORDER BY [i].[ItemType],
    [i].[ItemNo],
    [i0].[Id],
    [t1].[Id] -- Select SINGLE Item with Details by Id
SELECT [t].[ItemType],
    [t].[ItemNo],
    [t].[ItemCategory],
    [t].[ItemName],
    [t].[MItemName],
    [t1].[Id],
    [t1].[ItemType],
    [t1].[ItemNo],
    [t1].[Price],
    [t1].[CurrencyId],
    [t1].[CurrencyDescription],
    [t1].[CurrencyNotation],
    [t1].[c]
FROM (
        SELECT TOP(2) [i].[ItemType],
            [i].[ItemNo],
            [i].[ItemCategory],
            [i].[ItemName],
            [i].[MItemName]
        FROM [ItemHeader] AS [i]
        WHERE [i].[ItemType] = 'restaurant'
            AND [i].[ItemNo] = 'r0013'
    ) AS [t]
    LEFT JOIN (
        SELECT [i0].[Id],
            [i0].[ItemType],
            [i0].[ItemNo],
            [i0].[Price],
            [t0].[CurrencyId],
            [t0].[CurrencyDescription],
            [t0].[CurrencyNotation],
            [t0].[c],
            [i0].[CurrencyId] AS [CurrencyId0]
        FROM [ItemDetail] AS [i0]
            LEFT JOIN (
                SELECT [t2].[CurrencyId],
                    [t2].[CurrencyDescription],
                    [t2].[CurrencyNotation],
                    [t2].[c]
                FROM (
                        SELECT [c].[CurrencyId],
                            [c].[CurrencyDescription],
                            [c].[CurrencyNotation],
                            1 AS [c],
                            ROW_NUMBER() OVER(
                                PARTITION BY [c].[CurrencyId]
                                ORDER BY [c].[CurrencyId]
                            ) AS [row]
                        FROM [Currency] AS [c]
                    ) AS [t2]
                WHERE [t2].[row] <= 1
            ) AS [t0] ON [i0].[CurrencyId] = [t0].[CurrencyId]
    ) AS [t1] ON [t].[ItemType] = [t1].[ItemType]
    AND [t].[ItemNo] = [t1].[ItemNo]
ORDER BY [t].[ItemNo],
    [t].[ItemType],
    [t1].[CurrencyId0],
    [t1].[Price],
    [t1].[Id]