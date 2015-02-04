using System;
using Gtk;

namespace PGtk
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();                 //Metodo que iniciamos para ejecutar el gtk
			MainWindow win = new MainWindow (); //Crea ventana
			win.Show ();						//Muestra la ventana
			Application.Run ();
		}
	}
}
