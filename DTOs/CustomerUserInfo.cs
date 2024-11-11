public readonly record struct CreateCustomerUserInfo(
    BaseUserInfo BaseUserInfo
);
public readonly record struct UpdateCustomerUserInfo(
    int Id,
    BaseUserInfo BaseUserInfo
);
public readonly record struct ReadCustomerUserInfo(
    int Id,
    BaseUserInfo BaseUserInfo,
    DateTime CreatedAt
);