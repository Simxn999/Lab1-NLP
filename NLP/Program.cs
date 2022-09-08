using System.Text;
using NLPBot;

Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;

Console.WriteLine("Ask something!\n");
while (Console.ReadLine()?.Trim() is string input)
{
    if (input.Length == 0)
    {
        Console.WriteLine("Try again!");
        continue;
    }

    if (input.ToLower().Equals("q")) break;

    Console.WriteLine($"> {await Bot.Ask(input)}\n");
}