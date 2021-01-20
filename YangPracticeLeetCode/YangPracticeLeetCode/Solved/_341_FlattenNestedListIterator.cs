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
		/// listStack �� idxStack �u���@�h�ϥ�
		/// �ϥήɾ��b��  �J�줸���O list  (�Dlist�Oint�N�������~��e�i
		/// �N�⧹��list��currList ���è� listStack   ����list��idx�]����idxStack
		/// �M�� currList���  �ثe����list[idx]��List  idx�]�w���o�Ӥllist���}�Y 0
		/// �M��llist�@���]  �]��idx�W�L�llist
		/// �N��쥻���_�Ӫ�listStack��X�� �~��W�����L�{
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
		/// �ܪ�ı  �@�뻼�j  ��F�⦸ 
		/// 1  ConstructList(nestedList[i].GetList())  �g�� ConstructList(nestedList)  �ɭP�L�a���j
		/// 2 <![CDATA[  HasNext index < vals.Count; �g��   index < vals.Count - 1; ]]> 
		/// 
		/// Runtime: 220 ms, faster than 97.60% of C# online submissions for Flatten Nested List Iterator.
		///Memory Usage: 33.3 MB, less than 12.80% of C# online submissions for Flatten Nested List Iterator.
		/// 
		///  Runtime: 220 ms, faster than 97.60% of C# online submissions for Flatten Nested List Iterator.
		///Memory Usage: 33.3 MB, less than 12.80% of C# online submissions for Flatten Nested List Iterator.
		///
		/// ���G�o�ӴN�O Sol 1  ���L���O�u��iterator������ iterator
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
