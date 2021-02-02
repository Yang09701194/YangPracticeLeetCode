using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _1616_SplitTwoStringstoMakePalindrome
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			Console.WriteLine(s.CheckPalindromeFormation("abda", "acmc"));

			Console.WriteLine(s.CheckPalindromeFormation("x", "y"));
			Console.WriteLine(s.CheckPalindromeFormation("abdef", "fecab"));
			Console.WriteLine(s.CheckPalindromeFormation("ulacfd", "jizalu"));
			Console.WriteLine(s.CheckPalindromeFormation("xbdef", "xecab"));

			Console.WriteLine(s.CheckPalindromeFormation("askxrrnhyddrlmcgymtichivmwyjfpyqqxmiimxqqypfjywmvihcitmygcmlryczoygimgii", "iigmigyozcyfxgfzkwpvjuxbjphbbmwlhdcavhtjhbpccsxaaiyitfbzljvhjoytfqlqrohv"));

		}


		/// <summary>
		/// �ۤv�Q�X�Ӫ�   ���test case ��i�T�� �i��]�� contest�D 100  100  �ҥH���S�� discuss  
		/// �q�L����  �~���[��test case �o�{�u��Ĥ@�Ӧr���P�٤���   ���U�Ӫ�test case  ���O�_�W���j�q�ۦP��  �ҥH�ۦP���o�Ǧr�q�����i�H�ٲ�����
		///
		/// �o�٨S�짹��  �����䩹�����  ���o�ۦP���̤jindex  ���U�Ӥ@�}�l�������� �٬O�� V1 �Ҧ��r��զX  ���G�٬OTLE �j���S�e�i3��test case
		///
		/// �̫�A�J�ӷQ  �o�{����    �������X�̤��ۦP�M���P���{���I
		/// �������� AB �M BA  ���U�u�����  �@�ӬO A+��B  �@��  ��A+B  �N�O�������O����A �N�O������ B   �]�������@��  �@�}�l���r���P  �����N���P�F  ���Τ�U�h
		///
		/// �N�q�L�F   substring ���_���I  �n��Q�o�ܲM��  �n�@���g�藍�e��
		/// </summary>
		public class Solution
		{
			public bool CheckPalindromeFormation(string a, string b)
			{
				if (a.Length == 1)
					return true;

				//combine all prefix and suffix   and check each combine str
				List<string> ABComb = new List<string>();
				List<string> BAComb = new List<string>();
				char aStart = a.First();
				char aEnd = a.Last();
				char bStart = b.First();
				char bEnd = b.Last();
				bool isAB = aStart == bEnd;
				bool isBA = bStart == aEnd;

				int ABStart = 0;
				for (int i = 0; i < a.Length; i++)
				{
					if (a[i] == b[a.Length - 1 - i])
						ABStart++;
					else
						break;
				}
				int BAStart = 0;
				for (int i = 0; i < a.Length; i++)
				{
					if (b[i] == a[a.Length - 1 - i])
						BAStart++;
					else
						break;
				}

				int middle = (int)Math.Ceiling((double) a.Length / (double) 2);

				
				Func<string, bool> check = (s) =>
				{
					bool isAnyDiff = false;
					for (int t = ABStart, e = s.Length - t - 1; t < e; t++, e--)
					{
						if (s[t] != s[e])
						{
							isAnyDiff = true;
							break;
						}
					}
					if (!isAnyDiff)
						return true;
					return false;
				};

				if (ABStart == middle)
					return true;
				string A_allB = $"{a.Substring(0, ABStart)}{b.Substring(ABStart, b.Length  - ABStart)}";
				string Aall_B = $"{a.Substring(0, b.Length - ABStart)}{b.Substring(b.Length - ABStart, ABStart)}";
				if (check(A_allB))
					return true;
				if (check(Aall_B))
					return true;

				if (BAStart == middle)
					return true;
				string B_allA = $"{b.Substring(0, BAStart)}{a.Substring(BAStart, a.Length  - BAStart)}";
				string Ball_A = $"{b.Substring(0, b.Length - BAStart)}{a.Substring(b.Length  - BAStart, BAStart)}";
				if (check(B_allA))
					return true;
				if (check(Ball_A))
					return true;

				return false;
			}
		}


		/// <summary>
		/// �ݨ�TLE���r��  �}�l�Q���S������S�x��ٮɶ�
		/// ���� �Q�����k��������P�r   �u�n�Ĥ@�Ӧr���P    �N���Opalindrome
		/// �o�ˤl�i�H����ը䤤�@��ex A�_B�W���P  �N�i�H�����ٱ��@�b���ɶ�
		/// �o�̶}�l��AB���}������
		/// ���O�o�ӧ�}�u�b���e��� test case
		/// </summary>
		public class SolutionV2
		{
			public bool CheckPalindromeFormation(string a, string b)
			{
				if (a.Length == 1)
					return true;

				//combine all prefix and suffix   and check each combine str
				List<string> ABComb = new List<string>();
				List<string> BAComb = new List<string>();
				char aStart = a.First();
				char aEnd = a.Last();
				char bStart = b.First();
				char bEnd = b.Last();
				bool isAB = aStart == bEnd;
				bool isBA = bStart == aEnd;

				int ABStart = 0;
				for (int i = 0; i < a.Length; i++)
				{
					if (a[i] == b[a.Length - 1 - i])
						ABStart++;
					else
						break;
				}
				for (int i = ABStart; i < a.Length; i++)
				{
					if (isAB)
						ABComb.Add($"{a.Substring(0, i)}{b.Substring(i, b.Length - i)}");
				}

				int BAStart = 0;
				for (int i = 0; i < a.Length; i++)
				{
					if (b[i] == a[a.Length - 1 - i])
						BAStart++;
					else
						break;
				}
				for (int i = BAStart; i < a.Length; i++)
				{
					if (isBA)
						BAComb.Add($"{b.Substring(0, i)}{a.Substring(i, a.Length - i)}");
				}



				foreach (string s in ABComb)
				{
					bool isAnyDiff = false;
					for (int t = ABStart, e = s.Length - t - 1; t < e; t++, e--)
					{
						if (s[t] != s[e])
						{
							isAnyDiff = true;
							break;
						}
					}
					if (!isAnyDiff)
						return true;
				}
				foreach (string s in BAComb)
				{
					bool isAnyDiff = false;
					for (int t = BAStart, e = s.Length - t - 1; t < e; t++, e--)
					{
						if (s[t] != s[e])
						{
							isAnyDiff = true;
							break;
						}
					}
					if (!isAnyDiff)
						return true;
				}

				return false;
			}
		}


		/// <summary>
		/// �Ĥ@��    �o��Q�k�ܳ��   �եX�Ҧ�  AB  �M BA  �����I�q 0 ~ len - 1
		/// �M������j�M   �i�H���Obrute force
		///
		/// ���@�ӭ��I �Q�q�o�D�N�|²��ܦh  �@�}�l�H���|�O�Ҧ��l�r��  �S��k�@���D��  ���U�۵M�N���o���p  �N�b�H���S�n��  divide and conquer �h���j��C�Ӥl�r��B��
		/// ���G�ݤF�ܤ[   ���ӳo�D�]���I�|���H�~�|   ��M�ݥX��ӥu�O�������Ӧr��O���O palindrome   ���u�n�]�@�������  ���䩹�����^�ӴN�d�w   �ݳz�o�I�|²��ܦh
		/// ���G�N TLE
		/// </summary>
		public class SolutionV1
		{
			public bool CheckPalindromeFormation(string a, string b)
			{
				//combine all prefix and suffix   and check each combine str
				List<string> allComb = new List<string>();
				for (int i = 0; i < a.Length; i++)
				{
					allComb.Add($"{a.Substring(0, i)}{b.Substring(i, b.Length - i)}");
					allComb.Add($"{b.Substring(0, i)}{a.Substring(i, a.Length - i)}");
				}

				foreach (string s in allComb)
				{
					bool isAnyDiff = false;
					for (int t = 0, e = s.Length - 1; t < e; t++, e--)
					{
						if (s[t] != s[e])
						{
							isAnyDiff = true;
						}
					}
					if (!isAnyDiff)
						return true;
				}

				return false;
			}
		}


	}
}
