using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _1122_RelativeSortArray
	{

		public static void Test()
		{

			Solution s = new Solution();
			int[] arr1 = new[] {2, 3, 1, 3, 2, 4, 6, 7, 9, 2, 19};
			int[] arr2 = new[] { 2, 1, 4, 3, 9, 6 };
			s.RelativeSortArray(arr1, arr2).PrintList();

			int[] arr11 = new[] { 28, 6, 22, 8, 44, 17 };
			int[] arr12 = new[] { 22, 28, 8, 6 };
			s.RelativeSortArray(arr11, arr12).PrintList();



		}

		public class Solution
		{
			public int[] RelativeSortArray(int[] arr1, int[] arr2)
			{
				orderArr1 = arr1;
				orderArr2 = arr2;

				List<Item> results = arr1.Select(a => new Item(a)).ToList();
				ItemComparer c = new ItemComparer();
			    results.Sort(c);

				return results.Select(r => r.Value).ToArray();
			}

			public static int[] orderArr1 = null;
			public static int[] orderArr2 = null;
			public class ItemComparer : IComparer<Item>
			{
				public int Compare(Item a, Item b)
				{
					int aPos = Array.IndexOf(orderArr2, a.Value);
					int bPos = Array.IndexOf(orderArr2, b.Value);

					if (aPos == -1 && bPos >= 0)
						return 1;
					if (bPos == -1 && aPos >= 0)
						return -1;

					if (aPos == -1 && bPos == -1)
					{
						if (a.Value == b.Value)
							return 0;
						return a.Value < b.Value ? -1 : 1;
					}

					if (aPos == bPos)
						return 0;
					return aPos < bPos ? -1 : 1;
				}
			}

			public class Item
			{
				public Item(int value)
				{
					Value = value;
				}
				public int Value { get; set; }

				public override string ToString()
				{
					return Value.ToString();
				}
				


			}

		}
		


	}
}
