using System;

namespace LAdd
{
	public partial class AddLinkWindow : Gtk.Window
	{
		public AddLinkWindow () :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
	}
}

