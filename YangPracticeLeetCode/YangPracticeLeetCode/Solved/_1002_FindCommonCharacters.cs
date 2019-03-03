using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _1002_FindCommonCharacters
	{

		public static void Test()
		{
			Solution s = new Solution();

			string[] a4 = new [] { "bella", "label", "roller" };
			a4.PrintList();
			s.CommonChars(a4).PrintList();
			
			string[] a5 = new [] { "cool", "lock", "cook" };
			a5.PrintList();
			s.CommonChars(a5).PrintList();

		}

		public class Solution
		{
			public IList<string> CommonChars(string[] A)
			{
				Dictionary<char, int> commonCount = new Dictionary<char, int>();
				for (int i = 0; i < A[0].Length; i++)
				{
					char current = A[0][i];
					if(commonCount.ContainsKey(current))
						continue;

					bool isCommon = true;
					List<int> charCount = new List<int>();

					charCount.Add(A[0].Count(c => c == current));

					for (int j = 1; j < A.Length; j++)
					{
						if (!A[j].Contains(current))
						{
							isCommon = false;
							break;
						}
						charCount.Add(A[j].Count(c => c == current));
					}
					if (isCommon)
						commonCount.Add(current, charCount.Min());
				}

				List<string> result = new List<string>();

				foreach (KeyValuePair<char, int> kv in commonCount)
				{
					for (int i = 0; i < kv.Value; i++)
						result.Add(kv.Key.ToString());
				}

				return result;
			}
		}

	}
}
