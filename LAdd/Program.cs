using System;
using Gtk;

namespace LAdd
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Title = "LAdd";
			win.Show ();
			Application.Run ();
		}
	}
}
