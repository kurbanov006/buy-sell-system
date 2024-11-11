public readonly record struct ReviewBaseInfo(
    int ProductId,
    int CustomerUserId,
    string? Comment
);

public readonly record struct CreateReviewInfo(
    ReviewBaseInfo ReviewBaseInfo
);
public readonly record struct UpdateReviewInfo(
    int Id,
    ReviewBaseInfo ReviewBaseInfo
);
public readonly record struct ReadReviewInfo(
    int Id,
    ReviewBaseInfo ReviewBaseInfo,
    DateTime CreatedAt
);