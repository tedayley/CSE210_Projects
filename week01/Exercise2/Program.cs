using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Write("Enter your grade percentage (or type 'exit' to quit): ");
            string input = Console.ReadLine();
            
            if (input.ToLower() == "exit")
                break;
            
            if (!float.TryParse(input, out float percentage))
            {
                Console.WriteLine("Invalid input. Please enter a numeric grade.");
                continue;
            }
            
            string letter;
            string sign = "";
            
            // Determine letter grade
            if (percentage >= 90)
            {
                letter = "A";
            }
            else if (percentage >= 80)
            {
                letter = "B";
            }
            else if (percentage >= 70)
            {
                letter = "C";
            }
            else if (percentage >= 60)
            {
                letter = "D";
            }
            else
            {
                letter = "F";
            }
            
            // Determine the sign (+ or -)
            int lastDigit = (int)percentage % 10;
            
            if (letter != "A" && letter != "F")
            {
                if (lastDigit >= 7)
                {
                    sign = "+";
                }
                else if (lastDigit < 3)
                {
                    sign = "-";
                }
            }
            else if (letter == "A" && lastDigit < 3)
            {
                sign = "-"; // A- exists but not A+
            }
            // F has no sign, so we leave it as is
            
            Console.WriteLine($"Your letter grade is: {letter}{sign}");
            
            // Determine if the student passed
            if (percentage >= 70)
            {
                Console.WriteLine("Congratulations! You passed the class.");
            }
            else
            {
                Console.WriteLine("Keep working hard! You'll do better next time.");
            }
        }
    }
}