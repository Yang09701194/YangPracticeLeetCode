using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	public class _341_FlattenNestedListIterator
	{
		//  這篇有Iterator pattern 的非常詳細解釋
		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			List<NestedInteger> ls = new List<NestedInteger>()
			{
				new NestedIntegerImpl(null, 1),
				new NestedIntegerImpl(new List<NestedInteger>()
				{
					new NestedIntegerImpl(null, 2),
					new NestedIntegerImpl(null, 3),
				}, null),
				new NestedIntegerImpl(null, 4),
				new NestedIntegerImpl(new List<NestedInteger>()
				{
					new NestedIntegerImpl(null, 5),
					new NestedIntegerImpl(null, 6),
				}, null),
			};
			NestedIterator it = new NestedIterator(ls);
			while (it.HasNext())
			{
				Console.WriteLine(it.Next());
			}

			//Console.WriteLine(s.SpecialArray(new int[] { 3, 5 }));



		}




		// This is the interface that allows for creating nested lists.
		// You should not implement it, or speculate about its implementation
		public interface NestedInteger
		{

			// @return true if this NestedInteger holds a single integer, rather than a nested list.
			bool IsInteger();

			// @return the single integer that this NestedInteger holds, if it holds a single integer
			// Return null if this NestedInteger holds a nested list
			int GetInteger();

			// @return the nested list that this NestedInteger holds, if it holds a nested list
			// Return null if this NestedInteger holds a single integer
			IList<NestedInteger> GetList();
		}


		/// <summary>
		/// 自己測試用寫的
		/// </summary>
		public class NestedIntegerImpl : NestedInteger
		{
			public List<NestedInteger> ls;
			public int? val;

			public NestedIntegerImpl(List<NestedInteger> ls, int? val)
			{
				this.ls = ls;
				this.val = val;
			}

			public bool IsInteger()
			{
				return val != null;
			}

			public int GetInteger()
			{
				return val.GetValueOrDefault();
			}

			public IList<NestedInteger> GetList()
			{
				return ls;
			}
		}




		/// <summary>
		/// 其他人寫的  最快解  實測也差不多  有快有慢  記憶體有大有小
		/// 看起來很特別  最特別是  construct  直接拿nestedList  沒有預處理攤開
		/// 是HasNext的時候才一邊做
		/// 設計就要非常巧妙
		///
		/// 主要的好處應該是可以省掉預處理的時間   但是在讀取時速度較慢
		/// 不過這邊測試資料小  所以看不出明顯影響
		///
		///  
		/// 非常巧妙  直接看程式碼沒辦法完全全懂
		/// 跑了之後才看出幾個新的地方:
		/// listStack 跟 idxStack 只有一層使用
		/// 使用時機在於  遇到元素是 list  (非list是int就直接取繼續前進
		/// 就把完整list的currList 先藏到 listStack   完整list的idx也收到idxStack
		/// 然後 currList改裝  目前完整list[idx]的List  idx設定為這個子list的開頭 0
		/// 然後子list一直跑  跑到idx超過子list
		/// 就把原本收起來的listStack放出來 繼續上面的過程
		/// 
		/// 
		/// </summary>
		public class NestedIterator
		{
			private Stack<IList<NestedInteger>> listStack;
			private Stack<int> idxStack;
			private IList<NestedInteger> curList;
			private int curIdx;

			public NestedIterator(IList<NestedInteger> nestedList)
			{
				this.listStack = new Stack<IList<NestedInteger>>();
				this.idxStack = new Stack<int>();
				curList = nestedList;
				curIdx = 0;
			}

			public bool HasNext()
			{
				if (curIdx < curList.Count && curList[curIdx].IsInteger())
				{
					return true;
				}

				while (curIdx >= curList.Count)
				{
					if (listStack.Count == 0)
					{
						return false;
					}

					curList = listStack.Pop();
					curIdx = idxStack.Pop() + 1;
				}

				while (!curList[curIdx].IsInteger())
				{
					listStack.Push(curList);
					idxStack.Push(curIdx);

					curList = curList[curIdx].GetList();
					curIdx = 0;

					if (curIdx >= curList.Count)
					{
						break;
					}
				}

				return HasNext();
			}

			public int Next()
			{
				var nestedInteger = curList[curIdx++];
				return nestedInteger.GetInteger();
			}
		}

		/**
		 * Your NestedIterator will be called like this:
		 * NestedIterator i = new NestedIterator(nestedList);
		 * while (i.HasNext()) v[f()] = i.Next();
		 */


		/// <summary>
		/// 很直覺  一般遞迴  改了兩次 
		/// 1  ConstructList(nestedList[i].GetList())  寫成 ConstructList(nestedList)  導致無窮遞迴
		/// 2 <![CDATA[  HasNext index < vals.Count; 寫成   index < vals.Count - 1; ]]> 
		/// 
		/// Runtime: 220 ms, faster than 97.60% of C# online submissions for Flatten Nested List Iterator.
		///Memory Usage: 33.3 MB, less than 12.80% of C# online submissions for Flatten Nested List Iterator.
		/// 
		/// Runtime: 220 ms, faster than 97.60% of C# online submissions for Flatten Nested List Iterator.
		///Memory Usage: 33.3 MB, less than 12.80% of C# online submissions for Flatten Nested List Iterator.
		///
		/// 結果這個就是 Sol 1  不過不是真正iterator的概念 iterator
		///
		/// https://leetcode.com/problems/peeking-iterator/solution/
		/// If you've heard of Iterators, you might assume they're simply a way of iterating over indexed or finite data structures. 
		/// 
		///But actually Iterators have some interesting properties that make them widely useful for not only indexed collections (e.g. Array) and other finite data structures (e.g. LinkedList or HashMap keys), but also for (possibly-infinite) generated data. We'll look at an example of that soon.
		///
		/// we discard the current one and replace it with the item in the node after?

		///This means that if we're simply iterating a Linked List, and don't ever need to go back to the head, then we only need to keep one value around at a time.
		/// Another really interesting property of Iterators is that they can represent sequences without even using a data structure!
		/// 
		/// For example consider a range Iterator:
		/// <![CDATA[
		/// class RangeIterator:
		///     def __init__(self, min, max):
		///         self._max = max
		///         self._current = min
		/// 
		///     def hasNext(self):
		///         return self._current < self._max
		/// 
		///     def next(self):
		///         self._current += 1
		///         return self._current - 1
		/// If we simply converted this to an Array, we'd need to allocate a large chunk of memory if min and max are far apart. For the most part, this would probably be wasted space.
		/// 
		/// However, by using an Iterator, we can use features like for i in range(40, 20000000) while still retaining the O(1)O(1) space of classic for (int i = min; i < max; i++) style loops seen in other languages. 
		///
		/// ]]>
		///
		/// Our final property is one that we couldn't even do by copying values into an Array—handling an infinite sequence. 
		///
		/// An Iterator only provides two methods:
		/// 
		/// .next() This returns the next item in the sequence. You can't assume that this item actually "exists" yet, it might be created when you call .next(), or it might already exist in a data structure that you have an Iterator over.
		/// 
		/// Once .next() is called, it will update the state of the Iterator. This means once you've got a value from .next() you won't be able to get the same value again. Therefore, if you don't store or process the value you got from the Iterator then it's possibly gone forever!
		/// 
		/// .hasNext() This returns whether or not another item is available. For example, an array Iterator should return False if we're at the end of the array. But for an Iterator that can produce items indefinitely, such as our square generator above, it might never return False.
		/// 
		/// A further property of Iterators is that they provide a clean interface for the code using them. Without Iterators, Linked List's, for example, tend to be particularly messy, as the code for traversing them gets muddled within the application code. With an Iterator, the external code doesn't even know how the underlying data structure works. For all it knows, the data could be coming from a Linked List, an Array, a Tree, a State Machine, a clever number generator, a file reader, a robot sensor, etc.
		/// 
		/// Not having to deal with nodes, state, indexes, etc leads to clean code. We call this the Iterator Pattern, and it is one of the most important design patterns for a software engineer to know.
		/// 
		/// As shown above, with only two methods, we get a lot of benefit (e.g. infinite sequences) and increased performance (e.g. not expanding sequences like range into arrays). We also get a nice way of separating the underlying data structure from the code that uses it.
		/// 
		/// 重要   Time Space
		///
		/// Let N be the total number of integers within the nested list, L be the total number of lists within the nested list, and D be the maximum nesting depth (maximum number of lists inside each other).
		/// 
		/// Time complexity:
		/// 
		/// We'll analyze each of the methods separately.
		/// 
		/// Constructor: O(N + L)
		/// 
		/// The constructor is where all the time-consuming work is done.
		/// 
		/// For each list within the nested list, there will be one call to flattenList(...). The loop within flattenList(...) will then iterate nn times, where nn is the number of integers within that list. Across all calls to flattenList(...), there will be a total of NN loop iterations. Therefore, the time complexity is the number of lists plus the number of integers, giving us O(N + L).
		/// 
		/// !!!!  Notice that the maximum depth of the nesting does not impact the time complexity.
		/// 
		/// next(): O(1).
		/// 
		/// Getting the next element requires incrementing position by 1 and accessing an element at a particular index of the integers list. Both of these are O(1) operations.
		/// 
		/// hasNext(): O(1).
		/// 
		/// Checking whether or not there is a next element requires comparing the length of the integers list to the position variable. This is an O(1) operation.
		/// 
		/// Space complexity : O(N + D).
		/// 
		/// The most obvious auxiliary space is the integers list. The length of this is O(N).
		/// 
		/// The less obvious auxiliary space is the space used by the flattenList(...) function. Recall that recursive functions need to keep track of where they're up to by putting stack frames on the runtime stack. Therefore, we need to determine what the maximum number of stack frames there could be at a time is. Each time we encounter a nested list, we call flattenList(...) and a stack frame is added. Each time we finish processing a nested list, flattenList(...) returns and a stack frame is removed. Therefore, the maximum number of stack frames on the runtime stack is the maximum nesting depth, D.
		/// 
		/// Because these two operations happen one-after-the-other, and either could be the largest, we add their time complexities together giving a final result of O(N + D).
		///  
		/// </summary>
		public class NestedIterator_V1
		{
			List<int> vals = new List<int>();
			public NestedIterator_V1(IList<NestedInteger> nestedList)
			{
				ConstructList(nestedList);
			}

			public void ConstructList(IList<NestedInteger> nestedList)
			{
				for (int i = 0; i < nestedList.Count; i++)
				{
					if (nestedList[i].IsInteger())
					{
						vals.Add(nestedList[i].GetInteger());
					}
					else
					{
						ConstructList(nestedList[i].GetList());
					}
				}
			}

			int index = 0;
			public bool HasNext()
			{
				return index < vals.Count;
			}

			public int Next()
			{
				return vals[index++];
			}
		}

		///
		//  Your NestedIterator will be called like this:
		//  NestedIterator i = new NestedIterator(nestedList);
		//  while (i.HasNext()) v[f()] = i.Next();
		// /


	}
}
