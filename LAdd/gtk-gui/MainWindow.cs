
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;
	
	private global::Gtk.Action pasteAction1;
	
	private global::Gtk.Action copyAction;
	
	private global::Gtk.Action closeAction;
	
	private global::Gtk.Action preferencesAction;
	
	private global::Gtk.Action editAction;
	
	private global::Gtk.Action pasteAction;
	
	private global::Gtk.VBox vbox1;
	
	private global::Gtk.Toolbar toolbar1;
	
	private global::Gtk.Frame frame1;
	
	private global::Gtk.Alignment GtkAlignment;
	
	private global::Gtk.VBox vbox2;
	
	private global::Gtk.ScrolledWindow swLinks;
	
	private global::Gtk.HBox hbox1;
	
	private global::Gtk.ComboBox cbSearchFieldType;
	
	private global::Gtk.Entry searchEntry;
	
	private global::Gtk.Label GtkLabel2;

	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager ();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
		this.pasteAction1 = new global::Gtk.Action ("pasteAction1", null, null, "gtk-paste");
		w1.Add (this.pasteAction1, null);
		this.copyAction = new global::Gtk.Action ("copyAction", null, null, "gtk-copy");
		w1.Add (this.copyAction, null);
		this.closeAction = new global::Gtk.Action ("closeAction", null, null, "gtk-close");
		w1.Add (this.closeAction, null);
		this.preferencesAction = new global::Gtk.Action ("preferencesAction", null, null, "gtk-preferences");
		w1.Add (this.preferencesAction, null);
		this.editAction = new global::Gtk.Action ("editAction", null, null, "gtk-edit");
		w1.Add (this.editAction, null);
		this.pasteAction = new global::Gtk.Action ("pasteAction", null, null, "gtk-paste");
		w1.Add (this.pasteAction, null);
		this.UIManager.InsertActionGroup (w1, 0);
		this.AddAccelGroup (this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
		this.Icon = global::Stetic.IconLoader.LoadIcon (this, "stock_add-bookmark", global::Gtk.IconSize.Menu);
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox ();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		// Container child vbox1.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString ("<ui><toolbar name='toolbar1'><toolitem name='pasteAction1' action='pasteAction1'/><toolitem name='closeAction' action='closeAction'/></toolbar></ui>");
		this.toolbar1 = ((global::Gtk.Toolbar)(this.UIManager.GetWidget ("/toolbar1")));
		this.toolbar1.Name = "toolbar1";
		this.toolbar1.ShowArrow = false;
		this.vbox1.Add (this.toolbar1);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.toolbar1]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.frame1 = new global::Gtk.Frame ();
		this.frame1.Name = "frame1";
		this.frame1.ShadowType = ((global::Gtk.ShadowType)(0));
		this.frame1.BorderWidth = ((uint)(3));
		// Container child frame1.Gtk.Container+ContainerChild
		this.GtkAlignment = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
		this.GtkAlignment.Name = "GtkAlignment";
		this.GtkAlignment.LeftPadding = ((uint)(12));
		// Container child GtkAlignment.Gtk.Container+ContainerChild
		this.vbox2 = new global::Gtk.VBox ();
		this.vbox2.Name = "vbox2";
		this.vbox2.Spacing = 6;
		// Container child vbox2.Gtk.Box+BoxChild
		this.swLinks = new global::Gtk.ScrolledWindow ();
		this.swLinks.CanFocus = true;
		this.swLinks.Name = "swLinks";
		this.vbox2.Add (this.swLinks);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.swLinks]));
		w3.Position = 0;
		// Container child vbox2.Gtk.Box+BoxChild
		this.hbox1 = new global::Gtk.HBox ();
		this.hbox1.Name = "hbox1";
		this.hbox1.Spacing = 6;
		// Container child hbox1.Gtk.Box+BoxChild
		this.cbSearchFieldType = global::Gtk.ComboBox.NewText ();
		this.cbSearchFieldType.Name = "cbSearchFieldType";
		this.hbox1.Add (this.cbSearchFieldType);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.cbSearchFieldType]));
		w4.Position = 0;
		w4.Expand = false;
		w4.Fill = false;
		// Container child hbox1.Gtk.Box+BoxChild
		this.searchEntry = new global::Gtk.Entry ();
		this.searchEntry.CanFocus = true;
		this.searchEntry.Name = "searchEntry";
		this.searchEntry.IsEditable = true;
		this.searchEntry.InvisibleChar = '•';
		this.hbox1.Add (this.searchEntry);
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.searchEntry]));
		w5.Position = 1;
		this.vbox2.Add (this.hbox1);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox1]));
		w6.Position = 1;
		w6.Expand = false;
		w6.Fill = false;
		this.GtkAlignment.Add (this.vbox2);
		this.frame1.Add (this.GtkAlignment);
		this.GtkLabel2 = new global::Gtk.Label ();
		this.GtkLabel2.Name = "GtkLabel2";
		this.GtkLabel2.Ypad = 5;
		this.GtkLabel2.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>All links:</b>");
		this.GtkLabel2.UseMarkup = true;
		this.GtkLabel2.Justify = ((global::Gtk.Justification)(2));
		this.frame1.LabelWidget = this.GtkLabel2;
		this.vbox1.Add (this.frame1);
		global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.frame1]));
		w9.Position = 1;
		this.Add (this.vbox1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 364;
		this.DefaultHeight = 380;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.pasteAction1.Activated += new global::System.EventHandler (this.onAddLinkClicked);
		this.closeAction.Activated += new global::System.EventHandler (this.onRemoveLinkClicked);
		this.cbSearchFieldType.Changed += new global::System.EventHandler (this.onCbSearchFieldType);
		this.searchEntry.Changed += new global::System.EventHandler (this.onCbSearchFieldType);
		this.searchEntry.Activated += new global::System.EventHandler (this.onCbSearchFieldType);
	}
}
