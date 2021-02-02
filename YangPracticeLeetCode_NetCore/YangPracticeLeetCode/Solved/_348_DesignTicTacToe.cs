using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _348_DesignTicTacToe
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());


			TicTacToe t = new TicTacToe(2);
			Console.WriteLine(t.Move(0, 1, 2));
			Console.WriteLine(t.Move(1, 0, 1));
			Console.WriteLine(t.Move(1, 1, 2));


			t = new TicTacToe(3);
			Console.WriteLine(t.Move(0, 0, 1));
			Console.WriteLine(t.Move(0,2,2));
			Console.WriteLine(t.Move(2,2,1));
			Console.WriteLine(t.Move(1,1,2));
			Console.WriteLine(t.Move(2,0,1));
			Console.WriteLine(t.Move(1,0,2));
			Console.WriteLine(t.Move(2,1,1));


		}




		/// <summary>
		/// �O�H�ָ̧�   ���h�մX��  �]�O�| 50~90 ����  �ҥH�t�רS���u���j�t��
		/// �t���h  ���Ӱ}�C�u����
		/// �o�ӷQ�k ���Ӥ]�O�g��Q�k   �Τ@�ӼƦr�֥[  �N��@��C���ֿn��  �@�C²�Ƭ��@�Ӽ�
		/// ��   �ץ�P
		///
		/// �o�O�H�¼ƾڨӬ�
		/// ���O�A�� discuss  �o�{�o�˸�   �u�����ֳt���B
		/// https://leetcode.com/problems/design-tic-tac-toe/discuss/81898/Java-O(1)-solution-easy-to-understand
		/// �u���C��move �� O 1 ���ĪG
		///
		/// ��C  �n for 0~n �ˬd��  �ҥH��ڤW�٬O O n
		/// �o�˦]���u�֥[8�ӼƦr  �[�W  arr �� o 1 �ҥH���� n �v�T  �ٯu�� o 1
		/// 
		/// </summary>
		public class TicTacToe
		{
			private int[] rowsPlayer1;
			private int[] colsPlayer1;
			private int[] rowsPlayer2;
			private int[] colsPlayer2;
			private int diagonalMainPlayer1;
			private int diagonalMainPlayer2;
			private int diagonalAlternatePlayer1;
			private int diagonalAlternatePlayer2;
			private int n;
			/** Initialize your data structure here. */
			public TicTacToe(int n)
			{
				rowsPlayer1 = new int[n];
				colsPlayer1 = new int[n];
				rowsPlayer2 = new int[n];
				colsPlayer2 = new int[n];
				this.n = n;
			}

			/** Player {player} makes a move at ({row}, {col}).
				@param row The row of the board.
				@param col The column of the board.
				@param player The player, can be either 1 or 2.
				@return The current winning condition, can be either:
						0: No one wins.
						1: Player 1 wins.
						2: Player 2 wins. */
			public int Move(int row, int col, int player)
			{
				if (player == 1)
				{
					rowsPlayer1[row] += 1;
					colsPlayer1[col] += 1;
					if (row == col)
						diagonalMainPlayer1 += 1;
					if (row + col == n - 1)
						diagonalAlternatePlayer1 += 1;

					if (rowsPlayer1[row] == n || colsPlayer1[col] == n || diagonalMainPlayer1 == n || diagonalAlternatePlayer1 == n)
						return 1;
				}
				else
				{
					rowsPlayer2[row] += 1;
					colsPlayer2[col] += 1;

					if (row == col)
						diagonalMainPlayer2 += 1;
					if (row + col == n - 1)
						diagonalAlternatePlayer2 += 1;

					if (rowsPlayer2[row] == n || colsPlayer2[col] == n || diagonalMainPlayer2 == n || diagonalAlternatePlayer2 == n)
						return 2;
				}

				return 0;
			}
		}
		
		/// <summary>
		/// �A�[�t ?
		/// �Q��ٲ�   nxn  �@�H�s���٨S�Un�B�e ���|�s�u   �i�����^�� �L���G
		/// �L�k�[�֫ܦh 100^2 :100  �ʤ����@
		/// </summary>
		class TicTacToe_V2
		{

			int[,] board = null;
			private int size = 0;

			/** Initialize your data structure here. */
			public TicTacToe_V2(int n)
			{
				board = new int[n, n];
				size = n;
			}

			/** Player {player} makes a Move at ({row}, {col}).
				@param row The row of the board.
				@param col The column of the board.
				@param player The player, can be either 1 or 2.
				@return The current winning condition, can be either:
						0: No one wins.
						1: Player 1 wins.
						2: Player 2 wins. */
			private int totalMove = 0;
			public int Move(int row, int col, int player)
			{
				board[row, col] = player;

				totalMove++;
				if (totalMove < size)//�i��@��s��U
					return 0;

				return CheckWin(row, col, player);
			}

			private HashSet<string> diagonalPts = null;
			private int CheckWin(int row, int col, int player)
			{
				//  vertical
				bool isWin = true;
				for (int _row = 0; _row < size; _row++)
				{
					if (board[_row, col] != player)
					{
						isWin = false;
						break;
					}
				}
				if (isWin)
					return player;

				//  horizontal
				isWin = true;
				for (int _col = 0; _col < size; _col++)
				{
					if (board[row, _col] != player)
					{
						isWin = false;
						break;
					}
				}
				if (isWin)
					return player;

				//  diagonal   3x3 > 1,1 2,2 3,3 3,1 1,3  4x4 1,1 2,2 3,3 4,4  4,1 3,2 2,3 1,4
				if (diagonalPts == null)
				{
					diagonalPts = new HashSet<string>();
					for (int i = 0; i < size; i++)
					{
						diagonalPts.Add($"{i}_{i}");
						diagonalPts.Add($"{size - 1 - i}_{i}");
					}
				}
				if (diagonalPts.Contains($"{row}_{col}"))
				{
					isWin = true;
					for (int i = 0; i < size; i++)
					{
						if (board[size - 1 - i, i] != player)
						{
							isWin = false;
							break;
						}
					}
					if (isWin)
						return player;

					isWin = true;
					for (int i = 0; i < size; i++)
					{
						if (board[i, i] != player)
						{
							isWin = false;
							break;
						}
					}
					if (isWin)
						return player;
				}

				return 0;
			}

		}



		/// <summary>
		/// ��   �ˬd �����     29% ~ 93%
		///
		/// Runtime: 136 ms, faster than 93.27% of C# online submissions for Design Tic-Tac-Toe.
		//Memory Usage: 35.6 MB, less than 26.91% of C# online submissions for Design Tic-Tac-Toe.
		//
		//Runtime: 156 ms, faster than 29.60% of C# online submissions for Design Tic-Tac-Toe.
		//Memory Usage: 35.5 MB, less than 42.60% of C# online submissions for Design Tic-Tac-Toe.
		/// </summary>
		class TicTacToe_V1
		{

			int [,] board = null;
			private int size = 0;

			/** Initialize your data structure here. */
			public TicTacToe_V1(int n)
			{
				board = new int[n,n];
				size = n;
			}

			/** Player {player} makes a Move at ({row}, {col}).
				@param row The row of the board.
				@param col The column of the board.
				@param player The player, can be either 1 or 2.
				@return The current winning condition, can be either:
						0: No one wins.
						1: Player 1 wins.
						2: Player 2 wins. */
			public int Move(int row, int col, int player)
			{
				board[row, col] = player;

				return CheckWin(row, col, player);
			}

			private HashSet<string> diagonalPts = null;
			private int CheckWin(int row, int col, int player)
			{
				//  vertical
				bool isWin = true;
				for (int _row = 0; _row < size; _row++)
				{
					if (board[_row, col] != player)
					{
						isWin = false;
						break;
					}
				}
				if (isWin)
					return player;

				//  horizontal
				isWin = true;
				for (int _col = 0; _col < size; _col++)
				{
					if (board[row, _col] != player)
					{
						isWin = false;
						break;
					}
				}
				if (isWin)
					return player;

				//  diagonal   3x3 > 1,1 2,2 3,3 3,1 1,3  4x4 1,1 2,2 3,3 4,4  4,1 3,2 2,3 1,4
				if (diagonalPts == null)
				{
					diagonalPts = new HashSet<string>();
					for (int i = 0; i < size; i++)
					{
						diagonalPts.Add($"{i}_{i}");
						diagonalPts.Add($"{size - 1 - i}_{i}");
					}
				}
				if (diagonalPts.Contains($"{row}_{col}"))
				{
					isWin = true;
					for (int i = 0; i < size; i++)
					{
						if (board[size - 1 - i, i] != player)
						{
							isWin = false;
							break;
						}
					}
					if (isWin)
						return player;

					isWin = true;
					for (int i = 0; i < size; i++)
					{
						if (board[i, i] != player)
						{
							isWin = false;
							break;
						}
					}
					if (isWin)
						return player;
				}

				return 0;
			}

		}

		/**
		 * Your TicTacToe object will be instantiated and called as such:
		 * TicTacToe obj = new TicTacToe(n);
		 * int param_1 = obj.Move(row,col,player);
		 */



	}
}
