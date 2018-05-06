using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace W1A_MAC_Jukebox.Classes
{
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
