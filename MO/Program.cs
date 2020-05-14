using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MO3
{
    class Program
    {
        #region Условия
        //Чтобы использовать следующиq метод функция должна быть унимодальной*
        //*Унимодальной на отрезке [a, b] называется функция, которая:
        // 1) Определена во всех точках отрезка [a, b]
        // 2) Существует точка X* из [a, b], в которой функция достигает глобального минимума на [a, b]
        // 3) Слева от точки X* функция не возрастает, а справа не убывает
        #endregion
        #region Деление отрезка пополам
        //Решение задачи минимизации.На вход - сама функция, отрезок, на котором минимизируем и допустимая погрешность
        public static double FindPointOfMin(Func<double, double> f, double a, double b, double Eps)
        {
            double L = Math.Abs(b - a); //Длина отрезка
            double Xc; //Результирующая переменная
            double y, z; //Точки, в которых будут вестись вычисления
            double fx, fy, fz; //Значения функции в точках вычисления
            int k = 0; //Количество шагов
            do
            {
                Xc = (a + b) / 2;
                L = b - a;
                fx = f(Xc);
                y = a + L / 4;
                z = b - L / 4;
                fy = f(y);
                fz = f(z);
                if (fy < fx)
                {
                    //a = a;
                    b = Xc;
                    Xc = y;
                }
                else
                {
                    if (fz < fx)
                    {
                        a = Xc;
                        //b = b;
                        Xc = z;
                    }
                    else
                    {
                        a = y;
                        b = z;
                        //Xc = Xc;
                    }
                }
                k++;
                L = Math.Abs(b - a);
            }
            while (L > Eps);
            Console.WriteLine($"Количество итераций цикла: {k}");
            Xc = (a + b) / 2;
            return Xc;
        }
        #endregion


        static void Main(string[] args)
        {
            double f(double x) => (2 * x * x) - (12 * x); //Функция, которую будем минимизировать
            double A, B, Eps;
            A = 0;
            B = 10;
            Eps = 0.1;

            Console.WriteLine($"Метод деления отрезка пополам, Eps = {Eps} ");
            double X = FindPointOfMin(f, A, B, Eps);
            double Y = f(X);
            Console.WriteLine($"x* = {X}");
            Console.WriteLine($"f(x*) = {Y}");

           
            Console.ReadKey();
        }
    }
}
