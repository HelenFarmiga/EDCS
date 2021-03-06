using System;
using System.IO;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	private String filename;
	private string content;
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}


	protected void OnOpenActionActivated (object sender, EventArgs e)
	{
		// textView.Buffer.Text = "El texto que assigno al textView Buffer.Text";
		FileChooserDialog fileChooserDialog = new FileChooserDialog (
			"Elige el archivo",
			this,
			FileChooserAction.Open,
			Stock.Cancel, ResponseType.Cancel,
			Stock.Open, ResponseType.Ok); 
	

		if(fileChooserDialog.Run () == (int)ResponseType.Ok) {
		filename = fileChooserDialog.Filename;
			//Console.WriteLine ("Filename"+ fileChooserDialog.Filename);
			textView.Buffer.Text = File.ReadAllText (filename);
	}
		fileChooserDialog.Destroy ();
	}

	protected void OnSaveActionActivated (object sender, EventArgs e){
		if(filename == null){
			saveAs();
			}
		else{
				File.WriteAllText (filename,textView.Buffer.Text);
		}
	}

	private void saveAs(){
		FileChooserDialog fileChooserDialog = new FileChooserDialog(
			"Guardar",
			this,
			FileChooserAction.Save,
			Stock.Cancel, ResponseType.Cancel,
			Stock.Save, ResponseType.Ok);
		if((ResponseType)fileChooserDialog.Run() == ResponseType.Ok)
		File.WriteAllText(filename,textView.Buffer.Text);
		fileChooserDialog.Destroy();

		}
	protected void OnSaveAsActionActivated (object sender, EventArgs e)
	{
		saveAs ();
	}

	protected void OnNewActionActived (object sender, EventArgs e)
	{
		if(content.Equals (textView.Buffer.Text)) {
			MessageDialog messageDialog = new MessageDialog(
				this,
				DialogFlags.DestroyWithParent,
				MessageType.Question,
				ButtonsType.YesNo,
				"Hay cambios sin guardar. ¿Quieres descartar los cambios?");

				ResponseType ResponseType = (ResponseType)messageDialog.Run (); //para no tener que poner 2 veces destruir
				messageDialog.Destroy();
				if((ResponseType)messageDialog.Run() != ResponseType.Yes)
				return;
			}
			textView.Buffer.Text = "";
			content="";
			filename = null;
		}


}
