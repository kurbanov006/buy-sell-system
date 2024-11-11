public readonly record struct CreateSellerUserInfo(
    BaseUserInfo BaseUserInfo
);
public readonly record struct UpdateSellerUserInfo(
    int Id,
    BaseUserInfo BaseUserInfo
);
public readonly record struct ReadSellerUserInfo(
    int Id,
    BaseUserInfo BaseUserInfo,
    DateTime CreatedAt
);