using System;
using Gtk;

public partial class MainWindow: Gtk.Window 
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)		//Constructor
	{
		Build ();
		Label label = new Label ("Este se ha añadido a mano");
		vBox.Add;
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
}

