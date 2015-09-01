using System;
using System.Net.Mail;
using System.Net;
namespace LAdd
{
	public partial class EmailDialog : Gtk.Dialog
	{
		public EmailDialog ()
		{
			this.Build ();
			this.Title = "Share current database!";
		}

		protected void onSendEmail (object sender, EventArgs e)
		{
			string fromEmail = enFrom.Text;
			string toEmail = enTo.Text;
			string subject = "";
			if (fromEmail.Length > 0 && toEmail.Length > 0) {
				labelStatus.Text = "Not yet implment!";
				/*
				var _fromAddress = new MailAddress(fromEmail, "From Name");
				var _toAddress = new MailAddress(toEmail, "To Name");
				var smtp = new SmtpClient
				{
					Host = "smtp.gmail.com",
					Port = 587,
					EnableSsl = true,
					DeliveryMethod = SmtpDeliveryMethod.Network,
					UseDefaultCredentials = false,
					Credentials = new NetworkCredential(_fromAddress.Address, fromEmail)
				};
				using (var message = new MailMessage(_fromAddress,)
				       {
					Subject = subject,
					Body = tvMessage
				})
				{
					smtp.Send(message);
				}*/
			} else {
				labelStatus.Text = "You need to defind all inputs!";
			}
		}

		protected void onCancal (object sender, EventArgs e)
		{
			this.Destroy ();
		}
	}
}

