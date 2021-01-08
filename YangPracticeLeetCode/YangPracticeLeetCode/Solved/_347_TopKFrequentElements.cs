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

			List<int> test = new List<int>();
			//for (int i = 1; i < 10000; i++)
			//{
			//	for (int j = 0; j < i; j++)
			//	{
			//		test.Add(i);
			//	}
			//}
			Random r = new Random();
			for (int i = 1; i < 3000000; i++)
			{
				test.Add(r.Next(10000));
			}
			


			//        O nlogn (Order)  O n  (Bucket)
			//  筆   時間
			//
			//  後面反超
			//
			int k = 1000;
			var ta = test.ToArray();
			Console.WriteLine(ta.Length + " " + k);
			Solution_Order so = new Solution_Order();
			Solution_BucketSort sb = new Solution_BucketSort();
			TimerY t = TimerY.New();
			so.TopKFrequent(ta, k);
			Console.WriteLine("so " + t.TimingMs());
			t = TimerY.New();
			sb.TopKFrequent(ta, k);
			Console.WriteLine("sb " + t.TimingMs());

		}


		/// <summary>
		/// 一般來說
		/// </summary>
		public class Solution_Order
		{
			public int[] TopKFrequent(int[] nums, int k)
			{
				var numFreq = new Dictionary<int, int>();
				foreach (int num in nums)
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

				var freqNum = new Dictionary<int, HashSet<int>>();
				foreach (int num in numFreq.Keys)
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

				List<int> res = new List<int>();
				while (k > 0)
				{
					int maxFreq = freqNum.Keys.Max();
					res.AddRange(freqNum[maxFreq].ToList());
					k -= freqNum[maxFreq].Count();
					freqNum.Remove(maxFreq);
				}

				return res.ToArray();
			}
		}


		public class Solution_BucketSort
		{
			public int[] TopKFrequent(int[] nums, int k)
			{

				List<int>[] bucket = new List<int>[nums.Length + 1];
				Dictionary<int, int> frequencyDictionary = new Dictionary<int, int>();

				foreach (int n in nums)
				{
					if (frequencyDictionary.ContainsKey(n))
						frequencyDictionary[n]++;
					else
						frequencyDictionary[n] = 1;
				}

				foreach (int key in frequencyDictionary.Keys)
				{
					int frequency = frequencyDictionary[key];
					if (bucket[frequency] == null)
					{
						bucket[frequency] = new List<int>();
					}
					bucket[frequency].Add(key);
				}

				List<int> res = new List<int>();
				for (int pos = bucket.Length - 1; pos >= 0 && res.Count() < k; pos--)
				{
					if (bucket[pos] != null)
					{
						res.AddRange(bucket[pos]);
					}
				}
				return res.ToArray();
			}
		}


	}
}
