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
		/// �o�DTop Answer �i�H�ݨ��ҩ�  �٦�NP
		/// �N�u���ܼƾǪ��h��@�q�d��case
		/// ��d���Y�p   �M�ᵹ�p���i�t�᪺�W��
		/// �N�i�H�B�z�F  �W�L���ڥ������βz
		/// ������O�b�C�@�B���Y���n�ܺ�Ǫ����X���� 
		/// 
		/// If N > S * 2, we can return false directly in O(1)
		/// Note that it's the same to prove with the numbers 512 ~ 1511, or even smaller range.
		///	N/2 times check, O(S)to check a number in string S.9
		/// </summary>
		public class Solution
		{
			public bool QueryString(string S, int N)
			{
				
				for (int i = N; i < N/2; i--)
				{
					if (S.IndexOf(Convert.ToString(i, 2)) == -1)
						return false;
				}

				return true;
			}
		}

		/// <summary>
		/// ���g�@�ӳ̪�ı���g�k  �ɤO
		/// �M��  TLE
		/// ���۴N�|�}�l�Q  S����1000
		/// TLE test case  1000000000
		/// �j�� 2^30
		/// �H�ƦC�զX�ӻ�  ���D 30�� 1 �A 29��0  �N 870
		/// 870�Ӫ���30   �����W�L1000
		/// �ҥH�����[�@�Ӧ^��false  �٦�
		///
		/// �o�ˤl���Ӥ��|�Q�P hard coding @@
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
