using System;
using Gtk;
using System.Data;
using System.Collections.Generic;
using System.Diagnostics;

using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using LAdd;
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
	private string titleLoadingText = "Loading ..."; 
	private String approot;
	private TreeStore ts;
	private TreeView tv;
	private SQLiteConnection dbConn = null;
	private List<int> tsIdList = new List<int>();
	private List<string> tsLinkList = new List<string>();
	private string mode = "openlink";
	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		this.SetPosition(Gtk.WindowPosition.Center);
		Build ();
		buildLinksTree ();
		approot = AppDomain.CurrentDomain.BaseDirectory;
		setDbDataSource (approot+"LAdd.db");
		fillCbSearchFieldType ();
		fillLinksTreeFromDB ();
		searchEntry.GrabFocus ();
	}
	private void setDbDataSource(string dbPath){
		dbConn = new SQLiteConnection ("Data Source="+dbPath);
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
		if (mode.Equals ("editlink")) {
			//_dbDeleteLinkById (tsIdList[selectedRowNum]);
		} else if (mode.Equals ("deletelink")) {
			_dbDeleteLinkById (tsIdList [selectedRowNum]);
		} else {
			_openLinkByUrl (tsLinkList [selectedRowNum]);
		}
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
	/*** remove the seleted link in the TreeStore ***/
	protected void onRemoveLinkClicked (object sender, EventArgs e)
	{
		if (!mode.Equals("deletelink")) {
			mode = "deletelink";
			labelTopStatus.Text = "Click on a link to delete it!";
		} else {
			mode = "openlink";
			labelTopStatus.Text = "";
		}
	}
	private void _openLinkByUrl (string url){
		Process.Start (url);
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
	//TODO 6 add/make so enduser can create new FlagTypes.
	//TODO 7 test this app in on windows 7, 8...
	protected void onFetchTitles (object sender, EventArgs e)
	{
		dbConn.Open ();
		SQLiteCommand cmd = new SQLiteCommand(dbConn);
		cmd.CommandText = "select linkid, link from Links where title='" + titleLoadingText + "';";
		SQLiteDataReader reader = cmd.ExecuteReader();
		while (reader.Read ()) { 
			string _link = reader ["link"].ToString ();
			string _linkid = reader ["linkid"].ToString ();
			Thread th = new Thread (() =>_getWebPageTitleThenUpdateDB (_link, _linkid));
			th.Start ();
		}
		dbConn.Close ();
	}
	private void _getWebPageTitleThenUpdateDB(string link, string linkid)
	{
		// Create a request to the url
		HttpWebRequest request = HttpWebRequest.Create(link) as HttpWebRequest;
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
			if (new List<string> (response.Headers.AllKeys).Contains ("Content-Type")){
				if (response.Headers ["Content-Type"].StartsWith ("text/html")) {
					// Download the page
					WebClient web = new WebClient ();
					web.UseDefaultCredentials = true;
					string page = web.DownloadString (link);
					// Extract the title
					Regex ex = new Regex (regex, RegexOptions.IgnoreCase);
					dbConn.Open();
					SQLiteCommand cmd = new SQLiteCommand(dbConn);
					cmd.CommandText = "update Links set title=@title where linkid=@linkid;";
					cmd.Parameters.AddWithValue("@title", ex.Match (page).Value.Trim ());
					cmd.Parameters.AddWithValue("@linkid", linkid);
					cmd.ExecuteNonQuery();
					dbConn.Close();
					fillLinksTreeFromDB();
				}
			}
		} catch (WebException we) { 
			Console.WriteLine (we.ToString());
		}
	}
	protected void onBtnChooseDbClicked (object sender, EventArgs e)
	{
		Gtk.FileChooserDialog fcd = new Gtk.FileChooserDialog (
			"Select links database file",
			this,
			FileChooserAction.Open,
			"Cancal", ResponseType.Cancel,
			"Use this database", ResponseType.Accept
		);
		if (fcd.Run () == (int)ResponseType.Accept) {
			if (System.IO.Path.GetExtension (fcd.Filename) == ".db") {
				setDbDataSource (fcd.Filename);
				fillLinksTreeFromDB ();
				fcd.Destroy ();
			}
		} else
			fcd.Destroy ();
	}
	protected void onEditLinkAction (object sender, EventArgs e)
	{
		if (!mode.Equals("editlink")) {
			mode = "editlink";
			labelTopStatus.Text = "Click on a link to edit";
		} else {
			mode = "openlink";
			labelTopStatus.Text = "";
		} 
	}
}
