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
			//Console.WriteLine(
			//			s.LongestSubarray(new[] { 8, 2, 4, 7 }, 4)
			//			);

			//[9,10,1,7,9,3,9,9]
			//7
			//Console.WriteLine(
			//	s.LongestSubarray(new[] { 9, 10, 1, 7, 9, 3, 9, 9 }, 7)
			//);



			//[2,2,2,4,4,2,5,5,5,5,5,2]
			//2
			Console.WriteLine(
				s.LongestSubarray(new[] { 2, 2, 2, 4, 4, 2, 5, 5, 5, 5, 5, 2 }, 2)
			);



			Console.WriteLine(
			s.LongestSubarray(new[] { 24, 12, 71, 33, 5, 87, 10, 11, 3, 58, 2, 97, 97, 36, 32, 35, 15, 80, 24, 45, 38, 9, 22, 21, 33, 68, 22, 85, 35, 83, 92, 38, 59, 90, 42, 64, 61, 15, 4, 40, 50, 44, 54, 25, 34, 14, 33, 94, 66, 27, 78, 56, 3, 29, 3, 51, 19, 5, 93, 21, 58, 91, 65, 87, 55, 70, 29, 81, 89, 67, 58, 29, 68, 84, 4, 51, 87, 74, 42, 85, 81, 55, 8, 95, 39 }, 87)
			);


		}




		/// <summary>
		/// 發現一個新規則  動態選取區域  應該是往右移棟時  起始點i就要直接++
		/// 這樣子對於某些case會快很多  外層的i如果在內層j一直推進
		
		/// </summary>
		public class Solution
		{
			public int LongestSubarray(int[] nums, int limit)
			{

				int currI = nums[0];
				int currLength = 1;
				int maxLeng = 1;

				//發現標註掉竟然又快20ms  還是20%
				//bool isAllSame = true;
				//for (int i = 1; i < nums.Length; i++)
				//{
				//	if (currI != nums[i])
				//	{
				//		isAllSame = false;
				//		currI = nums[i];
				//		if (currLength > maxLeng)
				//			maxLeng = currLength;
				//		currLength = 1;
				//	}
				//	else
				//	{
				//		currLength++;
				//	}
				//}

				//if (limit == 0)
				//	return maxLeng;
				////if (isAllSame)
				//	return nums.Length;

				//maxLeng -= 1;
				List<int> numL = nums.ToList();
				List<int> curr = new List<int>();

				for (int i = 0; i < maxLeng; i++)
				{
					curr.Add(numL[i]);
				}


				int max = 0, min = int.MaxValue;
				if (curr.Any())
				{
					max = curr.Max();
					min = curr.Min();
				}


				for (int i = 0; i < numL.Count; i++)
				{
					int end = i + maxLeng;

					if (end > numL.Count)
						break;

					for (int j = end; j < numL.Count; j++)
					{
						curr.Add(numL[j]);

						//if (j + curr.Count >= numL.Count)
						//	break;

						if (numL[j] > max)
							max = numL[j];
						if (numL[j] < min)
							min = numL[j];

						if (Math.Abs(max - min) <= limit)
						{
							if (curr.Count > maxLeng)
								maxLeng = curr.Count;
						}
						if (Math.Abs(max - min) > limit)
						{
							int c0 = curr[0];
							curr.RemoveAt(0);

							i++;//

							if (curr.Any())
							{
								if (c0 == max)
									max = curr.Max();
								if (c0 == min)
									min = curr.Min();


							}
						}


					}

				}

				return maxLeng;
			}
		}




		/// <summary>
		/// 發現一個新規則  動態選取區域  應該是往右移棟時  起始點i就要直接++
		/// 這樣子對於某些case會快很多  外層的i如果在內層j一直推進
		/// 那外層不用跑幾次就結束了
		///
		/// 之前都沒想到  j全部輪完之後  i才++ 等於j做過的又再重複做一次
		/// 而且右移之後的curr  要取幾個  長度都會亂掉
		/// 因為到下一次i  curr的長度是已經跑到底的  已經不適用目前的i了
		/// 一知道j內i++  就省掉一堆code  
		///  
		/// 但是這樣還是在20%   最後一個最明顯的  就是curr.Max Min一直計算
		/// 這邊直接想確實不容易想到怎麼在優化
		/// 因為一旦選取區往右移  元素就變動了  此時最前面被移除的  可能是最大  也可能是最小
		/// 所以要重新找
		///
		/// 但就是在這邊  比對90%的解  竟然想到了一個方式去處理
		/// 來跟著試試
		/// 
		/// </summary>
		public class Solution
		{
			public int LongestSubarray(int[] nums, int limit)
			{

				int currI = nums[0];
				int currLength = 1;
				int maxLeng = 1;

				//發現標註掉竟然又快20ms  還是20%
				//bool isAllSame = true;
				//for (int i = 1; i < nums.Length; i++)
				//{
				//	if (currI != nums[i])
				//	{
				//		isAllSame = false;
				//		currI = nums[i];
				//		if (currLength > maxLeng)
				//			maxLeng = currLength;
				//		currLength = 1;
				//	}
				//	else
				//	{
				//		currLength++;
				//	}
				//}

				//if (limit == 0)
				//	return maxLeng;
				////if (isAllSame)
				//	return nums.Length;

				//maxLeng -= 1;
				List<int> numL = nums.ToList();
				List<int> curr = new List<int>();

				for (int i = 0; i < maxLeng; i++)
				{
					curr.Add(numL[i]);
				}


				int max = 0, min = int.MaxValue;
				if (curr.Any())
				{
					max = curr.Max();
					min = curr.Min();
				}


				for (int i = 0; i < numL.Count; i++)
				{
					int end = i + maxLeng;

					if (end > numL.Count)
						break;

					for (int j = end; j < numL.Count; j++)
					{
						curr.Add(numL[j]);

						//if (j + curr.Count >= numL.Count)
						//	break;

						if (numL[j] > max)
							max = numL[j];
						if (numL[j] < min)
							min = numL[j];

						if (Math.Abs(max - min) <= limit)
						{
							if (curr.Count > maxLeng)
								maxLeng = curr.Count;
						}
						if (Math.Abs(max - min) > limit)
						{
							int c0 = curr[0];
							curr.RemoveAt(0);

							i++;//

							if (curr.Any())
							{
								if (c0 == max)
									max = curr.Max();
								if (c0 == min)
									min = curr.Min();


							}
						}


					}

				}

				return maxLeng;
			}
		}





		/// <summary>
		/// 每次都計算 curr.Min Nax 是很明顯的優化地方  n^2  改成紀錄min max 新加入的比對  有更大或更小才更新  否則直接維持  因為每次的確只加一個數字  + 下一個和前個相同  continue
		/// 速度 22%  快一倍了 488ms
		/// </summary>
		public class Solution_V3
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
					int end = i + maxLeng; // - 1;
					if (end < 0)
						end = 0;

					if (end > numL.Count)
						break;



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
				for (int i = 1; i < nums.Length; i++)
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
