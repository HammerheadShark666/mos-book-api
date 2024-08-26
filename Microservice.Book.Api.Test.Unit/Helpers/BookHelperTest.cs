using Microservice.Book.Api.Helpers;

namespace Microservice.Book.Api.Test.Unit.Helpers;

public class BookHelperTests
{
    private BookHelper _bookHelper;

    [SetUp]
    public void SetUp()
    {
        _bookHelper = new BookHelper();
    }

    [Test]
    public void Validate_isbn_valid_return_true()
    {
        var isbn = "9780063376120";

        bool actualResult = _bookHelper.ValidISBN13(isbn);

        Assert.That(actualResult, Is.True);
    }

    [Test]
    public void Validate_isbn_invalid_return_false()
    {
        var isbn = "9780063376122";

        bool actualResult = _bookHelper.ValidISBN13(isbn);

        Assert.That(actualResult, Is.False);
    }

    [Test]
    public void Validate_isbn_no_isbn_return_false()
    {
        var isbn = "";

        bool actualResult = _bookHelper.ValidISBN13(isbn);

        Assert.That(actualResult, Is.False);
    }

    [Test]
    public void Validate_discount_valid_as_not_all_values_passed_return_true()
    {
        decimal? price = null;
        decimal? discount = null;
        int? discountTypeId = null;

        bool actualResult = _bookHelper.ValidDiscount(price, discount, discountTypeId);

        Assert.That(actualResult, Is.True);
    }

    [Test]
    public void Validate_discount_valid_percentage_discount_return_true()
    {
        decimal? price = 10.99m;
        decimal? discount = 5;
        int? discountTypeId = 1;

        bool actualResult = _bookHelper.ValidDiscount(price, discount, discountTypeId);

        Assert.That(actualResult, Is.True);
    }

    [Test]
    public void Validate_discount_invalid_percentage_discount_return_false()
    {
        decimal? price = 10.99m;
        decimal? discount = 100;
        int? discountTypeId = 1;

        bool actualResult = _bookHelper.ValidDiscount(price, discount, discountTypeId);

        Assert.That(actualResult, Is.False);
    }

    [Test]
    public void Validate_discount_valid_monetary_discount_return_true()
    {
        decimal? price = 10.99m;
        decimal? discount = 5;
        int? discountTypeId = 2;

        bool actualResult = _bookHelper.ValidDiscount(price, discount, discountTypeId);

        Assert.That(actualResult, Is.True);
    }

    [Test]
    public void Validate_discount_invalid_monetary_discount_return_false()
    {
        decimal? price = 11.00m;
        decimal? discount = 100;
        int? discountTypeId = 1;

        bool actualResult = _bookHelper.ValidDiscount(price, discount, discountTypeId);

        Assert.That(actualResult, Is.False);
    }
}