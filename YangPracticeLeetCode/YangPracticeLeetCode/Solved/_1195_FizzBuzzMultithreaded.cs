using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _1195_FizzBuzzMultithreaded
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			//Console.WriteLine(s.SpecialArray(new int[] { 3, 5 }));

		}



		//原來重點是  要跨執行緒鎖   同個instance 傳給四個執行緒  四個執行緒分別呼叫其中一個方法  應該是一直跑  所以會有這個thread沒通過就一直在同個數字打轉  等其他thread 把x++  目前這個thread才可能符合條件通過
		//用lock 速度faster 15%  另一個semaphore才快  semaphore我倒還真沒用過  強
		public class FizzBuzz
		{
			private int n;
			private int i;

			public FizzBuzz(int n)
			{
				this.n = n;
				i = 1;
			}
			
			public static object lockobj = new object();

			// printFizz() outputs "fizz".
			public void Fizz(Action printFizz)
			{
					while (i <= n)
					{
						lock (lockobj)
						{
							if (i > n) return;

							if (i % 3 == 0 && i%5>0)
							{
								printFizz();
								i++;
							}
						}
					}
			}

			// printBuzzz() outputs "buzz".
			public void Buzz(Action printBuzz)
			{
					while (i <= n)
					{
						lock (lockobj)
						{
							if (i > n) return;

							if (i % 5 == 0 && i%3 > 0)
							{
								printBuzz();
								i++;
							}
						}
					}
			}

			// printFizzBuzz() outputs "fizzbuzz".
			public void Fizzbuzz(Action printFizzBuzz)
			{
					while (i <= n)
					{
						lock (lockobj)
						{
							if (i > n) return;

							if (i % 15 == 0)
							{
								printFizzBuzz();
								i++;
							}
						}
					}
			}

			// printNumber(x) outputs "x", where x is an integer.
			public void Number(Action<int> printNumber)
			{
				while (i <= n)
				{
					lock (lockobj)
					{
						if (i > n) return;

						if (i % 3 > 0 && i % 5 > 0)
						{
							printNumber(i);
							i++;
						}
					}
				}
			}
		}



		//semaphore快   贏過100%
	public class FizzBuzz2
	{
		private int n;
		private int x;
		private Semaphore semNum;
		private Semaphore semFizz;
		private Semaphore semBuzz;
		private Semaphore semFizzBuzz;

		public FizzBuzz2(int n)
		{
			this.n = n;
			this.x = 1;
			semNum = new Semaphore(1, 1);
			semFizz = new Semaphore(0, 1);
			semBuzz = new Semaphore(0, 1);
			semFizzBuzz = new Semaphore(0, 1);
		}


		//	大意: WaitOne 是 封鎖目前的執行緒，直到目前的 WaitHandle 收到訊號為止。
		//	如果要繼續往下  Sem的值要 > 0 
		//	所以這邊很巧妙  流程是  一開始只有num允許往下跑  其他三個方法(緒)封住 num印出之後 x++  再丟進Release  就會解除另一個方法(緒)   原本的再執行就封住了
		//	所以就達到精準依序循環的效果   難怪比lockObj快

		// printFizz() outputs "fizz".
		public void Fizz(Action printFizz)
		{
			while (x <= n)
			{
				semFizz.WaitOne();

				if (x > n)
					return;

				if (x % 3 == 0)
				{
					printFizz();
					x++;
				}
				ReleaseSemaphore(x);
			}
		}

		// printBuzzz() outputs "buzz".
		public void Buzz(Action printBuzz)
		{
			while (x <= n)
			{
				semBuzz.WaitOne();

				if (x > n)
					return;

				if (x % 5 == 0)
				{
					printBuzz();
					x++;
				}
				ReleaseSemaphore(x);
			}
		}

		// printFizzBuzz() outputs "fizzbuzz".
		public void Fizzbuzz(Action printFizzBuzz)
		{
			while (x <= n)
			{
				semFizzBuzz.WaitOne();

				if (x > n)
					return;

				if (x % 15 == 0)
				{
					printFizzBuzz();
					x++;
				}

				ReleaseSemaphore(x);
			}
		}

		// printNumber(x) outputs "x", where x is an integer.
		public void Number(Action<int> printNumber)
		{
			while (x <= n)
			{
				semNum.WaitOne();

				if (x > n)
					return;

				if (x % 3 != 0 && x % 5 != 0)
				{
					printNumber(x);
					x++;
				}

				ReleaseSemaphore(x);
			}
		}

		private void ReleaseSemaphore(int i)
		{
			if (i > n)
			{
				semNum.Release();
				semFizz.Release();
				semBuzz.Release();
				semFizzBuzz.Release();
				return;
			}

			if (i % 15 == 0)
			{
				semFizzBuzz.Release();
			}
			else if (i % 3 == 0)
			{
				semFizz.Release();
			}
			else if (i % 5 == 0)
			{
				semBuzz.Release();
			}
			else
			{
				semNum.Release();
			}
		}
	}

}
}
