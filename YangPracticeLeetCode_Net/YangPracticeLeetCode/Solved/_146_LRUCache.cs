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



		//  C#看完  看Sol  都java
		// Approach 1: Ordered dictionary
		// Intuition
		// 
		// We're asked to implement the structure which provides the following operations in O(1) time :
		// 
		// Get the key / Check if the key exists
		// 
		// Put the key
		// 
		// Delete the first added key
		// 
		// The first two operations in O(1) time are provided by the standard hashmap, and the last one - by linked list.
		// 
		// There is a structure called ordered dictionary, it combines behind both hashmap and linked list. In Python this structure is called OrderedDict and in Java LinkedHashMap.
		// 
		// Let's use this structure here.

		//這裡又用了一個 java 特有的資結功能   竟然有內建  removeEldestEntry   根本就是複雜功能本來就內建的現成工具在套用
		//考工具   但是其他語言沒這工具  C#沒有  就要自己寫  才是真考驗  也比較花力氣
		//The java.util.LinkedHashMap.removeEldestEntry() method in Java is used keep a track of whether the map removes any eldest entry from the map. 
		//
		// 等於就是內建 LRU  所以直接呼叫接口就可以了 
		//
		// class LRUCache extends LinkedHashMap<Integer, Integer>{
		//     private int capacity;
		//     
		//     public LRUCache(int capacity) {
		//         super(capacity, 0.75F, true);
		//         this.capacity = capacity;
		//     }
		// 
		//     public int get(int key) {
		//         return super.getOrDefault(key, -1);
		//     }
		// 
		//     public void put(int key, int value) {
		//         super.put(key, value);
		//     }
		// 
		//     @Override
		//     protected boolean removeEldestEntry(Map.Entry<Integer, Integer> eldest) {
		//         return size() > capacity; 
		//     }
		// }
		//
		// Time complexity : O(1) both for put and get since all operations with ordered dictionary : get/in/set/move_to_end/popitem (get/containsKey/put/remove) are done in a constant time.
		// 
		// Space complexity : O(capacity) since the space is used only for an ordered dictionary with at most capacity + 1 elements.
		//
		//  LinkedHashMap 資結介紹  有記錄在 java專案
		//
		// 



		// Approach 2: Hashmap + DoubleLinkedList
		// Intuition
		// 
		// This Java solution is an extended version of the the article published on the Discuss forum.
		// 
		// The problem can be solved with a hashmap that keeps track of the keys and its values in the double linked list. That results in O(1) time for put and get operations and allows to remove the first added node in O(1) time as well.

		//這個版本  他說有在discuss   
		//所以概念其實和  底下的  MutableNode  是相同的
		//在處理   recently used 的時候  一樣用  moveToHead  代表最近使用   popTail  移除 最沒被用到的
		//
		//
		//
		// One advantage of double linked list is that the node can remove itself without other reference. In addition, it takes constant time to add and remove nodes from the head or tail.
		// 
		// One particularity about the double linked list implemented here is that there are pseudo head and pseudo tail to mark the boundary, so that we don't need to check the null node during the update.
		//
		// 
		// 
		// 
		// public class LRUCache {
		// 
		//   class DLinkedNode {
		//     int key;
		//     int value;
		//     DLinkedNode prev;
		//     DLinkedNode next;
		//   }
		// 
		//   private void addNode(DLinkedNode node) {
		//     /**
		//      * Always add the new node right after head.
		//      */
		//     node.prev = head;
		//     node.next = head.next;
		// 
		//     head.next.prev = node;
		//     head.next = node;
		//   }
		// 
		//   private void removeNode(DLinkedNode node){
		//     /**
		//      * Remove an existing node from the linked list.
		//      */
		//     DLinkedNode prev = node.prev;
		//     DLinkedNode next = node.next;
		// 
		//     prev.next = next;
		//     next.prev = prev;
		//   }
		// 
		//   private void moveToHead(DLinkedNode node){
		//     /**
		//      * Move certain node in between to the head.
		//      */
		//     removeNode(node);
		//     addNode(node);
		//   }
		// 
		//   private DLinkedNode popTail() {
		//     /**
		//      * Pop the current tail.
		//      */
		//     DLinkedNode res = tail.prev;
		//     removeNode(res);
		//     return res;
		//   }
		// 
		//   private Map<Integer, DLinkedNode> cache = new HashMap<>();
		//   private int size;
		//   private int capacity;
		//   private DLinkedNode head, tail;
		// 
		//   public LRUCache(int capacity) {
		//     this.size = 0;
		//     this.capacity = capacity;
		// 
		//     head = new DLinkedNode();
		//     // head.prev = null;
		// 
		//     tail = new DLinkedNode();
		//     // tail.next = null;
		// 
		//     head.next = tail;
		//     tail.prev = head;
		//   }
		// 
		//   public int get(int key) {
		//     DLinkedNode node = cache.get(key);
		//     if (node == null) return -1;
		// 
		//     // move the accessed node to the head;
		//     moveToHead(node);
		// 
		//     return node.value;
		//   }
		// 
		//   public void put(int key, int value) {
		//     DLinkedNode node = cache.get(key);
		// 
		//     if(node == null) {
		//       DLinkedNode newNode = new DLinkedNode();
		//       newNode.key = key;
		//       newNode.value = value;
		// 
		//       cache.put(key, newNode);
		//       addNode(newNode);
		// 
		//       ++size;
		// 
		//       if(size > capacity) {
		//         // pop the tail
		//         DLinkedNode tail = popTail();
		//         cache.remove(tail.key);
		//         --size;
		//       }
		//     } else {
		//       // update the value.
		//       node.value = value;
		//       moveToHead(node);
		//     }
		//   }
		// }
		//






		/// <summary>
		/// Runtime: 236 ms, faster than 83.37% of C# online submissions for LRU Cache.
		/// Memory Usage: 49.5 MB, less than 84.70% of C# online submissions for LRU Cache.
		///
		/// Runtime: 224 ms, faster than 98.29% of C# online submissions for LRU Cache.
		/// Memory Usage: 49.5 MB, less than 85.09% of C# online submissions for LRU Cache.
		///
		///
		/// 查一下  MutableNode    還沒看出有明顯加快很多的地方  真奇怪  沒有明顯優化的地方
		/// 
		/// 有了  關鍵在  List<int> keyUsedTime = new List<int>();
		/// if I use List to implement, Add to last(most recently used) O 1
		/// but remove first (LRU) O n , this is the key slow place
		/// 
		/// and from below can see, the key slow place is the place to change to fast,
		/// that is convert the slow place to fast is exactly the key of faster
		/// 
		/// 問題就在能不能找到方法  找不到就快不了
		///
		/// 底下就是將 Move To Front (他是做為最新使用的) 改成用自己寫的 Linked List
		/// 只要單 node 更新 Previous 和 Next
		/// 這樣子就避掉了  一般 insert 0 的 O n  就會快非常多
		///
		/// 輕鬆做到 put get 都 O 1  原本的List做法   get O 1 是自然  put 在 remove least recently used 
		///  
		/// </summary>
		public class LRUCache
		{
			public MutableNode First;
			public MutableNode Last;
			private readonly int _capacity;
			private int _count = 0;
			private readonly Dictionary<int, MutableNode> _nodes;

			
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
				//!!!
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
		/// 會有一個時間戳記   紀錄上次使用的時間   越早以前被用過的越先移除
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
		/// 己解  
		/// Runtime: 316 ms, faster than 40.30% of C# online submissions for LRU Cache.
		/// Memory Usage: 49.4 MB, less than 89.45% of C# online submissions for LRU Cache.
		///
		/// 紀錄time stamp的地方  原本用Dic詳細記錄key, time  取最小還要 O n  for一遍找最小
		/// 會 TLE 可能 600ms以上
		///
		/// 想到最小化  直接用List 存key  index順序直接表時間先後
		/// 搭配RemoveAt 0   Add結尾  Remove Key  就進到300ms   特別在Add 和  RemoveAt 0 特別省
		/// 直接定位 0 就是最早用的  完全不用遍歷搜尋
		///
		/// 這是一個經典圖片    一看就懂 LRU Cache 的細節
		/// https://upload.wikimedia.org/wikipedia/commons/8/88/Lruexample.png
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
