using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
    public static class CommonHelper
    {


        public static void PrintList<T>(this IList<T> ls)  
        {
            if (ls.Count == 0)
            {
                Console.WriteLine("list no item");
                return;
            }
            Console.WriteLine(
                ls.Select(i=>i.ToString()).Aggregate(
                    (pre, next) => pre + "," + next)
                    );
        }


	    public static List<List<T>> ChunkBy<T>(this IList<T> source, int chunkSize)
	    {
		    return source
			    .Select((x, i) => new { Index = i, Value = x })
			    .GroupBy(x => x.Index / chunkSize)
			    .Select(x => x.Select(v => v.Value).ToList())
			    .ToList();
	    }



	}

	

}
