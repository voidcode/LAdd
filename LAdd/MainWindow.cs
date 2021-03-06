﻿using System;
using Gtk;
using System.Data;
using System.Collections.Generic;
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
public partial class MainWindow: Gtk.Window
{
	private String approot;
	private TreeStore ts;
	private TreeView tv;
	private SQLiteConnection dbConn;
	private List<int> tsIdList = new List<int>();
	private List<string> tsLinkList = new List<string>();
	private bool deleteMode = false;
	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		this.SetPosition(Gtk.WindowPosition.Center);
		Build ();
		buildLinksTree ();
		approot = AppDomain.CurrentDomain.BaseDirectory;
		dbConn = new SQLiteConnection ("Data Source="+approot+"LAdd.db");
		fillCbSearchFieldType ();
		fillLinksTreeFromDB ();
		searchEntry.GrabFocus ();
	}
	protected void fillCbSearchFieldType(){
		dbConn.Open ();
		String getAllFlagTypesQ = "select * from FlagTypes;";
		try {
			SQLiteCommand cmd = new SQLiteCommand(getAllFlagTypesQ, dbConn);
			SQLiteDataReader reader = cmd.ExecuteReader();
			while(reader.Read()){
				cbSearchFieldType.AppendText (reader["title"].ToString());
			}
		} catch (SQLiteException e){
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
		tv.RowActivated += tvRowActivated;
	}
	/*on treeview tv on row-clciked*/
	void tvRowActivated (object o, RowActivatedArgs args)
	{
		int selectedRowNum = Convert.ToInt32(args.Path.ToString());
		if (deleteMode)
			_dbDeleteLinkById (tsIdList[selectedRowNum]);
		else
			_openLinkByUrl (tsLinkList[selectedRowNum]);
	}
	private void fillLinksTreeFromDB(){

		//gets all links from table Links
		//there is with join on FlagTypes Table
		string selectAllLinksQ; 
		if (cbSearchFieldType.ActiveText != null) {
			selectAllLinksQ = "select Links.linkid, Links.title, Links.link, FlagTypes.title as flagTitle " +
				"from Links " +
				"join FlagTypes on Links.flag = FlagTypes.flagid " +
				"where FlagTypes.title ='" + cbSearchFieldType.ActiveText + "';";
		} else {
			selectAllLinksQ = "select Links.linkid, Links.title, Links.link, FlagTypes.title as flagTitle from Links join FlagTypes on Links.flag = FlagTypes.flagid where Links.title like '%" + searchEntry.Text.ToString () + "%';";
		}
		//String selectAllLinksQ = "select Links.linkid, Links.title, Links.link, FlagTypes.title as flagTitle from Links join FlagTypes on Links.flag = FlagTypes.flagid;";
		try {
			dbConn.Open ();
			SQLiteCommand cmd = new SQLiteCommand(selectAllLinksQ, dbConn);
			SQLiteDataReader reader = cmd.ExecuteReader();
			ts.Clear ();
			//append all links to TreeStore
			tsIdList.Clear();
			tsLinkList.Clear();
			while(reader.Read()){
				ts.AppendValues(rmColmentEnding(reader["title"].ToString()), reader["flagTitle"], reader["Link"]);
				tsIdList.Add(Convert.ToInt32(reader["linkid"]));
				tsLinkList.Add(reader["Link"].ToString());
			}
		} catch (SQLiteException e){
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
		if (deleteMode) {
			deleteMode = false;
			labelTopStatus.Text = "";
		} else {
			labelTopStatus.Text = "Click on a link to delete it!";
			deleteMode = true;
		}
	}
	private void _openLinkByUrl (string url){
		System.Diagnostics.Process.Start (url);
	}
	private void _dbDeleteLinkById(int linkid){
		try {
			//delete seleted link base on linkid
			String deleteLinkQ = "delete from Links where linkid="+linkid.ToString()+";";
			dbConn.Open();
			SQLiteCommand cmd = new SQLiteCommand(deleteLinkQ, dbConn);
			if(cmd.ExecuteNonQuery() > 0){
				ts.Clear();
				//reload all links from table Links
				dbConn.Close();
				fillLinksTreeFromDB();
			} else {
				Console.WriteLine("DELETE: links with linkid=1 is delete from DB.");
			}
			dbConn.Close();
		} catch (SQLiteException error){
			Console.Write (error.ToString());
		}
	}
	private string rmColmentEnding(string t){
		if(t.Length > 50)
			return t.Substring(0, t.Length - (t.Length - 50)) + " ...";
		else
			return t;
	}
	private void _runLinkTreeSearch(){
		//run a db-search base on entry-text lookup link where title like input
		string searchQ; 
		if (cbSearchFieldType.ActiveText != null) {
			searchQ = "select Links.linkid, Links.title, Links.link, FlagTypes.title as flagTitle " +
				"from Links " +
				"join FlagTypes on Links.flag = FlagTypes.flagid " +
				"where FlagTypes.title ='" + cbSearchFieldType.ActiveText + "' " +
				"and Links.title like '%" + searchEntry.Text.ToString () + "%';";
		} else {
			searchQ = "select Links.linkid, Links.title, Links.link, FlagTypes.title as flagTitle from Links join FlagTypes on Links.flag = FlagTypes.flagid where Links.title like '%" + searchEntry.Text.ToString () + "%';";
		}
		SQLiteCommand cmd = new SQLiteCommand (searchQ, dbConn);
		try {
			dbConn.Open();
			SQLiteDataReader reader = cmd.ExecuteReader();
			ts.Clear (); //remove all links in links-tree
			tsIdList.Clear();
			tsLinkList.Clear();
			while(reader.Read()){
				ts.AppendValues(rmColmentEnding(reader["title"].ToString()), reader["flagTitle"], reader["Link"]);
				tsIdList.Add(Convert.ToInt32(reader["linkid"]));
				tsLinkList.Add(reader["Link"].ToString());
			}
			dbConn.Close();
		} catch (SQLiteException err){
			Console.Write(err.ToString());
		}
	}
	protected void onCbSearchFieldType (object sender, EventArgs e)
	{
		_runLinkTreeSearch ();
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
