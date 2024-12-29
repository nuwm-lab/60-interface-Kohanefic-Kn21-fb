using System;
using System.Text;
//
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

using System;
using System.Text;

class FractionalLinearFunction
{
    protected double a1, a0, b1, b0;

    public virtual void SetCoefficients()
    {
        Console.WriteLine("Введіть коефіцієнти для чисельника (a1, a0):");
        a1 = ReadDouble("a1");
        a0 = ReadDouble("a0");

        Console.WriteLine("Введіть коефіцієнти для знаменника (b1, b0):");
        b1 = ReadDouble("b1");
        b0 = ReadDouble("b0");
    }

    public virtual void DisplayCoefficients()
    {
        Console.WriteLine($"Чисельник: {a1}x + {a0}");
        Console.WriteLine($"Знаменник: {b1}x + {b0}");
    }

    public virtual double Calculate(double x0)
    {
        double numerator = a1 * x0 + a0;
        double denominator = b1 * x0 + b0;
        if (Math.Abs(denominator) < 1e-10)
        {
            throw new DivideByZeroException("Знаменник не може бути рівним нулю.");
        }
        return numerator / denominator;
    }

    protected double ReadDouble(string name)
    {
        while (true)
        {
            Console.WriteLine($"Введіть значення {name}:");
            if (double.TryParse(Console.ReadLine(), out double result))
            {
                return result;
            }
            Console.WriteLine("Некоректне значення, спробуйте ще раз.");
        }
    }
}

class FractionalQuadraticFunction : FractionalLinearFunction
{
    private double a2, b2;

    public override void SetCoefficients()
    {
        Console.WriteLine("Введіть коефіцієнти для чисельника (a2, a1, a0):");
        a2 = ReadDouble("a2");
        a1 = ReadDouble("a1");
        a0 = ReadDouble("a0");

        Console.WriteLine("Введіть коефіцієнти для знаменника (b2, b1, b0):");
        b2 = ReadDouble("b2");
        b1 = ReadDouble("b1");
        b0 = ReadDouble("b0");

    }

    public override void DisplayCoefficients()
    {

        Console.WriteLine($"Чисельник: {a1}x + {a0}");
        Console.WriteLine($"Знаменник: {b1}x + {b0}");

        Console.WriteLine($"Чисельник: {a2}x^2 + {a1}x + {a0}");
        Console.WriteLine($"Знаменник: {b2}x^2 + {b1}x + {b0}");

    }

    public override double Calculate(double x0)
    {

        double numerator = a1 * x0 + a0;
        double denominator = b1 * x0 + b0;
        if (denominator == 0)
        {
            throw new DivideByZeroException("Знаменник не може бути рівним нулю.");

        double numerator = a2 * x0 * x0 + a1 * x0 + a0;
        double denominator = b2 * x0 * x0 + b1 * x0 + b0;
        if (Math.Abs(denominator) < 1e-10)
        {
            throw new DivideByZeroException("Знаменник не може бути рівним нулю.");
        }
        return numerator / denominator;
    }
}

class Program
{

    static void Main(string[] args)
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;
        FractionalLinearFunction baseFunc;

        while (true)
        {
            Console.WriteLine("Введіть '0', щоб працювати з дробово-лінійною функцією, або '1' -- з дробово-квадратичною функцією. Введіть інше значення для виходу:");
            if (!int.TryParse(Console.ReadLine(), out int userSelect))
            {
                Console.WriteLine("Некоректний ввід. Завершення програми.");
                break;
            }

            if (userSelect == 0)
            {
                baseFunc = new FractionalLinearFunction();
            }
            else if (userSelect == 1)
            {
                baseFunc = new FractionalQuadraticFunction();
            }
            else
            {
                Console.WriteLine("Завершення програми.");
                break;
            }

            baseFunc.SetCoefficients();
            baseFunc.DisplayCoefficients();

            Console.WriteLine("Введіть значення x для обчислення функції:");
            if (double.TryParse(Console.ReadLine(), out double x))
            {
                try
                {
                    double result = baseFunc.Calculate(x);
                    Console.WriteLine($"Значення функції в точці x = {x}: {result}");
                }
                catch (DivideByZeroException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Некоректне значення x.");
            }


    // Абстрактний клас
    public abstract class Shape
    {
        // Віртуальний метод для відображення інформації
        public abstract void Display();

        // Абстрактний метод для розрахунку максимального елемента
        public abstract double MaxElement();

        // Конструктор
        public Shape()
        {
            Console.WriteLine("Викликано конструктор абстрактного класу Shape.");
        }

        // Деструктор
        ~Shape()
        {
            Console.WriteLine("Викликано деструктор абстрактного класу Shape.");
        }
    }

    // Клас для векторів, що наслідує абстрактний клас Shape
    public class Vector4D : Shape
    {
        protected double[] vector;

        // Конструктор
        public Vector4D()
        {
            vector = new double[4];
            Console.WriteLine("Викликано конструктор класу Vector4D.");
        }

        // Метод для задання елементів вектора
        public void SetElements(double[] elements)
        {
            if (elements.Length != 4)
            {
                throw new ArgumentException("Вектор повинен містити 4 елементи.");
            }
            for (int i = 0; i < 4; i++)
            {
                vector[i] = elements[i];
            }
        }

        // Перевизначення методу Display
        public override void Display()
        {
            Console.WriteLine("Вектор: [" + string.Join(", ", vector) + "]");
        }

        // Перевизначення методу MaxElement
        public override double MaxElement()
        {
            double max = vector[0];
            for (int i = 1; i < vector.Length; i++)
            {
                if (vector[i] > max)
                {
                    max = vector[i];
                }
            }
            return max;
        }

        // Деструктор
        ~Vector4D()
        {
            Console.WriteLine("Викликано деструктор класу Vector4D.");
        }
    }

    // Клас для матриць, що наслідує абстрактний клас Shape
    public class Matrix2D : Shape
    {
        private double[,] matrix;

        // Конструктор
        public Matrix2D()
        {
            matrix = new double[4, 4];
            Console.WriteLine("Викликано конструктор класу Matrix2D.");
        }

        // Метод для задання елементів матриці
        public void SetElements(double[,] elements)
        {
            if (elements.GetLength(0) != 4 || elements.GetLength(1) != 4)
            {
                throw new ArgumentException("Матриця повинна мати розмір 4x4.");
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    matrix[i, j] = elements[i, j];
                }
            }
        }

        // Перевизначення методу Display
        public override void Display()
        {
            Console.WriteLine("Матриця:");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        // Перевизначення методу MaxElement
        public override double MaxElement()
        {
            double max = matrix[0, 0];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
            }
            return max;
        }

        // Деструктор
        ~Matrix2D()
        {
            Console.WriteLine("Викликано деструктор класу Matrix2D.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Встановлюємо кодування UTF-8
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Створюємо об'єкт Vector4D
            Vector4D vector = new Vector4D();
            vector.SetElements(new double[] { 1.2, 3.4, 5.6, 2.3 });
            vector.Display();
            Console.WriteLine("Максимальний елемент вектора: " + vector.MaxElement());

            // Створюємо об'єкт Matrix2D
            Matrix2D matrix = new Matrix2D();
            matrix.SetElements(new double[,]
            {
                { 1.1, 2.2, 3.3, 4.4 },
                { 5.5, 6.6, 7.7, 8.8 },
                { 9.9, 10.0, 11.1, 12.2 },
                { 13.3, 14.4, 15.5, 16.6 }
            });
            matrix.Display();
            Console.WriteLine("Максимальний елемент матриці: " + matrix.MaxElement());

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