using LibraryManagementSystem.Data;
using LibraryManagementSystem.Entity;

class ReviewOperations
{
    private static AppDbContext context = new AppDbContext();

    public static void AddReview(int memberId, int bookId, string comment, int rating)
    {
        var existingReview = context.Reviews
            .FirstOrDefault(r => r.BookId == bookId && r.MemberId == memberId);

        if (existingReview != null)
        {
            throw new InvalidOperationException("You have already reviewed this book.");
        }

        Review review = new Review
        {
            BookId = bookId,
            MemberId = memberId,
            Comment = comment,
            Rating = rating,
            ReviewDate = DateTime.Now
        };

        context.Reviews.Add(review);
        context.SaveChanges();
    }
}