using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _1016_BinaryStringWithSubstringsRepresenting1ToN
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			Console.WriteLine(s.QueryString("0110", 4));

		}


		/// <summary>
		/// 100%
		///
		/// 這題Top Answer 可以看到證明  還有NP
		/// 就真的很數學的去找一段範圍的case
		/// 把範圍縮小   然後給小的可負擔的上界
		/// 就可以處理了  超過的根本都不用理
		/// 比較難是在每一步限縮都要很精準的給出說明 
		///
		///
		/// The number 1001 ~ 2000 have 1000 different continuous 10 digits.
		/// The string of length S has at most S - 9 different continuous 10 digits.
		/// 連續十個字為一組  len 10 就一組  len 11 兩組 因為可以往又在移一個  12 3組  > S-9
		///  
		///	So S <= 1000(這是題目的limit 長度最長1000), the achievable N <= 2000. (因為數字值1000~2000 就有1000種組合了
		/// 長度1000 頂多 991種   所以長度1000等於是說 N的值最大2000
		///
		/// 下面應該是推廣到題目以外的限制  也就是考慮所有可能的S長度limit值   可以說是比題目考慮得更全面  是最完整的考慮
		/// 不論S長度是多少都可以套用  這不得不說一下厲害了
		/// So S * 2 is a upper bound for achievable N.
		/// If N > S * 2, we can return false directly in O(1)
		/// Note that it's the same to prove with the numbers 512 ~ 1511, or even smaller range.
		///	N/2 times check, O(S)to check a number in string S.
		///
		/// The overall time complexity has upper bound O(S^2).
		///
		///
		///
		/// 
		/// </summary>
		public class Solution
		{
			public bool QueryString(string S, int N)
			{
				
				for (int i = N; i > N/2; i--)
				{
					if (S.IndexOf(Convert.ToString(i, 2)) == -1)
						return false;
				}

				return true;
			}
		}

		/// <summary>
		/// 先寫一個最直覺的寫法  暴力
		/// 然後  TLE
		/// 接著就會開始想  S長度1000
		/// TLE test case  1000000000
		/// 大概 2^30
		/// 以排列組合來說  先挑 30個 1 再 29個0  就 870
		/// 870個長度30   直接超過1000
		/// 所以直接加一個回傳false  還行
		///
		/// 這樣子應該不會被判 hard coding @@
		/// 50%
		/// </summary>
		public class Solution_V1
		{
			public bool QueryString(string S, int N)
			{
				if (N >= 1000000000)
					return false;

				List<string> binExpres = new List<string>();
				for (int i = 1; i <= N; i++)
				{
					binExpres.Add(Convert.ToString(i, 2));
				}

				for (int i = 0; i < N; i++)
				{
					if (S.IndexOf(binExpres[i]) == -1)
						return false;
				}

				return true;
			}
		}

	}
}
