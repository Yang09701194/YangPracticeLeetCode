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

			//[2,2,2,4,4,2,5,5,5,5,5,2]
			//2
			//Console.WriteLine(
			//	s.LongestSubarray(new[] { 2, 2, 2, 4, 4, 2, 5, 5, 5, 5, 5, 2 }, 2)
			//);



			Console.WriteLine(
			s.LongestSubarray(new[] { 24, 12, 71, 33, 5, 87, 10, 11, 3, 58, 2, 97, 97, 36, 32, 35, 15, 80, 24, 45, 38, 9, 22, 21, 33, 68, 22, 85, 35, 83, 92, 38, 59, 90, 42, 64, 61, 15, 4, 40, 50, 44, 54, 25, 34, 14, 33, 94, 66, 27, 78, 56, 3, 29, 3, 51, 19, 5, 93, 21, 58, 91, 65, 87, 55, 70, 29, 81, 89, 67, 58, 29, 68, 84, 4, 51, 87, 74, 42, 85, 81, 55, 8, 95, 39 }, 87)
			);


		}





		/// <summary>
		/// 每次都計算 curr.Min Nax 是很明顯的優化地方  n^2  改成紀錄min max 新加入的比對  有更大或更小才更新  否則直接維持  因為每次的確只加一個數字  + 下一個和前個相同  continue
		/// 速度 22%  快一倍了 488ms
		/// </summary>
		public class Solution
		{
			public int LongestSubarray(int[] nums, int limit)
			{

				int currI = nums[0];
				int currLength = 1;
				int maxLeng = 1;
				bool isAllSame = true;
				for (int i = 1; i < nums.Length; i++)
				{
					if (currI != nums[i])
					{
						isAllSame = false;
						currI = nums[i];
						if (currLength > maxLeng)
							maxLeng = currLength;
						currLength = 1;
					}
					else
					{
						currLength++;
					}
				}

				if (limit == 0)
					return maxLeng;
				if (isAllSame)
					return nums.Length;

				maxLeng -= 1;
				List<int> numL = nums.ToList();

				List<int> curr = new List<int>();
				for (int i = 0; i < maxLeng; i++)
				{
					curr.Add(nums[i]);
				}


				int max = -1, min = int.MaxValue;
				if (curr.Any())
				{
					max = curr.Max();
					min = curr.Min();
				}


				for (int i = 0; i < numL.Count; i++)
				{
					//if(i != 0)
					//	curr.RemoveAt(0);
					int end = i + maxLeng; // - 1;
					if (end < 0)
						end = 0;

					if (end > numL.Count)
						break;

					//for (int j = end; j < numL.Count; j++)
					//{
					//	curr.Add(numL[j]);
					//}

					//int start = curr.Any() ? i+1 : 0;
					for (int j = end; j < numL.Count; j++)
					{
						curr.Add(numL[j]);
						if (j > end && numL[end] == numL[j])
						{
							if (curr.Count > maxLeng)
								maxLeng = curr.Count;
							continue;
						}

						if (numL[j] > max)
							max = numL[j];
						if (numL[j] < min)
							min = numL[j];


						if (Math.Abs(max - min) <= limit)
						{
							if (curr.Count > maxLeng)
								maxLeng = curr.Count;
						}
						else
						{
							int c0 = curr[0];
							curr.RemoveAt(0);
							if (curr.Any())
							{
								if (c0 == max)
									max = curr.Max();
								if (c0 == min)
									min = curr.Min();
							}
							
								
							break;
						}


					}
				}

				return maxLeng;

			}
		}



		/// <summary>
		/// 改良自 v1  pass  速度 9%  1s  主要是一開始不論limit 都直接算max length
		/// </summary>
		public class Solution_V2
		{
			public int LongestSubarray(int[] nums, int limit)
			{
			
				int currr = nums[0];
				int currLength = 1;
				int maxLeng = 1;
				bool isAllSame = true;
				for (int i =1; i < nums.Length; i++)
				{
					if (currr != nums[i])
					{
						isAllSame = false;
						currr = nums[i];
						if (currLength > maxLeng)
							maxLeng = currLength;
						currLength = 1;
					}
					else
					{
						currLength++;
					}
				}

				if (limit == 0)
					return maxLeng;
				if (isAllSame)
					return nums.Length;

				maxLeng -= 1;
				List<int> numL = nums.ToList();

				List<int> curr = new List<int>();
				for (int i = 0; i < maxLeng; i++)
				{
					curr.Add(nums[i]);
				}

				for (int i = 0; i < numL.Count; i++)
				{
					//if(i != 0)
					//	curr.RemoveAt(0);
					int end = i + maxLeng; // - 1;
					if (end < 0)
						end = 0;

					if (end > numL.Count)
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
				
			}
		}




		/// <summary>
		/// 之前寫的   過了這麼久一時還想步道之前這個解法
		/// 一開始想就會覺得很飄渺  覺得這個解可能存在於任何地方  開始結尾也可以任意變動
		/// 所以很難找出一個有效的方法  因為看到他會一直變
		///
		/// 但是再看之前這個解法  瞬間就把情況看出關鍵歸納定型  就可以處理了
		/// 重點就是一個動態前後擴展的區間  一直動態往右移動測量
		/// 而且搭配maxlength機制  maxlength越大  直接往後跳的距離也越大  也越快看出到底長度會不會更長
		/// 找到更長的 或沒找到就在往右移一位  相當於把目前區段的第一個移除
		///
		/// 應該之前有過   現在再測 TLE  是 一堆1 + 11 12 13  前面很多相同  最後少量不同
		/// 58 / 60 test cases passed.
		/// </summary>
		public class Solution_V1
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

					if (end > numL.Count)
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
