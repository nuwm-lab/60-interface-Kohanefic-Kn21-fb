using System;

namespace LabWork
{
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
    }
}