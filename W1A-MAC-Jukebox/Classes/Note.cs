using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace W1A_MAC_Jukebox.Classes
{
   //* CW: Will be used to store Frequency and Duration.
   //* CW: The Song will use these properties to populate arguments required for the Console.Beep() command.
   //* CW: Build Constructor to populate required Frequency and Duration properties.
   //* CW: Constructor
   //* CW: ADDED: Adding Thread.Sleep() property.

   class Note
   {
      public int Frequency { get; set; }
      public int Duration { get; set; }
      public int Sleep { get; set; }

      public Note(int f, int d, int s)
      {
         Frequency = f;
         Duration = d;
         Sleep = s;
      }

   }

}
