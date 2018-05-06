using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using W1A_MAC_Jukebox.Classes;

namespace W1A_MAC_Jukebox
{
   class Program
   {
      //* AWA: Provide user with a main-menu that offers core-navigation for the application.
      //* AWA: From Main-Menu, allow the user to view the Jukebox song selection and display details about the song.
      //* AWA: Allow the user to select a song to play, which will then set the current song, show details, and allow the user to play it.

      static void Main(string[] args)
      {
         //Entry Point:

         //Build new Jukebox object:
         Classes.Jukebox jukebox = new Classes.Jukebox();

         jukebox.Setup();

         //jukebox.Play(jukebox.Albums[0].Songs[0]);
         //foreach (Album album in jukebox.Albums)
         //{
         //   Console.WriteLine("");
         //   Console.WriteLine(@" Now Playing each Song in Album: {0}) {1}:", album.ID, album.Description);
         //   foreach (Song song in album.Songs)
         //   {
         //      Console.WriteLine(@" - Now Playing Song: {0}) {1}...", song.ID, song.Description);
         //      jukebox.Play(song);
         //   }
         //}
         //Console.WriteLine("");
         //Console.WriteLine(" Bdeep, dbeep, bdp - ... That's All folks!!!");

         while (jukebox.Playing)
         {
            jukebox.MainMenuSelection();
         }
         Console.Write("     Press any key to continue closing...");
         Console.ReadLine();

      }

   }
}
