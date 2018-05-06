﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace W1A_MAC_Jukebox.Classes
{
   class Album
   {
      public int ID { get; set; }
      public string Description { get; set; }

      public List<Song> Songs = new List<Song>();

      public Album(int id, string description)
      {
         ID = id;
         Description = description;
      }

   }

}
