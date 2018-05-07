using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace W1A_MAC_Jukebox.Classes
{
   //Requirements:
   //* CW: Intent: Keep the Program>Main() method clean and ligtweight, utilizing this object to do the heavy work.
   //              - NOTE: Primarily used the Jukebox object for most of the heavy-work.
   //* CW: Menu Requirements: (See Jukebox Object for this functionality)
   //       - CW: User is able to make song selection from a menu, or exit if they would like to exit the program.
   //       - CW: Once a selection is made, the user should be able to view its details.
   //       - CW: User should now be able to play the Song.
   //       - CW: User should be able to go back to the main menu (likely, via a sub-menu off of the main menu).
   //* CW: Additional/Optional: (See Jukebox Object for this functionality)
   //       - CW: Re-organize the structure so user can choose an album, containig related Songs.
   //       - CW: Create a menu interface for this functionality as well.

   class Menu
   {
      public string Name { get; set; }
      public List<MenuOption> Options { get; set; }

      public Menu(string name, List<MenuOption> options)
      {
         Name = name;
         Options = options;
      }

      void PrintMenuOptions()
      {
         string paddingLeft = "     ";

         int count = 1;
         foreach (MenuOption option in Options)
         {
            Console.WriteLine(paddingLeft + $"{count++} {option.Description}");
         }
         Console.WriteLine("");
         Console.Write(paddingLeft + "Slection: > ");
      }

      public Action SelectOption()
      {
         string paddingLeft = "     ";

         PrintMenuOptions();
         string input = Console.ReadLine();
         int index = 0;
         bool valid = int.TryParse(input, out index);
         if (!valid || index <= 0 || index > Options.Count)
         {
            Console.WriteLine(paddingLeft + "Please make a valid selection.");
            return null;
         }
         return Options[index - 1].Action;
      }
   }
}
