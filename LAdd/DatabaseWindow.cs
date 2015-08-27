using System;
using System.IO;
using Gtk;
using System.Collections.Generic;
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
	public partial class DatabaseWindow : Gtk.Window
	{
		private List<string> allDbPaths = new List<string> ();
		private TreeStore ts;
		private TreeView tv;
		private SQLiteConnection dbConn;
		private string dbPath;
		private string dbFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString() + System.IO.Path.DirectorySeparatorChar.ToString() + "LAdd"+ System.IO.Path.DirectorySeparatorChar.ToString();
		public DatabaseWindow () : base (Gtk.WindowType.Toplevel)
		{
			this.Build ();
			this.Title = "Database's";
			this.SetPosition (Gtk.WindowPosition.Center);
			//mkdir dbRootDir if not exists
			if (!Directory.Exists (dbFolder)) Directory.CreateDirectory (dbFolder);
			buildTv (); 
			fillAllDbsIntoTv ();
		}
		protected void buildTv(){
			ts = new TreeStore (typeof(string));
			tv = new TreeView (ts);
			tv.HeadersVisible = false;
			CellRendererText crt = new CellRendererText ();
			crt.Ellipsize = Pango.EllipsizeMode.End;
			tv.AppendColumn("Databases", crt , "text", 0);

			swDatabases.Add (tv);
			swDatabases.ShowAll ();
			tv.RowActivated += tvRowActivated;
		}
		protected void fillAllDbsIntoTv(){
			ts.Clear ();
			allDbPaths.Clear ();
			foreach (string f in Directory.GetFiles(dbFolder)) { 
				ts.AppendValues (System.IO.Path.GetFileName (f));
				allDbPaths.Add (f);
			}
		}
		/*on treeview tv on row-clciked*/
		protected void tvRowActivated (object o, RowActivatedArgs args)
		{
			int _selectedRowNum = Convert.ToInt32(args.Path.ToString());
			string _selectedDbPath =allDbPaths[_selectedRowNum];
			string msg = "Do you want to switch to (" + System.IO.Path.GetFileName(_selectedDbPath)+ ") link-database?";
			MessageDialog md = new MessageDialog (null, DialogFlags.Modal, MessageType.Question, ButtonsType.OkCancel, msg);
			ResponseType rt = (ResponseType)md.Run ();
			if (rt == ResponseType.Ok) {
				Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
				//make changes
				config.AppSettings.Settings.Add("selectedDbPath", _selectedDbPath);
				//save to apply changes
				config.Save(ConfigurationSaveMode.Modified);
				ConfigurationManager.RefreshSection("appSettings");
				this.Destroy();
			}
			md.Destroy ();
		}	
		protected void onCreateDatabase (object sender, EventArgs e)
		{
			string enName = entryDbName.Text.Trim ();
			string enPassword = entryPassword.Text.Trim ();
			string enConfirmPassword = entryConfirmPassword.Text.Trim ();
			if (enPassword.Length > 0 || enConfirmPassword.Length > 0) {
				if (enPassword == enConfirmPassword) {
					if (enPassword.Length >= 8 && enConfirmPassword.Length >= 8 ) {
						//TODO regex user/ vaild need only storng password P@ssword1
						intiDb ();
						dbConn.SetPassword (enPassword);
						appendSchemaToDB ();
						fillAllDbsIntoTv ();
						clearCreatePage ();
						notebook1.PrevPage ();
					} else
						labelStatus.Text = "Password´s mush be 8 chars or longer!";
				} else labelStatus.Text = "Password and Confirm password do not match!";
			} else if (enName.Length > 0 && enPassword =="" && enConfirmPassword =="") {
				intiDb ();
				appendSchemaToDB ();
				fillAllDbsIntoTv ();
				clearCreatePage ();
				notebook1.PrevPage ();
			} else {
				labelStatus.Text = "You need to defind a database name!";
				entryDbName.GrabFocus ();
			}
		}
		private void clearCreatePage(){
			entryDbName.Text = "";
			entryPassword.Text = "";
			entryConfirmPassword.Text = "";
			labelStatus.Text = "";
		}
		private void intiDb(){
			dbPath = dbFolder + entryDbName.Text.Trim () + ".db";
			SQLiteConnection.CreateFile (dbPath);
			dbConn = new SQLiteConnection ("Data Source=" + dbPath);
		}
		private void appendSchemaToDB(){
			List<string> Q = new List<string> ();
			Q.Add ("create table Links (linkid integer primary key AUTOINCREMENT,title char(50) not null,link text not null,flag int);");
			Q.Add ("create table FlagTypes (flagid integer primary key AUTOINCREMENT,title char(50));");
			Q.Add ("insert into FlagTypes (title) values ('All');");
			dbConn.Open ();
			SQLiteCommand cmd = new SQLiteCommand (dbConn);
			foreach (string sql in Q) {
				cmd.CommandText = sql;
				cmd.ExecuteNonQuery ();
			}
			dbConn.Close ();
		}
	}
}