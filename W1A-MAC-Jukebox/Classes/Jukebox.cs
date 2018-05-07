using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace W1A_MAC_Jukebox.Classes
{
   //* CW: Contain a bool that tells the program that we are 'playing' or accessing the Jukebox.
   //* CW: CHANGED: FROM: "Contain list of available songs to play." - TO: Contain a list of available albums.
   //* INW: Setup() method: Will be called to initialize the state of our Jukebox object:
   //                       - Add Songs
   //                       - Welcome Message
   //                       - Anything else we need to do to set up the application.
   //       NOTE: This will fill the intent of the Constructor for this class.
   //* INW: AddSongs() method: Create Individual Songs and add them to the Songs collection.
   //* INW: ADDED: AddAlbums() method: Create Individual Albums and add them to the Albums collection.
   //* INW: Play() method: identify a Song to Play (user selection), and play song (accessing specific Song object).
   //* INW: ADDED: Stop() method: Stop Playing Jukebox.

   class Jukebox
   {
      string paddingLeft = "     ";

      public bool Playing { get; set; }
      public bool InAlbum1Section { get; set; }
      public bool InAlbum2Section { get; set; }
      public bool InA1S1Section { get; set; }
      public bool InA1S2Section { get; set; }
      public bool InA2S1Section { get; set; }
      public bool InA2S2Section { get; set; }
      public bool InA2S3Section { get; set; }

      public List<Album> Albums = new List<Album>();

      private Menu MainMenu { get; set; }
      private Menu Album1Menu { get; set; }
      private Menu Album2Menu { get; set; }
      public Menu A1S1Menu { get; set; }
      public Menu A1S2Menu { get; set; }
      public Menu A2S1Menu { get; set; }
      public Menu A2S2Menu { get; set; }
      public Menu A2S3Menu { get; set; }


      public void Setup()
      {
         //Initialize the state of the Jukebox object.
         //Add albums/songs
         //Display Welcome Message
         //Do any other work, etc.
         //...

         //AddAlbums:
         AddAlbums();               //Also adds related songs to each album
         //DisplayWelcomeMessage();

         //Build Menus:
         MainMenu = BuildMainMenu();
         Album1Menu = BuildAlbum1Menu();
         Album2Menu = BuildAlbum2Menu();
         A1S1Menu = BuildA1S1Menu();
         A1S2Menu = BuildA1S2Menu();
         A2S1Menu = BuildA2S1Menu();
         A2S2Menu = BuildA2S2Menu();
         A2S3Menu = BuildA2S3Menu();

         Playing = true;

         InAlbum1Section = false;
         InAlbum2Section = false;
         InA1S1Section = false;
         InA1S2Section = false;
         InA2S1Section = false;
         InA2S2Section = false;
         InA2S3Section = false;
      }

      private void DisplayWelcomeMessage()
      {
         string paddingLeft = "     ";
         Console.WriteLine(paddingLeft + "");
         Console.WriteLine(paddingLeft + "*************************************************");
         Console.WriteLine(paddingLeft + "*         Welcome to the 8-Bit Jukebox!         *");
         Console.WriteLine(paddingLeft + "*************************************************");
         Console.WriteLine(paddingLeft + "         Developer: Michael A. chamberlain       ");
         Console.WriteLine(paddingLeft + "         Ver 1.0.0: 2018-05-06                   ");
         Console.WriteLine(paddingLeft + "-------------------------------------------------");
         Console.WriteLine(paddingLeft + "Today's Date/Time: " + DateTime.Now.ToString());
         Console.WriteLine("");
      }

      Menu BuildMainMenu()
      {
         BuildMainHeader();
         return new Menu(
            "Main Menu",
            new List<MenuOption>
            {
               new MenuOption(Album1Selection, "Album 1: " + Albums[0].Description),
               new MenuOption(Album2Selection, "Album 2: " + Albums[1].Description),
               new MenuOption(PlayAllSongsSelection, "Play All Songs"),
               new MenuOption(ExitApplicationSelection, "Exit Application"),
            });
      }

      Menu BuildAlbum1Menu()
      {
         BuildMainHeader();
         return new Menu(
            "Album 1 Menu",
            new List<MenuOption>
            {
               new MenuOption(A1S1Selection, "Song 1: " + Albums[0].Songs[0].Description),
               new MenuOption(A1S2Selection, "Song 2: " + Albums[0].Songs[1].Description),
               new MenuOption(ExitAlbum1Selection, "Exit Album"),
            });
      }

      Menu BuildAlbum2Menu()
      {
         BuildMainHeader();
         return new Menu(
            "Album 2 Menu",
            new List<MenuOption>
            {
               new MenuOption(A2S1Selection, "Song 1: " + Albums[1].Songs[0].Description),
               new MenuOption(A2S2Selection, "Song 2: " + Albums[1].Songs[1].Description),
               new MenuOption(A2S3Selection, "Song 3: " + Albums[1].Songs[2].Description),
               new MenuOption(ExitAlbum2Selection, "Exit Album"),
            });
      }

      Menu BuildA1S1Menu()
      {
         BuildMainHeader();
         return new Menu(
            "Album 1; Song 1 Menu",
            new List<MenuOption>
            {
               new MenuOption(A1S1PlaySelection, "Play"),
               new MenuOption(ExitA1S1Selection, "Exit Song Selection"),
            });
      }

      Menu BuildA1S2Menu()
      {
         BuildMainHeader();
         return new Menu(
            "Album 1; Song 2 Menu",
            new List<MenuOption>
            {
               new MenuOption(A1S2PlaySelection, "Play"),
               new MenuOption(ExitA1S2Selection, "Exit Song Selection"),
            });
      }

      Menu BuildA2S1Menu()
      {
         BuildMainHeader();
         return new Menu(
            "Album 2; Song 1 Menu",
            new List<MenuOption>
            {
               new MenuOption(A2S1PlaySelection, "Play"),
               new MenuOption(ExitA2S1Selection, "Exit Song Selection"),
            });
      }

      Menu BuildA2S2Menu()
      {
         BuildMainHeader();
         return new Menu(
            "Album 2; Song 2 Menu",
            new List<MenuOption>
            {
               new MenuOption(A2S2PlaySelection, "Play"),
               new MenuOption(ExitA2S2Selection, "Exit Song Selection"),
            });
      }

      Menu BuildA2S3Menu()
      {
         BuildMainHeader();
         return new Menu(
            "Album 2; Song 3 Menu",
            new List<MenuOption>
            {
               new MenuOption(A2S3PlaySelection, "Play"),
               new MenuOption(ExitA2S3Selection, "Exit Song Selection"),
            });
      }




      public void MainMenuSelection()
      {
         Console.WriteLine(paddingLeft + MainMenu.Name + ":");
         Action action = MainMenu.SelectOption();
         if (action != null)
         {
            action.Invoke();
         }
      }


      private void Album1Selection()
      {
         InAlbum1Section = true;
         while (InAlbum1Section)
         {
            BuildMainHeader();
            Console.WriteLine(paddingLeft + Album1Menu.Name + ": Album Name: " + Albums[0].Description);
            Action action = Album1Menu.SelectOption();
            if (action != null)
            {
               action.Invoke();
            }
         }
      }

      private void Album2Selection()
      {
         InAlbum2Section = true;
         while (InAlbum2Section)
         {
            BuildMainHeader();
            Console.WriteLine(paddingLeft + Album2Menu.Name + ": Album Name: " + Albums[1].Description);
            Action action = Album2Menu.SelectOption();
            if (action != null)
            {
               action.Invoke();
            }
         }
      }

      private void A1S1Selection()
      {
         InA1S1Section = true;
         while (InA1S1Section)
         {
            BuildMainHeader();
            Song song = Albums[0].Songs[0];

            Console.WriteLine(paddingLeft + @"Song Title: {0}", song.Title);
            Console.WriteLine(paddingLeft + @"Song Author: {0}", song.Author);
            Console.WriteLine(paddingLeft + @"Song Source: {0}", song.Reference);
            Console.WriteLine(paddingLeft + @"Times Played: {0}", song.TimesPlayed);
            Console.WriteLine("");

            Console.WriteLine(paddingLeft + A1S1Menu.Name + ": Song Name: " + song.Description);
            Action action = A1S1Menu.SelectOption();
            if (action != null)
            {
               action.Invoke();
            }
         }
      }

      private void A1S2Selection()
      {
         InA1S2Section = true;
         while (InA1S2Section)
         {
            BuildMainHeader();
            Song song = Albums[0].Songs[1];

            Console.WriteLine(paddingLeft + @"Song Title: {0}", song.Title);
            Console.WriteLine(paddingLeft + @"Song Author: {0}", song.Author);
            Console.WriteLine(paddingLeft + @"Song Source: {0}", song.Reference);
            Console.WriteLine(paddingLeft + @"Times Played: {0}", song.TimesPlayed);
            Console.WriteLine("");

            Console.WriteLine(paddingLeft + A1S2Menu.Name + ": Song Name: " + song.Description);
            Action action = A1S2Menu.SelectOption();
            if (action != null)
            {
               action.Invoke();
            }
         }
      }

      private void A2S1Selection()
      {
         InA2S1Section = true;
         while (InA2S1Section)
         {
            BuildMainHeader();
            Song song = Albums[1].Songs[0];

            Console.WriteLine(paddingLeft + @"Song Title: {0}", song.Title);
            Console.WriteLine(paddingLeft + @"Song Author: {0}", song.Author);
            Console.WriteLine(paddingLeft + @"Song Source: {0}", song.Reference);
            Console.WriteLine(paddingLeft + @"Times Played: {0}", song.TimesPlayed);
            Console.WriteLine("");

            Console.WriteLine(paddingLeft + A2S1Menu.Name + ": Song Name: " + song.Description);
            Action action = A2S1Menu.SelectOption();
            if (action != null)
            {
               action.Invoke();
            }
         }
      }

      private void A2S2Selection()
      {
         InA2S2Section = true;
         while (InA2S2Section)
         {
            BuildMainHeader();
            Song song = Albums[1].Songs[1];

            Console.WriteLine(paddingLeft + @"Song Title: {0}", song.Title);
            Console.WriteLine(paddingLeft + @"Song Author: {0}", song.Author);
            Console.WriteLine(paddingLeft + @"Song Source: {0}", song.Reference);
            Console.WriteLine(paddingLeft + @"Times Played: {0}", song.TimesPlayed);
            Console.WriteLine("");

            Console.WriteLine(paddingLeft + A2S2Menu.Name + ": Song Name: " + song.Description);
            Action action = A2S2Menu.SelectOption();
            if (action != null)
            {
               action.Invoke();
            }
         }
      }

      private void A2S3Selection()
      {
         InA2S3Section = true;
         while (InA2S3Section)
         {
            BuildMainHeader();
            Song song = Albums[1].Songs[2];

            Console.WriteLine(paddingLeft + @"Song Title: {0}", song.Title);
            Console.WriteLine(paddingLeft + @"Song Author: {0}", song.Author);
            Console.WriteLine(paddingLeft + @"Song Source: {0}", song.Reference);
            Console.WriteLine(paddingLeft + @"Times Played: {0}", song.TimesPlayed);
            Console.WriteLine("");

            Console.WriteLine(paddingLeft + A2S3Menu.Name + ": Song Name: " + song.Description);
            Action action = A2S3Menu.SelectOption();
            if (action != null)
            {
               action.Invoke();
            }
         }
      }

      private void A1S1PlaySelection()
      {
         BuildMainHeader();
         Song song = Albums[0].Songs[0];

         Console.WriteLine(paddingLeft + @"Selection: Album 1 Song: {0}) {1}", song.ID, song.Description);
         Console.WriteLine("");
         Console.Write(paddingLeft + @"Now Playing: {0}...", song.Title);

         Play(song);
         song.TimesPlayed++;
         InA1S1Section = false;
      }

      private void A1S2PlaySelection()
      {
         BuildMainHeader();
         Song song = Albums[0].Songs[1];

         Console.WriteLine(paddingLeft + @"Selection: Album 1 Song: {0}) {1}", song.ID, song.Description);
         Console.WriteLine("");
         Console.Write(paddingLeft + @"Now Playing: {0}...", song.Title);

         Play(song);
         song.TimesPlayed++;
         InA1S2Section = false;
      }

      private void A2S1PlaySelection()
      {
         BuildMainHeader();
         Song song = Albums[1].Songs[0];

         Console.WriteLine(paddingLeft + @"Selection: Album 1 Song: {0}) {1}", song.ID, song.Description);
         Console.WriteLine("");
         Console.Write(paddingLeft + @"Now Playing: {0}...", song.Title);

         Play(song);
         song.TimesPlayed++;
         InA2S1Section = false;
      }

      private void A2S2PlaySelection()
      {
         BuildMainHeader();
         Song song = Albums[1].Songs[1];

         Console.WriteLine(paddingLeft + @"Selection: Album 1 Song: {0}) {1}", song.ID, song.Description);
         Console.WriteLine("");
         Console.Write(paddingLeft + @"Now Playing: {0}...", song.Title);

         Play(song);
         song.TimesPlayed++;
         InA2S2Section = false;
      }

      private void A2S3PlaySelection()
      {
         BuildMainHeader();
         Song song = Albums[1].Songs[2];

         Console.WriteLine(paddingLeft + @"Selection: Album 1 Song: {0}) {1}", song.ID, song.Description);
         Console.WriteLine("");
         Console.Write(paddingLeft + @"Now Playing: {0}...", song.Title);

         Play(song);
         song.TimesPlayed++;
         InA2S3Section = false;
      }



      private void PlayAllSongsSelection()
      {
         BuildMainHeader();
         Console.WriteLine("");
         Console.WriteLine(paddingLeft + "Selected: Play All Songs:");
         foreach (Album album in Albums)
         {
            Console.WriteLine("");
            Console.WriteLine(paddingLeft + @"Now Playing each Song in Album: {0}) {1}:", album.ID, album.Description);
            foreach (Song song in album.Songs)
            {
               Console.WriteLine(paddingLeft + @" - Now Playing Song: {0}) {1}...", song.ID, song.Description);
               Play(song);
               song.TimesPlayed++;
            }
         }
         //Console.WriteLine(" Bdeep, dbeep, bdp - ... That's All folks!!!");
         BuildMainHeader();
      }

      private void ExitApplicationSelection()
      {
         BuildMainHeader();
         Console.WriteLine("");
         Console.WriteLine(paddingLeft + "Thanks for using the 8-Bit Jukebox! Come back any time!");
         Stop();
      }

      private void ExitAlbum1Selection()
      {
         InAlbum1Section = false;
         BuildMainHeader();
         BuildMainMenu();
      }

      private void ExitAlbum2Selection()
      {
         InAlbum2Section = false;
         BuildMainHeader();
         BuildMainMenu();
      }

      private void ExitA1S1Selection()
      {
         InA1S1Section = false;
         BuildMainHeader();
         BuildMainMenu();
      }

      private void ExitA1S2Selection()
      {
         InA1S2Section = false;
         BuildMainHeader();
         BuildMainMenu();
      }

      private void ExitA2S1Selection()
      {
         InA2S1Section = false;
         BuildMainHeader();
         BuildMainMenu();
      }

      private void ExitA2S2Selection()
      {
         InA2S2Section = false;
         BuildMainHeader();
         BuildMainMenu();
      }

      private void ExitA2S3Selection()
      {
         InA2S3Section = false;
         BuildMainHeader();
         BuildMainMenu();
      }

      private void BuildMainHeader()
      {
         Console.Clear();
         DisplayWelcomeMessage();
      }

      // BUILD Ojbects: ---------------------------------------------------------------------------------------

      private void AddAlbums()
      {
         //Create Individual Albums
         Album album1 = new Classes.Album(1, "Warmups");
         Album album2 = new Classes.Album(2, "Game Themes");

         //Add them to the Jukebox.Albums Collection.
         Albums.Add(album1);
         Albums.Add(album2);

         //Add Songs to new Album:
         AddSongs(album1);
         AddSongs(album2);
         //...
      }

      private void AddSongs(Album album)
      {
         switch (album.ID)
         {
            case 1:
               //Add Songs to Album #1:
               //Create Individual Songs
               Song a1s1 = new Classes.Song(
                  1, 
                  "Doe Ray Me",
                  "Scale To Warm Up",
                  "GP",
                  "http://vbcity.com/forums/t/133752.aspx"
                  );
               Song a1s2 = new Classes.Song(
                  2, 
                  "Happy Birthday",
                  "Happy Birthday",
                  "GP",
                  "http://vbcity.com/forums/t/133752.aspx"
                  );

               //Build Notes for Song:
               BuildA1S1Notes(a1s1);
               BuildA1S2Notes(a1s2);

               //Add them to the Album.Songs Collection:
               album.Songs.Add(a1s1);
               album.Songs.Add(a1s2);
               break;

            case 2:
               //Add Songs to Album #2:
               //Create Individual Songs
               Song a2s1 = new Classes.Song(
                  1, 
                  "Super Mario Theme",
                  "Super Mario Song",
                  "Akash Agrawal",
                  "https://hashtagakash.wordpress.com/2014/01/22/182/"
                  );
               Song a2s2 = new Classes.Song(
                  2, 
                  "Tetris Theme",
                  "Tetris Cong in Script",
                  "GitHubgist>XeeX/Tetris.CSX",
                  "https://gist.github.com/XeeX/6220067"
                  );
               Song a2s3 = new Classes.Song(
                  3, 
                  "Custom Game Theme",
                  "Beep Music (Mario Bros Theme)",
                  "J0keR",
                  "https://www.autoitscript.com/forum/topic/40848-beep-music-mario-bros-theme/"
                  );

               //Build Notes for Song:
               BuildA2S1Notes(a2s1);
               BuildA2S2Notes(a2s2);
               BuildA2S3Notes(a2s3);

               //Add them to the Album.Songs Collection:
               album.Songs.Add(a2s1);
               album.Songs.Add(a2s2);
               album.Songs.Add(a2s3);
               break;

            default:
               break;
         }
         //...
      }

      private void BuildA1S1Notes(Song a1s1)
      {
         // DoeRayMe
         //Build note objects:
         Note n1 = new Note(264, (1000 / 4), 0);
         Note n2 = new Note(297, (1000 / 4), 0);
         Note n3 = new Note(330, (1000 / 4), 0);
         Note n4 = new Note(352, (1000 / 4), 0);
         Note n5 = new Note(396, (1000 / 4), 0);
         Note n6 = new Note(440, (1000 / 4), 0);
         Note n7 = new Note(495, (1000 / 4), 0);
         Note n8 = new Note(528, (1000 / 2), (1000 / 4));
         Note n9 = new Note(528, (1000 / 4), 0);
         Note n10 = new Note(495, (1000 / 4), 0);
         Note n11 = new Note(440, (1000 / 4), 0);
         Note n12 = new Note(396, (1000 / 4), 0);
         Note n13 = new Note(352, (1000 / 4), 0);
         Note n14 = new Note(330, (1000 / 4), 0);
         Note n15 = new Note(297, (1000 / 4), 0);
         Note n16 = new Note(264, (1000 / 2), 1000);

         //Inject note objects into Song.Notes Collection:
         a1s1.Notes.Add(n1);
         a1s1.Notes.Add(n2);
         a1s1.Notes.Add(n3);
         a1s1.Notes.Add(n4);
         a1s1.Notes.Add(n5);
         a1s1.Notes.Add(n6);
         a1s1.Notes.Add(n7);
         a1s1.Notes.Add(n8);
         a1s1.Notes.Add(n9);
         a1s1.Notes.Add(n10);
         a1s1.Notes.Add(n11);
         a1s1.Notes.Add(n12);
         a1s1.Notes.Add(n13);
         a1s1.Notes.Add(n14);
         a1s1.Notes.Add(n15);
         a1s1.Notes.Add(n16);
      }

      private void BuildA1S2Notes(Song a1s2)
      {
         int a = 440;
         int bb = 466;
         int b = 495;
         int c = 264;
         int cc = 528;
         int d = 297;
         int e = 330;
         int f = 352;
         int g = 396;

         int n = 1000;
         int h = (1000 / 2);
         int q = (1000 / 4);
         int ei = (1000 / 8);

         // DoeRayMe
         //Build note objects:
         Note n1 = new Note(c, ei, q);
         Note n2 = new Note(c, ei, ei);
         Note n3 = new Note(d, h, ei);
         Note n4 = new Note(c, h, ei);
         Note n5 = new Note(f, h, ei);
         Note n6 = new Note(e, n, q);

         Note n7 = new Note(c, ei, q);
         Note n8 = new Note(c, ei, ei);
         Note n9 = new Note(d, h, ei);
         Note n10 = new Note(c, h, ei);
         Note n11 = new Note(g, h, ei);
         Note n12 = new Note(f, n, q);

         Note n13 = new Note(c, ei, q);
         Note n14 = new Note(c, ei, ei);
         Note n15 = new Note(cc, h, ei);
         Note n16 = new Note(a, h, ei);
         Note n17 = new Note(f, q, ei);
         Note n18 = new Note(f, ei, ei);
         Note n19 = new Note(e, h, ei);
         Note n20 = new Note(d, n, q);

         Note n21 = new Note(bb, ei, q);
         Note n22 = new Note(bb, ei, ei);
         Note n23 = new Note(a, h, ei);
         Note n24 = new Note(f, h, ei);
         Note n25 = new Note(g, h, ei);
         Note n26 = new Note(f, n, n);

         //Inject note objects into Song.Notes Collection:
         a1s2.Notes.Add(n1);
         a1s2.Notes.Add(n2);
         a1s2.Notes.Add(n3);
         a1s2.Notes.Add(n4);
         a1s2.Notes.Add(n5);
         a1s2.Notes.Add(n6);

         a1s2.Notes.Add(n7);
         a1s2.Notes.Add(n8);
         a1s2.Notes.Add(n9);
         a1s2.Notes.Add(n10);
         a1s2.Notes.Add(n11);
         a1s2.Notes.Add(n12);

         a1s2.Notes.Add(n13);
         a1s2.Notes.Add(n14);
         a1s2.Notes.Add(n15);
         a1s2.Notes.Add(n16);
         a1s2.Notes.Add(n17);
         a1s2.Notes.Add(n18);
         a1s2.Notes.Add(n19);
         a1s2.Notes.Add(n20);

         a1s2.Notes.Add(n21);
         a1s2.Notes.Add(n22);
         a1s2.Notes.Add(n23);
         a1s2.Notes.Add(n24);
         a1s2.Notes.Add(n25);
         a1s2.Notes.Add(n26);
      }

      private void BuildA2S1Notes(Song a2s1)
      {
         // SuperMario
         //Build note objects:
         Note n1 = new Note(659, 125, 000);
         Note n2 = new Note(659, 125, 125);
         Note n3 = new Note(659, 125, 167);
         Note n4 = new Note(523, 125, 000);
         Note n5 = new Note(659, 125, 125);
         Note n6 = new Note(784, 125, 375);
         Note n7 = new Note(392, 125, 375);
         Note n8 = new Note(523, 125, 250);
         Note n9 = new Note(392, 125, 250);
         Note n10 = new Note(330, 125, 250);
         Note n11 = new Note(440, 125, 125);
         Note n12 = new Note(494, 125, 125);
         Note n13 = new Note(466, 125, 42);
         Note n14 = new Note(440, 125, 125);
         Note n15 = new Note(392, 125, 125);
         Note n16 = new Note(659, 125, 125);
         Note n17 = new Note(784, 125, 125);
         Note n18 = new Note(880, 125, 125);
         Note n19 = new Note(698, 125, 000);
         Note n20 = new Note(784, 125, 125);
         Note n21 = new Note(659, 125, 125);
         Note n22 = new Note(523, 125, 125);
         Note n23 = new Note(587, 125, 000);
         Note n24 = new Note(494, 125, 125);
         Note n25 = new Note(523, 125, 250);
         Note n26 = new Note(392, 125, 250);
         Note n27 = new Note(330, 125, 250);
         Note n28 = new Note(440, 125, 125);
         Note n29 = new Note(494, 125, 125);
         Note n30 = new Note(466, 125, 42);
         Note n31 = new Note(440, 125, 125);
         Note n32 = new Note(392, 125, 125);
         Note n33 = new Note(659, 125, 125);
         Note n34 = new Note(784, 125, 125);
         Note n35 = new Note(880, 125, 125);
         Note n36 = new Note(698, 125, 000);
         Note n37 = new Note(784, 125, 125);
         Note n38 = new Note(659, 125, 125);
         Note n39 = new Note(523, 125, 125);
         Note n40 = new Note(587, 125, 000);
         Note n41 = new Note(494, 125, 375);
         Note n42 = new Note(784, 125, 000);
         Note n43 = new Note(740, 125, 000);
         Note n44 = new Note(698, 125, 42);
         Note n45 = new Note(622, 125, 000);
         Note n46 = new Note(659, 125, 167);
         Note n47 = new Note(415, 125, 000);
         Note n48 = new Note(440, 125, 000);
         Note n49 = new Note(523, 125, 125);
         Note n50 = new Note(440, 125, 000);
         Note n51 = new Note(523, 125, 000);
         Note n52 = new Note(587, 125, 250);
         Note n53 = new Note(784, 125, 000);
         Note n54 = new Note(740, 125, 000);
         Note n55 = new Note(698, 125, 42);
         Note n56 = new Note(622, 125, 125);
         Note n57 = new Note(659, 125, 167);
         Note n58 = new Note(698, 125, 125);
         Note n59 = new Note(698, 125, 000);
         Note n60 = new Note(698, 125, 625);
         Note n61 = new Note(784, 125, 000);
         Note n62 = new Note(740, 125, 000);
         Note n63 = new Note(698, 125, 42);
         Note n64 = new Note(622, 125, 125);
         Note n65 = new Note(659, 125, 167);
         Note n66 = new Note(415, 125, 000);
         Note n67 = new Note(440, 125, 000);
         Note n68 = new Note(523, 125, 125);
         Note n69 = new Note(440, 125, 000);
         Note n70 = new Note(523, 125, 000);
         Note n71 = new Note(587, 125, 250);
         Note n72 = new Note(622, 125, 250);
         Note n73 = new Note(587, 125, 250);
         Note n74 = new Note(523, 125, 1000);

         //Inject note objects into Song.Notes Collection:
         a2s1.Notes.Add(n1);
         a2s1.Notes.Add(n2);
         a2s1.Notes.Add(n3);
         a2s1.Notes.Add(n4);
         a2s1.Notes.Add(n5);
         a2s1.Notes.Add(n6);
         a2s1.Notes.Add(n7);
         a2s1.Notes.Add(n8);
         a2s1.Notes.Add(n9);
         a2s1.Notes.Add(n10);
         a2s1.Notes.Add(n11);
         a2s1.Notes.Add(n12);
         a2s1.Notes.Add(n13);
         a2s1.Notes.Add(n14);
         a2s1.Notes.Add(n15);
         a2s1.Notes.Add(n16);
         a2s1.Notes.Add(n17);
         a2s1.Notes.Add(n18);
         a2s1.Notes.Add(n19);
         a2s1.Notes.Add(n21);
         a2s1.Notes.Add(n22);
         a2s1.Notes.Add(n23);
         a2s1.Notes.Add(n24);
         a2s1.Notes.Add(n25);
         a2s1.Notes.Add(n26);
         a2s1.Notes.Add(n27);
         a2s1.Notes.Add(n28);
         a2s1.Notes.Add(n29);
         a2s1.Notes.Add(n30);
         a2s1.Notes.Add(n31);
         a2s1.Notes.Add(n32);
         a2s1.Notes.Add(n33);
         a2s1.Notes.Add(n34);
         a2s1.Notes.Add(n35);
         a2s1.Notes.Add(n36);
         a2s1.Notes.Add(n37);
         a2s1.Notes.Add(n38);
         a2s1.Notes.Add(n39);
         a2s1.Notes.Add(n40);
         a2s1.Notes.Add(n41);
         a2s1.Notes.Add(n42);
         a2s1.Notes.Add(n43);
         a2s1.Notes.Add(n44);
         a2s1.Notes.Add(n45);
         a2s1.Notes.Add(n46);
         a2s1.Notes.Add(n47);
         a2s1.Notes.Add(n48);
         a2s1.Notes.Add(n49);
         a2s1.Notes.Add(n50);
         a2s1.Notes.Add(n51);
         a2s1.Notes.Add(n52);
         a2s1.Notes.Add(n53);
         a2s1.Notes.Add(n54);
         a2s1.Notes.Add(n55);
         a2s1.Notes.Add(n56);
         a2s1.Notes.Add(n57);
         a2s1.Notes.Add(n58);
         a2s1.Notes.Add(n59);
         a2s1.Notes.Add(n60);
         a2s1.Notes.Add(n61);
         a2s1.Notes.Add(n62);
         a2s1.Notes.Add(n63);
         a2s1.Notes.Add(n64);
         a2s1.Notes.Add(n65);
         a2s1.Notes.Add(n66);
         a2s1.Notes.Add(n67);
         a2s1.Notes.Add(n68);
         a2s1.Notes.Add(n69);
         a2s1.Notes.Add(n71);
         a2s1.Notes.Add(n72);
         a2s1.Notes.Add(n73);
         a2s1.Notes.Add(n74);
      }

      private void BuildA2S2Notes(Song a2s2)
      {
         // Tetris
         //Build note objects:
         Note n1 = new Note(658, 125, 000);
         Note n2 = new Note(1320, 500, 000);
         Note n3 = new Note(990, 250, 000);
         Note n4 = new Note(1056, 250, 000);
         Note n5 = new Note(1188, 250, 000);
         Note n6 = new Note(1320, 125, 000);
         Note n7 = new Note(1188, 125, 000);
         Note n8 = new Note(1056, 250, 000);
         Note n9 = new Note(990, 250, 000);
         Note n10 = new Note(880, 500, 000);
         Note n11 = new Note(880, 250, 000);
         Note n12 = new Note(1056, 250, 000);
         Note n13 = new Note(1320, 500, 000);
         Note n14 = new Note(1188, 250, 000);
         Note n15 = new Note(1056, 250, 000);
         Note n16 = new Note(990, 750, 000);
         Note n17 = new Note(1056, 250, 000);
         Note n18 = new Note(1188, 500, 000);
         Note n19 = new Note(1320, 500, 000);
         Note n20 = new Note(1056, 500, 000);
         Note n21 = new Note(880, 500, 000);
         Note n22 = new Note(880, 500, 250);
         Note n23 = new Note(1188, 500, 000);
         Note n24 = new Note(1408, 250, 000);
         Note n25 = new Note(1760, 500, 000);
         Note n26 = new Note(1584, 250, 000);
         Note n27 = new Note(1408, 250, 000);
         Note n28 = new Note(1320, 750, 000);
         Note n29 = new Note(1056, 250, 000);
         Note n30 = new Note(1320, 500, 000);
         Note n31 = new Note(1188, 250, 000);
         Note n32 = new Note(1056, 250, 000);
         Note n33 = new Note(990, 500, 000);
         Note n34 = new Note(990, 250, 000);
         Note n35 = new Note(1056, 250, 000);
         Note n36 = new Note(1188, 500, 000);
         Note n37 = new Note(1320, 500, 000);
         Note n38 = new Note(1056, 500, 000);
         Note n39 = new Note(880, 500, 000);
         Note n40 = new Note(880, 500, 500);
         Note n41 = new Note(1320, 500, 000);
         Note n42 = new Note(990, 250, 000);
         Note n43 = new Note(1056, 250, 000);
         Note n44 = new Note(1188, 250, 000);
         Note n45 = new Note(1320, 125, 000);
         Note n46 = new Note(1188, 125, 000);
         Note n47 = new Note(1056, 250, 000);
         Note n48 = new Note(990, 250, 000);
         Note n49 = new Note(880, 500, 000);
         Note n50 = new Note(880, 250, 000);
         Note n51 = new Note(1056, 250, 000);
         Note n52 = new Note(1320, 500, 000);
         Note n53 = new Note(1188, 250, 000);
         Note n54 = new Note(1056, 250, 000);
         Note n55 = new Note(990, 750, 000);
         Note n56 = new Note(1056, 250, 000);
         Note n57 = new Note(1188, 500, 000);
         Note n58 = new Note(1320, 500, 000);
         Note n59 = new Note(1056, 500, 000);
         Note n60 = new Note(880, 500, 000);
         Note n61 = new Note(880, 500, 250);
         Note n62 = new Note(1188, 500, 000);
         Note n63 = new Note(1408, 250, 000);
         Note n64 = new Note(1760, 500, 000);
         Note n65 = new Note(1584, 250, 000);
         Note n66 = new Note(1408, 250, 000);
         Note n67 = new Note(1320, 750, 000);
         Note n68 = new Note(1056, 250, 000);
         Note n69 = new Note(1320, 500, 000);
         Note n70 = new Note(1188, 250, 000);
         Note n71 = new Note(1056, 250, 000);
         Note n72 = new Note(990, 500, 000);
         Note n73 = new Note(990, 250, 000);
         Note n74 = new Note(1056, 250, 000);
         Note n75 = new Note(1188, 500, 000);
         Note n76 = new Note(1320, 500, 000);
         Note n77 = new Note(1056, 500, 000);
         Note n78 = new Note(880, 500, 000);
         Note n79 = new Note(880, 500, 1000);

         //Inject note objects into Song.Notes Collection:
         a2s2.Notes.Add(n1);
         a2s2.Notes.Add(n2);
         a2s2.Notes.Add(n3);
         a2s2.Notes.Add(n4);
         a2s2.Notes.Add(n5);
         a2s2.Notes.Add(n6);
         a2s2.Notes.Add(n7);
         a2s2.Notes.Add(n8);
         a2s2.Notes.Add(n9);
         a2s2.Notes.Add(n10);
         a2s2.Notes.Add(n11);
         a2s2.Notes.Add(n12);
         a2s2.Notes.Add(n13);
         a2s2.Notes.Add(n14);
         a2s2.Notes.Add(n15);
         a2s2.Notes.Add(n16);
         a2s2.Notes.Add(n17);
         a2s2.Notes.Add(n18);
         a2s2.Notes.Add(n19);
         a2s2.Notes.Add(n20);
         a2s2.Notes.Add(n21);
         a2s2.Notes.Add(n22);
         a2s2.Notes.Add(n23);
         a2s2.Notes.Add(n24);
         a2s2.Notes.Add(n25);
         a2s2.Notes.Add(n26);
         a2s2.Notes.Add(n27);
         a2s2.Notes.Add(n28);
         a2s2.Notes.Add(n29);
         a2s2.Notes.Add(n30);
         a2s2.Notes.Add(n31);
         a2s2.Notes.Add(n32);
         a2s2.Notes.Add(n33);
         a2s2.Notes.Add(n34);
         a2s2.Notes.Add(n35);
         a2s2.Notes.Add(n36);
         a2s2.Notes.Add(n37);
         a2s2.Notes.Add(n38);
         a2s2.Notes.Add(n39);
         a2s2.Notes.Add(n40);
         a2s2.Notes.Add(n41);
         a2s2.Notes.Add(n42);
         a2s2.Notes.Add(n43);
         a2s2.Notes.Add(n44);
         a2s2.Notes.Add(n45);
         a2s2.Notes.Add(n46);
         a2s2.Notes.Add(n47);
         a2s2.Notes.Add(n48);
         a2s2.Notes.Add(n49);
         a2s2.Notes.Add(n50);
         a2s2.Notes.Add(n51);
         a2s2.Notes.Add(n52);
         a2s2.Notes.Add(n53);
         a2s2.Notes.Add(n54);
         a2s2.Notes.Add(n55);
         a2s2.Notes.Add(n56);
         a2s2.Notes.Add(n57);
         a2s2.Notes.Add(n58);
         a2s2.Notes.Add(n59);
         a2s2.Notes.Add(n60);
         a2s2.Notes.Add(n61);
         a2s2.Notes.Add(n62);
         a2s2.Notes.Add(n63);
         a2s2.Notes.Add(n64);
         a2s2.Notes.Add(n65);
         a2s2.Notes.Add(n66);
         a2s2.Notes.Add(n67);
         a2s2.Notes.Add(n68);
         a2s2.Notes.Add(n69);
         a2s2.Notes.Add(n70);
         a2s2.Notes.Add(n71);
         a2s2.Notes.Add(n72);
         a2s2.Notes.Add(n73);
         a2s2.Notes.Add(n74);
         a2s2.Notes.Add(n75);
         a2s2.Notes.Add(n76);
         a2s2.Notes.Add(n77);
         a2s2.Notes.Add(n78);
         a2s2.Notes.Add(n79);
      }

      private void BuildA2S3Notes(Song a2s3)
      {
         // CustomGameTheme
         //Build note objects:
         Note n1 = new Note(450, 110, 000);
         Note n2 = new Note(500, 110, 000);
         Note n3 = new Note(550, 110, 000);
         Note n4 = new Note(450, 110, 000);
         Note n5 = new Note(675, 200, 000);
         Note n6 = new Note(675, 200, 000);
         Note n7 = new Note(600, 300, 000);
         Note n8 = new Note(450, 110, 000);
         Note n9 = new Note(500, 110, 000);
         Note n10 = new Note(550, 110, 000);
         Note n11 = new Note(450, 110, 000);
         Note n12 = new Note(600, 200, 000);
         Note n13 = new Note(600, 200, 000);
         Note n14 = new Note(550, 300, 000);
         Note n15 = new Note(525, 110, 000);
         Note n16 = new Note(450, 300, 000);
         Note n17 = new Note(450, 110, 000);
         Note n18 = new Note(500, 110, 000);
         Note n19 = new Note(550, 110, 000);
         Note n20 = new Note(450, 110, 000);
         Note n21 = new Note(500, 400, 000);
         Note n22 = new Note(600, 300, 000);
         Note n23 = new Note(500, 400, 000);
         Note n24 = new Note(475, 200, 000);
         Note n25 = new Note(450, 200, 000);
         Note n26 = new Note(400, 200, 000);
         Note n27 = new Note(600, 500, 000);
         Note n28 = new Note(525, 500, 000);
         Note n29 = new Note(450, 110, 000);
         Note n30 = new Note(500, 110, 000);
         Note n31 = new Note(550, 110, 000);
         Note n32 = new Note(450, 110, 000);
         Note n33 = new Note(675, 200, 000);
         Note n34 = new Note(675, 200, 000);
         Note n35 = new Note(600, 300, 000);
         Note n36 = new Note(450, 110, 000);
         Note n37 = new Note(500, 110, 000);
         Note n38 = new Note(550, 110, 000);
         Note n39 = new Note(450, 110, 000);
         Note n40 = new Note(800, 200, 000);
         Note n41 = new Note(500, 200, 000);
         Note n42 = new Note(550, 300, 000);
         Note n43 = new Note(525, 110, 000);
         Note n44 = new Note(450, 300, 000);
         Note n45 = new Note(450, 110, 000);
         Note n46 = new Note(500, 110, 000);
         Note n47 = new Note(550, 110, 000);
         Note n48 = new Note(450, 110, 000);
         Note n49 = new Note(500, 400, 000);
         Note n50 = new Note(600, 300, 000);
         Note n51 = new Note(500, 400, 000);
         Note n52 = new Note(475, 200, 000);
         Note n53 = new Note(450, 200, 000);
         Note n54 = new Note(400, 200, 000);
         Note n55 = new Note(600, 500, 000);
         Note n56 = new Note(525, 500, 000);

         //Inject note objects into Song.Notes Collection:
         a2s3.Notes.Add(n1);
         a2s3.Notes.Add(n2);
         a2s3.Notes.Add(n3);
         a2s3.Notes.Add(n4);
         a2s3.Notes.Add(n5);
         a2s3.Notes.Add(n6);
         a2s3.Notes.Add(n7);
         a2s3.Notes.Add(n8);
         a2s3.Notes.Add(n9);
         a2s3.Notes.Add(n10);
         a2s3.Notes.Add(n11);
         a2s3.Notes.Add(n12);
         a2s3.Notes.Add(n13);
         a2s3.Notes.Add(n14);
         a2s3.Notes.Add(n15);
         a2s3.Notes.Add(n16);
         a2s3.Notes.Add(n17);
         a2s3.Notes.Add(n18);
         a2s3.Notes.Add(n19);
         a2s3.Notes.Add(n20);
         a2s3.Notes.Add(n21);
         a2s3.Notes.Add(n22);
         a2s3.Notes.Add(n23);
         a2s3.Notes.Add(n24);
         a2s3.Notes.Add(n25);
         a2s3.Notes.Add(n26);
         a2s3.Notes.Add(n27);
         a2s3.Notes.Add(n28);
         a2s3.Notes.Add(n29);
         a2s3.Notes.Add(n30);
         a2s3.Notes.Add(n31);
         a2s3.Notes.Add(n32);
         a2s3.Notes.Add(n33);
         a2s3.Notes.Add(n34);
         a2s3.Notes.Add(n35);
         a2s3.Notes.Add(n36);
         a2s3.Notes.Add(n37);
         a2s3.Notes.Add(n38);
         a2s3.Notes.Add(n39);
         a2s3.Notes.Add(n40);
         a2s3.Notes.Add(n41);
         a2s3.Notes.Add(n42);
         a2s3.Notes.Add(n43);
         a2s3.Notes.Add(n44);
         a2s3.Notes.Add(n45);
         a2s3.Notes.Add(n46);
         a2s3.Notes.Add(n47);
         a2s3.Notes.Add(n48);
         a2s3.Notes.Add(n49);
         a2s3.Notes.Add(n50);
         a2s3.Notes.Add(n51);
         a2s3.Notes.Add(n52);
         a2s3.Notes.Add(n53);
         a2s3.Notes.Add(n54);
         a2s3.Notes.Add(n55);
         a2s3.Notes.Add(n56);
      }

      public void Play(Song song)
      {
         Playing = true;

         //Identify a Song to Play (user selection), and play song.
         foreach (Note note in song.Notes)
         {
            Console.Beep(note.Frequency, note.Duration);
            Thread.Sleep(note.Sleep);
         }
         //Stop();
      }

      public void Stop()
      {
         Playing = false;
      }



   }

}
