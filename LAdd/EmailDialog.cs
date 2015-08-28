using System;
using System.Net.Mail;

namespace LAdd
{
	public partial class EmailDialog : Gtk.Dialog
	{
		public EmailDialog ()
		{
			this.Build ();
			this.Title = "Share current database via email!";
		}

		protected void onSendEmail (object sender, EventArgs e)
		{
			string fromEmail = enFrom.Text;
			string toEmail = enTo.Text;
			if (fromEmail.Length > 0 && toEmail.Length > 0) {
				labelStatus.Text = "Not yet implment!";
			} else {
				labelStatus.Text = "Email is NOT sendt!";
			}
		}
	}
}

