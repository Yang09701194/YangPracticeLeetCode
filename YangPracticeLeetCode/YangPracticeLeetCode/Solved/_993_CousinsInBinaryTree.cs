using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	public class _993_CousinsInBinaryTree
	{

		public static void Test()
		{
			Solution s = new Solution();

			int?[] t1 = new int?[] {1, 2, 3, null, 4, null, 5};

			TreeNode root = new TreeNode(t1[0].GetValueOrDefault());
			ProduceTreeNode(t1, t1.Length, 0, root);
			Console.WriteLine(s.IsCousins(root, 5, 3));

		}


		public static void ProduceTreeNode(int?[] values, int length, int currentPos, TreeNode node)
		{
			if (node == null)
				return;
			int left = 2 * currentPos + 1;
			int right = 2 * currentPos + 2;
			if (left < length && values[left] != null)
				node.left = new TreeNode(values[left].GetValueOrDefault());
			if (right < length && values[right] != null)
				node.right = new TreeNode(values[right].GetValueOrDefault());
			ProduceTreeNode(values, length, left, node.left);
			ProduceTreeNode(values, length, right, node.right);
		}


		public class Solution
		{
			public bool IsCousins(TreeNode root, int x, int y)
			{

				ParentLevel pl  = new ParentLevel() { level = 0}; 
				TreeNode rx = RecursiveFind(x, root, pl);

				ParentLevel pl2 = new ParentLevel() { level = 0 };
				TreeNode ry = RecursiveFind(y, root, pl2);

				int? parent1 = pl.parentValues.Any() ? (int?)pl.parentValues[0] : null;
				int? parent2 = pl2.parentValues.Any() ? (int?)pl2.parentValues[0] : null;

				Console.WriteLine(pl.level + " " +parent1);
				Console.WriteLine(pl2.level + " " + parent2);

				return pl.level == pl2.level && 
				       parent1 != parent2;

			}

			public TreeNode RecursiveFind(int val, TreeNode node, ParentLevel pl)
			{
				pl.level++;
				if (node == null)
				{
					pl.level--;
					return null;
				}
				if (node.val == val)
					return node;
				TreeNode findL = RecursiveFind(val, node.left, pl);
				if (findL != null)
				{
					pl.parentValues.Add(node.val); 
					return findL;
				}
				TreeNode findR = RecursiveFind(val, node.right, pl);
				if (findR != null)
				{
					pl.parentValues.Add(node.val);
					return findR;
				}

				pl.level--;

				return null;
			}
		}

		public class ParentLevel
		{
			public int level;
			public List<int> parentValues = new List<int>();
		}

	}
}
