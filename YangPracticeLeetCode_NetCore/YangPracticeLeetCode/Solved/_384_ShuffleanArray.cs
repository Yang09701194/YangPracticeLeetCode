using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _384_ShuffleanArray
	{

		public static void Test()
		{
			//Solution s = new Solution();

			////Console.WriteLine(s.NumPoints());

			//Console.WriteLine(s.SpecialArray(new int[] { 3, 5 }));

		}


		/// <summary>
		/// Time complexity : \mathcal{O}(n)O(n)
		///The Fisher-Yates algorithm runs in linear time, as generating a random index and swapping two values can be done in constant time.
		///Space complexity : \mathcal{ O}(n)O(n)
		///Although we managed to avoid using linear space on the auxiliary array from the brute force approach, we still need it for reset, so we're stuck with linear space complexity.
		/// </summary>
		public class Solution
		{
			public int[] oriArr = null;
			public int[] shuffleArr = null;

			public Solution(int[] nums)
			{
				shuffleArr = nums;
				oriArr = nums.ToArray();

			}

			/** Resets the array to its original configuration and return it. */
			public int[] Reset()
			{
				return oriArr.ToArray();
			}

			Random rnd = new Random(Guid.NewGuid().GetHashCode());

			/** Returns a random shuffling of the array. */
			public int[] Shuffle()
			{
				//稍微改一下 去掉 i j 相同重取的可能性 直接 +1 以不重複
				// 就再進10%   336ms  81.78%
				// 應該主要差在這
				// 這種寫法都算是100%  只是誤差的快慢    320的解跑個幾次 也會變340
				int i = rnd.Next(oriArr.Length);
				int j = rnd.Next(oriArr.Length);
				if (i == j)
					j += 1;

				int temp = shuffleArr[i];
				shuffleArr[i] = shuffleArr[j];
				shuffleArr[j] = temp;

				return shuffleArr;
			}
		}







		/// <summary>
		/// 完全自己寫的  一次過關  不錯
		/// 也是有 71%   340ms
		///
		/// 看來這題真的常考題  看過不少次
		/// 看Sol才知是 Fisher-Yates Algorithm
		///
		/// 直接看描述有點難知道細節動作  用詞不熟
		/// https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
		///  Write down the numbers from 1 through N.
		/// Pick a random number k between one and the number of unstruck numbers remaining(inclusive).
		/// Counting from the low end, strike out the kth number not yet struck out, and write it down at the end of a separate list.
		/// Repeat from step 2 until all the numbers have been struck out.
		/// The sequence of numbers written down in step 3 is now a random permutation of the original numbers. 
		///
		/// 看影片簡單多了
		/// https://www.youtube.com/watch?v=tLxBwSL3lPQ
		/// 就跟我之前學的交換相同
		///
		/// but for each possible permutation of the array to be truly
		/// equally likely
		///
		///Sol 1   random 從 n arr 移除元素 也是滿有趣的想法  可惜n^2
		///
		/// 
		/// </summary>
		public class Solution_V2
		{
			public int[] oriArr = null;
			public int[] shuffleArr = null;

			List<int[]> permutationIndex = new List<int[]>();


			public Solution_V2(int[] nums)
			{
				shuffleArr = nums;
				oriArr = nums.ToArray();

			}

			/** Resets the array to its original configuration and return it. */
			public int[] Reset()
			{
				return oriArr.ToArray();
			}

			Random rnd = new Random(Guid.NewGuid().GetHashCode());

			/** Returns a random shuffling of the array. */
			public int[] Shuffle()
			{
				int i = 0, j = 0;
				while (i == j)
				{
					i = rnd.Next(oriArr.Length);
					j = rnd.Next(oriArr.Length);
				}

				int temp = shuffleArr[i];
				shuffleArr[i] = shuffleArr[j];
				shuffleArr[j] = temp;

				return shuffleArr;
			}
		}



		/// <summary>
		/// Sol 2 跟這個很像  跟我上面不同是
		/// 他是對 1~n 全部換一次
		/// 不過我新寫的 每次只換一次 i j還是過  也快100ms
		///
		/// 
		/// </summary>
		public class Solution_V1
		{
			private int[] initNums = new int[] { };
			public Solution_V1(int[] nums)
			{
				initNums = nums;
			}

			/** Resets the array to its original configuration and return it. */
			public int[] Reset()
			{
				return initNums;
			}

			/** Returns a random shuffling of the array. */
			public int[] Shuffle()
			{
				int[] numCopy = initNums.ToArray();
				Random r = new Random();
				for (int i = initNums.Length - 1; i >= 1; i--)
				{
					int j = r.Next(0, i + 1);
					int temp = numCopy[i];
					numCopy[i] = numCopy[j];
					numCopy[j] = temp;
				}

				return numCopy;
			}

		}


	}
}
