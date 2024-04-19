using ConsoleApp1;


namespace Tests
{
	public class Tests
	{		
		private MyMathFunction obj;
		[SetUp]
		public void Setup()
		{
			obj = new MyMathFunction();
		}


		[TestCase(-1, 20, -1)]
		//[TestCase(0.3, 20, -1.2038899999999999)]
		[TestCase(0.3, 20, -1.20388)]
		[TestCase(1, 20, 0)]
		[TestCase(1.2, 20, 0.18232)]
		[TestCase(1.4, 20, 0.33647)]
		[TestCase(1.7, 20, 0.53061)]
		public void Ln(double x, int n, double res)
		{
			Assert.AreEqual(res, obj.Ln(x, n), 0.00001);
		}


		[TestCase(-1, 20, 0.54030)]
		[TestCase(0.4, 20, 0.92106)]
		[TestCase(0.9, 20, 0.62161)]
		[TestCase(1.6, 20, -0.02920)]
		[TestCase(2, 20, -0.41615)]
		public void Cos(double x, int n, double res)
		{
			Assert.AreEqual(res, obj.Cos(x, n));
		}

		[TestCase(-1, 20, -0.84147)]
		[TestCase(0.4, 20, 0.38942)]
		[TestCase(0.9, 20, 0.78333)]
		[TestCase(1.6, 20, 0.99957)]
		[TestCase(2, 20, 0.90930)]
		public void Sin(double x, int n, double res)
		{
			Assert.AreEqual(res, obj.Sin(x, n));
		}


		[TestCase(0.2, -1.57)]
		[TestCase(0.5, -0.6)]
		[TestCase(1, 0)]
		[TestCase(1.2, 0.06)]
		[TestCase(1.7, -0.06)]
		[TestCase(-0.2, -1.93)] // -1.93414
		[TestCase(-0.5, 4.42)] // 4.42234
		[TestCase(-1, 1.38)] // 1.38177
		[TestCase(-1.2, 1.09)] // 1.09479
		[TestCase(-1.7, 0.56)] // 0.563703
		public void Function(double x, double expected)
		{
			double result = obj.Function(x);
			Assert.AreEqual(expected, result, 0.01); // “ест на близость вещественных чисел
		}
	}
}