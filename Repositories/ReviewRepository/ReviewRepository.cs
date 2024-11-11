public class ReviewRepository(AppDbContext context) : GenericRepository<Review>(context), IReviewRepository
{

}