using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _984_StringWithoutAAAorBBB
	{

		public static void Test()
		{
			Solution s = new Solution();

			Console.WriteLine(s.StrWithout3a3b(20, 42));
			Console.WriteLine(s.StrWithout3a3b(1, 2));
			Console.WriteLine(s.StrWithout3a3b(4, 1));
			Console.WriteLine(s.StrWithout3a3b(1, 1));
			Console.WriteLine(s.StrWithout3a3b(4, 4));
			Console.WriteLine(s.StrWithout3a3b(4, 6));

			string s1 = s.StrWithout3a3b(46, 79);
			Console.WriteLine(s1);
			Console.WriteLine(s1.Length);
			Console.WriteLine(46+79);
		
		}
	}


	/// <summary>
	/// 差距是2的倍數
	/// n  2n+2              NNnNNnNN
	/// 2n+2 - n = n+2
	/// 差距是奇數
	/// 把某個字母掉到前頭 後面就變偶數
	/// 就用偶數的方式處理
	/// 27 28 => 1 => 27 27 => 0 =>n=0
	/// 27 29 => 2 => n =1
	/// 27 30 => 3 => 27 29 => 2 => n=0 26 2 1 2
	/// 27 37 => 10 => n= 8
	/// </summary>
	public class Solution
	{
		public string StrWithout3a3b(int A, int B)
		{
			string output = "";


			string largerLetter = A > B ? "a" : "b";
			string smallerLetter = largerLetter == "b" ? "a" : "b";
			int larger = Math.Max(A, B);
			int smaller = Math.Min(A, B);

			Func<int, int, string> doubleStr = (lg, sm) =>
			{
				string doublestr = "";
				while (lg > 0 || sm > 0)
				{
					for (int i = 0; i < 2; i++)
					{
						if (lg > 0)
						{
							doublestr += largerLetter;
							--lg;
						}
					}
					for (int i = 0; i < 1; i++)
					{
						if (sm > 0)
						{
							doublestr += smallerLetter;
							--sm;
						}
					}
				}
				return doublestr;
			};

			Func<int, string, string> singleStr = (sm, beginLetter) =>
			{
				string singlestr = "";
				
				for (int i = 0; i < sm; i++)
					singlestr += largerLetter + smallerLetter;
				singlestr = beginLetter + singlestr;
				return singlestr;
			};
			
			int diff = Math.Abs(A - B);
			bool isEven = diff % 2 == 0;

			if (!isEven)
				diff -= 1;

			int n = diff - 2;
			if (n >=2) //diff >= 4
			{
				output += singleStr(smaller - n, isEven ? "" : largerLetter);
				output += doubleStr((2*n)+2, n);
			}
			else if (-2 <= n  && n <= -1) //0 1
			{
				output += singleStr(smaller, isEven ? "" : largerLetter);
			}
			else //diff = 2 3
			{
				output += singleStr(smaller, isEven ? "" : largerLetter);
				output += largerLetter + largerLetter;
			}

			return output;
		}

	}


}
