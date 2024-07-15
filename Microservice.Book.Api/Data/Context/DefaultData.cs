namespace Microservice.Book.Api.Data.Context;

public class DefaultData
{
    public static List<Domain.Series> GetSeriesDefaultData()
    {
        return new List<Domain.Series>()
        {
            new Domain.Series { Id = 1, Name = "The Arc of a Scythe" },
            new Domain.Series { Id = 2, Name = "The Infinity Cycle" },
            new Domain.Series { Id = 3, Name = "Queen’s Thief" }
        };
    }

    public static List<Domain.DiscountType> GetDiscountTypeDefaultData()
    {
        return new List<Domain.DiscountType>()
        {
            new Domain.DiscountType { Id = 1, Name = "Percentage" },
            new Domain.DiscountType { Id = 2, Name = "Monetary" } 
        };
    }

    public static List<Domain.Publisher> GetPublisherDefaultData()
    {
        return new List<Domain.Publisher>()
        {
            new Domain.Publisher { Id = 1, Name = "Simon & Schuster Books for Young Readers" },
            new Domain.Publisher { Id = 2, Name = "Bulletin Blue Ribbon" },
            new Domain.Publisher { Id = 3, Name = "Quill Tree Books" },
            new Domain.Publisher { Id = 4, Name = "Bloomsbury Publishing PLC"},
            new Domain.Publisher { Id = 5, Name = "Penguin Books Ltd" },
            new Domain.Publisher { Id = 6, Name = "Duckworth Books" },
            new Domain.Publisher { Id = 7, Name = "Little, Brown Book Group"}

        };
    }

    public static List<Domain.Author> GetAuthorDefaultData()
    {
        return new List<Domain.Author>()
        {
            CreateAuthor(new Guid("aa1dc96f-3be5-41cd-8a1b-207284af3fdd"), "Silver", "Elsie", null),
            CreateAuthor(new Guid("af95fb7e-8d97-4892-8da3-5e6e51c54044"), "James", "Arthur", "Henry"),
            CreateAuthor(new Guid("55b431ff-693e-4664-8f65-cfd8d0b14b1b"), "Cooper", "Paul", null),
            CreateAuthor(new Guid("2385de72-2302-4ced-866a-fa199116ca6e"), "Mateal", "Sam", "John"),
            CreateAuthor(new Guid("47417642-87d9-4047-ae13-4c721d99ab48"), "Henry", "Emily", null),
            CreateAuthor(new Guid("ff4d5a80-81e3-42e3-8052-92cf5c51e797"), "Steadman", "A.F.", null),
            CreateAuthor(new Guid("5ff79dfe-c1fa-4dd9-996f-bc96649d6dfc"), "Tores", "Francesca", "De"),
            CreateAuthor(new Guid("ae55b0d1-ba02-41e1-9efa-9b4d4ac15eec"), "Neal", "Shusterman", null),
            CreateAuthor(new Guid("c95ba8ff-06a1-49d0-bc45-83f89b3ce820"), "Adam", "Silvera", null),
            CreateAuthor(new Guid("f07e88ac-53b2-4def-af07-957cbb18523c"), "Turner", "Megan", "Whalen")
        }; 
    }

