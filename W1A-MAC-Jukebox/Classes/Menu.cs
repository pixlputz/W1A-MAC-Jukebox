using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace W1A_MAC_Jukebox.Classes
{
   //* AWA: Intent: Keep the Program>Main() method clean and ligtweight, utilizing this object to do the heavy work.
   //* AWA: Menu Requirements:
   //       - AWA: User is able to make song selection from a menu, or exit if they would like to exit the program.
   //       - AWA: Once a selection is made, the user should be able to view its details.
   //       - AWA: User should now be able to play the Song.
   //       - AWA: User should be able to go back to the main menu (likely, via a sub-menu off of the main menu).
   //* AWA: Additional/Optional:
   //       - AWA: Re-organize the structure so user can choose an album, containig related Songs.
   //       - AWA: Create a menu interface for this functionality as well.


   class Menu
   {
      public string Name { get; set; }
      public List<MenuOption> Options { get; set; }

      public Menu(string name, List<MenuOption> options)
      {
         Name = Name;
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
