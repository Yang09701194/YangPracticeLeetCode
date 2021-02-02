using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _350_IntersectionofTwoArraysII
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			s.Intersect(new int[] { 1, 2 }, new int[] { 1, 1 }).PrintList();
			s.Intersect(new int[] { 1 }, new int[] { }).PrintList();
			s.Intersect(new int[] { 1, 2, 2, 1 }, new int[] { 2, 2 }).PrintList();
			s.Intersect(new int[] { 4, 9, 5 }, new int[] { 9, 4, 9, 8, 4 }).PrintList();

		}



		/// <summary>
		/// ��L�H��  �r�媺�Ѫk
		/// �]ok  ���L�ڨS�Q��γo��   �i���dic��O(1) �٨S����H��
		///
		/// �{�b�]�]�O�ܩ_��  range �ܤƤj  faster 94.8%  ~  10%����
		/// �N���o��
		/// </summary>
		public class Solution
		{
			public int[] Intersect(int[] nums1, int[] nums2)
			{

				List<int> list = new List<int>();
				Dictionary<int, int> d = new Dictionary<int, int>();

				foreach (int num in nums1)
				{
					if (!d.ContainsKey(num))
					{
						d.Add(num, 1);
					}
					else
						d[num]++;
				}

				foreach (int num in nums2)
				{
					if (d.ContainsKey(num) && d[num] > 0)
					{
						list.Add(num);
						d[num]--;
					}

				}

				return list.ToArray();
			}
		}

		/// <summary>
		/// self done
		///
		/// Runtime: 236 ms, faster than 84.11% of C# online submissions for Intersection of Two Arrays II.
		/// Memory Usage: 31.7 MB, less than 64.85% of C# online submissions for Intersection of Two Arrays II.
		///
		/// �o�D�t���ܤƤj   �]�� 10% 40% 60%
		/// �O����  80 90 
		/// </summary>
		public class Solution_V1
		{
			public int[] Intersect(int[] nums1, int[] nums2)
			{
				if (!nums1.Any() || !nums2.Any())
				{
					return new int[] { };
				}

				var n1 = nums1.ToList();
				var n2 = nums2.ToList();
				n1.Sort();
				n2.Sort();

				List<int> res = new List<int>();
				for (int i = 0, k = 0; k < n2.Count && i < n1.Count;)
				{
					if (n1[i] < n2[k])
					{
						i++;
					}
					else if (n1[i] > n2[k])
					{
						k++;
					}
					else// ==
					{
						res.Add(n2[k]);
						k++;
						i++;
					}
				}

				return res.ToArray();
			}
		}



	}
}
