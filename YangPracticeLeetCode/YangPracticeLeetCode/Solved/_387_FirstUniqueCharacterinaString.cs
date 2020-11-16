using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _387_FirstUniqueCharacterinaString
	{


		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			Console.WriteLine(s.FirstUniqChar("leetcode"));
			Console.WriteLine(s.FirstUniqChar("loveleetcode"));

		}

		

		/// <summary>
		/// 最高票數  這樣寫竟然又更快  96%   我原本以為用字串一個個找  有點呆  因為可能會大量重複找
		/// 所以我下面就是直接26個字母找一遍  但這樣會用到dic 可能就慢了
		/// </summary>
		public class Solution
		{
			public int FirstUniqChar(String s)
			{

				Func<char, int> toAscii = c =>
				{
					return Convert.ToInt32(c) - 97;
				};


				int[] freq = new int[26];
				for (int i = 0; i < s.Length; i++)
					freq[s[i] - 'a']++;
				for (int i = 0; i < s.Length; i++)
					if (freq[s[i] - 'a'] == 1)
						return i;
				return -1;
			}
		}


		/// <summary>
		/// speed 80 ~ 96%    說明如下方   這個比較奇怪  跑的range比較大
		/// </summary>
		public class SolutionMe
		{
			public int FirstUniqChar(string s)
			{

				Func<char, int> toAscii = c =>
				{
					return Convert.ToInt32(c) - 97;
				};

				int[] charPos = new int[26];
				int[] charCou = new int[26];

				for (int i = 0; i < s.Length; i++)
				{
					int cI = toAscii(s[i]);
					if (charPos[cI] == 0)
					{
						charPos[cI] = i;
					}

					int charNum = toAscii(s[i]);
					charCou[charNum]++;
				}

				int minPos = int.MaxValue;
				bool isAny1 = false;
				for (int i = 0; i < charCou.Length; i++)
				{
					if (charCou[i] == 1)
					{
						isAny1 = true;
						int pos = charPos[i];
						if (pos < minPos)
							minPos = pos;
					}
				}

				if (!isAny1)
					return -1;

				return minPos;

			}
		}




		/// <summary>
		/// 這樣子是 speed win 26%    我覺得這已經很快了  因為我好不容易竟然一下就想到 O n的解法   這題很容易不小心就 O n^2  比較的方式稍微換掉就 > n了   這題沒用到orderby nlogn 就能比出來  就是利用了迴圈 和比大小
		/// 所以還只有26%  仔細看就覺得可能字典 dic[]++ 還能再改進   所以就改成上方的陣列
		/// 馬上就 76%   陣列的想法用到了可能一年前contest的時候  某個情況下轉成int會很好處理  重點就會是ASCII的數值   97是重要數字
		/// 字典是因為  一開始要containskey給1 可能 binary search o nlogn? 或者更快  之後每次都要[]++  這邊好像跟hashset一樣 O 1 或更慢   但是直接想就會覺得  dic一定結構上比 arr龐大複雜  所以就算再怎麼快  應該是比較慢  這邊%就證明了  
		/// </summary>
		public class SolutionV0
		{
			public int FirstUniqChar(string s)
			{
				Dictionary<char, int> charPos = new Dictionary<char, int>();
				Dictionary<char, int> charCou = new Dictionary<char, int>();

				for (int i = 0; i < s.Length; i++)
				{
					if (!charPos.ContainsKey(s[i]))
					{
						charPos[s[i]] = i;
					}

					if (!charCou.ContainsKey(s[i]))
					{
						charCou[s[i]] = 1;
					}
					else
					{
						charCou[s[i]]++;
					}
				}

				int minPos = int.MaxValue;
				bool isAny1 = false;
				foreach (var kv in charCou)
				{
					if (kv.Value == 1)
					{
						isAny1 = true;
						int pos = charPos[kv.Key];
						if (pos < minPos)
							minPos = pos;
					}
				}

				if (!isAny1)
					return -1;

				return minPos;

			}
		}

	}
}
