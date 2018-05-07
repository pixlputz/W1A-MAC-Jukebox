using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace W1A_MAC_Jukebox.Classes
{
   //Extra Class not required; used to build MenuOptions into each Menu object.

   class MenuOption
   {
      public Action Action { get; set; }
      public string Description { get; set; }

      public MenuOption(Action action, string description)
      {
         Action = action;
         Description = description;
      }
   }
}
