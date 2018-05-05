using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace W1A_MAC_Jukebox.Classes
{
   //* CW: Will be used to store Frequency and Duration.
   //* CW: The Song will use these properties to populate arguments required for the Console.Beep() command.
   //* CW: Build Constructor to populate required Frequency and Duration properties.

   class Note
   {
      public int Frequency { get; set; }
      public int duration { get; set; }

      public Note(int f, int d)
      {
         Frequency = f;
         duration = d;
      }

   }

}
