using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _1018_BinaryPrefixDivisibleBy5
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			s.PrefixesDivBy5(new int[] { 0, 1, 1, 1, 1, 1 }).PrintList();
			s.PrefixesDivBy5(new int[] {  1, 1, 1}).PrintList();
	
		}


		/// <summary>
		/// �P�˺�k 
		/// List.Add  �ְ̧��b 77%  �� Array  �̧֥i100%  ���\  �����ۤv�Q��
		/// 
		///Runtime: 240 ms, faster than 90.32% of C# online submissions for Binary Prefix Divisible By 5.
		///Memory Usage: 35.4 MB, less than 6.45% of C# online submissions for Binary Prefix Divisible By 5.
		/// </summary>
		public class Solution
		{
			public IList<bool> PrefixesDivBy5(int[] A)
			{
				bool[] res = new bool[A.Length];

				int current = 0;
				int previous = A[0];
				res[0] = previous == 0;
				for (int i = 1; i < A.Length; i++)
				{
					previous = ((previous * 2) + A[i])%5;
					res[i] = previous == 0;
				}
				
				return res;
			}
		}



		/// <summary>
		/// mod ���`���Ʒ���  �ƦC���ƴ`��
		/// 1 2 4 8 6 2 4 8 6 2 4 8
		///
		/// ����2000 TLE  �}�l�Q��L��k
		/// �o�Ӥ覡�]��  �ƦC�O������  �ҥH�ȨS��k�����֥[  �N�S��k�Q��dp���عB�βֿn�e�������G
		/// �b�Q�n�Ϋe�������G  �Q�쥪���O*2  ���O������*2���G�@��  �i���γo�Ӵ`�� 
		/// </summary>
		public class Solution_V1
		{
			public IList<bool> PrefixesDivBy5(int[] A)
			{
				List<int> lastNum = new List<int>();
				lastNum.Add(1);
				int[] binLast = new[] { 2, 4, 8, 6 };
				for (int i = 1; i < A.Length; i++)
				{
					lastNum.Add(binLast[(i - 1) % 4]);
				}

				int length = A.Length - 1;
				List<bool> res = new List<bool>();

				List<int> bin = new List<int>();
				for (int i = 0; i < A.Length; i++)
				{
					bin.Add(A[i]);
					int lastNumSum = 0;
					for (int j = 0; j < bin.Count; j++)
					{
						lastNumSum += bin[j] * lastNum[bin.Count - 1 - j];
					}
					res.Add(lastNumSum % 5 == 0);
				}
				return res;
			}
		}

	}
}
