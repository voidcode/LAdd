using System;
using Gtk;
using System.Data;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using System.IO;

public partial class MainWindow: Gtk.Window
{
	String approot;
	public TreeStore ts;
	TreeView tv;
	SqliteConnection dbConn;
	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
		buildLinksTree ();
		approot = AppDomain.CurrentDomain.BaseDirectory;
		dbConn = new SqliteConnection ("Data Source="+approot+"LAdd.db, Version=3");
		fillCbSearchFieldType ();
		fillLinksTreeFromDB ();
	}
	protected void fillCbSearchFieldType(){
		dbConn.Open ();
		String getAllFlagTypesQ = "select * from FlagTypes;";
		try {
			SqliteCommand cmd = new SqliteCommand(getAllFlagTypesQ, dbConn);
			SqliteDataReader reader = cmd.ExecuteReader();
			while(reader.Read()){
				//fillCbSearchFieldType.AppendText (reader["title"].ToString());
			}
		} catch (SqliteException e){
			Console.Write (e.ToString());
		}
		dbConn.Close ();
	}
	protected void buildLinksTree(){
		//defind datatype of data in the TreeStore
		ts = new TreeStore (typeof(string), typeof(string), typeof(string), typeof(string));
		tv = new TreeView (ts);
		tv.HeadersVisible = true;
		//this tree has 3 columns Title, Link and Flag
		tv.AppendColumn ("Title", new CellRendererText (), "text", 0);
		tv.AppendColumn ("Flag", new CellRendererText (), "text", 1);
		tv.AppendColumn ("Link", new CellRendererText (), "text", 2);
		swLinks.Add (tv);
		swLinks.ShowAll ();
	}
	public void fillLinksTreeFromDB(){
		dbConn.Open ();
		//gets all links from table Links
		//there is with join on FlagTypes Table
		String selectAllLinksQ = "select Links.linkid, Links.title, Links.link, FlagTypes.title as flagTitle from Links join FlagTypes on Links.flag = FlagTypes.flagid;";
		try {
			SqliteCommand cmd = new SqliteCommand(selectAllLinksQ, dbConn);
			SqliteDataReader reader = cmd.ExecuteReader();
			ts.Clear ();
			//append all links to TreeStore
			while(reader.Read()){
				ts.AppendValues(reader["title"], reader["flagTitle"], reader["Link"]);
			}
		} catch (SqliteException e){
			Console.Write (e.ToString());
		}
		dbConn.Close ();
	}
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	/*** Show a dialog where enduser can add a new link to db. ***/
	protected void onAddLinkClicked(object sender, EventArgs e)
	{
		//init of new/ add link dialog
		LAdd.newLinkDialog newLinkDialog = new LAdd.newLinkDialog ();
		newLinkDialog.Title = "New Link";
		newLinkDialog.ShowAll ();
		newLinkDialog.Destroyed += onAddLinkDestroyed;
	}
	protected void onAddLinkDestroyed(object sender, EventArgs args){
		searchEntry.Text = "";
		fillLinksTreeFromDB ();
	}
	/*** remove the seleted link in the TreeStore. 
	 * Or error msg... text: You need to select a link before you can delete it ***/
	protected void onRemoveLinkClicked (object sender, EventArgs e)
	{
		//Console.WriteLine(tp[0]);
		try {
			//TODO 2 get seleted linkid from TreeStore

			//delete seleted link base on linkid
			String deleteLinkQ = "delete from Links where linkid=2";
	
			dbConn.Open();
			SqliteCommand cmd = new SqliteCommand(deleteLinkQ, dbConn);
			if(cmd.ExecuteNonQuery() > 0){
				ts.Clear();
				//reload all links from table Links
				dbConn.Close();
				fillLinksTreeFromDB();
			} else {
				Console.WriteLine("DELETE: links with linkid=1 is delete from DB.");
			}
			dbConn.Close();
		} catch (SqliteException error){
			Console.Write (error.ToString());
		}
	}

	protected void onSearchBtnClicked (object sender, EventArgs e)
	{
		Console.WriteLine("onSearchBtnClicked");
		//run a db-search base on entry-text lookup link where title like input
		String searchQ = "select Links.linkid, Links.title, Links.link, FlagTypes.title as flagTitle from Links join FlagTypes on Links.flag = FlagTypes.flagid where Links.title like '%"+searchEntry.Text.ToString()+"%';";
		SqliteCommand cmd = new SqliteCommand (searchQ, dbConn);
		try {
			dbConn.Open();
			SqliteDataReader reader = cmd.ExecuteReader();
			ts.Clear (); //remove all links in links-tree
			while(reader.Read()){
				ts.AppendValues(reader["title"], reader["flagTitle"], reader["Link"]);
			}
			dbConn.Close();
		} catch (SqliteException err){
			Console.Write(err.ToString());
		}
	}
	//TODO 3
	/*
		add a http tcp server here os use just can write
		http://localhost:1010/<LINK-URL>
		this save the link to sqlite3 db.
	*/
	//TODO 6 add/make so enduser can create new FlagTypes.
	//TODO 7 test this app in on windows 7, 8...
}
