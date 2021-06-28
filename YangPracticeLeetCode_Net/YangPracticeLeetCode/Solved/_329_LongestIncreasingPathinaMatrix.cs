using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAlgo.DS;

namespace YangPracticeLeetCode.Solved
{
	class _329_LongestIncreasingPathinaMatrix
	{

		public static void Test()
		{
			Solution s = new Solution();

			///Console.WriteLine(s.NumPoints());

			Console.WriteLine(s.SpecialArray(new int[] {3, 5}));

		}





		/// <summary>
		///
		/// ���Q��  ���Wpath  �i�H�� < �����Y  �νb�Y���  �p -> �j
		/// �F���V�ۦP���i�H�۳s   �N�ܦ�  directed graph
		/// �S�n��path  �i��i�H��  dfs  ��  bfs
		/// �ҿת� path ���� �i�H���N�O path finding���ɭ� �X�{�L���̪�����
		/// �ӥB DFS  �|�۰��׶}�w���X�L���I
		///
		/// ���e�@�i�� �b evernote     �p�G�O nxn �Ӽ�  ��ƾF����I�s���@�u  �ѹϥi�ݥX  ��Ʒ|�O
		/// 4x4  4-1 *  4+4 
		/// nxn  (n-1)* 2n =  2n^2 - 2n
		///
		/// 5x3  5-1 * 3 + 3-1* 5
		/// mxn  (m-1)* n + (n-1)*m = mn - n + mn - m = 2mn-m-n
		/// 
		/// �Ҧ���  �i���O   �����ѥ����k��   �ѤW�C���U�C    ������  ���橹�k��
		/// �ҥH for i �T�w  j = 1~n     j�T�w  i = 1~n   �Ҧ���c�� Graph with adjacency list
		/// 
		/// </summary>
		public class Solution
		{
			public int LongestIncreasingPath(int[][] matrix)
			{
				//�إ� graph   directed graph �� edge��V  �p->�j   mxn���I  �|��

				Graph<int> graph = new Graph<int>();


				List<Tuple<int, int>> edges = new List<Tuple<int, int>>();

				Func<int, int, int, int> getIdx = (row, col, rowLen) => { return rowLen * row + col; };

				//  matrix  m x n   int[�C][��]

				// 1 2 3   i=0 j= 0 + 1~3
				// 4 5 6   i=1 j= 3 + 1~3
				// 7 8 9   i=2 j= 6 + 1~3
				// �I���s��  ��G���ন  �@���丹  �p�W 3x3  �s�� 1~9  

				int rowLength = matrix.Length;
				int colLength = matrix[0].Length;

				//  ������
				for (int i = 0; i < rowLength; i++) //�T�w�C
				{
					for (int j = 0; j < colLength - 1; j++) //��
					{
						int left = getIdx(i, j, rowLength);
						int right = getIdx(i, j + 1, rowLength);

						if (matrix[i][j] < matrix[i][j + 1])
							edges.Add(Tuple.Create(left, right));
						else
							edges.Add(Tuple.Create(right, left));
					}
				}
				//  ������
				for (int i = 0; i < matrix.Length; i++) //�T�w��
				{
					for (int j = 0; j < matrix[0].Length - 1; j++) //��
					{
						int left = getIdx(i, j, rowLength);
						int right = getIdx(i, j + 1, rowLength);

						if (matrix[i][j] < matrix[i][j + 1])
							edges.Add(Tuple.Create(left, right));
						else
							edges.Add(Tuple.Create(right, left));
					}
				}

				graph


			}
		}
	}
}
