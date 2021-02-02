using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _334_IncreasingTripletSubsequence
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			Console.WriteLine(s.IncreasingTriplet(new int[] { 1, 1, -2, 6 }));
			//Console.WriteLine(s.IncreasingTriplet(new int[] { 1, 2, 3, 4, 5 }));
			//Console.WriteLine(s.IncreasingTriplet(new int[] { 5, 4, 3, 2, 1 }));
			//Console.WriteLine(s.IncreasingTriplet(new int[] { 2, 1, 5, 0, 4, 6 }));

		}



		/// <summary>
		///
		/// �v���\  ��@��  pass
		/// ���ܪ�����  �ण�� O n
		/// ����M�������L��� ��ı�����حǭǤ���� n^2  22�ۤ�  �N�O���إk�U�����  1~n  2~n ....
		/// ����  n^2 * n  ���ӬO n^3 �o�ӳB�z�|�u���ܽ���    �]���n�O���C�� ���p��j  ���⤸����
		/// �M��A�e����   �᭱���ժ��e����   �j��  �e�ժ��ᤸ��  �N�Otrue 
		///
		/// �������L�o�ث��  �ӷQ O n
		/// ��򨫤@�M�N���D���T�I�s��W��
		/// �W���p�Q���  �N�e���չ�
		/// �����N�|�Q��   ���W�A�U�A�W   �u�n�᭱���W  ����e�����W   ����  ��²�ƥu�n���L��e�����U �N��C��e�W �N�O�W��
		/// �ҥH�u�n���U�����q  �N�O�����̧C�I
		/// ���U�ӧ䦸�C�I  �b�@���I���󦸧C�I  �N����   �NO n�F
		///
		/// Runtime: 88 ms, faster than 91.75% of C# online submissions for Increasing Triplet Subsequence.
		/// Memory Usage: 25.2 MB, less than 81.75% of C# online submissions for Increasing Triplet Subsequence.
		/// Next challenges:
		///
		/// 
		/// </summary>
		public class Solution
		{
		
			public bool IncreasingTriplet(int[] nums)
			{
		
				int _1stLowestIdx = -1;
				int _2stLowestIdx = -1;
				int _3stLowestIdx = -1;
				_1stLowestIdx = 0;
				for (int i = 1; i < nums.Length; i++)
				{
					//  �o�䦳�@��  case  �p�G�g >  �e�G�� 1 1  �N�|�����i�U��if
					//  �M��N��  2st  �]��  �ĤG�� 1  �N���F   �ҥH�n��  >=  �N��ư����۵������p
					if (nums[_1stLowestIdx] >= nums[i])
					{
						_1stLowestIdx = i;
					}
					else if (_2stLowestIdx == -1)
					{
						_2stLowestIdx = i;
					}
					else if (_2stLowestIdx != -1 && nums[_2stLowestIdx] > nums[i])
					{
						_2stLowestIdx = i;
					}
					else if (_2stLowestIdx != -1 && nums[i] > nums[_2stLowestIdx])
					{
						return true;
					}

				}

				return false;

			}

		}

		// �o�D�ܤ���   �W���Q��  ��  Sol  �����ۦP
		// Sol �]�u���@��  ���g�h�r   �]�Q�P   �ҥH���i�ٲ�����  good
		//
		//
		// class Solution {
		//     public boolean increasingTriplet(int[] nums) {
		//         int first_num = Integer.MAX_VALUE;
		//         int second_num = Integer.MAX_VALUE;
		//         for (int n: nums) {
		//             if (n <= first_num) {
		//                 first_num = n;
		//             } else if (n <= second_num) {
		//                 second_num = n;
		//             } else {
		//                 return true;
		//             }
		//         }
		//         return false;
		//     }
		// }



	}

}

