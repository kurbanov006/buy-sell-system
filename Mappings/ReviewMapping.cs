public static class ReviewMapping
{
    public static Review CreateToReview(this CreateReviewInfo createReview)
    {
        return new Review()
        {
            ProductId = createReview.ReviewBaseInfo.ProductId,
            CustomerUserId = createReview.ReviewBaseInfo.CustomerUserId,
            Comment = createReview.ReviewBaseInfo.Comment
        };
    }

    public static Review UpdateToReview(this Review review, UpdateReviewInfo updateReview)
    {
        review.ProductId = updateReview.ReviewBaseInfo.ProductId;
        review.CustomerUserId = updateReview.ReviewBaseInfo.CustomerUserId;
        review.Comment = updateReview.ReviewBaseInfo.Comment;
        review.UpdatedAt = DateTime.UtcNow;
        return review;
    }

    public static ReadReviewInfo ToRead(this Review review)
    {
        return new ReadReviewInfo()
        {
            Id = review.Id,
            CreatedAt = review.CreatedAt,
            ReviewBaseInfo = new ReviewBaseInfo()
            {
                ProductId = review.ProductId,
                CustomerUserId = review.CustomerUserId,
                Comment = review.Comment
            }
        };
    }

    public static Review ToDeleted(this Review review)
    {
        review.IsDeleted = true;
        review.DeletedAt = DateTime.UtcNow;
        return review;
    }
}