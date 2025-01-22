using System;

namespace Puffer_Zone.WKFServices;

public class WKTInputHandler 
{
    
    public static double ReadUserInput(string prompt)
    {
        Console.WriteLine(prompt);
        string input = Console.ReadLine();
        double result;
        while (string.IsNullOrEmpty(input) || !double.TryParse(input, out result))
        {
            Console.WriteLine("Wrong input! Try again!");
            input = Console.ReadLine();
        }
        return result;
    }

    public static double ReadRadius()
    {
        double radius = ReadUserInput("Please enter radius: ");
        while (radius <= 0)
        {
            Console.WriteLine("Radius must be a positive number!");
            radius = ReadUserInput("Please enter radius: ");
        }

        return radius;
    }
}