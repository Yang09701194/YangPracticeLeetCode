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
			Solution_V5 s6 = new Solution_V5();

			//Console.WriteLine(s.NumPoints());
			//Console.WriteLine(s.ConcatenatedBinary(3));


			for (int i = 0; i <= 12; i++)
			{
				Console.WriteLine(s.ConcatenatedBinary(12));
			}
			//Console.WriteLine(s.ConcatenatedBinary(4926));
			for (int i = 0; i <= 12; i++)
			{
				Console.WriteLine(s6.ConcatenatedBinary(i));
			}

		}




		/// <summary>
		/// Sol 3
		/// 最快  104ms
		/// 快在2的pow的判斷  比我log快
		/// Time Complexity: \mathcal{O}(n)O(n). We iterate nn numbers, and for each number we spend \mathcal{O}(1)O(1) to add it to the final result.
		///Space Complexity: \mathcal{O}(1)O(1), since we do not need any extra data structure.
		/// </summary>
		class Solution
		{
			public int ConcatenatedBinary(int n)
			{
				int MOD = 1000000007;
				int length = 0; // bit length of addends
				long result = 0; // long accumulator
				for (int i = 1; i <= n; i++)
				{
					// when meets power of 2, increase the bit length
					if ((i & (i - 1)) == 0)
					{
						length++;
					}
					result = ((result << length) | i) % MOD;
				}
				return (int)result;
			}
		}


		/// <summary>
		/// Sol V2  496 ms
		/// V7原理類似  但是我自己想得比較快  因為我直接取Log+1
		/// </summary>
		class Solution_V8
		{
			public int ConcatenatedBinary(int n)
			{
				int MOD = 1000000007;
				int length = 0; // bit length of addends
				long result = 0; // long accumulator
				for (int i = 1; i <= n; i++)
				{
					// when meets power of 2, increase the bit length
					if (Math.Pow(2, (int)(Math.Log(i) / Math.Log(2))) == i)
					{
						length++;
					}
					result = ((result * (int)Math.Pow(2, length)) + i) % MOD;
				}
				return (int)result;
			}
		}

		/// <summary>
		/// Sol 2nd 不一位一位移  一次計算i的bin長度   直接移動
		/// 就  324ms 也太快了  但是才 53%
		/// 可見一堆人都去抄 Sol 3了
		/// Time Complexity: \mathcal{O}(n\log(n))O(nlog(n)). We iterate nn numbers, and for each number we spend \mathcal{O}(\log(n))O(log(n)) to check wether it is power of 22 and add to the final result.
		///Space Complexity: \mathcal{O}(1)O(1), since we do not need any extra data structure.
		/// </summary>
		public class Solution_V7
		{
			public int ConcatenatedBinary(int n)
			{
				const long num = (long)1000000007;
				long lb = 0;
				int bitLen = 1;
				for (int i = 1; i <= n; i++)
				{
					bitLen = GetBinaryLength(i);
					lb = lb << bitLen;
					lb += i;
					lb = lb % num;
				}
				return (int)lb;
			}

			public static int GetBinaryLength(int n)
			{
				return (int)Math.Log(n, 2) + 1;
			}

		}

		/// <summary>
		/// sol有提到一點
		/// 免去字串拼接可以省掉很多時間
		/// 這樣子跟SBuilder 相同  只是少字串拼接
		/// 但可能SB太快  沒差多少
		/// 但是真的就比 += 快
		///
		///Time Complexity: \mathcal{O}(n\log(n))O(nlog(n)). We iterate nn numbers, and for each number we spend \mathcal{O}(\log(n))O(log(n)) to transform it into the binary form and add it to the final result.
		/// Space Complexity: Depends on the implementation. In Python, we firstly concatenate all string together, so the total space usage is \mathcal{O}(n\log(n))O(nlog(n)). While in Java and C++, we add the string into the final result immediately without concatenating, so the space complexity is \mathcal{O}(n)O(n). Of course, you can implement the immediately adding version in Python, but that requires extra codes.
		/// </summary>
		public class Solution_V6
		{
			public static Dictionary<int, string> binSD = new Dictionary<int, string>();

			public int ConcatenatedBinary(int n)
			{
				const long num = (long)1000000007;
				long lb = 0;
				for (int i = 1; i <= n; i++)
				{
					string bin = Convert.ToString(i, 2);
					for (int j = 0; j < bin.Length; j++)
					{
						lb = lb << 1;

						if (bin[j] == '1')
							lb += 1;

						if (lb > num)
						{
							lb = lb % num;
						}
					}
				}
				return (int)lb;
			}

		}





		/// <summary>
		/// 別人解答  888ms 原本以為很快了  結果今天答案數夠多  %出來了
		/// 竟然還是在 47%  可見其他人滿誇張的
		/// 可能一堆人都有訂 premium  所以都知道解答?
		///
		///  有寫到power 已經是有看解答的了  這題不知道數學會看不懂這解法
		/// </summary>
		public class Solution_V5
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
		///
		/// 倍數 mod = mod後 倍數  
		/// 7%3 = 1
		/// 7 = 2 * 3 +1
		/// 14 = 2* 3 + 1 * 2
		/// = 1 * 2
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
