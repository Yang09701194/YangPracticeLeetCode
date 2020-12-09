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
		/// �̧�  104ms
		/// �֦b2��pow���P�_  ���log��
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
		/// V7��z����  ���O�ڦۤv�Q�o�����  �]���ڪ�����Log+1
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
		/// Sol 2nd ���@��@�첾  �@���p��i��bin����   ��������
		/// �N  324ms �]�ӧ֤F  ���O�~ 53%
		/// �i���@��H���h�� Sol 3�F
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
		/// sol������@�I
		/// �K�h�r������i�H�ٱ��ܦh�ɶ�
		/// �o�ˤl��SBuilder �ۦP  �u�O�֦r�����
		/// ���i��SB�ӧ�  �S�t�h��
		/// ���O�u���N�� += ��
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
		/// �O�H�ѵ�  888ms �쥻�H���ܧ֤F  ���G���ѵ��׼ư��h  %�X�ӤF
		/// ���M�٬O�b 47%  �i����L�H���رi��
		/// �i��@��H�����q premium  �ҥH�����D�ѵ�?
		///
		///  ���g��power �w�g�O���ݸѵ����F  �o�D�����D�ƾǷ|�ݤ����o�Ѫk
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
		/// �򥻤W  ����Ӯt
		/// ��ڤW�ӻ�  �o�˴N���X�F  LC �b�����ɭ�
		/// �O�ΦP�@��{������ �h new class �� instance 
		/// �ҥHstatic���覡cache����
		/// ���A�C�����_�@��s�{��
		/// �ΩҪ��̧֪�Cache Dic
		/// ���\�[�t��1596ms
		/// ���L�o���I���B�~�ۤF
		/// �H���s���]�ӻ�  �o�˨èS������i�B
		///
		/// ���� mod = mod�� ����  
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
