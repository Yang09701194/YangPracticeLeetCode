using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5532_EvenOddTree
	{


		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			//Console.WriteLine(s.SpecialArray(new int[] { 3, 5 }));
			//Console.WriteLine(s.SpecialArray(new int[] { 0, 0 }));

		}

		/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
		public class Solution
		{
			public bool IsEvenOddTree(TreeNode root)
			{
				Dictionary<int, List<int>> levelLs = new Dictionary<int, List<int>>();
				RootNodeToLevel(0, levelLs, root);

				foreach (KeyValuePair<int, List<int>> kv in levelLs)
				{
					if (kv.Key % 2 == 0)
					{
						for (int i = 0; i < kv.Value.Count; i++)
						{
							if (kv.Value[i] % 2 == 0)
								return false;
							if (i < kv.Value.Count - 1 && kv.Value[i] >= kv.Value[i + 1])
								return false;
						}
					}
					else
					{
						for (int i = 0; i < kv.Value.Count; i++)
						{
							if (kv.Value[i] % 2 != 0)
								return false;
							if (i < kv.Value.Count - 1 && kv.Value[i] <= kv.Value[i + 1])
								return false;
						}
					}
				}

				return true;
			}

			public void RootNodeToLevel(int lvl, Dictionary<int, List<int>> levelLs, TreeNode t)
			{ 
				if(levelLs.ContainsKey(lvl))
					levelLs[lvl].Add(t.val);
				else
				{
					levelLs.Add(lvl, new List<int>() {t.val});
				}

				int lvlp = lvl + 1;
				if(t.left != null)
					RootNodeToLevel(lvlp, levelLs, t.left);
				if (t.right != null)

					RootNodeToLevel(lvlp, levelLs, t.right);
			}


		}


	}
}
