using System;

class Program
{
    static void Main()
    {
        Random random = new Random();
        
        while (true)
        {
            int magicNumber = random.Next(1, 101);
            int guessCount = 0;
            
            Console.WriteLine("I've chosen a magic number between 1 and 100. Try to guess it!");
            
            while (true)
            {
                Console.Write("What is your guess? ");
                
                if (!int.TryParse(Console.ReadLine(), out int guess))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }
                
                guessCount++;
                
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it in {guessCount} attempts!");
                    break;
                }
            }
            
            Console.Write("Do you want to play again? (yes/no): ");
            string playAgain = Console.ReadLine().ToLower();
            
            if (playAgain != "yes")
            {
                Console.WriteLine("Thanks for playing!");
                break;
            }
        }
    }
}
