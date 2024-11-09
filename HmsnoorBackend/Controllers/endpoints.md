# Endpoints

    base: /api (?page=1&show=20)

## Notes

- ItemHeader -> unique (ItemNo, ItemType)
- ItemDetail -> unique (ItemNo, ItemType, CurrencyId)

## Item Endpoints

### GetItem List

Use to fetch list of items with this endpoint. Additional filter can be added using query string.

    /items (?page=1&show=20)
    /items?type=Minibar
    /items?code=M001

### GetItem by ItemNo

Use to fetch item by item code. Can get multiple items because ItemNo is not unique solely

    /items/code/{itemNo}
    /items/code/M001
    /items/code/M002
    /items/code/M003

### GetItem by ItemType

    /items/code/{itemNo}
    /items/code/M001
    /items/code/M002
    /items/code/M003

### GetItem By Id

    /items/types/{ItemType}/code/{ItemNo}
    /items/types/Minibar/code/M001
    /items/types/Minibar/code/M002
    /items/types/Minibar/code/M003

    /items/types/{ItemType}/code/{ItemNo}
    /items/types/Minibar/code/M001
    /items/types/Minibar/code/M002
    /items/types/Minibar/code/M003
