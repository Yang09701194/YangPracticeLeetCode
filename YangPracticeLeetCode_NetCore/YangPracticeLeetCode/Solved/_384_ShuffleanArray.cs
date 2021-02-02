using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _384_ShuffleanArray
	{

		public static void Test()
		{
			//Solution s = new Solution();

			////Console.WriteLine(s.NumPoints());

			//Console.WriteLine(s.SpecialArray(new int[] { 3, 5 }));

		}


		/// <summary>
		/// Time complexity : \mathcal{O}(n)O(n)
		///The Fisher-Yates algorithm runs in linear time, as generating a random index and swapping two values can be done in constant time.
		///Space complexity : \mathcal{ O}(n)O(n)
		///Although we managed to avoid using linear space on the auxiliary array from the brute force approach, we still need it for reset, so we're stuck with linear space complexity.
		/// </summary>
		public class Solution
		{
			public int[] oriArr = null;
			public int[] shuffleArr = null;

			public Solution(int[] nums)
			{
				shuffleArr = nums;
				oriArr = nums.ToArray();

			}

			/** Resets the array to its original configuration and return it. */
			public int[] Reset()
			{
				return oriArr.ToArray();
			}

			Random rnd = new Random(Guid.NewGuid().GetHashCode());

			/** Returns a random shuffling of the array. */
			public int[] Shuffle()
			{
				//�y�L��@�U �h�� i j �ۦP�������i��� ���� +1 �H������
				// �N�A�i10%   336ms  81.78%
				// ���ӥD�n�t�b�o
				// �o�ؼg�k����O100%  �u�O�~�t���ֺC    320���Ѷ]�ӴX�� �]�|��340
				int i = rnd.Next(oriArr.Length);
				int j = rnd.Next(oriArr.Length);
				if (i == j)
					j += 1;

				int temp = shuffleArr[i];
				shuffleArr[i] = shuffleArr[j];
				shuffleArr[j] = temp;

				return shuffleArr;
			}
		}







		/// <summary>
		/// �����ۤv�g��  �@���L��  ����
		/// �]�O�� 71%   340ms
		///
		/// �ݨӳo�D�u���`���D  �ݹL���֦�
		/// ��Sol�~���O Fisher-Yates Algorithm
		///
		/// �����ݴy�z���I�����D�Ӹ`�ʧ@  �ε�����
		/// https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
		///  Write down the numbers from 1 through N.
		/// Pick a random number k between one and the number of unstruck numbers remaining(inclusive).
		/// Counting from the low end, strike out the kth number not yet struck out, and write it down at the end of a separate list.
		/// Repeat from step 2 until all the numbers have been struck out.
		/// The sequence of numbers written down in step 3 is now a random permutation of the original numbers. 
		///
		/// �ݼv��²��h�F
		/// https://www.youtube.com/watch?v=tLxBwSL3lPQ
		/// �N��ڤ��e�Ǫ��洫�ۦP
		///
		/// but for each possible permutation of the array to be truly
		/// equally likely
		///
		///Sol 1   random �q n arr �������� �]�O�����쪺�Q�k  �i��n^2
		///
		/// 
		/// </summary>
		public class Solution_V2
		{
			public int[] oriArr = null;
			public int[] shuffleArr = null;

			List<int[]> permutationIndex = new List<int[]>();


			public Solution_V2(int[] nums)
			{
				shuffleArr = nums;
				oriArr = nums.ToArray();

			}

			/** Resets the array to its original configuration and return it. */
			public int[] Reset()
			{
				return oriArr.ToArray();
			}

			Random rnd = new Random(Guid.NewGuid().GetHashCode());

			/** Returns a random shuffling of the array. */
			public int[] Shuffle()
			{
				int i = 0, j = 0;
				while (i == j)
				{
					i = rnd.Next(oriArr.Length);
					j = rnd.Next(oriArr.Length);
				}

				int temp = shuffleArr[i];
				shuffleArr[i] = shuffleArr[j];
				shuffleArr[j] = temp;

				return shuffleArr;
			}
		}



		/// <summary>
		/// Sol 2 ��o�ӫܹ�  ��ڤW�����P�O
		/// �L�O�� 1~n �������@��
		/// ���L�ڷs�g�� �C���u���@�� i j�٬O�L  �]��100ms
		///
		/// 
		/// </summary>
		public class Solution_V1
		{
			private int[] initNums = new int[] { };
			public Solution_V1(int[] nums)
			{
				initNums = nums;
			}

			/** Resets the array to its original configuration and return it. */
			public int[] Reset()
			{
				return initNums;
			}

			/** Returns a random shuffling of the array. */
			public int[] Shuffle()
			{
				int[] numCopy = initNums.ToArray();
				Random r = new Random();
				for (int i = initNums.Length - 1; i >= 1; i--)
				{
					int j = r.Next(0, i + 1);
					int temp = numCopy[i];
					numCopy[i] = numCopy[j];
					numCopy[j] = temp;
				}

				return numCopy;
			}

		}


	}
}
