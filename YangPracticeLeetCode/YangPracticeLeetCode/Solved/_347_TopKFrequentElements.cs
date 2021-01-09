using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YangPracticeLeetCode.Helper;

namespace YangPracticeLeetCode.Solved
{
	class _347_TopKFrequentElements
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			//Console.WriteLine(s.SpecialArray(new int[] { 3, 5 }));

		


			//        O nlogn (Order)  O n  (Bucket)
			//  筆   時間
			//  
			//  後面反超
			//
			
			int[] testCases = new int[]
			{
				//300, 3000, 30000, 300000,3000000, 30000000,
				300000000
			};

			foreach (int testCase in testCases)
			{
				List<int> test = new List<int>();
				//for (int i = 1; i < 10000; i++)
				//{
				//	for (int j = 0; j < i; j++)
				//	{
				//		test.Add(i);
				//	}
				//}
				Random r = new Random();
				for (int i = 1; i < testCase; i++)
				{
					test.Add(r.Next(testCase/10000));
				}

				int topK = testCase / 10000;
				var ta = test.ToArray();
				Console.WriteLine("length: " + ta.Length + " top: " + topK);
				Solution_RemoveMax so = new Solution_RemoveMax();
				Solution_BucketSort sb = new Solution_BucketSort();
				TimerY t = TimerY.New();
				so.TopKFrequent(ta, topK);
				Console.WriteLine("so " + t.TimingMs());
				t = TimerY.New();
				sb.TopKFrequent(ta, topK);
				Console.WriteLine("sb " + t.TimingMs());

			}
			// length: 299999999 top: 30000

			// RemoveMax
			// 13673.8614    //數每個數的freq
			// 3.9296        //freq分群
			// 3.9041        //取前k
			// 13686.5751

			// Bucket
			// 15042.0228
			// 0.974
			// 2205.1969
			// sb 17252.1434

			// 此二解  前兩步驟做的事情其實差不多  時間也差不多  都是毫秒
			// 只有最後一步有巨大差距
			// 應該是因為  bucket 會一堆空值  因為他的freq bucket 開太細太大了
			// removemax 很精準  因為她就是所有存在的freq分類 很精準
			// 所以一直max remove  動作最少量
			//  本來 max 就是怕怕的 O n   遞減就是  怕的  n^2
			//  但是相較之下  freq少量精準    所以反而比 bucket快
			//  這個級距是 bucket是開相同長度 3 億
			//  實際removemax  因為 30000個數字  最平均會是freq = 10000  所以頂多30000 可能少很多
			//  所以就差10000倍   實際跑差1000倍左右
			//  所以 O 不一定完全決定   跟做法還是有關  做法不同  O 的 n就又不同了
			//  或者是說   bucket 是 O n    removeMax 是 O k^2
			//  
			//  但是這個 k 就很有趣
			//  k 小的話  不用說  最後一步取 一定超快
			// 要比時間最長 考慮 k 最大    因為  k個數 * 平均freq =  陣列長n
			// 加上最後其實 是 freq 或 k 兩者小的值  決定時間
			//  freq不同數如果小 k 再大 一下子就加滿    每個freq都有大量數
			//  k小   freq再大  也只取k個
			//  
			//  所以因為   k * freq = n
			//  所以 k freq 的 min 要最大  就是開根號  
			//  根號一下去  馬上就小很多了   就快很多  n^1/2  
			//  所以 O用  k  freq 決定   那就真的小很多  也快很多
			//  所以 O k freq  比 O n 一定快很多
			//

			 
		}


		/// <summary>
		/// 
		/// </summary>
		public class Solution_RemoveMax
		{
			public int[] TopKFrequent(int[] nums, int k)
			{
				var numFreq = new Dictionary<int, int>();

				var t = TimerY.New();

				foreach (int num in nums)//數每個數的freq
				{
					if (numFreq.ContainsKey(num))
					{
						numFreq[num]++;
					}
					else
					{
						numFreq.Add(num, 1);
					}
				}

				t.TimingMs(true);
				t = TimerY.New();

				var freqNum = new Dictionary<int, HashSet<int>>();
				foreach (int num in numFreq.Keys)//freq分群
				{
					int freq = numFreq[num];
					if (freqNum.ContainsKey(freq))
					{
						freqNum[freq].Add(num);
					}
					else
					{
						freqNum.Add(freq, new HashSet<int> { num });
					}
				}

				t.TimingMs(true);
				t = TimerY.New();

				List<int> res = new List<int>();
				while (k > 0)//取前k
				{
					int maxFreq = freqNum.Keys.Max();
					res.AddRange(freqNum[maxFreq].ToList());
					k -= freqNum[maxFreq].Count();
					freqNum.Remove(maxFreq);
				}

				t.TimingMs(true);
				t = TimerY.New();

				return res.ToArray();
			}
		}


		public class Solution_BucketSort
		{
			public int[] TopKFrequent(int[] nums, int k)
			{

				List<int>[] bucket = new List<int>[nums.Length + 1];
				Dictionary<int, int> frequencyDictionary = new Dictionary<int, int>();

				var t = TimerY.New();
				foreach (int n in nums)//數每個數的freq
				{
					if (frequencyDictionary.ContainsKey(n))
						frequencyDictionary[n]++;
					else
						frequencyDictionary[n] = 1;
				}

				t.TimingMs(true);
				t = TimerY.New();

				foreach (int key in frequencyDictionary.Keys)//freq分群
				{
					int frequency = frequencyDictionary[key];
					if (bucket[frequency] == null)
					{
						bucket[frequency] = new List<int>();
					}
					bucket[frequency].Add(key);
				}
				t.TimingMs(true);
				t = TimerY.New();


				List<int> res = new List<int>();//取前k
				for (int pos = bucket.Length - 1; pos >= 0 && res.Count() < k; pos--)
				{
					if (bucket[pos] != null)
					{
						res.AddRange(bucket[pos]);
					}
					//else
					//{
					//	//Console.WriteLine("null");
					//}
				}
				t.TimingMs(true);
				t = TimerY.New();


				return res.ToArray();
			}
		}


	}
}
