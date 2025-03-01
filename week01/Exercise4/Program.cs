using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        while (true)
        {
            Console.WriteLine("Enter a list of numbers, type 0 when finished.");
            
            while (true)
            {
                Console.Write("Enter number: ");
                if (!int.TryParse(Console.ReadLine(), out int number))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }
                
                if (number == 0) break;
                numbers.Add(number);
            }
            
            if (numbers.Count == 0)
            {
                Console.WriteLine("No numbers entered.");
            }
            else
            {
                int sum = numbers.Sum();
                double average = numbers.Average();
                int max = numbers.Max();
                int? smallestPositive = numbers.Where(n => n > 0).DefaultIfEmpty().Min();
                int? smallestNegative = numbers.Where(n => n < 0).DefaultIfEmpty().Max();
                
                numbers.Sort();
                
                Console.WriteLine($"The sum is: {sum}");
                Console.WriteLine($"The average is: {average}");
                Console.WriteLine($"The largest number is: {max}");
                
                if (smallestPositive.HasValue)
                {
                    Console.WriteLine($"The smallest positive number is: {smallestPositive.Value}");
                }
                if (smallestNegative.HasValue)
                {
                    Console.WriteLine($"The smallest negative number is: {smallestNegative.Value}");
                }
                
                Console.WriteLine("Sorted list:");
                Console.WriteLine(string.Join(", ", numbers));
            }
            
            Console.Write("Would you like to enter another list? (yes/no): ");
            string response = Console.ReadLine().Trim().ToLower();
            if (response != "yes") break;
        }
    }
}
