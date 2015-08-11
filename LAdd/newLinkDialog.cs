using System;
using System.Data;
using System.IO;
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
		String approot;
		SQLiteConnection dbConn;
		public newLinkDialog ()
		{
			this.Build ();
			this.SetPosition (Gtk.WindowPosition.Center);
			approot = AppDomain.CurrentDomain.BaseDirectory;
			dbConn = new SQLiteConnection ("Data Source="+approot+"LAdd.db, Version=3");
			fillCbFlagWithAllFlagTypes ();
		}
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
		protected void newLinkDialog_btnOk (object sender, EventArgs e)
		{
			//TODO check if Link exists in db before addning it to Links-table
			String title = entryTitle.Text;
			String link = entryLink.Text;

			String flag = "1";
			if (title.Length > 0 && link.Length > 0) {
				String insertLinkQ = "insert into Links (title, link, flag) values ('"+title+"', '"+link+"', '"+flag+"');";			
				try {
					SQLiteCommand cmd = new SQLiteCommand (insertLinkQ, dbConn);
					dbConn.Open ();
					//try to insert a userdefine link.
					if(cmd.ExecuteNonQuery() > 0){
						this.Destroy(); //kill newLinkDialog
					} else {
						labelStatus.Text = "Error: Link is NOT saved!";
					}
					dbConn.Close();
				} catch (SQLiteException e2){
					Console.Write (e2.ToString ());
				}

			} else {
				labelStatus.Text = "Need add title and link";
			}
		}

		protected void newLinkDialog_btnClose (object sender, EventArgs e)
		{
			this.Destroy ();
		}
	}
}

