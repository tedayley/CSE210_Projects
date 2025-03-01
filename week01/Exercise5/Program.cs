using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        DisplayWelcome();
        string userName = PromptUserName();
        ConsoleColor favoriteColor = PromptUserColor();
        Console.ForegroundColor = favoriteColor;
        int favoriteNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(favoriteNumber);
        DisplayResult(userName, squaredNumber, favoriteColor);
        Console.ResetColor();
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Enter your name: ");
        return Console.ReadLine();
    }

    static ConsoleColor PromptUserColor()
    {
        Console.Write("Enter your favorite color (Red, Green, Blue, Yellow, Cyan, Magenta, White): ");
        while (true)
        {
            string colorInput = Console.ReadLine();
            if (Enum.TryParse(colorInput, true, out ConsoleColor color))
            {
                return color;
            }
            Console.Write("Invalid color. Please enter a valid color: ");
        }
    }

    static int PromptUserNumber()
    {
        Console.Write("Enter your favorite number: ");
        int number;  // Declare number outside the loop
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.Write("Invalid input. Please enter a valid integer: ");
        }
        return number;
    }


    static int SquareNumber(int number)
    {
        return number * number;
    }

    static void DisplayResult(string name, int squaredNumber, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine($"{name}, the square of your favorite number is {squaredNumber}.");
        Console.ResetColor();
    }
}
