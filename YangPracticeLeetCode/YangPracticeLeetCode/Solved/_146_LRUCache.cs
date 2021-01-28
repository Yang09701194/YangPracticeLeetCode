using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _146_LRUCache
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			LRUCache l = new LRUCache(3);

			l.Put(1, 11);
			l.Put(2, 22);
			l.Put(3, 33);
			l.Put(5, 55);
			l.Get(3);
			l.Get(3);
			l.Get(3);
			l.Get(2);
			l.Get(2);
			l.Put(6, 66);

		}

		/// <summary>
		/// Runtime: 236 ms, faster than 83.37% of C# online submissions for LRU Cache.
		/// Memory Usage: 49.5 MB, less than 84.70% of C# online submissions for LRU Cache.
		///
		/// �o�Ӧh���X����i 100  �D�n�t���u�b
		/// MutableNode  �t�W
		///
		/// Runtime: 224 ms, faster than 98.29% of C# online submissions for LRU Cache.
		/// Memory Usage: 49.5 MB, less than 85.09% of C# online submissions for LRU Cache.
		/// 
		/// </summary>
		public class LRUCache
		{
			public MutableNode First;
			public MutableNode Last;
			private readonly int _capacity;
			private int _count = 0;
			private readonly Dictionary<int, MutableNode> _nodes;

			/// <summary>
			/// �d�@�U  MutableNode    �ٸ��S�ݥX������[�֫ܦh���a��  �u�_��  �S�������u�ƪ��a��
			/// </summary>
			public class MutableNode
			{
				public int Key;
				public int Value;
				public MutableNode Next;
				public MutableNode Previous;

				public MutableNode(int key, int value)
				{
					Key = key;
					Value = value;
				}

				public override string ToString()
				{
					return $"[{Key}:{Value}]";
				}
			}

			public LRUCache(int capacity)
			{
				_capacity = capacity;
				_nodes = new Dictionary<int, MutableNode>(capacity);
				First = new MutableNode(int.MinValue, int.MinValue);
				Last = new MutableNode(int.MinValue, int.MinValue);
			}

			private void MoveToFront(MutableNode node)
			{
				if (node == First.Next) return;
				node.Previous.Next = node.Next;
				node.Next.Previous = node.Previous;
				node.Previous = First;
				node.Next = First.Next;
				node.Next.Previous = node;
				First.Next = node;
			}

			public int Get(int key)
			{
				MutableNode node;
				_nodes.TryGetValue(key, out node);
				if (node == null) return -1;
				MoveToFront(node);
				return node.Value;
			}

			public void Put(int key, int value)
			{
				MutableNode node;
				_nodes.TryGetValue(key, out node);
				if (node == null)
				{
					if (_capacity == _count)
					{
						node = Last.Previous;
						_nodes.Remove(node.Key);
						node.Key = key;
						node.Value = value;
						_nodes.Add(key, node);
					}
					else
					{
						if (_count == 0)
						{
							First.Next = new MutableNode(key, value) {Previous = First, Next = Last};
							Last.Previous = First.Next;
						}
						else
						{
							First.Next = new MutableNode(key, value) {Next = First.Next, Previous = First};
							First.Next.Next.Previous = First.Next;
						}

						_nodes.Add(key, First.Next);
						_count++;
						return;
					}
				}
				else
				{
					node.Value = value;
				}

				MoveToFront(node);
			}

			public override string ToString()
			{
				StringBuilder res = new StringBuilder();
				var node = First;
				res.Append('[');
				while (node != null)
				{
					if (node.Key == int.MinValue)
					{
						node = node.Next;
						continue;
					}

					res.Append(node);
					node = node.Next;
				}

				res.Append(']');
				return res.ToString();
			}
			
		}

		/// <summary>
		/// Design a data structure that follows the constraints of a
		/// Least Recently Used (LRU)
		/// cache.
		///
		/// https://en.wikipedia.org/wiki/Cache_replacement_policies#LRU
		/// �|���@�Ӯɶ��W�O   �����W���ϥΪ��ɶ�   �V���H�e�Q�ιL���V������
		/// 
		/// Implement the LRUCache class:
		/// 
		/// LRUCache(int capacity) Initialize the LRU cache with positive size capacity.
		/// int get(int key) Return the value of the key if the key exists, otherwise return -1.
		/// void put(int key, int value) Update the value of the key if the key exists. Otherwise, add the key-value pair to the cache. If the number of keys exceeds the capacity from this operation, evict the !! least recently used key. !!
		/// 
		/// Follow up:
		/// Could you do get and put in O(1) time complexity?
		///
		/// 
		/// if get want to time compley O 1 , that is HashMap or Dictionary
		/// if put comp O 1 , DS may use Array or HashTable or Dictionary , Dic add compl = O 1 if not increased accomodate, if accomodation, it'll cost O(count=n)
		///
		/// and to consider counting the frequency,
		/// since it need to order by freq, O 1 is nearly impossible
		/// try use dictionary with order by
		///
		/// �v��  
		/// Runtime: 316 ms, faster than 40.30% of C# online submissions for LRU Cache.
		/// Memory Usage: 49.4 MB, less than 89.45% of C# online submissions for LRU Cache.
		///
		/// ����time stamp���a��  �쥻��Dic�ԲӰO��key, time  ���̤p�٭n O n  for�@�M��̤p
		/// �| TLE �i�� 600ms�H�W
		///
		/// �Q��̤p��  ������List �skey  index���Ǫ�����ɶ�����
		/// �f�tRemoveAt 0   Add����  Remove Key  �N�i��300ms   �S�O�bAdd �M  RemoveAt 0 �S�O��
		/// �����w�� 0 �N�O�̦��Ϊ�  �������ιM���j�M
		/// 
		/// 
		/// </summary>
		public class LRUCache_V1
		{

			Dictionary<int, int> keyVal = new Dictionary<int, int>();
			List<int> keyUsedTime = new List<int>();
			private int capacity = 0;

			//LinkedList<int> keyUsedTime = new LinkedList<int>();

			public LRUCache_V1(int capacity)
			{
				this.capacity = capacity;
			}

			public int Get(int key)
			{
				if (keyVal.ContainsKey(key))
				{
					keyUsedTime.Remove(key);
					keyUsedTime.Add(key);
					return keyVal[key];
				}
				else
				{
					return -1;
				}
			}

			public void Put(int key, int value)
			{
				//Console.WriteLine("add " + key);

				Action upsert = () =>
				{
					if (!keyVal.ContainsKey(key))
					{
						count++;
						keyVal.Add(key, value);
						keyUsedTime.Add(key);
					}
					else
					{
						keyVal[key] = value;
						keyUsedTime.Remove(key);
						keyUsedTime.Add(key);
					}
				};

				if (count < capacity)
				{
					upsert();
				}
				else
				{
					int fkey = keyUsedTime.First();

					if (!keyVal.ContainsKey(key))
					{
						keyVal.Remove(fkey);
						keyUsedTime.Remove(fkey);
					}

					//Console.WriteLine("rem " + fkey);
					upsert();
				}
			}

			private int count = 0;

		}


		/**
		 * Your LRUCache object will be instantiated and called as such:
		 * LRUCache obj = new LRUCache(capacity);
		 * int param_1 = obj.Get(key);
		 * obj.Put(key,value);
		 */

	}
}
