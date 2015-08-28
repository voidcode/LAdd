
// This file has been generated by the GUI designer. Do not modify.
namespace LAdd
{
	public partial class newLinkDialog
	{
		private global::Gtk.VBox vbox2;
		private global::Gtk.Label label1;
		private global::Gtk.Label label2;
		private global::Gtk.Entry entryTitle;
		private global::Gtk.Label label3;
		private global::Gtk.Entry entryLink;
		private global::Gtk.HBox hbox1;
		private global::Gtk.Label label4;
		private global::Gtk.ComboBox cbFlag;
		private global::Gtk.HBox hbox2;
		private global::Gtk.Entry enFlagtitle;
		private global::Gtk.Button btnAddNewFalgType;
		private global::Gtk.Button btnRemoveNewFalgType;
		private global::Gtk.Label labelStatus;
		private global::Gtk.Button buttonCancel;
		private global::Gtk.Button buttonOk;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget LAdd.newLinkDialog
			this.Name = "LAdd.newLinkDialog";
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Internal child LAdd.newLinkDialog.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			this.vbox2.BorderWidth = ((uint)(9));
			// Container child vbox2.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.Xalign = 1F;
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("New Link");
			this.vbox2.Add (this.label1);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.label1]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.Xalign = 0F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Title</b>");
			this.label2.UseMarkup = true;
			this.vbox2.Add (this.label2);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.label2]));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.entryTitle = new global::Gtk.Entry ();
			this.entryTitle.CanFocus = true;
			this.entryTitle.Name = "entryTitle";
			this.entryTitle.IsEditable = true;
			this.entryTitle.InvisibleChar = '•';
			this.vbox2.Add (this.entryTitle);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.entryTitle]));
			w4.Position = 2;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.Xalign = 0F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Link</b>");
			this.label3.UseMarkup = true;
			this.vbox2.Add (this.label3);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.label3]));
			w5.Position = 3;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.entryLink = new global::Gtk.Entry ();
			this.entryLink.CanFocus = true;
			this.entryLink.Name = "entryLink";
			this.entryLink.IsEditable = true;
			this.entryLink.InvisibleChar = '•';
			this.vbox2.Add (this.entryLink);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.entryLink]));
			w6.Position = 4;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.label4 = new global::Gtk.Label ();
			this.label4.Name = "label4";
			this.label4.Xalign = 0F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Flag's</b>");
			this.label4.UseMarkup = true;
			this.hbox1.Add (this.label4);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.label4]));
			w7.Position = 0;
			w7.Expand = false;
			w7.Fill = false;
			this.vbox2.Add (this.hbox1);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox1]));
			w8.Position = 5;
			w8.Expand = false;
			w8.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.cbFlag = global::Gtk.ComboBox.NewText ();
			this.cbFlag.Name = "cbFlag";
			this.vbox2.Add (this.cbFlag);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.cbFlag]));
			w9.Position = 6;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.enFlagtitle = new global::Gtk.Entry ();
			this.enFlagtitle.CanFocus = true;
			this.enFlagtitle.Name = "enFlagtitle";
			this.enFlagtitle.IsEditable = true;
			this.enFlagtitle.InvisibleChar = '•';
			this.hbox2.Add (this.enFlagtitle);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.enFlagtitle]));
			w10.Position = 0;
			// Container child hbox2.Gtk.Box+BoxChild
			this.btnAddNewFalgType = new global::Gtk.Button ();
			this.btnAddNewFalgType.CanFocus = true;
			this.btnAddNewFalgType.Name = "btnAddNewFalgType";
			this.btnAddNewFalgType.UseUnderline = true;
			// Container child btnAddNewFalgType.Gtk.Container+ContainerChild
			global::Gtk.Alignment w11 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w12 = new global::Gtk.HBox ();
			w12.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w13 = new global::Gtk.Image ();
			w13.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-add", global::Gtk.IconSize.Menu);
			w12.Add (w13);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w15 = new global::Gtk.Label ();
			w15.LabelProp = global::Mono.Unix.Catalog.GetString ("_Add");
			w15.UseUnderline = true;
			w12.Add (w15);
			w11.Add (w12);
			this.btnAddNewFalgType.Add (w11);
			this.hbox2.Add (this.btnAddNewFalgType);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.btnAddNewFalgType]));
			w19.Position = 1;
			w19.Expand = false;
			w19.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.btnRemoveNewFalgType = new global::Gtk.Button ();
			this.btnRemoveNewFalgType.CanFocus = true;
			this.btnRemoveNewFalgType.Name = "btnRemoveNewFalgType";
			this.btnRemoveNewFalgType.UseUnderline = true;
			// Container child btnRemoveNewFalgType.Gtk.Container+ContainerChild
			global::Gtk.Alignment w20 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w21 = new global::Gtk.HBox ();
			w21.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w22 = new global::Gtk.Image ();
			w22.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-remove", global::Gtk.IconSize.Menu);
			w21.Add (w22);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w24 = new global::Gtk.Label ();
			w24.LabelProp = global::Mono.Unix.Catalog.GetString ("_Remove");
			w24.UseUnderline = true;
			w21.Add (w24);
			w20.Add (w21);
			this.btnRemoveNewFalgType.Add (w20);
			this.hbox2.Add (this.btnRemoveNewFalgType);
			global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.btnRemoveNewFalgType]));
			w28.Position = 2;
			w28.Expand = false;
			w28.Fill = false;
			this.vbox2.Add (this.hbox2);
			global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox2]));
			w29.Position = 7;
			w29.Expand = false;
			w29.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.labelStatus = new global::Gtk.Label ();
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Xalign = 1F;
			this.vbox2.Add (this.labelStatus);
			global::Gtk.Box.BoxChild w30 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.labelStatus]));
			w30.PackType = ((global::Gtk.PackType)(1));
			w30.Position = 8;
			w30.Expand = false;
			w30.Fill = false;
			w1.Add (this.vbox2);
			global::Gtk.Box.BoxChild w31 = ((global::Gtk.Box.BoxChild)(w1 [this.vbox2]));
			w31.Position = 0;
			w31.Expand = false;
			w31.Fill = false;
			// Internal child LAdd.newLinkDialog.ActionArea
			global::Gtk.HButtonBox w32 = this.ActionArea;
			w32.Name = "dialog1_ActionArea";
			w32.Spacing = 10;
			w32.BorderWidth = ((uint)(5));
			w32.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonCancel = new global::Gtk.Button ();
			this.buttonCancel.CanDefault = true;
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = global::Mono.Unix.Catalog.GetString ("_Cancel");
			this.AddActionWidget (this.buttonCancel, -6);
			global::Gtk.ButtonBox.ButtonBoxChild w33 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w32 [this.buttonCancel]));
			w33.Expand = false;
			w33.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOk = new global::Gtk.Button ();
			this.buttonOk.CanDefault = true;
			this.buttonOk.CanFocus = true;
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.UseUnderline = true;
			this.buttonOk.Label = global::Mono.Unix.Catalog.GetString ("_Save");
			this.AddActionWidget (this.buttonOk, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w34 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w32 [this.buttonOk]));
			w34.Position = 1;
			w34.Expand = false;
			w34.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 313;
			this.DefaultHeight = 283;
			this.Show ();
			this.btnAddNewFalgType.Clicked += new global::System.EventHandler (this.onAddNewFalgType);
			this.buttonCancel.Clicked += new global::System.EventHandler (this.newLinkDialog_btnClose);
			this.buttonOk.Clicked += new global::System.EventHandler (this.newLinkDialog_btnOk);
		}
	}
}
