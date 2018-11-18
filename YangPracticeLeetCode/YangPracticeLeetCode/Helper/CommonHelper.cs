using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Helper
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


    }
}
