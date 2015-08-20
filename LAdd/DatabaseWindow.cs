using System;
using Gtk;
using System.Collections.Generic;
#if __MonoCS__
using SQLiteCommand = Mono.Data.Sqlite.SqliteCommand;
using SQLiteConnection = Mono.Data.Sqlite.SqliteConnection;
using SQLiteDataReader = Mono.Data.Sqlite.SqliteDataReader;
using SQLiteException = Mono.Data.Sqlite.SqliteException;
using System.IO;
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
		private TreeStore ts;
		private TreeView tv;
		private SQLiteConnection dbConn;
		private string dbPath;
		private string dbFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString() + System.IO.Path.DirectorySeparatorChar.ToString() + "LAdd"+ System.IO.Path.DirectorySeparatorChar.ToString();
		public DatabaseWindow () : base (Gtk.WindowType.Toplevel)
		{
			this.Build ();
			this.SetPosition (Gtk.WindowPosition.Center);
			//mkdir dbRootDir if not exists
			if (!Directory.Exists (dbFolder)) Directory.CreateDirectory (dbFolder);
			fillAllDbsIntoTv ();
		}
		protected void fillAllDbsIntoTv(){
			ts = new TreeStore (typeof(string), typeof(string));
			tv = new TreeView (ts);
			tv.HeadersVisible = true;
			tv.AppendColumn("Databases", new CellRendererText(), "text", 0);
			foreach(string f in Directory.GetFiles(dbFolder)) ts.AppendValues (f);
			swDatabases.Add(tv);
			swDatabases.ShowAll ();
			//TODO fix / show all appendValues in swDatabases
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
					} else
						labelStatus.Text = "Password´s mush be 8 chars or longer!";
				} else labelStatus.Text = "Password and Confirm password do not match!";
			} else if (enName.Length > 0 && enPassword =="" && enConfirmPassword =="") {
				intiDb ();
				appendSchemaToDB ();
				fillAllDbsIntoTv ();
			} else {
				labelStatus.Text = "You need to defind a database name!";
				entryDbName.GrabFocus ();
			}
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