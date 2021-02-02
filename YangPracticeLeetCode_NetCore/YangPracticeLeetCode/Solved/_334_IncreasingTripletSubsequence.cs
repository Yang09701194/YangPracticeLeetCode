using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _334_IncreasingTripletSubsequence
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			Console.WriteLine(s.IncreasingTriplet(new int[] { 1, 1, -2, 6 }));
			//Console.WriteLine(s.IncreasingTriplet(new int[] { 1, 2, 3, 4, 5 }));
			//Console.WriteLine(s.IncreasingTriplet(new int[] { 5, 4, 3, 2, 1 }));
			//Console.WriteLine(s.IncreasingTriplet(new int[] { 2, 1, 5, 0, 4, 6 }));

		}



		/// <summary>
		///
		/// 己成功  改一次  pass
		/// 提示直接說  能不能 O n
		/// 那當然直接跳過思考 直覺的那種倆倆比較的 n^2  22相比  就是那種右下的梯形  1~n  2~n ....
		/// 比兩個  n^2 * n  應該是 n^3 這個處理會真的很複雜    因為要記錄每個 左小於大  的兩元素組
		/// 然後再前後比對   後面的組的前元素   大於  前組的後元素  就是true 
		///
		/// 直接跳過這種思路  來想 O n
		/// 怎麼走一遍就知道有三點連續上升
		/// 上升聯想到圖  就畫走勢圖
		/// 漸漸就會想到   先上再下再上   只要後面的上  高於前面的上   不用  更簡化只要高過於前面的下 就算低於前上 就是上升
		/// 所以只要往下的路段  就是紀錄最低點
		/// 接下來找次低點  在一個點高於次低點  就成立   就O n了
		///
		/// Runtime: 88 ms, faster than 91.75% of C# online submissions for Increasing Triplet Subsequence.
		/// Memory Usage: 25.2 MB, less than 81.75% of C# online submissions for Increasing Triplet Subsequence.
		/// Next challenges:
		///
		/// 
		/// </summary>
		public class Solution
		{
		
			public bool IncreasingTriplet(int[] nums)
			{
		
				int _1stLowestIdx = -1;
				int _2stLowestIdx = -1;
				int _3stLowestIdx = -1;
				_1stLowestIdx = 0;
				for (int i = 1; i < nums.Length; i++)
				{
					//  這邊有一個  case  如果寫 >  前二數 1 1  就會直接進下個if
					//  然後就把  2st  設成  第二個 1  就錯了   所以要用  >=  就能排除掉相等的情況
					if (nums[_1stLowestIdx] >= nums[i])
					{
						_1stLowestIdx = i;
					}
					else if (_2stLowestIdx == -1)
					{
						_2stLowestIdx = i;
					}
					else if (_2stLowestIdx != -1 && nums[_2stLowestIdx] > nums[i])
					{
						_2stLowestIdx = i;
					}
					else if (_2stLowestIdx != -1 && nums[i] > nums[_2stLowestIdx])
					{
						return true;
					}

				}

				return false;

			}

		}

		// 這題很不錯   上面想的  跟  Sol  完全相同
		// Sol 也只有一個  長篇多字   因想同   所以都可省略不看  good
		//
		//
		// class Solution {
		//     public boolean increasingTriplet(int[] nums) {
		//         int first_num = Integer.MAX_VALUE;
		//         int second_num = Integer.MAX_VALUE;
		//         for (int n: nums) {
		//             if (n <= first_num) {
		//                 first_num = n;
		//             } else if (n <= second_num) {
		//                 second_num = n;
		//             } else {
		//                 return true;
		//             }
		//         }
		//         return false;
		//     }
		// }



	}

}

