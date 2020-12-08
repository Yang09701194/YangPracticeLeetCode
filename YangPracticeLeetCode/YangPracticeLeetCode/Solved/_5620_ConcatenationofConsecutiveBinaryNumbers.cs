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
		/// �򥻤W  ����Ӯt
		/// ��ڤW�ӻ�  �o�˴N���X�F  LC �b�����ɭ�
		/// �O�ΦP�@��{������ �h new class �� instance 
		/// �ҥHstatic���覡cache����
		/// ���A�C�����_�@��s�{��
		/// �ΩҪ��̧֪�Cache Dic
		/// ���\�[�t��1596ms
		/// ���L�o���I���B�~�ۤF
		/// �H���s���]�ӻ�  �o�˨èS������i�B 
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
		/// ���G�N�L���F  Accepted  �]��O�b�Ӧۤv�Q�쪺
		/// 2456ms
		///
		/// �o�Dcontest �˥����h ��100%
		/// �N�b�Q���S����֪�
		/// ���G�H�K��@��  �T�꦳  800ms��
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
		/// ���ݥL�H��  �A�ۤv�Q��  �٬O���i�B
		/// �_�ǥ������]�~46ms  �ܺC��
		///
		/// ���ݥk��  ���w�g�O��²�檺����F  �̰�¦���ާ@
		///
		/// ���G��M�Q��   �Ƥd�Ӧr�����   
		/// �T��N�|�p�Q   StringBuilder   �h�B�z�j�q�N�|������|
		///
		/// ���G  �ߨ�N�o��F 6ms  �v�T�W�j
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
