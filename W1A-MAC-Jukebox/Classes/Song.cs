using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace W1A_MAC_Jukebox.Classes
{
   //* CW: Contain unique identifier of some kind (name/ID), used by Jukebox to identify & select desired Song object.
   //* CW: Properties: Times played, Description, etc - details to display under selection process.
   //* CW: Contain list of Note objects.
   //* CW: Play() method: Allow user to play each Note comprising the Song.
   //* CW: Use Console.Beep() method: Accecpting a frequency, and duration for each Note.
   //       - Playing a single note looks something like Console.Beep(1080, 5000).
   //       - Our Play() method will utilize this built-in method to play each note.

   class Song
   {
      public int ID { get; set; }
      public string Description { get; set; }
      public int TimesPlayed { get; set; }

      public List<Note> Notes = new List<Note>();

      public Song(int id, string description)
      {
         ID = id;
         Description = description;
         TimesPlayed = 0;
      }

      public void Play()
      {
         //AWA: Build method content...
         //...
         foreach (Note n in Notes)
         {
            Console.Beep(n.Frequency, n.duration);
         }
         //Increment TimesPlayed:
         this.TimesPlayed++;
      }

   }

}
