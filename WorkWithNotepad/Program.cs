using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WorkWithNotepad
{
	internal class Program
	{
		[DllImport("user32.dll")]
		private static extern int SendMessage(IntPtr windowHandle, uint message, string addString1, string addString2);
		static void Main(string[] args)
		{
			Process[] processes = Process.GetProcesses();
			Process notepad = new Process();
			foreach (Process process in processes)
			{
				if (process.ProcessName == "notepad")
				{
					notepad = process; break;
				}
			}
			System.Timers.Timer timer = new System.Timers.Timer();
			timer.Interval = 1000;
			timer.Elapsed += UpdateTime;
		}

		public static void UpdateTime(Process process)
		{
			SendMessage(process.MainWindowHandle, 0x0C, string.Empty, DateTime.Now.ToString());
		}
	}
}
