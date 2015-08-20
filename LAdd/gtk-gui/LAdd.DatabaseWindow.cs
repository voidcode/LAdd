
// This file has been generated by the GUI designer. Do not modify.
namespace LAdd
{
	public partial class DatabaseWindow
	{
		private global::Gtk.VBox vbox2;
		
		private global::Gtk.HBox hbox2;
		
		private global::Gtk.Label label3;
		
		private global::Gtk.HBox hbox3;
		
		private global::Gtk.ScrolledWindow swDatabases;
		
		private global::Gtk.TreeView treeview1;
		
		private global::Gtk.VBox vbox3;
		
		private global::Gtk.Label label4;
		
		private global::Gtk.Label label5;
		
		private global::Gtk.Entry entryDbName;
		
		private global::Gtk.Label label6;
		
		private global::Gtk.Entry entryPassword;
		
		private global::Gtk.Label label33;
		
		private global::Gtk.Entry entryConfirmPassword;
		
		private global::Gtk.Button btnCreateDb;
		
		private global::Gtk.Label labelStatus;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget LAdd.DatabaseWindow
			this.Name = "LAdd.DatabaseWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("DatabaseWindow");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child LAdd.DatabaseWindow.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			this.vbox2.BorderWidth = ((uint)(15));
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Databases");
			this.hbox2.Add (this.label3);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.label3]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			this.vbox2.Add (this.hbox2);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox2]));
			w2.Position = 0;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox ();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.swDatabases = new global::Gtk.ScrolledWindow ();
			this.swDatabases.Name = "swDatabases";
			this.swDatabases.VscrollbarPolicy = ((global::Gtk.PolicyType)(2));
			// Container child swDatabases.Gtk.Container+ContainerChild
			this.treeview1 = new global::Gtk.TreeView ();
			this.treeview1.CanFocus = true;
			this.treeview1.Name = "treeview1";
			this.swDatabases.Add (this.treeview1);
			this.hbox3.Add (this.swDatabases);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.swDatabases]));
			w4.Position = 0;
			// Container child hbox3.Gtk.Box+BoxChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			this.vbox3.BorderWidth = ((uint)(15));
			// Container child vbox3.Gtk.Box+BoxChild
			this.label4 = new global::Gtk.Label ();
			this.label4.Name = "label4";
			this.label4.Xalign = 0F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("Create new datbase");
			this.vbox3.Add (this.label4);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.label4]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.label5 = new global::Gtk.Label ();
			this.label5.Name = "label5";
			this.label5.Xalign = 1F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("Name");
			this.vbox3.Add (this.label5);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.label5]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.entryDbName = new global::Gtk.Entry ();
			this.entryDbName.CanFocus = true;
			this.entryDbName.Name = "entryDbName";
			this.entryDbName.IsEditable = true;
			this.entryDbName.InvisibleChar = '•';
			this.vbox3.Add (this.entryDbName);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.entryDbName]));
			w7.Position = 2;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.label6 = new global::Gtk.Label ();
			this.label6.Name = "label6";
			this.label6.Xalign = 1F;
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString ("Password");
			this.vbox3.Add (this.label6);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.label6]));
			w8.Position = 3;
			w8.Expand = false;
			w8.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.entryPassword = new global::Gtk.Entry ();
			this.entryPassword.CanFocus = true;
			this.entryPassword.Name = "entryPassword";
			this.entryPassword.IsEditable = true;
			this.entryPassword.InvisibleChar = '•';
			this.vbox3.Add (this.entryPassword);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.entryPassword]));
			w9.Position = 4;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.label33 = new global::Gtk.Label ();
			this.label33.Name = "label33";
			this.label33.Xalign = 1F;
			this.label33.LabelProp = global::Mono.Unix.Catalog.GetString ("Confirm password");
			this.vbox3.Add (this.label33);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.label33]));
			w10.Position = 5;
			w10.Expand = false;
			w10.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.entryConfirmPassword = new global::Gtk.Entry ();
			this.entryConfirmPassword.CanFocus = true;
			this.entryConfirmPassword.Name = "entryConfirmPassword";
			this.entryConfirmPassword.IsEditable = true;
			this.entryConfirmPassword.InvisibleChar = '•';
			this.vbox3.Add (this.entryConfirmPassword);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.entryConfirmPassword]));
			w11.Position = 6;
			w11.Expand = false;
			w11.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.btnCreateDb = new global::Gtk.Button ();
			this.btnCreateDb.CanFocus = true;
			this.btnCreateDb.Name = "btnCreateDb";
			this.btnCreateDb.UseUnderline = true;
			this.btnCreateDb.Label = global::Mono.Unix.Catalog.GetString ("Build new database");
			this.vbox3.Add (this.btnCreateDb);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.btnCreateDb]));
			w12.Position = 7;
			w12.Expand = false;
			w12.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.labelStatus = new global::Gtk.Label ();
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Justify = ((global::Gtk.Justification)(1));
			this.vbox3.Add (this.labelStatus);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.labelStatus]));
			w13.Position = 8;
			w13.Expand = false;
			w13.Fill = false;
			this.hbox3.Add (this.vbox3);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.vbox3]));
			w14.Position = 1;
			this.vbox2.Add (this.hbox3);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox3]));
			w15.Position = 1;
			w15.Expand = false;
			w15.Fill = false;
			this.Add (this.vbox2);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 436;
			this.DefaultHeight = 282;
			this.Show ();
		}
	}
}
