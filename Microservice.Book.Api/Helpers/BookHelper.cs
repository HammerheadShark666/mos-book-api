using Microservice.Book.Api.Helpers.Interfaces;

namespace Microservice.Book.Api.Helpers;

public class BookHelper : IBookHelper
{
    public bool ValidISBN13(string code)
    {
        code = code.Replace("-", "").Replace(" ", "");
        if (code.Length != 13) return false;
        int sum = 0;
        foreach (var (index, digit) in code.Select((digit, index) => (index, digit)))
        {
            if (char.IsDigit(digit)) sum += (digit - '0') * (index % 2 == 0 ? 1 : 3);
            else return false;
        }
        return sum % 10 == 0;
    }

    public bool ValidDiscount(decimal? price, decimal? discount, int? discountTypeId)
    {
        if (discountTypeId == null || price == null || discount == null)
            return true;

        switch (discountTypeId)
        {
            case 1:

                var percentageDiscountValue = (price / 100) * discount;
                if ((price - percentageDiscountValue) <= 0)
                    return false;

                break;
            case 2:

                if (price - discount < 1)
                    return false;

                break;
        }

        return true;
    }
}