    public static List<Domain.Book> GetBookDefaultData()
    {
        var wildLoveSummary = "Pure romantic escapism from the author of the Chestnut Springs series, as the 'world's hottest billionaire' unexpectedly finds himself a new parent whilst trying to keep his hands off his best friend's little sister.";
        var fallOfCivilizationsSummary = "Ranging from Mesopotamia to Roman Britain, Cooper's engrossing volume – based on his hit history podcast – charts the rise and decline of several ancient civilizations.";
        var funnyStorySummary = "From the bestselling author of Happy Place and Book Lovers comes another witty and romantic tale, as two wronged exes hatch a plan to make their former partners' lives hell."; ;
        var SkandarAndTheChaosTrialsSummary = "More heart-pounding adventures lie in wait for Skandar Smith in the third instalment of Steadman's blockbuster children's fantasy saga, as the friends must take part in a series of dangerous challenges across the island.";
        var saltbloodSummary = "Reimagining the life of groundbreaking seventeenth-century woman pirate Mary Read, de Tores' dynamic debut entwines themes of gender and survival into a rollicking period adventure story.";
        var infinitySonSummary = "Growing up in New York, brothers Emil and Brighton always idolized the Spell Walkers—a vigilante group sworn to rid the world of specters. While the Spell Walkers and other celestials are born with powers, specters take them, violently stealing the essence of endangered magical creatures.";
        var infinityReaperSummary = "Emil and Brighton Rey defied the odds. They beat the Blood Casters and escaped with their lives–or so they thought. When Brighton drank the Reaper’s Blood, he believed it would make him invincible, but instead the potion is killing him.";
        var infinityKingsSummary = "After the ultimate betrayal, Emil must rise up as a leader to stop his brother, Brighton, before he becomes too powerful. Even if that means pushing away Ness and Wyatt as they compete for his heart so he can focus on the war.";
        var scytheSummary = "A world with no hunger, no disease, no war, no misery: humanity has conquered all those things, and has even conquered death. Now Scythes are the only ones who can end life—and they are commanded to do so, in order to keep the size of the population under control.";
        var thunderheadSummary = "The Thunderhead is the perfect ruler of a perfect world, but it has no control over the scythedom. A year has passed since Rowan had gone off grid. Since then, he has become an urban legend, a vigilante snuffing out corrupt scythes in a trial by fire. His story is told in whispers across the continent.";
        
        return new List<Domain.Book>()
        {
            CreateBook(new Guid("07c06c3f-0897-44b6-ae05-a70540e73a12"), "Infinity Son", "9780063376120", new Guid("c95ba8ff-06a1-49d0-bc45-83f89b3ce820"), 3, 2, infinitySonSummary, "New", 50, 7.50m, null, null),
            CreateBook(new Guid("6131ce7e-fb11-4608-a3d3-f01caee2c465"), "Infinity Reaper", "9780062882318", new Guid("c95ba8ff-06a1-49d0-bc45-83f89b3ce820"), 3, 2, infinityReaperSummary, "New", 34, 8.50m, null, null),
            CreateBook(new Guid("29a75938-ce2d-473b-b7fe-2903fe97fd6e"), "Infinity Kings", "9781398504974", new Guid("c95ba8ff-06a1-49d0-bc45-83f89b3ce820"), 3, 2, infinityKingsSummary, "New", 23, 9.99m, null, null),
            CreateBook(new Guid("23608dce-2142-4d2b-b909-948316b5efaf"), "Scythe", "9781442472433", new Guid("ae55b0d1-ba02-41e1-9efa-9b4d4ac15eec"), 1, 1, scytheSummary, "Used", 1, 3.50m, null, null),
            CreateBook(new Guid("f3fcab1f-1c11-47f5-9e11-7868a88408e6"), "Thunderhead", "9781442472457", new Guid("ae55b0d1-ba02-41e1-9efa-9b4d4ac15eec"), 1, 1, thunderheadSummary, "Used", 3, 2.5m, null, null),
            CreateBook(new Guid("ecf65c56-5670-473b-9f20-fb0b191c2f0f"), "Saltblood", "9781526680266", new Guid("5ff79dfe-c1fa-4dd9-996f-bc96649d6dfc"), 4, null, saltbloodSummary, "New", 30, 15.99m, null, null),
            CreateBook(new Guid("285c81bc-f257-4ffb-b6ce-7ab5fa9e5c81"), "Skandar and the Chaos Trials", "9781398529687", new Guid("ff4d5a80-81e3-42e3-8052-92cf5c51e797"), 1, null, SkandarAndTheChaosTrialsSummary, "New", 20, 12.99m, null, null),
            CreateBook(new Guid("01f54aa7-c51a-4b92-a72b-68e0965bf246"), "Funny Story", "2928377225186", new Guid("47417642-87d9-4047-ae13-4c721d99ab48"), 5, null, funnyStorySummary, "New", 20, 11.99m, null, null),
            CreateBook(new Guid("6b85f863-7991-4f93-bf86-8c756fdeac87"), "Fall of Civilizations: Stories of Greatness and Decline", "9780715655009", new Guid("55b431ff-693e-4664-8f65-cfd8d0b14b1b"), 6, null, fallOfCivilizationsSummary, "New", 10, 15.99m, 10.0m, 1),
            CreateBook(new Guid("37544155-da95-49e8-b7fe-3c937eb1de98"), "Wild Love", "9780349441634", new Guid("aa1dc96f-3be5-41cd-8a1b-207284af3fdd"), 7, null, wildLoveSummary, "New", 10, 9.99m, null, null) 
        };
    }

    private static Domain.Author CreateAuthor(Guid id, string surname, string firstName, string? middlename)
    {
        return new Domain.Author { Id = id, Surname = surname, FirstName = firstName, MiddleName = middlename };
    }

    private static Domain.Book CreateBook(Guid id, string title, string isbn, Guid authorId, int publisherId, int? seriesId,
                                             string summary, string condition, int numberInStock, decimal? price,
                                             decimal? discount, int? discountTypeId)
    {
        return new Domain.Book
        {
            Id = id,
            Title = title,
            ISBN = isbn,
            AuthorId = authorId,
            PublisherId = publisherId,
            SeriesId = seriesId,
            Summary = summary,
            Condition = condition,
            NumberInStock = numberInStock,
            Price = price,
            Discount = discount,
            DiscountTypeId = discountTypeId,
            Created = DateTime.Now,
            LastUpdated = DateTime.Now
        };
    }
}