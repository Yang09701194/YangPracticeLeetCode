using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5614_FindtheMostCompetitiveSubsequence
	{

		/// <summary>
		/// not solved
		/// </summary>
		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			//s.MostCompetitive(new int[] { 2, 10, 3, 5, 9, 4, 2, 0, 6, 7, 8, 0, 6, 5, 8, 1, 6, 1, 5, 5, 2, 10, 9, 5, 7, 7, 3, 2, 1, 4, 0, 7, 0, 3, 10, 10, 5, 10, 4, 7, 0, 2, 10, 9, 0, 2, 6, 10, 6, 9, 2, 1, 9, 8, 7, 2, 0, 7, 3, 6, 2, 1, 8, 0, 0, 0, 10, 4, 3, 5, 0, 8, 1, 8, 5, 1, 6, 0, 4, 4, 10, 2, 0, 5, 1, 1, 3, 3, 5, 2, 6, 5, 6, 0, 3, 8, 0, 1, 7, 0, 0, 9, 6, 10, 5, 9, 8, 9, 8, 7, 8, 10, 6, 3, 8, 0, 5, 7, 4, 3, 5, 7, 7, 0, 3, 10, 1, 3, 10, 2, 10, 3, 2, 6, 3, 10, 8, 10, 6, 0, 7, 6, 2, 10, 4, 0, 7, 4, 8, 8, 1, 7, 1, 4, 9, 7, 7, 8, 9, 8, 7, 2, 4, 9, 8, 8, 0, 8, 2, 10, 7, 3, 10, 8, 5, 1, 1, 3, 0, 5, 1, 7, 1, 7, 9, 2, 6, 9, 6, 10, 6, 1, 7, 8, 3, 6, 9, 3, 5, 9, 0, 9, 3, 5, 8, 4, 6, 8, 10, 8, 0, 9, 3, 7, 10, 4, 4, 2, 3, 7, 2, 10, 3, 5, 4, 9, 9, 2, 1, 2, 10, 4, 4, 4, 3, 5, 9, 7, 2, 0, 3, 6, 6, 7, 3, 9, 4, 6, 9, 7, 1, 3, 2, 3, 6, 6, 1, 7, 10, 0, 4, 10, 3, 5, 0, 10, 3, 10, 3, 0, 0, 1, 6, 6, 5, 9, 10, 5, 5, 9, 0, 5, 4, 1, 10, 2, 3, 1, 7, 9, 10, 10, 4, 3, 5, 9, 5, 4, 4, 8, 0, 1, 8, 1, 4, 6, 5, 6, 0, 6, 8, 6, 5, 6, 5, 7, 9, 5, 8, 8, 4, 2, 0, 0, 2, 9, 4, 9, 2, 6, 5, 2, 2, 8, 5, 4, 10, 8, 7, 7, 3, 4, 2, 0, 4, 3, 8, 6, 1, 7, 10, 10, 7, 4, 0, 6, 6, 0, 5, 6, 10, 3, 8, 3, 2, 4, 10, 4, 3, 0, 4, 10, 7, 6, 0, 4, 7, 0, 5, 2, 5, 2, 10, 9, 1, 10, 9, 6, 6, 5, 9, 10, 1, 3, 5, 2, 0, 6, 8, 5, 6, 3, 4, 8, 4, 0, 7, 0, 7, 9, 9, 1, 4, 6, 4, 5, 7, 3, 0, 4, 4, 9, 10, 5, 10, 3, 9, 6, 6, 2, 9, 4, 0, 4, 3, 3, 1, 7, 2, 1, 0, 2, 6, 7, 1, 1, 0, 3, 9, 8, 9, 4, 6, 3, 10, 7, 3, 1, 5, 2, 0, 3, 9, 5, 3, 3, 3, 1, 7, 5, 8, 10, 10, 8, 0, 2, 3, 3, 2, 9, 3, 1, 3, 9, 0, 1, 8, 2, 1, 6, 0, 6, 3, 1, 3, 1, 10, 5, 6, 0, 4, 7, 10 }, 79).PrintList();
s.MostCompetitive(new int[] { 2, 10, 6, 10, 8, 2, 7, 10, 0, 5, 1, 3, 3, 2, 8, 6, 10, 1, 2, 7, 7, 2, 8, 2, 0, 10, 5, 8, 1, 2, 4, 4, 3, 9, 6, 0, 0, 0, 10, 4, 7, 1, 2, 0, 6, 6, 0, 8, 5, 4, 4, 6, 8, 4, 10, 4, 4, 1, 5, 5, 6, 8, 3, 6, 3, 4, 6, 0, 7, 5, 5, 3, 7, 1, 4, 0, 8, 9, 4, 10, 5, 3, 3, 0, 9, 4, 10, 6, 10, 5, 5, 0, 0, 6, 1, 9, 1, 8, 10, 5, 2, 0, 9, 1, 3, 10, 5, 9, 6, 7, 6, 1, 10, 2, 3, 7, 3, 1, 4, 5, 6, 6, 5, 10, 1, 4, 6, 8, 10, 8, 3, 0, 7, 2, 10, 7, 8, 2, 1, 3, 7, 2, 4, 4, 7, 4, 7, 9, 10, 3, 7, 9, 6, 0, 9, 0, 6, 8, 0, 4, 3, 5, 5, 6, 2, 5, 4, 4, 3, 2, 8, 0, 6, 4, 9, 7, 7, 4, 10, 1, 2, 1, 10, 1, 10, 7, 10, 8, 6, 9, 1, 3, 10, 1, 6, 6, 6, 2, 6, 1, 8, 2, 1, 2, 10, 2, 5, 3, 5, 8, 6, 5, 9, 7, 10, 5, 1, 8, 0, 1, 2, 5, 8, 5, 8, 7, 2, 2, 8, 0, 4, 6, 7, 9, 3, 8, 0, 5, 6, 8, 0, 0, 10, 3, 9, 10, 10, 8, 0, 1, 3, 10, 0, 0, 7, 7, 5, 4, 2, 1, 4, 8, 4, 3, 2, 10, 0, 7, 8, 4, 3, 10, 8, 10, 2, 8, 7, 5, 10, 3, 2, 10, 5, 4, 1, 6, 2, 1, 4, 4, 7, 8, 5, 7, 10, 2, 3, 1, 7, 3, 2, 5, 5, 2, 2, 1, 10, 9, 3, 3, 4, 6, 3, 10, 6, 7, 5, 8, 0, 0, 2, 7, 6, 4, 8, 4, 0, 1, 9, 2, 6, 1, 8, 2, 7, 0, 7, 2, 7, 3, 8, 5, 2, 9, 7, 1, 3, 7, 3, 2, 8, 4, 1, 4, 3, 3, 6, 3, 8, 0, 5, 7, 8, 6, 1, 9, 7, 2, 9, 7, 4, 2, 0, 8, 4, 0, 4, 10, 9, 0, 6, 6, 9, 5, 9, 1, 2, 9, 7, 4, 5, 9, 9, 6, 4, 0, 0, 3, 5, 6, 2, 2, 8, 8, 1, 2, 10, 7, 6, 5, 8, 9, 9, 5, 0, 10, 10 }, 193).PrintList();


			s.MostCompetitive(new int[] { 84, 10, 71, 23, 66, 61, 62, 64, 34, 41, 80, 25, 91, 43, 4, 75, 65, 13, 37, 41, 46, 90, 55, 8, 85, 61, 95, 71 }, 24).PrintList();

			s.MostCompetitive(new int[] { 2, 4, 3, 3, 5, 4, 9, 6 }, 4).PrintList();
			s.MostCompetitive(new int[] { 11, 52, 57, 91, 47, 95, 86, 46, 87, 47, 70, 56, 54, 61, 89, 44, 3, 73, 1, 7, 87, 48, 17, 25, 49, 54, 6, 72, 97, 62, 16, 11, 47, 34, 68, 58, 14, 36, 46, 65, 2, 15 }, 18).PrintList();

						s.MostCompetitive(new int[] { 71, 18, 52, 29, 55, 73, 24, 42, 66, 8, 80, 2 }, 3).PrintList();
			s.MostCompetitive(new int[] { 3,5,2,6 }, 2).PrintList();

		}

		public class Solution
		{
			public int[] MostCompetitive(int[] nums, int k)
			{
				var orderNums = nums.OrderBy(n => n).ToList();
				List<int[]> ans = new List<int[]>();
				while (orderNums.Count > 0)
				{
					int i = 0;

					bool isNotFound = true;
					for (int j = i;j < nums.Length; j++)
					{
						if (nums[j] == orderNums[0])
						{
							isNotFound = false;
							i = j;
							break;
						}
					}

					if (!isNotFound)
					{

						var sub = nums.Skip(i).Take(nums.Length - i).ToList();
						if (sub.Count == k)
						{
							ans.Add(sub.ToArray());
						}
						else if (sub.Count > k)
						{
							for (int j = 1; j < sub.Count() - 1; j++)
							{
								//if(String.Join("", sub).StartsWith("0000000000000000000000"))
								//	Console.WriteLine();
								if (sub[j] <= sub[j + 1])
								{
									var minSec = sub.Skip(j + 2).Take(sub.Count - k).ToList();
									if (j < k - 1 &&
									    (sub[j + 1] > minSec.Min()))
									{
										sub.RemoveAt(j + 1);
										j -= 1;
									}


								}
								else if (sub[j] > sub[j + 1])
								{
									sub.RemoveAt(j);
									j -= 1;

								}

								if (sub.Count == k)
								{
									ans.Add(sub.ToArray());
									break;
								}
							}
							if (sub.Count > k)
							{
								ans.Add(sub.Take(k).ToArray());
							}
						}
						if (ans.Count > 0)
						{
							var orderAsn = ans.OrderBy(n => { return String.Join("_", n.Select(q => q.ToString().PadLeft(9, '_'))); }).ToList();
							return orderAsn[0];
						}
					}

					orderNums.RemoveAt(0);
				}

				return null;
			}
		}


	}
}
