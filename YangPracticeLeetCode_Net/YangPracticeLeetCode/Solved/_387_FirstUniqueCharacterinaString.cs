using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _387_FirstUniqueCharacterinaString
	{


		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			Console.WriteLine(s.FirstUniqChar("leetcode"));
			Console.WriteLine(s.FirstUniqChar("loveleetcode"));

		}

		

		/// <summary>
		/// �̰�����  �o�˼g���M�S���  96%   �ڭ쥻�H���Φr��@�ӭӧ�  ���I�b  �]���i��|�j�q���Ƨ�
		/// �ҥH�ڤU���N�O����26�Ӧr����@�M  ���o�˷|�Ψ�dic �i��N�C�F
		/// </summary>
		public class Solution
		{
			public int FirstUniqChar(String s)
			{

				Func<char, int> toAscii = c =>
				{
					return Convert.ToInt32(c) - 97;
				};


				int[] freq = new int[26];
				for (int i = 0; i < s.Length; i++)
					freq[s[i] - 'a']++;
				for (int i = 0; i < s.Length; i++)
					if (freq[s[i] - 'a'] == 1)
						return i;
				return -1;
			}
		}


		/// <summary>
		/// speed 80 ~ 96%    �����p�U��   �o�Ӥ���_��  �]��range����j
		/// </summary>
		public class SolutionMe
		{
			public int FirstUniqChar(string s)
			{

				Func<char, int> toAscii = c =>
				{
					return Convert.ToInt32(c) - 97;
				};

				int[] charPos = new int[26];
				int[] charCou = new int[26];

				for (int i = 0; i < s.Length; i++)
				{
					int cI = toAscii(s[i]);
					if (charPos[cI] == 0)
					{
						charPos[cI] = i;
					}

					int charNum = toAscii(s[i]);
					charCou[charNum]++;
				}

				int minPos = int.MaxValue;
				bool isAny1 = false;
				for (int i = 0; i < charCou.Length; i++)
				{
					if (charCou[i] == 1)
					{
						isAny1 = true;
						int pos = charPos[i];
						if (pos < minPos)
							minPos = pos;
					}
				}

				if (!isAny1)
					return -1;

				return minPos;

			}
		}




		/// <summary>
		/// �o�ˤl�O speed win 26%    ��ı�o�o�w�g�ܧ֤F  �]���ڦn���e�����M�@�U�N�Q�� O n���Ѫk   �o�D�ܮe�����p�ߴN O n^2  ������覡�y�L�����N > n�F   �o�D�S�Ψ�orderby nlogn �N���X��  �N�O�Q�ΤF�j�� �M��j�p
		/// �ҥH�٥u��26%  �J�ӬݴNı�o�i��r�� dic[]++ �ٯ�A��i   �ҥH�N�令�W�誺�}�C
		/// ���W�N 76%   �}�C���Q�k�Ψ�F�i��@�~�econtest���ɭ�  �Y�ӱ��p�U�নint�|�ܦn�B�z  ���I�N�|�OASCII���ƭ�   97�O���n�Ʀr
		/// �r��O�]��  �@�}�l�ncontainskey��1 �i�� binary search o nlogn? �Ϊ̧��  ����C�����n[]++  �o��n����hashset�@�� O 1 �Χ�C   ���O�����Q�N�|ı�o  dic�@�w���c�W�� arr�e�j����  �ҥH�N��A����  ���ӬO����C  �o��%�N�ҩ��F  
		/// </summary>
		public class SolutionV0
		{
			public int FirstUniqChar(string s)
			{
				Dictionary<char, int> charPos = new Dictionary<char, int>();
				Dictionary<char, int> charCou = new Dictionary<char, int>();

				for (int i = 0; i < s.Length; i++)
				{
					if (!charPos.ContainsKey(s[i]))
					{
						charPos[s[i]] = i;
					}

					if (!charCou.ContainsKey(s[i]))
					{
						charCou[s[i]] = 1;
					}
					else
					{
						charCou[s[i]]++;
					}
				}

				int minPos = int.MaxValue;
				bool isAny1 = false;
				foreach (var kv in charCou)
				{
					if (kv.Value == 1)
					{
						isAny1 = true;
						int pos = charPos[kv.Key];
						if (pos < minPos)
							minPos = pos;
					}
				}

				if (!isAny1)
					return -1;

				return minPos;

			}
		}

	}
}
