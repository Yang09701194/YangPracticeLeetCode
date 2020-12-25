using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _371_SumofTwoIntegers
	{
		
		public static void Test()
		{
			Solution_Log s = new Solution_Log();

			//Console.WriteLine(s.NumPoints());

			//Console.WriteLine(s.GetSum(15, 2));
			Console.WriteLine(s.GetSum(15, -2));
			//Console.WriteLine(s.GetSum(2147483647, -2147483647));

		}


		/// <summary>
		/// 解 2 ok
		/// 這邊有加筆記了  也可以直接看sol
		/// https://leetcode.com/problems/sum-of-two-integers/solution/
		/// 解釋字多  看原文
		/// </summary>
		class Solution
		{
			public int GetSum(int a, int b)
			{
				while (b != 0)
				{
					int answer = a ^ b;
					int carry = (a & b) << 1;
					a = answer;
					b = carry;
				}

				return a;
			}
		}

		class Solution_Log
		{

			public int GetSum(int a, int b)
			{
				while (b != 0)
				{
					Console.WriteLine($"a {Convert.ToString(a,2).PadLeft5_0()}");
					Console.WriteLine($"b {Convert.ToString(b,2).PadLeft5_0()}");
					int answer = a ^ b;
					Console.WriteLine($"answer (a^b)   {Convert.ToString(answer, 2).PadLeft5_0()}" );
					int carry = (a & b) << 1;
					Console.WriteLine($"carry (a&b)<<1 {Convert.ToString(carry, 2).PadLeft5_0()}");

					a = answer;
					b = carry;
				}

				return a;
			}

		

		}




		/// <summary>
		/// 解1 在 java 沒問題  C# submit 有問題  本機卻沒問題   可能是網站問題  已提問
		/// 
		/// </summary>
		class Solution_V1
		{
			public int GetSum(int a, int b)
			{
				int x = Math.Abs(a), y = Math.Abs(b);
				// ensure that.Abs(a) >=.Abs(b)
				if (x < y) return GetSum(b, a);

				//.Abs(a) >=.Abs(b) --> 
				// a dete.Mines the sign
				int sign = a > 0 ? 1 : -1;

				if (a * b >= 0)
				{
					// sum of two positive integers x + y
					// where x > y
					while (y != 0)
					{
						int answer = x ^ y;
						int carry = (x & y) << 1;
						x = answer;
						y = carry;
					}
				}
				else
				{
					// difference of two positive integers x - y
					// where x > y
					while (y != 0)
					{
						int answer = x ^ y;
						int borrow = ((~x) & y) << 1;
						x = answer;
						y = borrow;
					}
				}
				return x * sign;
			}
		}




	}
}
