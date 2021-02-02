using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _1018_BinaryPrefixDivisibleBy5
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			s.PrefixesDivBy5(new int[] { 0, 1, 1, 1, 1, 1 }).PrintList();
			s.PrefixesDivBy5(new int[] {  1, 1, 1}).PrintList();
	
		}


		/// <summary>
		/// 同樣算法 
		/// List.Add  最快停在 77%  改 Array  最快可100%  成功  完全自己想的
		/// 
		///Runtime: 240 ms, faster than 90.32% of C# online submissions for Binary Prefix Divisible By 5.
		///Memory Usage: 35.4 MB, less than 6.45% of C# online submissions for Binary Prefix Divisible By 5.
		/// </summary>
		public class Solution
		{
			public IList<bool> PrefixesDivBy5(int[] A)
			{
				bool[] res = new bool[A.Length];

				int current = 0;
				int previous = A[0];
				res[0] = previous == 0;
				for (int i = 1; i < A.Length; i++)
				{
					previous = ((previous * 2) + A[i])%5;
					res[i] = previous == 0;
				}
				
				return res;
			}
		}



		/// <summary>
		/// mod 的循環數概念  數列重複循環
		/// 1 2 4 8 6 2 4 8 6 2 4 8
		///
		/// 長度2000 TLE  開始想其他方法
		/// 這個方式因為  數列是往左動  所以值沒辦法直接累加  就沒辦法利用dp那種運用累積前面的結果
		/// 在想要用前面的結果  想到左移是*2  那是不倍數*2結果一樣  可能能用這個循環 
		/// </summary>
		public class Solution_V1
		{
			public IList<bool> PrefixesDivBy5(int[] A)
			{
				List<int> lastNum = new List<int>();
				lastNum.Add(1);
				int[] binLast = new[] { 2, 4, 8, 6 };
				for (int i = 1; i < A.Length; i++)
				{
					lastNum.Add(binLast[(i - 1) % 4]);
				}

				int length = A.Length - 1;
				List<bool> res = new List<bool>();

				List<int> bin = new List<int>();
				for (int i = 0; i < A.Length; i++)
				{
					bin.Add(A[i]);
					int lastNumSum = 0;
					for (int j = 0; j < bin.Count; j++)
					{
						lastNumSum += bin[j] * lastNum[bin.Count - 1 - j];
					}
					res.Add(lastNumSum % 5 == 0);
				}
				return res;
			}
		}

	}
}
