using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _412_FizzBuzz
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			//Console.WriteLine(s.SpecialArray(new int[] { 3, 5 }));

		}

		public class Solution//244ms  64.15% 有時候92%  相對於下面比較不穩定  常常跑到50%   
		{
			public IList<string> FizzBuzz(int n)
			{
				const string f = "Fizz";
				const string b = "Buzz";
				const string fb = "FizzBuzz";
				string[] res = new string[n];//以leetcode的mem計算來說 改成static沒差多少
				bool isMulti5;
				bool isMulti3;
				for (int i = 1; i <= n; i++)
				{
					isMulti5 = i % 5 == 0;//變數移出去 mem沒差多少  改成string 速度mem都沒差多少
					isMulti3 = i % 3 == 0;
					if (isMulti5 && isMulti3)
						res[i-1] = fb;
					else if (isMulti3)
						res[i - 1] = f;
					else if (isMulti5)
						res[i - 1] = b;
					else
						res[i - 1] = i.ToString();
				}
				return res;
			}
		}

		public class Solution2  //看解答看到的特殊想法   這個速度就贏90%了  236ms
		{

			public IList<string> FizzBuzz(int n)
			{

				List<string> ret = new List<string>();

				for (int i = 1, fizz = 0, buzz = 0; i <= n; i++)
				{
					fizz++;
					buzz++;
					if (fizz == 3 && buzz == 5)
					{
						ret.Add("FizzBuzz");
						fizz = 0;
						buzz = 0;
					}
					else if (fizz == 3)
					{
						ret.Add("Fizz");
						fizz = 0;
					}
					else if (buzz == 5)
					{
						ret.Add("Buzz");
						buzz = 0;
					}
					else
					{
						ret.Add(i.ToString());
					}
				}
				return ret;
			}
		}



	}
}
