using System;

public class Fraction
{
    public int Numerator { get; private set; }
    public int Denominator { get; private set; }

    // Constructor
    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }

        // Simplify the fraction using gcd
        int commonDivisor = GCD(numerator, denominator);
        Numerator = numerator / commonDivisor;
        Denominator = denominator / commonDivisor;

        // Ensure the denominator is positive for consistent representation
        if (Denominator < 0)
        {
            Numerator = -Numerator;
            Denominator = -Denominator;
        }
    }

    // ToString equivalent to Python's __str__
    public override string ToString()
    {
        return $"{Numerator}/{Denominator}";
    }

    // Convert to decimal
    public double ToDecimal()
    {
        return (double)Numerator / Denominator;
    }

    // Add two fractions
    public Fraction Add(Fraction other)
    {
        if (other == null)
        {
            throw new ArgumentException("Can only add another Fraction.");
        }
        int newNumerator = Numerator * other.Denominator + other.Numerator * Denominator;
        int newDenominator = Denominator * other.Denominator;
        return new Fraction(newNumerator, newDenominator);
    }

    // Subtract two fractions
    public Fraction Subtract(Fraction other)
    {
        if (other == null)
        {
            throw new ArgumentException("Can only subtract another Fraction.");
        }
        int newNumerator = Numerator * other.Denominator - other.Numerator * Denominator;
        int newDenominator = Denominator * other.Denominator;
        return new Fraction(newNumerator, newDenominator);
    }

    // Multiply two fractions
    public Fraction Multiply(Fraction other)
    {
        if (other == null)
        {
            throw new ArgumentException("Can only multiply by another Fraction.");
        }
        int newNumerator = Numerator * other.Numerator;
        int newDenominator = Denominator * other.Denominator;
        return new Fraction(newNumerator, newDenominator);
    }

    // Divide two fractions
    public Fraction Divide(Fraction other)
    {
        if (other == null)
        {
            throw new ArgumentException("Can only divide by another Fraction.");
        }
        return new Fraction(Numerator * other.Denominator, Denominator * other.Numerator);
    }

    // Greatest Common Divisor
    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}

public class Program
{
    public static void Main()
    {
        // Example usage
        Fraction f1 = new Fraction(2, 3);
        Fraction f2 = new Fraction(3, 4);
        Console.WriteLine(f1);  // Output: 2/3
        Console.WriteLine(f1.ToDecimal());  // Output: 0.6666...
        Console.WriteLine(f1.Add(f2));  // Output: 17/12
        Console.WriteLine(f1.Multiply(f2));  // Output: 6/12 or 1/2 after reduction
    }
}
