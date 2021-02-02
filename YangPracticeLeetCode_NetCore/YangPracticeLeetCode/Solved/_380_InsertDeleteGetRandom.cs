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
		/// �o���o��  ���M�ٯ�Q��  �s�ߤ@�ʳ� ElementAt ����A�令List [] �u��
		/// 152 ms, faster than 83.56% of
		/// �h�e�X���i�H�� 144 ms  97%
		/// ��100%�]�O�o��  ���ӳ̨ΤF
		///
		/// �S���a��b  List ������  ���D�ֳt  index�����bdic
		/// ������  �N�̫ᤸ������ idx dic��s��idx ����ls��
		/// 
		/// �o�ۤ]�O sol ���Ѫk  ��  �A��y
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
		/// �]���ۼg  ���i�B
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
		/// ���Ӥ]�� ok ���ۼg  Dic
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
