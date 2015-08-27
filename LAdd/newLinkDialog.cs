﻿using System;
using Gtk;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Configuration;
#if __MonoCS__
	using SQLiteCommand = Mono.Data.Sqlite.SqliteCommand;
	using SQLiteConnection = Mono.Data.Sqlite.SqliteConnection;
	using SQLiteDataReader = Mono.Data.Sqlite.SqliteDataReader;
	using SQLiteException = Mono.Data.Sqlite.SqliteException;
#else
	using SQLiteCommand = System.Data.SQLite.SQLiteCommand;
	using SQLiteConnection = System.Data.SQLite.SQLiteConnection;
	using SQLiteDataReader = System.Data.SQLite.SQLiteDataReader;
	using SQLiteException = System.Data.SQLite.SQLiteException;
#endif
namespace LAdd
{
	public partial class newLinkDialog : Gtk.Dialog
	{
		private string titleLoadingText = "Loading ...";
		private string selectedDbPath;
		private SQLiteConnection dbConn = new SQLiteConnection ();
		private Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
		public newLinkDialog ()
		{
			this.Build ();
			this.SetPosition (Gtk.WindowPosition.Center);
			//get then set SQLconn by selectedDbPath from appconfig
			if (config.AppSettings.Settings.Count > 0) {
				selectedDbPath = config.AppSettings.Settings ["selectedDbPath"].Value.ToString ();
				if (File.Exists (selectedDbPath)) {
					dbConn.ConnectionString = "Data Source=" + selectedDbPath;

					fillCbFlagWithAllFlagTypes ();
					fillInputsFromClipboard ();

					/* retry getting title if value enter in entryLink widget*/
					entryLink.Activated += entryLink_activated;
					entryLink.GrabFocus ();
					Gtk.Clipboard.Get (Gdk.Selection.Clipboard).OwnerChange += onClipboardOwnerChange;
				} else {
					lockInputs ();
				}
			} else lockInputs ();
		}
		private void lockInputs (){
			entryTitle.IsEditable = false;
			entryLink.IsEditable = false;
		}
		protected void entryLink_activated (object sender, EventArgs e)
		{
			string link = entryLink.Text.Trim ();
			if (link.StartsWith ("http")) {
				/*try get retrive the <Title> base on url*/
				Thread th = new Thread (() => _getWebPageTitle (link));
				th.Start ();
			}
		}
		protected void onClipboardOwnerChange(object sender, EventArgs e){
			fillInputsFromClipboard ();
		}
		private void fillInputsFromClipboard(){
			String urlFromClipboard = Gtk.Clipboard.Get (Gdk.Selection.Clipboard).WaitForText ();
			if (urlFromClipboard != null) {
				entryLink.Text = urlFromClipboard;
				if (urlFromClipboard.StartsWith ("http")) {
					/*try get retrive the <Title> base on url*/
					Thread th = new Thread (() => _getWebPageTitle (urlFromClipboard));
					th.Start ();
				}
			}
		}
		/* this method is from this blog.
		 * http://blogs.msdn.com/b/noahc/archive/2007/02/19/get-a-web-page-s-title-from-a-url-c.aspx */
		protected void fillCbFlagWithAllFlagTypes(){
			dbConn.Open ();
			String getAllFlagTypesQ = "select * from FlagTypes;";
			try {
				SQLiteCommand cmd = new SQLiteCommand(getAllFlagTypesQ, dbConn);
				SQLiteDataReader reader = cmd.ExecuteReader();
				while(reader.Read()){
					cbFlag.AppendText (reader["title"].ToString());
				}
			} catch (SQLiteException e){
				Console.Write (e.ToString());
			}
			dbConn.Close ();
		}
		private bool _checkIfInputDataIsInDb(){
			string link = entryLink.Text.Trim();
			if (link.Length > 0 && cbFlag.ActiveText != null) {
				string lookupCheckQ = "select count(*) as numberOfRows from Links "+
						"where link='"+link+"' "+ 
						"and flag=(select flagid from FlagTypes where title='"+cbFlag.ActiveText+"');";
				try {
					SQLiteCommand cmd = new SQLiteCommand (lookupCheckQ, dbConn);
					dbConn.Open ();
					SQLiteDataReader reader = cmd.ExecuteReader ();
					if (reader.Read ()) {
						Console.WriteLine (reader ["numberOfRows"]);
						if(Convert.ToInt32( reader["numberOfRows"]) >0){ 
							dbConn.Close ();
							return true;
						} else {
							dbConn.Close ();
							return false;
						}
					} else {
						dbConn.Close ();
						return false;
					}
				} catch (Exception e) {
					dbConn.Close ();
					Console.WriteLine (e.ToString ());
					return false;
				}
			} else {
				return false;
			}
		}
		protected void newLinkDialog_btnOk (object sender, EventArgs e)
		{
			if (!_checkIfInputDataIsInDb ()) {
				string title = entryTitle.Text.Trim();
				string link = entryLink.Text;
				if (title.Length > 0 && link.Length > 0) {
					if (cbFlag.ActiveText != null) {
						string insertLinkQ = "insert into Links (title, link, flag) " +
						                     "values ('" + title + "', '" + link + "', " +
						                     "(select flagid from FlagTypes where title='" + cbFlag.ActiveText + "'));";		
						try {
							SQLiteCommand cmd = new SQLiteCommand (insertLinkQ, dbConn);
							dbConn.Open ();
							//try to insert a userdefine link.
							if (cmd.ExecuteNonQuery () > 0) {
								this.Destroy (); //kill newLinkDialog
							} else {
								labelStatus.Text = "Error: Link is NOT saved!";
							}
							dbConn.Close ();
						} catch (SQLiteException e2) {
							Console.Write (e2.ToString ());
						}
					} else {
						cbFlag.GrabFocus ();
						cbFlag.ShowNow ();
						labelStatus.Text = "You need to choose a flag!";
					}
				} else {
					labelStatus.Text = "Need add title and link";
				}
			} else {
				entryLink.GrabFocus ();
				labelStatus.Text = "This link exists!";
			}
		}
		protected void onBtnPasteClipboardTextIntoEntryLinkClicked (object sender, EventArgs e)
		{
			labelStatus.Text = "";
			fillInputsFromClipboard ();
		}
		protected void newLinkDialog_btnClose (object sender, EventArgs e)
		{
			this.Destroy ();
		}
		/* this method is from this blog.
		 * http://blogs.msdn.com/b/noahc/archive/2007/02/19/get-a-web-page-s-title-from-a-url-c.aspx */
		private void _getWebPageTitle(string url)
		{
			entryTitle.Text = titleLoadingText;
			// Create a request to the url
			HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;

			// If the request wasn't an HTTP request (like a file), ignore it
			//if (request == null) return null;

			// Use the user's credentials
			request.UseDefaultCredentials = true;

			// Obtain a response from the server, if there was an error, return nothing
			HttpWebResponse response = null;
			try { 
				response = request.GetResponse() as HttpWebResponse; 
				// Regular expression for an HTML title
				string regex = @"(?<=<title.*>)([\s\S]*)(?=</title>)";
				// If the correct HTML header exists for HTML text, continue
				if (new List<string> (response.Headers.AllKeys).Contains ("Content-Type"))
				if (response.Headers ["Content-Type"].StartsWith ("text/html")) {
					// Download the page
					WebClient web = new WebClient ();
					web.UseDefaultCredentials = true;
					string page = web.DownloadString (url);

					// Extract the title
					Regex ex = new Regex (regex, RegexOptions.IgnoreCase);
					entryTitle.Text = "";
					entryTitle.Text = ex.Match (page).Value.Trim ();
				} else {
					entryLink.Text = "";
				}
			} catch (WebException) { 
				//return null; 
			}
		}
		protected void onAddNewFalgType (object sender, EventArgs e)
		{
			if (enFlagtitle.Text.Length > 0) {
				string addQ = "insert into FlagTypes (title) values ('"+enFlagtitle.Text+"');";
				SQLiteCommand cmd = new SQLiteCommand (addQ, dbConn);
				dbConn.Open ();
				if (cmd.ExecuteNonQuery () > 0){
					dbConn.Close ();
					labelStatus.Text = enFlagtitle.Text + " falg is added!";
					enFlagtitle.Text = "";
					fillCbFlagWithAllFlagTypes ();
				} else{
					dbConn.Close ();
					labelStatus.Text = enFlagtitle.Text + " falg is NOT added!";
				}
			} else {
				labelStatus.Text = "You need to defind a flagname!";
				enFlagtitle.GrabFocus ();
			}
		}
		protected void onRemoveNewFalgType (object sender, EventArgs e)
		{
			if (enFlagtitle.Text.Length > 0) {
				string removeQ = "delete from FlagTypes where flagid=(select flagid from FlagTypes where title='"+enFlagtitle.Text+"');";
				SQLiteCommand cmd = new SQLiteCommand (removeQ, dbConn);
				dbConn.Open ();
				if (cmd.ExecuteNonQuery () > 0) {
					labelStatus.Text = cbFlag.ActiveText + " is removed!";
					enFlagtitle.Text = "";
					dbConn.Close ();
					fillCbFlagWithAllFlagTypes ();
				} else {
					dbConn.Close ();
					labelStatus.Text = (cbFlag.ActiveText != null) ? (cbFlag.ActiveText + " is NOT removed!") : "Flag is NOT removed!";
				}
			} else {
				labelStatus.Text = "You need to defind a flagname!";
				enFlagtitle.GrabFocus ();
			}
		}
	}
}