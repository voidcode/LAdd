
// This file has been generated by the GUI designer. Do not modify.
namespace LAdd
{
	public partial class DatabaseWindow
	{
		private global::Gtk.Notebook notebook1;
		private global::Gtk.VBox vbox2;
		private global::Gtk.HBox hbox3;
		private global::Gtk.ScrolledWindow swDatabases;
		private global::Gtk.Label label1;
		private global::Gtk.VBox vbox3;
		private global::Gtk.Label label5;
		private global::Gtk.Entry entryDbName;
		private global::Gtk.EventBox ebPasswordInputs;
		private global::Gtk.Expander expander1;
		private global::Gtk.VBox vbox4;
		private global::Gtk.Label label6;
		private global::Gtk.Entry entryPassword;
		private global::Gtk.Label label33;
		private global::Gtk.Entry entryConfirmPassword;
		private global::Gtk.Label GtkLabelPasswordTitle;
		private global::Gtk.Button btnCreateDb;
		private global::Gtk.Label labelStatus;
		private global::Gtk.Label label2;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget LAdd.DatabaseWindow
			this.Name = "LAdd.DatabaseWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("DatabaseWindow");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child LAdd.DatabaseWindow.Gtk.Container+ContainerChild
			this.notebook1 = new global::Gtk.Notebook ();
			this.notebook1.CanFocus = true;
			this.notebook1.Name = "notebook1";
			this.notebook1.CurrentPage = 1;
			this.notebook1.TabPos = ((global::Gtk.PositionType)(1));
			this.notebook1.BorderWidth = ((uint)(6));
			// Container child notebook1.Gtk.Notebook+NotebookChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox ();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.swDatabases = new global::Gtk.ScrolledWindow ();
			this.swDatabases.CanFocus = true;
			this.swDatabases.Name = "swDatabases";
			this.hbox3.Add (this.swDatabases);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.swDatabases]));
			w1.Position = 0;
			this.vbox2.Add (this.hbox3);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox3]));
			w2.Position = 0;
			this.notebook1.Add (this.vbox2);
			// Notebook tab
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("All databases");
			this.notebook1.SetTabLabel (this.vbox2, this.label1);
			this.label1.ShowAll ();
			// Container child notebook1.Gtk.Notebook+NotebookChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			this.vbox3.BorderWidth = ((uint)(15));
			// Container child vbox3.Gtk.Box+BoxChild
			this.label5 = new global::Gtk.Label ();
			this.label5.Name = "label5";
			this.label5.Xalign = 1F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("Name");
			this.vbox3.Add (this.label5);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.label5]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.entryDbName = new global::Gtk.Entry ();
			this.entryDbName.CanFocus = true;
			this.entryDbName.Name = "entryDbName";
			this.entryDbName.IsEditable = true;
			this.entryDbName.InvisibleChar = '•';
			this.vbox3.Add (this.entryDbName);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.entryDbName]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.ebPasswordInputs = new global::Gtk.EventBox ();
			this.ebPasswordInputs.Name = "ebPasswordInputs";
			// Container child ebPasswordInputs.Gtk.Container+ContainerChild
			this.expander1 = new global::Gtk.Expander (null);
			this.expander1.CanFocus = true;
			this.expander1.Name = "expander1";
			// Container child expander1.Gtk.Container+ContainerChild
			this.vbox4 = new global::Gtk.VBox ();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.label6 = new global::Gtk.Label ();
			this.label6.Name = "label6";
			this.label6.Xalign = 1F;
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString ("Password");
			this.vbox4.Add (this.label6);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.label6]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.entryPassword = new global::Gtk.Entry ();
			this.entryPassword.CanFocus = true;
			this.entryPassword.Name = "entryPassword";
			this.entryPassword.IsEditable = true;
			this.entryPassword.InvisibleChar = '•';
			this.vbox4.Add (this.entryPassword);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.entryPassword]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.label33 = new global::Gtk.Label ();
			this.label33.Name = "label33";
			this.label33.Xalign = 1F;
			this.label33.LabelProp = global::Mono.Unix.Catalog.GetString ("Confirm password");
			this.vbox4.Add (this.label33);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.label33]));
			w8.Position = 2;
			w8.Expand = false;
			w8.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.entryConfirmPassword = new global::Gtk.Entry ();
			this.entryConfirmPassword.CanFocus = true;
			this.entryConfirmPassword.Name = "entryConfirmPassword";
			this.entryConfirmPassword.IsEditable = true;
			this.entryConfirmPassword.InvisibleChar = '•';
			this.vbox4.Add (this.entryConfirmPassword);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.entryConfirmPassword]));
			w9.Position = 3;
			w9.Expand = false;
			w9.Fill = false;
			this.expander1.Add (this.vbox4);
			this.GtkLabelPasswordTitle = new global::Gtk.Label ();
			this.GtkLabelPasswordTitle.Name = "GtkLabelPasswordTitle";
			this.GtkLabelPasswordTitle.LabelProp = global::Mono.Unix.Catalog.GetString ("Use password?");
			this.GtkLabelPasswordTitle.UseUnderline = true;
			this.expander1.LabelWidget = this.GtkLabelPasswordTitle;
			this.ebPasswordInputs.Add (this.expander1);
			this.vbox3.Add (this.ebPasswordInputs);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.ebPasswordInputs]));
			w12.Position = 2;
			w12.Expand = false;
			w12.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.btnCreateDb = new global::Gtk.Button ();
			this.btnCreateDb.CanFocus = true;
			this.btnCreateDb.Name = "btnCreateDb";
			this.btnCreateDb.UseUnderline = true;
			this.btnCreateDb.Label = global::Mono.Unix.Catalog.GetString ("Create database");
			this.vbox3.Add (this.btnCreateDb);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.btnCreateDb]));
			w13.Position = 3;
			w13.Expand = false;
			w13.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.labelStatus = new global::Gtk.Label ();
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Xalign = 1F;
			this.labelStatus.Justify = ((global::Gtk.Justification)(1));
			this.vbox3.Add (this.labelStatus);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.labelStatus]));
			w14.Position = 4;
			this.notebook1.Add (this.vbox3);
			global::Gtk.Notebook.NotebookChild w15 = ((global::Gtk.Notebook.NotebookChild)(this.notebook1 [this.vbox3]));
			w15.Position = 1;
			// Notebook tab
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("New database");
			this.notebook1.SetTabLabel (this.vbox3, this.label2);
			this.label2.ShowAll ();
			this.Add (this.notebook1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 436;
			this.DefaultHeight = 166;
			this.Show ();
			this.btnCreateDb.Clicked += new global::System.EventHandler (this.onCreateDatabase);
		}
	}
}
