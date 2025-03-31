using System;
using System.Collections.Generic;
using System.Threading;

abstract class Activity
{
    protected string Name;
    protected string Description;
    
    public Activity(string name, string description)
    {
        Name = name;
        Description = description;
    }
    
    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"{Name} Activity");
        Console.WriteLine(Description);
        Console.Write("Enter duration in seconds: ");
        int duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
        Run(duration);
        Console.WriteLine("Good job! Activity completed.");
        ShowSpinner(3);
    }
    
    protected abstract void Run(int duration);
    
    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by guiding you through slow breathing.") { }
    
    protected override void Run(int duration)
    {
        for (int i = 0; i < duration; i += 6)
        {
            Console.WriteLine("Breathe in...");
            ShowSpinner(3);
            Console.WriteLine("Breathe out...");
            ShowSpinner(3);
        }
    }
}

class ReflectionActivity : Activity
{
    private static readonly List<string> Prompts = new()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    
    private static readonly List<string> Questions = new()
    {
        "Why was this experience meaningful to you?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What did you learn about yourself?"
    };
    
    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times of strength and resilience.") { }
    
    protected override void Run(int duration)
    {
        Random rand = new();
        Console.WriteLine(Prompts[rand.Next(Prompts.Count)]);
        ShowSpinner(3);
        int timeSpent = 0;
        while (timeSpent < duration)
        {
            Console.WriteLine(Questions[rand.Next(Questions.Count)]);
            ShowSpinner(3);
            timeSpent += 3;
        }
    }
}

class ListingActivity : Activity
{
    private static readonly List<string> Prompts = new()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are some of your personal heroes?"
    };
    
    public ListingActivity() : base("Listing", "This activity will help you reflect on positive aspects of your life.") { }
    
    protected override void Run(int duration)
    {
        Random rand = new();
        Console.WriteLine(Prompts[rand.Next(Prompts.Count)]);
        ShowSpinner(3);
        List<string> responses = new();
        Console.WriteLine("Start listing items:");
        int timeSpent = 0;
        while (timeSpent < duration)
        {
            responses.Add(Console.ReadLine());
            timeSpent += 3;
        }
        Console.WriteLine($"You listed {responses.Count} items!");
    }
}

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing");
            Console.WriteLine("2. Reflection");
            Console.WriteLine("3. Listing");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");
            
            string choice = Console.ReadLine();
            Activity activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectionActivity(),
                "3" => new ListingActivity(),
                "4" => null,
                _ => null
            };
            
            if (activity == null) break;
            activity.Start();
        }
    }
}