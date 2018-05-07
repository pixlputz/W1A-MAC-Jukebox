using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using W1A_MAC_Jukebox.Classes;

namespace W1A_MAC_Jukebox
{
   class Program
   {
      //Requirements:
      //* CW: Provide user with a main-menu that offers core-navigation for the application.
      //* CW: From Main-Menu, allow the user to view the Jukebox song selection and display details about the song.
      //* CW: Allow the user to select a song to play, which will then set the current song, show details, and allow the user to play it.

      static void Main(string[] args)
      {
         //Entry Point:

         //Build new Jukebox object:
         Classes.Jukebox jukebox = new Classes.Jukebox();

         //Setup all Application Objects:
         jukebox.Setup();

         while (jukebox.Playing)             //Continue Running Application:
         {
            jukebox.MainMenuSelection();
         }
         //Exiting Application:
         Console.Write("     Press any key to continue closing...");
         Console.ReadLine();
      }

   }
}
