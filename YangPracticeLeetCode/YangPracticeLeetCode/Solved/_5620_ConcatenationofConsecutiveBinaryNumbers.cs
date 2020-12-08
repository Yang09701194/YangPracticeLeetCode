using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5620_ConcatenationofConsecutiveBinaryNumbers
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			//Console.WriteLine(s.ConcatenatedBinary(3));
			Console.WriteLine(s.ConcatenatedBinary(4926));



		}



		public class Solution
		{
			public int ConcatenatedBinary(int n)
			{
				var ans = 0;
				var length = 1;
				var nextpower = 2; // to determine binary length of next element
				var mod = (int)1e9 + 7;

				for (var i = 1; i <= n; i++)
				{
					if (i >= nextpower)
					{
						length++;
						nextpower <<= 1;
					}

					ans = MultMod(ans, 1 << length, mod);
					ans += i;
					ans %= mod;
				}

				return ans;
			}

			private static int MultMod(int a, int b, int mod)
			{
				var res = 0;
				a %= mod;

				while (b > 0)
				{
					if ((b & 1) > 0)
						res = (res + a) % mod;

					a = (2 * a) % mod;
					b >>= 1;
				}

				return res;
			}
		}


		/// <summary>
		/// 基本上  不算太差
		/// 實際上來說  這樣就測出了  LC 在測的時候
		/// 是用同一支程式內部 去 new class 的 instance 
		/// 所以static的方式cache有用
		/// 不適每次都起一支新程式
		/// 用所知最快的Cache Dic
		/// 成功加速到1596ms
		/// 不過這有點用額外招了
		/// 以全新重跑來說  這樣並沒有任何進步 
		/// </summary>
		public class Solution_V4
		{
			public static Dictionary<int, string> binSD = new Dictionary<int, string>();

			public int ConcatenatedBinary(int n)
			{
				StringBuilder binS = new StringBuilder();
				for (int i = 1; i <= n; i++)
				{
					if (binSD.ContainsKey(i))
					{
						binS.Append(binSD[i]);
					}
					else
					{
						string bn = Convert.ToString(i, 2);
						binSD[i] = bn;
						binS.Append(binSD[i]);
					}

				}
				string bin = binS.ToString();
				const long num = 1000000007;
				long lb = 0;
				for (int i = 0; i < bin.Length; i++)
				{
					lb = lb << 1;

					if (bin[i] == '1')
						lb += 1;
					else
						continue;

					if (lb > num)
					{
						lb = lb % num;
					}
				}

				return (int)lb;
			}

		}
		

		/// <summary>
		/// 結果就過關了  Accepted  也算是半個自己想到的
		/// 2456ms
		///
		/// 這題contest 樣本不多 都100%
		/// 就在想有沒有更快的
		/// 結果隨便找一個  確實有  800ms的
		/// 
		/// </summary>
		public class Solution_V3
		{
			public static Dictionary<int, string> binSD = new Dictionary<int, string>();

			public int ConcatenatedBinary(int n)
			{
				StringBuilder binS = new StringBuilder();
				for (int i = 1; i <= n; i++)
				{
					string bn = Convert.ToString(i, 2);
					binS.Append(bn);
				}
				string bin = binS.ToString();
				const long num = 1000000007;
				long lb = 0;
				for (int i = 0; i < bin.Length; i++)
				{
					lb = lb << 1;

					if (bin[i] == '1')
						lb += 1;

					if (lb > num)
					{
						lb = lb % num;
					}
				}

				return (int)lb;
			}

		}




		/// <summary>
		/// 233 / 403 test cases passed.
		/// 4926
		/// 先看他人解  再自己想的  還是有進步
		/// 奇怪本機測也才46ms  很慢嗎
		///
		/// 左看右看  都已經是最簡單的比較了  最基礎的操作
		///
		/// 結果突然想到   數千個字串拼接   
		/// 確實就會聯想   StringBuilder   多處理大量就會切身體會
		///
		/// 結果  立刻就得到了 6ms  影響超大
		/// </summary>
		public class Solution_V2
		{
			public int ConcatenatedBinary(int n)
			{
				string bin = "";
				for (int i = 1; i <= n; i++)
				{
					string bn = Convert.ToString(i, 2);
					bin += bn;
				}
				const long num= 1000000007;
				long lb = 0;
				for (int i = 0; i < bin.Length; i++)
				{
					lb = lb << 1;

					if (bin[i] == '1')
						lb += 1;

					if (lb > num)
					{
						lb = lb % num;
					}
				}

				return (int)lb;
			}

		}



		/// <summary>
		/// 205 / 403 test cases passed.
		/// n 8259
		/// TLE 
		/// </summary>
		public class Solution_V1
		{
			public int ConcatenatedBinary(int n)
			{
				string bin = "";
				for (int i = 0; i < n; i++)
				{
					string bn = Convert.ToString(i, 2);
					bin += bn;
				}

				BigInteger b = BinToDec(bin);
				BigInteger mod = b % 1000000007;
				int im = (int) mod;
				return im;
			}


			public static BigInteger BinToDec(string value)
			{
				// BigInteger can be found in the System.Numerics dll
				BigInteger res = 0;

				// I'm totally skipping error handling here
				foreach (char c in value)
				{
					res <<= 1;
					res += c == '1' ? 1 : 0;
				}

				return res;
				//return res.ToString();
			}

		}


	}
}
