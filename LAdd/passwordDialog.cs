using System;
namespace LAdd
{
	public partial class passwordDialog : Gtk.Dialog
	{
		public passwordDialog (string selectedDbPath)
		{
			this.Build ();
			this.Title = "Password protected";
			labelDbName.Text = selectedDbPath;
		}

		protected void onCancel (object sender, EventArgs e)
		{
			this.Destroy ();
		}

		protected void onOk (object sender, EventArgs e)
		{
			MainWindow mw = new MainWindow();
			if (enPassword.Text.Length > 0) { 
				mw.DbSetPassword = enPassword.Text.ToString ();
				this.Destroy ();
			} else enPassword.GrabFocus ();
		}
	}
}

