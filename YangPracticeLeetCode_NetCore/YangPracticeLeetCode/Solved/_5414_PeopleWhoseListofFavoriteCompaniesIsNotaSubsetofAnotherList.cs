using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5414_PeopleWhoseListofFavoriteCompaniesIsNotaSubsetofAnotherList
	{


		public static void Test()
		{
			Solution s = new Solution();


			//[["leetcode","google","facebook"],["google","microsoft"],["google","facebook"],["google"],["amazon"]]
				//s.PeopleIndexes(new List<IList<string>>()
				//{
				//	new List<string>() {"leetcode","google","facebook" },
				//	new List<string>() {"google","microsoft" },
				//	new List<string>() { "google","facebook"},
				//	new List<string>() {"google" },
				//	new List<string>() { "amazon"},


				//}).PrintList();

			//[["kmccktodigztyrwpvlif","mcircxcauajyzlppedqy","rgjghlcicyocusukhmjb","zkcqvffyeekjdwqtjege"],["kfkzsjhkdrtsztchhazh","kmccktodigztyrwpvlif","rgjghlcicyocusukhmjb"],["kfkzsjhkdrtsztchhazh","kmccktodigztyrwpvlif","mcircxcauajyzlppedqy","zkcqvffyeekjdwqtjege"],["kfkzsjhkdrtsztchhazh","kmccktodigztyrwpvlif","mcircxcauajyzlppedqy","rgjghlcicyocusukhmjb"],["kfkzsjhkdrtsztchhazh","kmccktodigztyrwpvlif"]]

			s.PeopleIndexes(new List<IList<string>>()
			{
				new List<string>() { "kmccktodigztyrwpvlif","mcircxcauajyzlppedqy","rgjghlcicyocusukhmjb","zkcqvffyeekjdwqtjege"},
				new List<string>() {"kfkzsjhkdrtsztchhazh","kmccktodigztyrwpvlif","rgjghlcicyocusukhmjb" },
				new List<string>() { "kfkzsjhkdrtsztchhazh","kmccktodigztyrwpvlif","mcircxcauajyzlppedqy","zkcqvffyeekjdwqtjege"},
				new List<string>() { "kfkzsjhkdrtsztchhazh","kmccktodigztyrwpvlif","mcircxcauajyzlppedqy","rgjghlcicyocusukhmjb"},
				new List<string>() { "kfkzsjhkdrtsztchhazh","kmccktodigztyrwpvlif"},
				

			}).PrintList();

		}


		public class Solution
		{
			public IList<int> PeopleIndexes(IList<IList<string>> favoriteCompanies)
			{
				Dictionary<int, IList<Dictionary<string, string>>> dics = new Dictionary<int, IList<Dictionary<string, string>>>();
				foreach (IList<string> list in favoriteCompanies)
				{
					if(!dics.ContainsKey(list.Count))
						dics.Add(list.Count, new List<Dictionary<string, string>>()
						{
							list.ToDictionary(c => c)
						});
					else
					{
						dics[list.Count].Add(list.ToDictionary(c => c));
					}
				}

				List<int> distinct = new List<int>();

				int max = dics.Max(d => d.Key);
				for (int i = 0; i < favoriteCompanies.Count; i++)
				{
					bool isDistinct = true;
					bool isbreak = false;

					var list = favoriteCompanies[i];
					int len = list.Count;
					for (int j = len + 1; j <= max; j++)//題意同數量不用比 一定不同 所以+1
					{
						if (!dics.ContainsKey(j))
							continue;
						var other = dics[j];


						foreach (var oth in other)
						{
							isDistinct = false;
							isbreak = false;
							for (int k = 0; k < len; k++)
							{
								if (!oth.ContainsKey(list[k]))
								{
									isDistinct = true;
									break;
								}
							}

							if (!isDistinct)
								break;

						}
						if (!isDistinct)
							break;
						
					}

					if (isDistinct)
						distinct.Add(i);
				}

				return distinct;
			}
		}

	}
}
