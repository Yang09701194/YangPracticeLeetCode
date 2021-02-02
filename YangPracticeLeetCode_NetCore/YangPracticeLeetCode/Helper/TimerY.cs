using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Helper
{
	public class TimerY
	{
		private DateTime _start = DateTime.Now;
		public TimerY()
		{
			_start = DateTime.Now;
		}

		public static TimerY New()
		{
			return new TimerY();
		}

		public string TimingMs(bool isPrint = false)
		{
			string ms = DateTime.Now.Subtract(_start).TotalMilliseconds.ToString();
			if(isPrint)
				Console.WriteLine(ms);
			return ms;
		}

	}
}
