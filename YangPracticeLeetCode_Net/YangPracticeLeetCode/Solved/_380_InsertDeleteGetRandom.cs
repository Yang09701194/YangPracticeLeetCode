using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _380_InsertDeleteGetRandom
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			//Console.WriteLine(s.SpecialArray(new int[] { 3, 5 }));

		}

		/// <summary>
		/// 這很聰明  竟然還能想到  連唯一缺陷 ElementAt 都能再改成List [] 優化
		/// 152 ms, faster than 83.56% of
		/// 多送幾次可以到 144 ms  97%
		/// 看100%也是這招  應該最佳了
		///
		/// 特殊的地方在  List 的元素  為求快速  index紀錄在dic
		/// 移除時  將最後元素移到 idx dic更新為idx 移除ls尾
		/// 
		/// 這招也是 sol 的解法  結  再到y
		/// 
		/// </summary>
		public class RandomizedSet
		{

			Dictionary<int, int> d = new Dictionary<int, int>();
			List<int> l = new List<int>();

			/** Initialize your data structure here. */
			public RandomizedSet()
			{

			}

			/** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
			public bool Insert(int val)
			{
				if (d.ContainsKey(val))
				{
					return false;
				}
				else
				{
					l.Add(val);
					d[val] = l.Count - 1;
					return true;
				}
			}

			/** Removes a value from the set. Returns true if the set contained the specified element. */
			public bool Remove(int val)
			{
				if (d.ContainsKey(val))
				{
					int index = d[val];
					int last = l[l.Count - 1];
					l[index] = last;
					d[last] = index;
					d.Remove(val);
					l.RemoveAt(l.Count - 1);
					return true;
				}
				else
				{
					return false;
				}
			}

			Random rnd = new Random();
			/** Get a random element from the set. */
			public int GetRandom()
			{
				return l[rnd.Next(l.Count)];
			}
		}


		/// <summary>
		/// 也全自寫  有進步
		/// Runtime: 236 ms, faster than 28.94% of C# online submissions for Insert Delete GetRandom O(1).
		/// Memory Usage: 41 MB, less than 67.82% of C# online submissions for Insert Delete GetRandom O(1).
		/// </summary>
		public class RandomizedSet_V2
		{

			HashSet<int> h = new HashSet<int>();

			/** Initialize your data structure here. */
			public RandomizedSet_V2()
			{

			}

			/** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
			public bool Insert(int val)
			{
				return h.Add(val);
			}

			/** Removes a value from the set. Returns true if the set contained the specified element. */
			public bool Remove(int val)
			{
				return h.Remove(val);
			}

			Random rnd = new Random();
			/** Get a random element from the set. */
			public int GetRandom()
			{
				int len = h.Count;
				return h.ElementAt(rnd.Next(len));
			}
		}


		/// <summary>
		/// 應該也還 ok 全自寫  Dic
		/// 
		/// Runtime: 248 ms, faster than 24.54% of C# online submissions for Insert Delete GetRandom O(1).
		//Memory Usage: 42.7 MB, less than 23.15% of C# online submissions for Insert Delete GetRandom O(1).
		/// </summary>
		public class RandomizedSet_V1
		{

			Dictionary<int, int> dic = new Dictionary<int, int>();

			/** Initialize your data structure here. */
			public RandomizedSet_V1()
			{

			}

			/** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
			public bool Insert(int val)
			{
				if (dic.ContainsKey(val))
				{
					return false;
				}
				else
				{
					dic[val] = val;
					return true;
				}
			}

			/** Removes a value from the set. Returns true if the set contained the specified element. */
			public bool Remove(int val)
			{
				return dic.Remove(val);
			}

			Random rnd = new Random();
			/** Get a random element from the set. */
			public int GetRandom()
			{
				int len = dic.Count;
				return dic.ElementAt(rnd.Next(len)).Value;
			}
		}
	}
}
