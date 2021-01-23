using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	public class _341_FlattenNestedListIterator
	{
		//  �o�g��Iterator pattern ���D�`�ԲӸ���
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
					new NestedIntegerImpl(new List<NestedInteger>()
					{
						new NestedIntegerImpl(null, 31),
						new NestedIntegerImpl(null, 32),
						new NestedIntegerImpl(new List<NestedInteger>()
						{
							new NestedIntegerImpl(null, 311),
							new NestedIntegerImpl(null, 312),
						}, null),
					}, null),
				}, null),
				new NestedIntegerImpl(null, 4),
				new NestedIntegerImpl(new List<NestedInteger>()
				{
					new NestedIntegerImpl(null, 5),
					new NestedIntegerImpl(null, 6),
				}, null),
			};
			NestedIterator it = new NestedIterator(ls);

			List<NestedInteger> ls2 = new List<NestedInteger>()
			{
				new NestedIntegerImpl(null, 1),
				new NestedIntegerImpl(new List<NestedInteger>()
				{
					new NestedIntegerImpl(null, 4),
					new NestedIntegerImpl(new List<NestedInteger>()
					{
						new NestedIntegerImpl(null, 6),
					}, null),
				}, null),
			};
			NestedIterator_Sol2 it2 = new NestedIterator_Sol2(ls);

			while (it2.HasNext())
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
		/// �ۤv���եμg��
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


		//Sol 4 ���L  ���MC# �T��O��Iterator
		//This approach works best in Java but isn't well suited to other languages. Have a look at Approach 5 if you're looking for an elegant Python and JavaScript approach.

		/// <summary>
		/// time space �ݰ_�Ӥ��Ӻ⦳����S�O
		///
		/// �t�@�ӤH�g���P���� Sol 3 ���O�h�f�t�@�� List  �N�ܳǥX�F
		///
		/// �����[�����ӥD�n�t�b  Sol3 �� getList index++ �n�z�L stack push pop �ǻ�
		/// 
		/// �����Τ@��list  �N����++  ���ӴN�t�b�o
		/// 
		/// Runtime: 240 ms, faster than 40.35% of C# online submissions for Flatten Nested List Iterator.
		/// Memory Usage: 33.6 MB, less than 11.11% of C# online submissions for Flatten Nested List Iterator.
		///
		///
		/// Intuition
		/// 
		/// Reversing the lists to put them onto the stack can be an expensive operation, and it turns out it isn't necessary.
		/// 
		/// Instead of pushing every item of a sub-list onto the stack, we can instead associate an index pointer with each sub-list, that keeps track of how far along that sub-list we are. Adding a new sub-list to the stack now becomes an O(1)O(1) operation instead of a O(length of sublist)O(lengthofsublist) one.
		///
		/// The total time complexity across all method calls for using up the entire iterator remains the same, but work is only done when it's necessary, thus improving performance when we only use part of the iterator. This is a desirable property for an iterator.
		/// 
		/// Algorithm
		/// 
		/// This approach can be implemented as either one stack of pairs/ tuples, or two stacks with one for NestedIntegers and the other for indexes. The best decision for this is language-dependent. I tried both for the Java and found that attempting to put Pair objects onto a single stack doesn't work well because updating an index count requires popping and then reconstructing the entire Pair due to immutability (alternatives such as using.Length-2 Listss as pairs are possible, but I don't think ideal). Using two stacks is cleaner.
		///
		/// Complexity Analysis
		/// 
		/// Let NN be the total number of integers within the nested list, LL be the total number of lists within the nested list, and DD be the maximum nesting depth (maximum number of lists inside each other).
		/// 
		/// Time complexity:
		/// 
		/// Constructor: O(1).
		/// 
		/// Pushing a list onto a stack is by reference in all the programming languages we're using here. This means that instead of creating a new list, some information about how to get to the existing list is put onto the stack. The list is not traversed, as it doesn't need reversing this time, and we're not pushing the items on one-by-one. This is, therefore, an O(1)O(1) operation.
		/// 
		/// makeStackTopAnInteger() / next() / hasNext(): O(L/N) or O(1).
		/// 
		/// Same as Approach 2.
		/// 
		/// Space complexity : O(D).
		/// 
		/// At any given time, the stack contains only one nestedList reference for each level. This is unlike the previous approach, wherein the worst case we need to put almost all elements onto the stack.
		/// 
		/// Because there's one reference on the stack at each level, the worst case is when we're looking at the deepest leveled list, giving a space complexity is O(D)O(D).
		///
		/// 
		/// </summary>
		public class NestedIterator_Sol3
		{
			private Stack<IList<NestedInteger>> listStack = new Stack<IList<NestedInteger>>();
			private Stack<int> indexStack = new Stack<int>();

			public NestedIterator_Sol3(IList<NestedInteger> nestedList)
			{
				listStack.Push(nestedList);
				indexStack.Push(0);
			}


			public int Next()
			{
				if (!HasNext()) throw new Exception();
				int currentPosition = indexStack.Pop();
				indexStack.Push(currentPosition + 1);
				return listStack.Peek()[currentPosition].GetInteger();
			}



			public bool HasNext()
			{
				MakeStackTopAnint();
				return indexStack.Any();
			}


			private void MakeStackTopAnint()
			{

				while (indexStack.Any())
				{

					// If the top list is used up, pop it and its index.
					if (indexStack.Peek() >= listStack.Peek().Count())
					{
						indexStack.Pop();
						listStack.Pop();
						continue;
					}

					// Otherwise, if it's already an integer, we don't need to do anything.
					if (listStack.Peek()[indexStack.Peek()].IsInteger())
					{
						break;
					}

					// Otherwise, it must be a list. We need to update the previous index
					// and then.Add the new list with an index of 0.
					listStack.Push(listStack.Peek()[indexStack.Peek()].GetList());
					indexStack.Push(indexStack.Pop() + 1);
					indexStack.Push(0);
				}
			}
		}


		/// <summary>
		/// ��L�H�g��  �ָ̧�  ����]�t���h  ���֦��C  �O���馳�j���p
		/// �ݰ_�ӫܯS�O  �̯S�O�O  construct  ������nestedList  �S���w�B�z�u�}
		/// �OHasNext���ɭԤ~�@�䰵
		/// �]�p�N�n�D�`����
		///
		/// �D�n���n�B���ӬO�i�H�ٱ��w�B�z���ɶ�   ���O�bŪ���ɳt�׸��C
		/// ���L�o����ո�Ƥp  �ҥH�ݤ��X����v�T
		///
		///  
		/// �D�`����  �����ݵ{���X�S��k��������
		/// �]�F����~�ݥX�X�ӷs���a��:
		/// listStack �� idxStack �H��iterator��F���a�誺���O�h�� �����W�[  ��sol3 gif����
		/// �ϥήɾ��b��  �J�줸���O list  (�Dlist�Oint�N�������~��e�i
		/// �N�⧹��list��currList ���è� listStack   ����list��idx�]����idxStack
		/// �M�� currList���  �ثe����list[idx]��List  idx�]�w���o�Ӥllist���}�Y 0
		/// �M��llist�@���]  �]��idx�W�L�llist
		/// �N��쥻���_�Ӫ�listStack��X�� �~��W�����L�{
		///
		/// �o�]�O Sol3 ���Q�k   ���O time space �N���u�q
		/// �����N�@�˪����k   �����S�O��  ��s�@�U
		/// Runtime: 224 ms, faster than 94.15% of C# online submissions for Flatten Nested List Iterator.
		/// Memory Usage: 32.9 MB, less than 84.80% of C# online submissions for Flatten Nested List Iterator.
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

		//*
		// * Your NestedIterator will be called like this:
		// * NestedIterator i = new NestedIterator(nestedList);
		// * while (i.HasNext()) v[f()] = i.Next();




		/// <summary>
		/// Runtime: 232 ms, faster than 76.47% of C# online submissions for Flatten Nested List Iterator.
		/// Memory Usage: 33.9 MB, less than 10.59% of C# online submissions for Flatten Nested List Iterator
		///
		/// ��ڤW�O���I�p�_��   ��ܧ�  �� sol3 ��
		/// �H��r�����ӻ�  �Pı sol3 �|�� sol2��   ���L�]�����R��]���ѤF
		///
		/// �ҥH�H�o��ӻ�  ls reverse��  �@�� pop   �|��index �@�� push pop ��
		///
		/// 
		/// 
		/// </summary>
		public class NestedIterator_Sol2
		{

			// In Java, the Stack class is considered deprecated. Best practice is to use
			// a Stack instead. We'll use.Push() for push, and.Pop() for pop.
			private Stack<NestedInteger> stack;

			public NestedIterator_Sol2(IList<NestedInteger> nestedList)
			{
				// The constructor puts them on in the order we require. No need to reverse.

				//�o�̦]���O java stack ��Deque  �ҥH java new�� �O����
				//C# new ��  �]���L�Ofor push �|�ܰf��
				//�ҥH�n���f�ǦA��i�h  �L�{�A�f  �|�ܷ|����
				stack = new Stack<NestedInteger>(nestedList.Reverse());
			}

			public int Next()
			{
				// As per java specs, throw an exception if there's no elements left.
				if (!HasNext()) throw new Exception();
				// hasNext ensures the stack top is now an integer. Pop and return
				// this integer.
				return stack.Pop().GetInteger();
			}

			public bool HasNext()
			{
				// Check if there are integers left by getting one onto the top of stack.
				makeStackTopAnint();
				// If there are any integers remaining, one will be on the top of the stack,
				// and therefore the stack can't possibly be empty.
				return stack.Any();
			}


			private void makeStackTopAnint()
			{
				// While there are items remaining on the stack and the front of 
				// stack is a list (i.e. not integer), keep unpacking.
				while (stack.Any() && !stack.Peek().IsInteger())
				{
					// Put the NestedIntegers onto the stack in reverse order.
					IList<NestedInteger> nestedList = stack.Pop().GetList();
					for (int i = nestedList.Count() - 1; i >= 0; i--)
					{
						stack.Push(nestedList[i]);
					}
				}
			}
		}


		/// <summary>
		/// �ܪ�ı  �@�뻼�j  ��F�⦸ 
		/// 1  ConstructList(nestedList[i].GetList())  �g�� ConstructList(nestedList)  �ɭP�L�a���j
		/// 2 <![CDATA[  HasNext index < vals.Count; �g��   index < vals.Count - 1; ]]> 
		/// 
		/// Runtime: 220 ms, faster than 97.60% of C# online submissions for Flatten Nested List Iterator.
		///Memory Usage: 33.3 MB, less than 12.80% of C# online submissions for Flatten Nested List Iterator.
		/// 
		/// Runtime: 220 ms, faster than 97.60% of C# online submissions for Flatten Nested List Iterator.
		///Memory Usage: 33.3 MB, less than 12.80% of C# online submissions for Flatten Nested List Iterator.
		///
		/// ���G�o�ӴN�O Sol 1  ���L���O�u��iterator������ iterator
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
		/// Our final property is one that we couldn't even do by copying values into an Array�Xhandling an infinite sequence. 
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
		/// ���n   Time Space
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
