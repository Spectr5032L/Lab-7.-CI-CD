using System;

namespace ConsoleApp1
{



	public class MyMathFunction
	{
		public double Sin(double x, int n)
		{
			x = NormalizeAngle(x);

			double result = 0;
			for (int i = 0; i < n; i++)
			{
				result += Math.Pow(-1, i) * Math.Pow(x, 2 * i + 1) / Factorial(2 * i + 1);
			}

			result = Math.Round(result, 5);
			return result;
		}

		public double Cos(double x, int n)
		{
			if (x < 0) x = x * (-1);
			x = NormalizeAngle(x);

			double result = 0;
			for (int i = 0; i < n; i++)
			{
				result += Math.Pow(-1, i) * Math.Pow(x, 2 * i) / Factorial(2 * i);
			}

			result = Math.Round(result, 5);
			return result;
		}

		public double Ln(double x, int n)
		{
			if (x <= 0)
			{
				Console.WriteLine("Не определен");
				return -1;
			}

			if (x == 1)
			{
				return 0;
			}

			double result = 0;
			for (int i = 1; i <= n; i++)
			{
				result += Math.Pow(-1, i + 1) * Math.Pow(x - 1, i) / i;
			}

			result = Math.Round(result, 5);
			return result;
		}

		public double Factorial(int n)
		{
			if (n == 0)
			{
			}
			double result = 1;
			for (int i = 2; i <= n; i++)
			{
				result *= i;
			}
			return result;
		}

		public double Function(double x)
		{
			if (x >= 0)
			{
				return Ln(x, 300) * Cos(x, 300);
			}
			else
			{
				return Math.Abs(Sin(x, 300) - Cos(x, 300)) / (Ln(Math.Abs(x), 300) + 1);
			}
		}

		private static double NormalizeAngle(double angle) // Преобразование радиан чтобы не больше 2п
		{
			double twoPi = 2 * Math.PI;
			return angle % twoPi;
		}
	}
}

//using System;

//namespace ConsoleApp1
//{

//	internal class Program
//	{
//		static void Main(string[] args)
//		{
//			double x = 534567890;
//			//Console.WriteLine(Math.Round(MyMathFunction.Sin(x, 20), 5));
//			Console.WriteLine(MyMathFunction.Function(x));
//		}

//	}

//	public static class MyMathFunction
//	{
//		public static double Sin(double x, int n)
//		{

//			x = NormalizeAngle(x);

//			double result = 0;
//			for (int i = 0; i < n; i++)
//			{
//				result += Math.Pow(-1, i) * Math.Pow(x, 2 * i + 1) / Factorial(2 * i + 1);
//			}
//			return result;
//		}

//		public static double Cos(double x, int n)
//		{
//			if (x < 0) x = x * (-1);
//			x = NormalizeAngle(x);

//			double result = 0;
//			for (int i = 0; i < n; i++)
//			{
//				result += Math.Pow(-1, i) * Math.Pow(x, 2 * i) / Factorial(2 * i);
//			}
//			return result;
//		}

//		public static double Ln(double x, int n)
//		{
//			// Проверка на входные данные
//			if (x <= 0)
//			{
//				throw new ArgumentException("Аргумент должен быть положительным");
//			}

//			// Вычисление натурального логарифма с использованием ряда Тейлора
//			double result = 0;
//			for (int i = 1; i <= n; i++)
//			{
//				double term = Math.Pow(-1, i + 1) * Math.Pow(x - 1, i) / i;
//				result += term;
//			}
//			return result;
//		}

//		public static double Factorial(int n)
//		{
//			if (n == 0)
//			{
//			}
//			double result = 1;
//			for (int i = 2; i <= n; i++)
//			{
//				result *= i;
//			}
//			return result;
//		}

//		public static double Function(double x)
//		{
//			if (x >= 0)
//			{
//				//double ans = Ln(x, 200);
//				//double ans = Cos(x, 20);
//				//Console.WriteLine(Math.Round(ans, 5));
//				//return ans;
//				return Ln(x, 300) * Cos(x, 300);
//			}
//			else
//			{
//				return Math.Abs(Sin(x, 300) - Cos(x, 300)) / (Ln(Math.Abs(x), 300) + 1);
//			}
//		}

//		private static double NormalizeAngle(double angle) // Преобразование радиан чтобы не больше 2п
//		{
//			double twoPi = 2 * Math.PI;
//			return angle % twoPi;
//		}
//	}
//}












//С использованием ряда Тейлора

//			public static double Ln(double x, int n)
//{
//	if (x <= 0)
//	{
//		Console.WriteLine("Не определен");
//		return -1;
//	}

//	if (x == 1)
//	{
//		return 0;
//	}

//	double result = 0;
//	for (int i = 1; i <= n; i++)
//	{
//		result += Math.Pow(-1, i + 1) * Math.Pow(x - 1, i) / i;
//	}

//	//double result = (x - 1) / 1;
//	//result = result - Math.Pow(x - 1, 2) / 2;
//	//for (int i = 4; i <= n; i += 2)
//	//{
//	//	//result += Math.Pow(x - 1, i - 1) / (i - 1);
//	//	//result -= Math.Pow(x - 1, (i)) / (i);
//	//}

//	return result;
//}

//С использованием ряда Лейбницы
//			public static double Ln(double x)
//{
//	if (x <= 0)
//	{
//		Console.WriteLine("Не определен");
//		return double.NaN;
//	}

//	if (x == 1)
//	{
//		return 0;
//	}

//	double result = 0;
//	double term = (x - 1) / (x + 1);
//	double termSquared = term * term;
//	double currentTerm = term;
//	double denominator = 1;

//	for (int i = 1; i < 1000; i += 2) // Выбираем достаточное количество итераций
//	{
//		result += currentTerm / i;
//		currentTerm *= termSquared;
//		denominator += 2;
//	}

//	return 2 * result;
//}