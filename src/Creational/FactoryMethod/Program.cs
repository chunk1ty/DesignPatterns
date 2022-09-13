using FactoryMethod;

var discountFactories = new List<DiscountFactory>
{
    new CountryDiscountFactory("BG"),
    new CountryDiscountFactory("US"),
    new CountryDiscountFactory("ITL"),
    new CodeDiscountFactory()
};

foreach (var discountFactory in discountFactories)
{
    var discount = discountFactory.CreateDiscountService();
    Console.WriteLine($"Percentage {discount.Discount()} coming from {discount}");
}