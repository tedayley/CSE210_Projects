using System;
using System.Collections.Generic;

class Word
{
    public string Text { get; set; }
    public bool Hidden { get; set; }

    public Word(string word)
    {
        Text = word;
        Hidden = false;
    }

    public void Hide()
    {
        Hidden = true;
    }

    public override string ToString()
    {
        return Hidden ? new string('_', Text.Length) : Text;
    }
}

class Reference
{
    public string Book { get; set; }
    public string StartVerse { get; set; }
    public string EndVerse { get; set; }

    public Reference(string reference)
    {
        string[] parts = reference.Split(' ');
        Book = parts[0];
        if (parts[1].Contains("-"))
        {
            string[] verses = parts[1].Split('-');
            StartVerse = verses[0];
            EndVerse = verses[1];
        }
        else
        {
            StartVerse = parts[1];
            EndVerse = StartVerse;
        }
    }

    public override string ToString()
    {
        return StartVerse == EndVerse ? $"{Book} {StartVerse}" : $"{Book} {StartVerse}-{EndVerse}";
    }
}

class Scripture
{
    public Reference Ref { get; set; }
    public List<Word> Words { get; set; }

    public Scripture(string reference, string text)
    {
        Ref = new Reference(reference);
        Words = new List<Word>();
        foreach (var word in text.Split())
        {
            Words.Add(new Word(word));
        }
    }

    public string GetDisplayText()
    {
        string result = Ref.ToString() + "\n";
        foreach (var word in Words)
        {
            result += word.ToString() + " ";
        }
        return result.TrimEnd();
    }

    public void HideRandomWord()
    {
        var random = new Random();
        var visibleWords = new List<Word>();
        foreach (var word in Words)
        {
            if (!word.Hidden)
            {
                visibleWords.Add(word);
            }
        }
        if (visibleWords.Count > 0)
        {
            var randomWord = visibleWords[random.Next(visibleWords.Count)];
            randomWord.Hide();
        }
    }
}

class Program
{
    static void ClearScreen()
    {
        Console.Clear();
    }

    static void Main(string[] args)
    {
        string scriptureText = "For God so loved the world that he gave his only begotten Son, " +
                               "that whosoever believeth in him should not perish, but have everlasting life.";

        Scripture scripture = new Scripture("John 3:16", scriptureText);

        while (true)
        {
            ClearScreen();
            Console.WriteLine(scripture.GetDisplayText());

            Console.Write("\nPress Enter to hide a word, or type 'quit' to exit: ");
            string userInput = Console.ReadLine()?.Trim().ToLower();

            if (userInput == "quit")
            {
                break;
            }

            scripture.HideRandomWord();

            // Check if all words are hidden
            if (scripture.Words.TrueForAll(w => w.Hidden))
            {
                ClearScreen();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are now hidden!");
                break;
            }
        }
    }
}
