using LibraryManagementSystem.Data;
using LibraryManagementSystem.Entity;

class PublisherOperation
{
    private static AppDbContext context = new AppDbContext();

    public static Publisher SearchPublisher(int publisherId)
    {
        var existingPublisher = context.Publishers.FirstOrDefault(p => p.Id == publisherId);
        if (existingPublisher == null)
        {
            throw new ArgumentException($"Publisher does not exist.");
        }
        return existingPublisher;
    }

    public static void AddPublisher(Publisher publisher)
    {
        if (string.IsNullOrWhiteSpace(publisher.PublisherName))
            throw new ArgumentException("Publisher name cannot be empty.");

        context.Publishers.Add(publisher);
        context.SaveChanges();
    }

    public static void UpdatePublisher(Publisher publisher, int publisherId)
    {
        var existingPublisher = SearchPublisher(publisherId);

        existingPublisher.PublisherName = publisher.PublisherName;
        existingPublisher.Country = publisher.Country;
        existingPublisher.EstablishedYear = publisher.EstablishedYear;
        existingPublisher.Website = publisher.Website;

        context.SaveChanges();
    }

    public static void DeletePublisher(int publisherId)
    {
        var existingPublisher = SearchPublisher(publisherId);
        context.Publishers.Remove(existingPublisher);
        context.SaveChanges();
    }

    public static List<Publisher> ReadAllPublishers()
    {
        return context.Publishers.ToList();
    }
}