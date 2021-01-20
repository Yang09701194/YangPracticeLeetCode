using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	public class _341_FlattenNestedListIterator
	{

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



		/**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * interface NestedInteger {
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */



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
		///  Runtime: 220 ms, faster than 97.60% of C# online submissions for Flatten Nested List Iterator.
		///Memory Usage: 33.3 MB, less than 12.80% of C# online submissions for Flatten Nested List Iterator.
		///
		/// 結果這個就是 Sol 1  不過不是真正iterator的概念 iterator
		///
		/// https://leetcode.com/problems/peeking-iterator/solution/
		/// If you've heard of Iterators, you might assume they're simply a way of iterating over indexed or finite data structures. 
		/// 
		///
		///
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
