using System;
using System.IO;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	private String filename;
	private String content ="";

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		Label label = new Label ("Este lo he añadido a mano");
		label.Visible = true;
		vBox.Add (label);


	}
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}


	protected void OnButtonAceptarClicked (object sender, EventArgs e)
	{
		labelSaludo.Text = "Hola " + entryNombre.Text;
	}


	protected void OnOpenActionActivated (object sender, EventArgs e)
	{
		if (!content.Equals (text1.Buffer.Text)) {
			MessageDialog messageDialog = new MessageDialog (
				this,
				DialogFlags.DestroyWithParent,
				MessageType.Question,
				ButtonsType.YesNo,
				"Hay cambios sin guardar. ¿Descartar cambios");
			ResponseType response = (ResponseType)messageDialog.Run ();
			messageDialog.Destroy ();
			if (response != ResponseType.Yes)
				return;
		}

		FileChooserDialog fileChooserDialog = new FileChooserDialog (
			"Elige una opcion",
			this,
			FileChooserAction.Open,
			Stock.Cancel, ResponseType.Cancel,
			Stock.Open, ResponseType.Ok);

		if (fileChooserDialog.Run () == (int)ResponseType.Ok) {
			filename = fileChooserDialog.Filename;
			text1.Buffer.Text = File.ReadAllText (filename);

		}
		fileChooserDialog.Destroy();
	}
	
	protected void OnSaveActionActivated (object sender, EventArgs e)
	{
		if (filename == null)
			saveAs ();
		else
			File.WriteAllText (filename,text1.Buffer.Text);
	}
	
	protected void OnSaveAsActionActivated (object sender, EventArgs e)
	{
		saveAs ();
	}

	private void saveAs(){
		FileChooserDialog fileChooserDialog = new FileChooserDialog (
			"Guardar",
			this,
			FileChooserAction.Save,
			Stock.Cancel, ResponseType.Cancel,
			Stock.Save, ResponseType.Ok);

		if (fileChooserDialog.Run () == (int)ResponseType.Ok)
			File.WriteAllText (fileChooserDialog.Filename,text1.Buffer.Text);

		fileChooserDialog.Destroy();
	}


	protected void OnNewActionActivated (object sender, EventArgs e)
	{
		if (!content.Equals (text1.Buffer.Text)) {
			MessageDialog messageDialog = new MessageDialog (
				this,
				DialogFlags.DestroyWithParent,
				MessageType.Question,
				ButtonsType.YesNo,
				"Hay cambios sin guardar. ¿Descartar cambios");
			ResponseType response = (ResponseType)messageDialog.Run ();
			messageDialog.Destroy ();
			if (response != ResponseType.Yes)
				return;
		}
		text1.Buffer.Text = "";
		filename = null;
	}

	protected void OnQuitAction1Activated (object sender, DeleteEventArgs e)
	{
		Application.Quit ();
		e.RetVal = true;}
}
