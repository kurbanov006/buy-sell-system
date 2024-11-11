public readonly record struct ProductBaseInfo(
    string ProductName,
    int SellerUserId,
    int Quantity,
    decimal Price
);

public readonly record struct CreateProductInfo(
    ProductBaseInfo ProductBaseInfo
);
public readonly record struct UpdateProductInfo(
    int Id,
    ProductBaseInfo ProductBaseInfo
);
public readonly record struct ReadProductInfo(
    int Id,
    ProductBaseInfo ProductBaseInfo,
    DateTime CreatedAt
);

