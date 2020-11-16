using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _1616_SplitTwoStringstoMakePalindrome
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			Console.WriteLine(s.CheckPalindromeFormation("abda", "acmc"));

			Console.WriteLine(s.CheckPalindromeFormation("x", "y"));
			Console.WriteLine(s.CheckPalindromeFormation("abdef", "fecab"));
			Console.WriteLine(s.CheckPalindromeFormation("ulacfd", "jizalu"));
			Console.WriteLine(s.CheckPalindromeFormation("xbdef", "xecab"));

			Console.WriteLine(s.CheckPalindromeFormation("askxrrnhyddrlmcgymtichivmwyjfpyqqxmiimxqqypfjywmvihcitmygcmlryczoygimgii", "iigmigyozcyfxgfzkwpvjuxbjphbbmwlhdcavhtjhbpccsxaaiyitfbzljvhjoytfqlqrohv"));

		}


		/// <summary>
		/// 自己想出來的   邊對test case 改進三次 可能因為 contest題 100  100  所以先沒看 discuss  
		/// 通過版本  繼續觀察test case 發現只比第一個字不同還不夠   接下來的test case  都是起訖有大量相同的  所以相同的這些字段落都可以省略不比
		///
		/// 這還沒到完全  先雙邊往內比較  取得相同的最大index  接下來一開始中間部分 還是用 V1 所有字串組合  結果還是TLE 大概又前進3個test case
		///
		/// 最後再仔細想  發現關鍵    雙邊比較出最內相同和不同的臨界點
		/// 中間部分 AB 和 BA  其實各只有兩種  一個是 A+全B  一個  全A+B  就是中間不是都放A 就是ˇ都放 B   因為中間一樣  一開始有字不同  中間就不同了  不用比下去
		///
		/// 就通過了   substring 的起迄點  要能想得很清楚  要一次寫對不容易
		/// </summary>
		public class Solution
		{
			public bool CheckPalindromeFormation(string a, string b)
			{
				if (a.Length == 1)
					return true;

				//combine all prefix and suffix   and check each combine str
				List<string> ABComb = new List<string>();
				List<string> BAComb = new List<string>();
				char aStart = a.First();
				char aEnd = a.Last();
				char bStart = b.First();
				char bEnd = b.Last();
				bool isAB = aStart == bEnd;
				bool isBA = bStart == aEnd;

				int ABStart = 0;
				for (int i = 0; i < a.Length; i++)
				{
					if (a[i] == b[a.Length - 1 - i])
						ABStart++;
					else
						break;
				}
				int BAStart = 0;
				for (int i = 0; i < a.Length; i++)
				{
					if (b[i] == a[a.Length - 1 - i])
						BAStart++;
					else
						break;
				}

				int middle = (int)Math.Ceiling((double) a.Length / (double) 2);

				
				Func<string, bool> check = (s) =>
				{
					bool isAnyDiff = false;
					for (int t = ABStart, e = s.Length - t - 1; t < e; t++, e--)
					{
						if (s[t] != s[e])
						{
							isAnyDiff = true;
							break;
						}
					}
					if (!isAnyDiff)
						return true;
					return false;
				};

				if (ABStart == middle)
					return true;
				string A_allB = $"{a.Substring(0, ABStart)}{b.Substring(ABStart, b.Length  - ABStart)}";
				string Aall_B = $"{a.Substring(0, b.Length - ABStart)}{b.Substring(b.Length - ABStart, ABStart)}";
				if (check(A_allB))
					return true;
				if (check(Aall_B))
					return true;

				if (BAStart == middle)
					return true;
				string B_allA = $"{b.Substring(0, BAStart)}{a.Substring(BAStart, a.Length  - BAStart)}";
				string Ball_A = $"{b.Substring(0, b.Length - BAStart)}{a.Substring(b.Length  - BAStart, BAStart)}";
				if (check(B_allA))
					return true;
				if (check(Ball_A))
					return true;

				return false;
			}
		}


		/// <summary>
		/// 看到TLE長字串  開始想有沒有什麼特徵能省時間
		/// 推著 想像左右往內比較同字   只要第一個字不同    就不是palindrome
		/// 這樣子可以有兩組其中一組ex A起B訖不同  就可以直接省掉一半的時間
		/// 這裡開始有AB分開的概念
		/// 但是這個改良只在往前兩個 test case
		/// </summary>
		public class SolutionV2
		{
			public bool CheckPalindromeFormation(string a, string b)
			{
				if (a.Length == 1)
					return true;

				//combine all prefix and suffix   and check each combine str
				List<string> ABComb = new List<string>();
				List<string> BAComb = new List<string>();
				char aStart = a.First();
				char aEnd = a.Last();
				char bStart = b.First();
				char bEnd = b.Last();
				bool isAB = aStart == bEnd;
				bool isBA = bStart == aEnd;

				int ABStart = 0;
				for (int i = 0; i < a.Length; i++)
				{
					if (a[i] == b[a.Length - 1 - i])
						ABStart++;
					else
						break;
				}
				for (int i = ABStart; i < a.Length; i++)
				{
					if (isAB)
						ABComb.Add($"{a.Substring(0, i)}{b.Substring(i, b.Length - i)}");
				}

				int BAStart = 0;
				for (int i = 0; i < a.Length; i++)
				{
					if (b[i] == a[a.Length - 1 - i])
						BAStart++;
					else
						break;
				}
				for (int i = BAStart; i < a.Length; i++)
				{
					if (isBA)
						BAComb.Add($"{b.Substring(0, i)}{a.Substring(i, a.Length - i)}");
				}



				foreach (string s in ABComb)
				{
					bool isAnyDiff = false;
					for (int t = ABStart, e = s.Length - t - 1; t < e; t++, e--)
					{
						if (s[t] != s[e])
						{
							isAnyDiff = true;
							break;
						}
					}
					if (!isAnyDiff)
						return true;
				}
				foreach (string s in BAComb)
				{
					bool isAnyDiff = false;
					for (int t = BAStart, e = s.Length - t - 1; t < e; t++, e--)
					{
						if (s[t] != s[e])
						{
							isAnyDiff = true;
							break;
						}
					}
					if (!isAnyDiff)
						return true;
				}

				return false;
			}
		}


		/// <summary>
		/// 第一版    這邊想法很單純   組出所有  AB  和 BA  分割點從 0 ~ len - 1
		/// 然後全部搜尋   可以說是brute force
		///
		/// 有一個重點 想通這題就會簡單很多  一開始以為會是所有子字串  沒辦法一看題目  腦袋自然就往這邊鑽  就在以為又要用  divide and conquer 去遞迴對每個子字串處裡
		/// 結果看了很久   說來這題也有點會讓人誤會   突然看出原來只是直接比整個字串是不是 palindrome   那只要跑一次比全部  雙邊往內收回來就搞定   看透這點會簡單很多
		/// 結果就 TLE
		/// </summary>
		public class SolutionV1
		{
			public bool CheckPalindromeFormation(string a, string b)
			{
				//combine all prefix and suffix   and check each combine str
				List<string> allComb = new List<string>();
				for (int i = 0; i < a.Length; i++)
				{
					allComb.Add($"{a.Substring(0, i)}{b.Substring(i, b.Length - i)}");
					allComb.Add($"{b.Substring(0, i)}{a.Substring(i, a.Length - i)}");
				}

				foreach (string s in allComb)
				{
					bool isAnyDiff = false;
					for (int t = 0, e = s.Length - 1; t < e; t++, e--)
					{
						if (s[t] != s[e])
						{
							isAnyDiff = true;
						}
					}
					if (!isAnyDiff)
						return true;
				}

				return false;
			}
		}


	}
}
