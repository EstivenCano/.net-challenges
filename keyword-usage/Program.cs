// See https://aka.ms/new-console-template for more information

// Exercise 01

Console.WriteLine("Exercise 01:");

User newUser = new User("Estiven", 25, "test@email.com");

newUser.logUser();

/* --------------------------------------------------------- */

// Exercise 02
Console.WriteLine("\nExercise 02:");

Math math = new Math();

string result = math.sum([8, 8, 8, 8]);

Console.WriteLine(result);

/* --------------------------------------------------------- */

// Exercise 03

Console.WriteLine("\nExercise 03:");

CurrencyConverter converter = new CurrencyConverter();
var phrase = converter.CurrencyToWord(40000, string.Empty);

Console.WriteLine(phrase);
/* --------------------------------------------------------- */


