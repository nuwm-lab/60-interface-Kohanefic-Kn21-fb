using System;
using System.Text;

abstract class FractionalFunction
{
    public FractionalFunction()
    {
        Console.WriteLine("Створено об'єкт класу FractionalFunction.");
    }

    public abstract void SetCoefficients(params double[] coefficients);
    public abstract void DisplayCoefficients();
    public abstract double Calculate(double x0);

    ~FractionalFunction()
    {
        Console.WriteLine("Видалено об'єкт класу FractionalFunction.");
    }
}

class FractionalLinearFunction : FractionalFunction
{
    protected double a1, a0, b1, b0;

    public FractionalLinearFunction()
    {
        Console.WriteLine("Створено об'єкт класу FractionalLinearFunction.");
    }

    public override void SetCoefficients(params double[] coefficients)
    {
        a1 = coefficients[0];
        a0 = coefficients[1];
        b1 = coefficients[2];
        b0 = coefficients[3];
    }

    public override void DisplayCoefficients()
    {
        Console.WriteLine($"Чисельник: {a1}x + {a0}");
        Console.WriteLine($"Знаменник: {b1}x + {b0}");
    }

    public override double Calculate(double x0)
    {
        double numerator = a1 * x0 + a0;
        double denominator = b1 * x0 + b0;
        if (denominator == 0)
        {
            throw new DivideByZeroException("Знаменник не може бути рівним нулю.");
        }
        return numerator / denominator;
    }

    ~FractionalLinearFunction()
    {
        Console.WriteLine("Видалено об'єкт класу FractionalLinearFunction.");
    }
}

class FractionalQuadraticFunction : FractionalFunction
{
    private double a2, a1, a0, b2, b1, b0;

    public FractionalQuadraticFunction()
    {
        Console.WriteLine("Створено об'єкт класу FractionalQuadraticFunction.");
    }

    public override void SetCoefficients(params double[] coefficients)
    {
        a2 = coefficients[0];
        a1 = coefficients[1];
        a0 = coefficients[2];
        b2 = coefficients[3];
        b1 = coefficients[4];
        b0 = coefficients[5];
    }

    public override void DisplayCoefficients()
    {
        Console.WriteLine($"Чисельник: {a2}x^2 + {a1}x + {a0}");
        Console.WriteLine($"Знаменник: {b2}x^2 + {b1}x + {b0}");
    }

    public override double Calculate(double x0)
    {
        double numerator = a2 * x0 * x0 + a1 * x0 + a0;
        double denominator = b2 * x0 * x0 + b1 * x0 + b0;
        if (denominator == 0)
        {
            throw new DivideByZeroException("Знаменник не може бути рівним нулю.");
        }
        return numerator / denominator;
    }

    ~FractionalQuadraticFunction()
    {
        Console.WriteLine("Видалено об'єкт класу FractionalQuadraticFunction.");
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;

        FractionalFunction linearFunc = new FractionalLinearFunction();
        linearFunc.SetCoefficients(2, 3, 1, 4);
        linearFunc.DisplayCoefficients();
        double resultLinear = linearFunc.Calculate(4);
        Console.WriteLine($"Значення дробово-лінійної функції в точці x = 4: {resultLinear}");

        FractionalFunction quadraticFunc = new FractionalQuadraticFunction();
        quadraticFunc.SetCoefficients(4, 2, 3, 1, 1, 4);
        quadraticFunc.DisplayCoefficients();
        double resultQuadratic = quadraticFunc.Calculate(4);
        Console.WriteLine($"Значення дробової квадратичної функції в точці x = 4: {resultQuadratic}");

    }
}