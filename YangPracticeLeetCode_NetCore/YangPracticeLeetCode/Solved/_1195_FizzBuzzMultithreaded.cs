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



		//��ӭ��I�O  �n��������   �P��instance �ǵ��|�Ӱ����  �|�Ӱ�������O�I�s�䤤�@�Ӥ�k  ���ӬO�@���]  �ҥH�|���o��thread�S�q�L�N�@���b�P�ӼƦr����  ����Lthread ��x++  �ثe�o��thread�~�i��ŦX����q�L
		//��lock �t��faster 15%  �t�@��semaphore�~��  semaphore�ڭ��ٯu�S�ιL  �j
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



		//semaphore��   Ĺ�L100%
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


		//	�j�N: WaitOne �O ����ثe��������A����ثe�� WaitHandle ����T������C
		//	�p�G�n�~�򩹤U  Sem���ȭn > 0 
		//	�ҥH�o��ܥ���  �y�{�O  �@�}�l�u��num���\���U�]  ��L�T�Ӥ�k(��)�ʦ� num�L�X���� x++  �A��iRelease  �N�|�Ѱ��t�@�Ӥ�k(��)   �쥻���A����N�ʦ�F
		//	�ҥH�N�F���Ķ̌Ǵ`�����ĪG   ���Ǥ�lockObj��

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
