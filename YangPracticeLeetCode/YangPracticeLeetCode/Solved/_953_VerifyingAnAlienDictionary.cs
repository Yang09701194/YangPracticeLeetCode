using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _953_VerifyingAnAlienDictionary
	{

		public static void Test()
		{
			Solution s = new Solution();

			int?[] a4 = new int?[] {3};
			int?[] a5 = new int?[] {1, 2, 3, 4, 5, 6, null, null, null, 7, 8};


			string[] words1 = new[] {"hello", "leetcode"};
			string order1 = "hlabcdefgijkmnopqrstuvwxyz";
			Console.WriteLine(s.IsAlienSorted(words1, order1) + " is true");

			string[] words2 = new[] {"word", "world", "row"};
			string order2 = "worldabcefghijkmnpqstuvxyz";
			Console.WriteLine(s.IsAlienSorted(words2, order2) + " is false");

			string[] words3 = new[] {"apple", "app"};
			string order3 = "abcdefghijklmnopqrstuvwxyz";
			Console.WriteLine(s.IsAlienSorted(words3, order3) + " is false");
		}

		public class Solution
		{
			public bool IsAlienSorted(string[] words, string order)
			{
				//排序使用
				rOrder = order;
				//原本想說是排序  但是排序  題目應該是  給一個亂的輸入  輸出是排序好的
				//但是再細想一下  這裡是  檢查 是否符合排序
				//排序就是  前後比大小一直比下去   所以我就這樣做  就是結果了
				//應該一個for迴圈  順著比下去就搞定了
				for (int i = 0; i < words.Length -1; i++)
				{
					string sPre = words[i];
					string sNext = words[i + 1];

					int compare = Compare(sPre, sNext);
					if (compare == 1)
						return false;
				}
				return true;
			}
			
			private string rOrder = "";
			public int GetPos(char c)
			{
				return rOrder.IndexOf(c);
			}
			
			/// <summary>
			/// 1:s1 larger than s2    -1: s1 less than s2  0: s1==s2 
			/// </summary>
			/// <returns></returns>
			public int Compare(string s1, string s2)
			{
				int cou1 = s1.Length;
				int cou2 = s2.Length;
				int couMin = Math.Min(cou1, cou2);

				for (int i = 0; i < couMin; i++)
				{
					int p1 = GetPos(s1[i]);
					int p2 = GetPos(s2[i]);
					if (p1 > p2)
						return 1;
					else if (p1 < p2)
						return -1;
					else if (p1 == p2 && i != couMin-1)
						continue;
					else if (p1 == p2 && i == couMin - 1)
					{
						if (cou1 == cou2)
							return 0;
						else
							return cou1 > cou2 ? 1 : -1;
					}
					else
						throw new Exception("Impossible??");
				}
				throw new Exception("Impossible??2");
			}

		}
	}
}
