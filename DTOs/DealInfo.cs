public readonly record struct DealBaseInfo(
    int ProductId,
    int SellerUserId,
    int CustomerUserId
);

public readonly record struct CreateDealInfo(
    DealBaseInfo DealBaseInfo
);
public readonly record struct UpdateDealInfo(
    int Id,
    DealBaseInfo DealBaseInfo
);
public readonly record struct ReadDealInfo(
    int Id,
    DealBaseInfo DealBaseInfo,
    DateTime CreatedAt
);