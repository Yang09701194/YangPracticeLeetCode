using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _378_KthSmallestElementinaSortedMatrix
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			//[[1,3,5],[6,7,12],[11,14,14]]
			//4
			Console.WriteLine(s.KthSmallest(new int[][]
				{
					new []{1,3,5},
					new [] {6,7,12},
					new []{11,14,14},
				},
				4
				//2
			));



			Console.WriteLine(s.KthSmallest(new int[][]
				{
					new []{-5},
					
				},
				//8
				1
			));


			Console.WriteLine(s.KthSmallest(new int[][]
			{
				new []{1,5,9},
				new []{10,11,13},
				new []{12,13,15},
			}, 
				8
				//2
				));

		}





		public class Solution
		{
			public int KthSmallest(int[][] matrix, int k)
			{
				int n = matrix.Length;
				int minIdx = k - 1;// 2 - 1
				int maxIdx = n * n - k; // 9 - 8
				List<int> vPoss = new List<int>();

				if (maxIdx <= n)
				{
					// eg �ĤK�j  8~9 > 7~8   0 ,1
					for (int i = n - maxIdx - 1; i < n; i++)
					{
						for (int j = n - 1; j >= n - 1 - i; j--)
						{
							vPoss.Add(matrix[i][j]);
						}
					}

					vPoss = vPoss.OrderByDescending(v => v).ToList();
					return vPoss[maxIdx];
				}
				else if (minIdx < n)
				{
					for (int i = 0; i <= minIdx; i++)
					{
						for (int j = 0; j <= minIdx - i; j++)
						{
							vPoss.Add(matrix[i][j]);
						}
					}

					vPoss = vPoss.OrderBy(v => v).ToList();
					return vPoss[minIdx];
				}
				else
				{

					for (int i = 0; i < n; i++)
					{
						for (int j = 0; j < n; j++)
						{
							vPoss.Add(matrix[i][j]);
						}
					}

					vPoss = vPoss.OrderBy(v => v).ToList();
					return vPoss[k - 1];
				}
			}
		
		}




		/// <summary>
		/// �ڬOı�o  �o�n���O�L�Ъ� Counting Sort
		/// ���O�x�} �]���C��Ƨ�
		/// ��ı�O �����[  �AOrder nlogn
		/// ���L�o�ؤS�h�[�@�ӱ���   ���Ʀn�Ǫ�    �@�w������
		/// ��������  �j��TLE �]����
		/// �Q����   �p���N�q���W��X��  �j���k�W��X��  ���Υ���
		/// �A�Q�@�U  �Ҧp�ĤT�p  ���i��O  ���W ���� �W�W  
		/// �H������  �ڲq  ���ݬO���j�ٰ��p  �N�q���W �Υk�U �Υu���� (�]���P�ɦҼ{ �k�U,��,�W)
		/// �Y��k�p  �N�����i�� k*�W  ��+(k-1)*�W  ����k-2�W  �]�N�O �ר��u
		/// �Ӹո�
		///
		/// ���� �n����������  ex 3x3  123�i�ΤW��  ���O 4 �H�W���ӻ� �i���m��4���Ϲ﨤�u
		/// �N�n�Ҽ{�����F  �N��ok
		/// ���ӷQ�k  �H5x5  �q�D�﨤�u�����W �C���@��
		///
		/// ���� �]�����] 4,4 �O�����W�@ ���O���@�w��n�e�|�p���b4~5��2x2 �W�������i��O�T�ӤW
		///
		/// �ҥH��X��  �J�M�T�p �i�� �W�W  ����  �Φۤv �� �W
		/// ���]�N�O�@��list ��k�p  �N�O�h���ۤv  �A��k-1�Ӥ�����k��  �ܹ��ƦC�զX
		/// �]���n�p �@�w�O���� �Ω��W �]���i��@�� �@�W
		/// �Ҧp��5�p�����W�W  �i��O  �� �M ���� �٦��W �M�W�W  �]���i��O�s��ʧ@�����W�W
		/// �Ϊ� ��  ���W ���W�W  ����
		/// ���O�o�˷Q  �Sı�o�S���@�ө��T�������X��
		///
		/// �S�Q��@�Ӻ�X��  ���C���I  ���i�H�����ݥX�W���̦h���X�ӧ�j��
		/// ����  �q�o��i�H�ݥX  �N��T�p  �W�W�]���@�w  �u�O�إi��
		/// ���p��n����  �Ϲ﨤�u��ok �]���T��N�O�̪����|  �u���|���|�]�t�b�d��
		///
		/// �j��n  < n^2
		/// �o�˪����|    �T�꦳�i���J���W�b��
		/// 
		/// �ҥH���i��u�� �W�Ln �N�n�Ҽ{����
		/// ��~�٦b�Ȥ~n �N��������  �|���|�e��TLE  ���ոզn�F
		///
		/// >-------
		///
		/// �G�M�L��  ���׳���
		/// 160 ms, faster than 51.80%
		/// 39.7 MB, less than 5.40% of C#
		/// </summary>
		public class Solution_V1
		{
			public int KthSmallest(int[][] matrix, int k)
			{
				int n = matrix.Length;
				int minIdx = k - 1;// 2 - 1
				int maxIdx = n * n - k; // 9 - 8
				List<vPos> vPoss = new List<vPos>();

				if (maxIdx <= n)
				{
					// eg �ĤK�j  8~9 > 7~8   0 ,1
					for (int i = n-maxIdx-1; i < n; i++)
					{
						for (int j = n-1; j >= n -1 - i; j--)
						{
							vPoss.Add(new vPos {row = i, col = j, val = matrix[i][j]});
						}
					}

					vPoss = vPoss.OrderByDescending(v => v.val).ToList();
					return vPoss[maxIdx].val;
				}
				else if (minIdx < n)
				{
					for (int i = 0; i <= minIdx; i++)
					{
						for (int j = 0; j <= minIdx - i; j++)
						{
							vPoss.Add(new vPos {row = i, col = j, val = matrix[i][j]});
						}
					}

					vPoss = vPoss.OrderBy(v => v.val).ToList();
					return vPoss[minIdx].val;
				}
				else
				{

					for (int i = 0; i < n; i++)
					{
						for (int j = 0; j < n; j++)
						{
							vPoss.Add(new vPos {row = i, col = j, val = matrix[i][j]});
						}
					}

					vPoss = vPoss.OrderBy(v => v.val).ToList();
					return vPoss[k - 1].val;
				}
			}


			public class vPos
			{
				public int row;
				public int col;
				public int val;
			}
		}



	}

}

