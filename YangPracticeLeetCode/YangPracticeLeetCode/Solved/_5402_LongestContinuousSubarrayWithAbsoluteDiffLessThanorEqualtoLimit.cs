using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5402_LongestContinuousSubarrayWithAbsoluteDiffLessThanorEqualtoLimit
	{
		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(
			//s.LongestSubarray(new[] { 4, 2, 2, 2, 4, 4, 2, 2 }, 0)
			//);
			Console.WriteLine(
						s.LongestSubarray(new[] { 8, 2, 4, 7 }, 4)
						);

			Console.WriteLine(
			s.LongestSubarray(new[] { 24, 12, 71, 33, 5, 87, 10, 11, 3, 58, 2, 97, 97, 36, 32, 35, 15, 80, 24, 45, 38, 9, 22, 21, 33, 68, 22, 85, 35, 83, 92, 38, 59, 90, 42, 64, 61, 15, 4, 40, 50, 44, 54, 25, 34, 14, 33, 94, 66, 27, 78, 56, 3, 29, 3, 51, 19, 5, 93, 21, 58, 91, 65, 87, 55, 70, 29, 81, 89, 67, 58, 29, 68, 84, 4, 51, 87, 74, 42, 85, 81, 55, 8, 95, 39 }, 87)
			);


		}

		public class Solution
		{
			public int LongestSubarray(int[] nums, int limit)
			{
				if (limit == 0)//這段去掉也可以過  //0  檢查連續相同數列
				{
					int currr = -1;
					int currLength = 0;
					int maxLength = 0;
					foreach (int num in nums)
					{
						if (currr != num)
						{
							currr = num;
							if (currLength > maxLength)
								maxLength = currLength;
							currLength = 1;
						}
						else
						{
							currLength++;
						}
					}

					return maxLength;

				}

				int first = nums[0];//這段要加才不會timeout
				bool isAllSame = true;
				foreach (int num in nums)//全部相同直接回傳參數長度  
				{
					if (num != first)
					{
						isAllSame = false;
						break;
					}
				}
				if (isAllSame)
					return nums.Length;


				int maxLeng = 0;
				List<int> numL = nums.ToList();

				List<int> curr = new List<int>();

				for (int i = 0; i < numL.Count; i++)
				{
					//if(i != 0)
					//	curr.RemoveAt(0);
					int end = i + maxLeng; // - 1;
					if (end < 0)
						end = 0;

					if(end > numL.Count)
						break;

					//for (int j = end; j < numL.Count; j++)
					//{
					//	curr.Add(numL[j]);
					//}

					//int start = curr.Any() ? i+1 : 0;
					for (int j = end; j < numL.Count; j++)
					{
						curr.Add(numL[j]);

						int max = curr.Max();
						int min = curr.Min();

						if (Math.Abs(max - min) <= limit)
						{
							if (curr.Count > maxLeng)
								maxLeng = curr.Count;
						}
						else
						{
							curr.RemoveAt(0);
							break;
						}


					}
				}

				return maxLeng;

				//	List<int> numL = nums.ToList();
				//	while (numL.Count > 0)
				//	{
				//		int max = numL.Max();
				//		int min = numL.Min();

				//		if (Math.Abs(max - min) <= limit)
				//			return numL.Count;

				//		if (numL[0] == max || numL[0] == min)
				//		{
				//			numL.RemoveAt(0);
				//		}
				//		else if (numL[numL.Count - 1] == max || numL[numL.Count - 1] == min)
				//		{
				//			numL.RemoveAt(numL.Count - 1);
				//		}
				//		else
				//		{
				//			numL.RemoveAt(0);

				//		}

				//		//var numRemoveLeft = numL.ToList();
				//		//numRemoveLeft.RemoveAt(0);
				//		//max = numRemoveLeft.Max();
				//		//min = numRemoveLeft.Min();
				//		//if (Math.Abs(max - min) <= limit)
				//		//	return numRemoveLeft.Count;

				//		//var numRemoveRight = numL.ToList();
				//		//numRemoveRight.RemoveAt(numRemoveRight.Count - 1);
				//		//max = numRemoveRight.Max();
				//		//min = numRemoveRight.Min();
				//		//if (Math.Abs(max - min) <= limit)
				//		//	return numRemoveRight.Count;

				//		//if (numRemoveRight.Count > 0)
				//		//{
				//		//	numRemoveRight.RemoveAt(0);
				//		//	numL = numRemoveRight;
				//		//}
				//		//else
				//		//{
				//		//	break;
				//		//}
				//	}

				//	return 0;

			}
		}


	}
}
