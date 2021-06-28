using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAlgo.DS;
using DSAlgo.ALGO;

namespace YangPracticeLeetCode.Solved
{
	class _329_LongestIncreasingPathinaMatrix
	{

		public static void Test()
		{
			Solution s = new Solution();

			///Console.WriteLine(s.NumPoints());

			Console.WriteLine(s.LongestIncreasingPath(
				new int[][]
				{
					new []{9,9,4},
					new []{6,6,8},
					new []{2,1,1},
				}));

			Console.WriteLine(s.LongestIncreasingPath(
				new int[][]
				{
					new []{3,4,5},
					new []{3,2,6},
					new []{2,2,1},
				}));

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
		/// �M�� DFS �ڦ���s  �i�H�O���L��X���I �����|���̤j�{��
		/// 
		/// </summary>
		public class Solution
		{
			public int LongestIncreasingPath(int[][] matrix)
			{
				Func<int, int, int, int> getIdx = (row, col, rowLen) => { return rowLen * row + col; };

				//�إ� graph   directed graph �� edge��V  �p->�j   mxn���I  �|��

				List<Tuple<int, int>> edges = new List<Tuple<int, int>>();
				
				//  matrix  m x n   int[�C][��]

				// 0 1 2    i=0 j= 0 + 1~3
				// 3 4 5    i=1 j= 3 + 1~3
				// 6 7 8    i=2 j= 6 + 1~3
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
						else if(matrix[i][j] > matrix[i][j + 1])
							edges.Add(Tuple.Create(right, left));
					}
				}
				//  ������
				for (int i = 0; i < matrix.Length; i++) //�T�w��
				{
					for (int j = 0; j < matrix[0].Length - 1; j++) //�C
					{
						int left = getIdx(j, i, rowLength);
						int right = getIdx(j+1, i, rowLength);

						if (matrix[j][i] < matrix[j+1][i])
							edges.Add(Tuple.Create(left, right));
						else if(matrix[j][i] > matrix[j+1][i])
							edges.Add(Tuple.Create(right, left));
					}
				}

				List<int> vertexes = new List<int>();
				for (int i = 0; i < rowLength * colLength - 1; i++)
				{
					vertexes.Add(i);
				}

				//graph
				Graph<int> graph = new Graph<int>(vertexes, edges, GraphOption.Diirected);

				DFS_Algo dfs = new DFS_Algo();
				//DFS_Algo.IsMarkGrayDark = false;
				dfs.DFS(0, graph);

				int maxDfsPath = dfs.GetMaxDfsPathLen();

				return maxDfsPath;
			}
		}
	}
}
