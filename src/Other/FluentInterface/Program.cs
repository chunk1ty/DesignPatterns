// See https://aka.ms/new-console-template for more information

using FluentInterface;

Enumerable.Range(0, 11)
    .Where(x => x % 2 == 0)
    .Select(x => x * x).ToList()
    .ForEach(Console.WriteLine);

Console.WriteLine(new string('-', 60));

var customer = new Customer();
customer.FirstName("Andriyan")
        .LastName("Krastev")
        .Gender("Male")
        .Address("Sofia")
        .PrintToConsole();