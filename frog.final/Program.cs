using System;
using System.Threading;

namespace frog.with.arrays
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.CursorVisible = false; //Make cursor invisible
            Random rastgele = new Random(); //Random

            //variables

            //intro and menu variables
            bool introColor = true;
            int introColorRandom;
            ConsoleKeyInfo introJump;
            ConsoleKeyInfo menuJump;
            ConsoleKeyInfo charJump;
            bool startGame = false;

            //Game variables

            //special powers
            bool stoptime = false;
            bool frogstop = false;
            DateTime ST1 = DateTime.Now;
            DateTime ST2 = DateTime.Now;
            DateTime SF1 = DateTime.Now;
            DateTime SF2 = DateTime.Now;

            //player control[Ga.1]
            double Time = 0;
            double Score = 60;
            double TotalScore = 0;
            int Level = 1;
            int Life = 1;
            string frogDirection = "None ";
            int frogX = 29; int frogY = 7;
            ConsoleKeyInfo Frog;
            char character = 'F';
            DateTime timer1 = DateTime.Now;
            DateTime timer2 = DateTime.Now;
            DateTime frog1 = DateTime.Now;
            DateTime frog2 = DateTime.Now;

            //Level variables[Ga.2]
            bool levelbool = true;

            //Play again varibles


            //Car variables[Ga.3]
            DateTime car1T1 = DateTime.Now;
            DateTime car1T2 = DateTime.Now;
            DateTime car2T1 = DateTime.Now;
            DateTime car2T2 = DateTime.Now;
            bool roadcontrol1 = false; bool roadcontrol2 = false; bool roadcontrol3 = false; bool roadcontrol4 = false; // For control the "sollama" situation
       
            //CREATİNG THE CARS WİTH ARRAYS
            int[] allCarX = new int[24];
            int[] allCarY = new int[24];
            int[] allCarLengths = new int[24];
            int[] allCarSpeeds = new int[24];
            string[] allCars = new string[24];
            char[] allCarsChar = new char[24];

            char[] road1 = new char[59];
            char[] road2 = new char[59];
            char[] road3 = new char[59];
            char[] road4 = new char[59];
            char[] sidewalks1 = new char[59];
            char[] sidewalks2 = new char[59];
            string space = "                                                                                                          ";


            road1[0] = ' '; road1[3] = ' '; road1[54] = ' '; road1[58] = ' '; road1[1] = 'R'; road1[2] = '1'; road1[55] = '<'; road1[56] = '<'; road1[57] = '<';
            road2[0] = ' '; road2[3] = ' '; road2[54] = ' '; road2[58] = ' '; road2[1] = 'R'; road2[2] = '2'; road2[55] = '<'; road2[56] = '<'; road2[57] = '<';
            road3[0] = ' '; road3[3] = ' '; road3[54] = ' '; road3[58] = ' '; road3[1] = 'R'; road3[2] = '3'; road3[55] = '>'; road3[56] = '>'; road3[57] = '>';
            road1[0] = ' '; road4[3] = ' '; road4[54] = ' '; road4[58] = ' '; road4[1] = 'R'; road4[2] = '4'; road4[55] = '>'; road4[56] = '>'; road4[57] = '>';


            for (int sidewalks0 = 0; sidewalks0 < sidewalks1.Length; sidewalks0++)
            {
                sidewalks1[sidewalks0] = '-';
                sidewalks2[sidewalks0] = '-';
            }

            for (int roads = 4; roads < 54; roads++)
            {
                road1[roads] = '.';
                road2[roads] = '.';
                road3[roads] = '.';
                road4[roads] = '.';
            }

            for (int a = 0; a < allCars.Length; a++)
            {
                allCarX[a] = rastgele.Next(4, 52);

                if (a <= 11)
                    allCarY[a] = rastgele.Next(3, 5);
                if (a > 11)
                    allCarY[a] = rastgele.Next(5, 7);

                allCarLengths[a] = rastgele.Next(2, 5);
                allCarSpeeds[a] = 1;

                if (allCarLengths[a] == 2 && allCarSpeeds[a] == 1)
                { allCars[a] = "11"; allCarsChar[a] = '1'; }
                else if (allCarLengths[a] == 3 && allCarSpeeds[a] == 1)
                { allCars[a] = "111"; allCarsChar[a] = '1'; }
                else if (allCarLengths[a] == 4 && allCarSpeeds[a] == 1)
                { allCars[a] = "1111"; allCarsChar[a] = '1'; }
                else if (allCarLengths[a] == 2 && allCarSpeeds[a] == 2)
                { allCars[a] = "22"; allCarsChar[a] = '2'; }
                else if (allCarLengths[a] == 3 && allCarSpeeds[a] == 2)
                { allCars[a] = "222"; allCarsChar[a] = '2'; }
                else if (allCarLengths[a] == 4 && allCarSpeeds[a] == 2)
                { allCars[a] = "2222"; allCarsChar[a] = '2'; }
            }

            for (int b = 0; b < 12; b++)
            {
                for (int innerB = 0; innerB < 12; innerB++)
                {
                    if (((b != innerB) && (allCarY[b] == allCarY[innerB])) && ((((allCarX[innerB] < allCarX[b]) && (allCarX[innerB] + allCarLengths[innerB]) >= allCarX[b])) ||
                        (((allCarX[b] < allCarX[innerB]) && (allCarX[b] + allCarLengths[b] >= allCarX[innerB]))) || ((allCarX[b] == allCarX[innerB]))))
                    {
                        allCarX[b] = rastgele.Next(4, 52);
                        innerB = 0;
                        b = 0;
                    }
                }
            }
            for (int b = 12; b < 24; b++)
            {
                for (int innerB = 12; innerB < 24; innerB++)
                {
                    if (((b != innerB) && (allCarY[b] == allCarY[innerB])) && ((((allCarX[innerB] < allCarX[b]) && (allCarX[innerB] + allCarLengths[innerB]) >= allCarX[b])) ||
                        (((allCarX[b] < allCarX[innerB]) && (allCarX[b] + allCarLengths[b] >= allCarX[innerB]))) || ((allCarX[b] == allCarX[innerB]))))
                    {
                        allCarX[b] = rastgele.Next(4, 52);
                        innerB = 12;
                        b = 12;
                    }
                }
            }

            //Writing cars
            for (int c = 0; c < allCars.Length; c++)
            {
                for (int innerC = 0; innerC < allCarLengths[c]; innerC++)
                {
                    if (allCarY[c] == 3)
                    { road1[(allCarX[c] + innerC)] = allCarsChar[c]; }
                    if (allCarY[c] == 4)
                    { road2[(allCarX[c] + innerC)] = allCarsChar[c]; }
                    if (allCarY[c] == 5)
                    { road3[(allCarX[c] + innerC)] = allCarsChar[c]; }
                    if (allCarY[c] == 6)
                    { road4[(allCarX[c] + innerC)] = allCarsChar[c]; }
                }
            }
            //-------------------------------------------------------------------------------------------------


            //MENU

            //intro [Welcome part][İN.1]
            while (introColor == true)
            {
                Thread.Sleep(250);

                if (Console.KeyAvailable)
                {
                    introJump = Console.ReadKey(true);
                    if (introJump.Key == ConsoleKey.Enter) introColor = false;
                }
                introColorRandom = rastgele.Next(1, 6);

                if (introColorRandom == 1) Console.ForegroundColor = ConsoleColor.Yellow;
                if (introColorRandom == 2) Console.ForegroundColor = ConsoleColor.Green;
                if (introColorRandom == 3) Console.ForegroundColor = ConsoleColor.Blue;
                if (introColorRandom == 4) Console.ForegroundColor = ConsoleColor.Red;
                if (introColorRandom == 5) Console.ForegroundColor = ConsoleColor.Cyan;

                Console.SetCursorPosition(24, 0);
                Console.WriteLine("WELCOME TO THE DANGEROUS ROAD");  //Opening scene
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(@"
                                   _     _
                                  /@\---/@\
                                ,'         `.
                               |             |
                               <`-----------'>
                              / `. `-----' ,' \
                             /    `-------'    \
                            :  |   _______   |  :
                            |  `.,'       `.,'  |
                           ,`.   \    o    /   ,'.
                          /   `.  `.     ,'  ,'   \
                        ^^^^----^^^^-----^^^^----^^^^   ");
                Console.ResetColor();

            }
            for (int i = 0; i < 15; i++)
            {
                Thread.Sleep(150);
                Console.SetCursorPosition(22, i);
                Console.WriteLine(space);
            }
            //intro [Menu Part][İN.2]
            while (startGame == false)
            {
                Thread.Sleep(150); Console.SetCursorPosition(25, 1);
                Console.WriteLine("---------------------------");
                Thread.Sleep(150); Console.SetCursorPosition(25, 2);
                Console.WriteLine("|                         |");
                Thread.Sleep(0); Console.SetCursorPosition(34, 2);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("| MENU |");
                Console.ResetColor();
                Thread.Sleep(150); Console.SetCursorPosition(25, 3);
                Console.WriteLine("|                         |");
                Thread.Sleep(150); Console.SetCursorPosition(25, 4);
                Console.WriteLine("|        1)Start          |");
                Console.SetCursorPosition(25, 5);
                Console.WriteLine("|    2)Choose Character   |");
                Thread.Sleep(150); Console.SetCursorPosition(25, 6);
                Console.WriteLine("|         3)Quit          |");
                Thread.Sleep(150); Console.SetCursorPosition(25, 7);
                Console.WriteLine("|                         |");
                Thread.Sleep(150); Console.SetCursorPosition(25, 8);
                Console.WriteLine("---------------------------");

                //İntro [Choice part][İN.3]
                Thread.Sleep(0);
                menuJump = Console.ReadKey(true);

                while (menuJump.Key != ConsoleKey.D1 && menuJump.Key != ConsoleKey.D2 && menuJump.Key != ConsoleKey.D3)
                {
                    Thread.Sleep(300); Console.SetCursorPosition(17, 9);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You pressed wrong button please try again");
                    Console.ResetColor();
                    Thread.Sleep(300); Console.SetCursorPosition(17, 9);
                    Console.WriteLine(space);

                    if (Console.KeyAvailable)
                    { menuJump = Console.ReadKey(true); }
                }
                Console.SetCursorPosition(17, 9);
                Console.WriteLine("                                         ");

                if (menuJump.Key == ConsoleKey.D1) //Start game with forg
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.SetCursorPosition(34, 4);
                    Console.WriteLine("1)Start");
                    Console.ResetColor();
                    Thread.Sleep(750);
                    startGame = true;

                    for (int i = 0; i < 9; i++)
                    {
                        Thread.Sleep(150);
                        Console.SetCursorPosition(22, i);
                        Console.WriteLine(space);
                    }

                }
                else if (menuJump.Key == ConsoleKey.D2) //Choose Character
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.SetCursorPosition(30, 5);
                    Console.WriteLine("2)Choose Character");
                    Console.ResetColor();
                    Thread.Sleep(750);

                    for (int i = 0; i < 9; i++)
                    {
                        Thread.Sleep(150);
                        Console.SetCursorPosition(22, i);
                        Console.WriteLine(space);
                    }
                    //Choose the character and start
                    Thread.Sleep(150); Console.SetCursorPosition(18, 0);
                    Console.WriteLine("---------------------------------------");
                    Thread.Sleep(150); Console.SetCursorPosition(18, 1);
                    Console.WriteLine("|                                     |");
                    Thread.Sleep(0); Console.SetCursorPosition(30, 1);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("| CHARACTERS |");
                    Console.ResetColor();
                    Thread.Sleep(150); Console.SetCursorPosition(18, 2);
                    Console.WriteLine("|                                     |");
                    Thread.Sleep(150); Console.SetCursorPosition(18, 3);
                    Console.WriteLine("|          1)'F': The Frog            |");
                    Console.SetCursorPosition(18, 4);
                    Console.WriteLine("|          2)'R': The Rabbit          |");
                    Thread.Sleep(150); Console.SetCursorPosition(18, 5);
                    Console.WriteLine("|          3)'K': The Kangroo         |");
                    Thread.Sleep(150); Console.SetCursorPosition(18, 6);
                    Console.WriteLine("|                                     |");
                    Thread.Sleep(150); Console.SetCursorPosition(18, 7);
                    Console.WriteLine("---------------------------------------");
                    charJump = Console.ReadKey(true);

                    while (charJump.Key != ConsoleKey.D1 && charJump.Key != ConsoleKey.D2 && charJump.Key != ConsoleKey.D3)
                    {
                        Thread.Sleep(300); Console.SetCursorPosition(17, 9);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You pressed wrong button please try again");
                        Console.ResetColor();
                        Thread.Sleep(300); Console.SetCursorPosition(17, 9);
                        Console.WriteLine(space);

                        if (Console.KeyAvailable)
                        { charJump = Console.ReadKey(true); }
                    }
                    Console.SetCursorPosition(17, 9);
                    Console.WriteLine(space);

                    if (charJump.Key == ConsoleKey.D1)
                    {
                        character = 'F';
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.SetCursorPosition(29, 3);
                        Console.WriteLine("1)'F': The Frog");
                        Console.ResetColor();
                    }
                    if (charJump.Key == ConsoleKey.D2)
                    {
                        character = 'R';
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(29, 4);
                        Console.WriteLine("2)'R': The Rabbit");
                        Console.ResetColor();
                    }
                    if (charJump.Key == ConsoleKey.D3)
                    {
                        character = 'K';
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.SetCursorPosition(29, 5);
                        Console.WriteLine("3)'K': The Kangroo");
                        Console.ResetColor();
                    }
                    startGame = true;
                    for (int i = 0; i < 9; i++)
                    {
                        Thread.Sleep(150);
                        Console.SetCursorPosition(17, i);
                        Console.WriteLine(space);
                    }
                }
                else if (menuJump.Key == ConsoleKey.D3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.SetCursorPosition(35, 6);
                    Console.WriteLine("3)Quit");
                    Console.ResetColor();
                    Thread.Sleep(750);

                    for (int i = 0; i < 9; i++)
                    {
                        Thread.Sleep(150);
                        Console.SetCursorPosition(22, i);
                        Console.WriteLine(space);
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Thread.Sleep(300); Console.SetCursorPosition(34, 10);
                    Console.WriteLine("-----------");
                    Console.SetCursorPosition(34, 11);
                    Console.WriteLine("| GOODBYE |");
                    Console.SetCursorPosition(34, 12);
                    Console.WriteLine("-----------");
                    Thread.Sleep(300); Environment.Exit(exitCode: 0);

                }
            }

            //LOADİNG SCENE[LO.1]
            Thread.Sleep(300);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(30, 3);
            Console.WriteLine("Loading please wait");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(30, 4);
            Console.WriteLine("-------------------");
            Console.SetCursorPosition(30, 5);
            Console.WriteLine("|                 |");
            Console.SetCursorPosition(30, 6);
            Console.WriteLine("-------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            for (int l = 0; l < 17; l++)
            {
                Thread.Sleep(200);
                Console.SetCursorPosition(31 + l, 5);
                Console.WriteLine("0");
            }
            Console.ResetColor();


            //-------------------------------------------------------------------------------------------------
            //Game starts
            while (true)
            {
                //Frog figure
                if (character == 'F')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(0, 10);
                    Console.WriteLine(@"
    _    _
   (o)--(o)      I am just a frog for you...
  /.______.\     But I have a power that nobody can have...
  \________/     I can stop the time for 5 second but I lose one of my lifes
 ./        \.
( .        , )
 \ \_\\//_/ /
 ~~  ~~  ~~ ");

                }
                if (character == 'R')
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(0, 10);
                    Console.WriteLine(@"
           /\ /|
          |||| |    I am just a rabbit for you...
           \ | \    But I have a power that nobody can have...
       _ _ /  @ @   I can get an 1 extra life but I can't move for 40 seconds
     /    \   =>X<=
   /|      |   /
   \|     /__| |
     \_____\ \__\
 ");

                }
                if (character == 'K')
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.SetCursorPosition(0, 10);
                    Console.WriteLine(@"
  _,'   ___
<__\__/    \   I am just a kangroo for you...
    \_  /  _\  But I have a power that nobody can have...
      \,\ / \\ I can jump to the other side of the road but I lose 1 of my lifes
        //   \\
      ,/'     `\_, ");

                }
                Console.ResetColor();

                //Frog controls!!!!!

                    if ((Console.KeyAvailable && frogY != 2) && frogstop == false)
                {
                    frog2 = DateTime.Now;
                    TimeSpan ts5 = frog2 - frog1;
                    if ((ts5.TotalMilliseconds / 400) >= 1)
                    {
                        frog1 = frog2;

                        Frog = Console.ReadKey(true);

                        if ((frogY != 2) && (Frog.Key == ConsoleKey.UpArrow || Frog.Key == ConsoleKey.W))
                        {
                            if (frogY == 2)
                            { sidewalks1[frogY] = '-'; }
                            else if (frogY == 3)
                            { road1[frogX] = '.'; }
                            else if (frogY == 4)
                            { road2[frogX] = '.'; }
                            else if (frogY == 5)
                            { road3[frogX] = '.'; }
                            else if (frogY == 6)
                            { road4[frogX] = '.'; }
                            else if (frogY == 7)
                            { sidewalks2[frogX] = '-'; }

                            frogY--;
                            frogDirection = "-Up- ";
                        }

                        else if ((frogX != 4) && (Frog.Key == ConsoleKey.LeftArrow || Frog.Key == ConsoleKey.A))
                        {
                            if (frogY == 2)
                            { sidewalks1[frogY] = '-'; }
                            else if (frogY == 3)
                            { road1[frogX] = '.'; }
                            else if (frogY == 4)
                            { road2[frogX] = '.'; }
                            else if (frogY == 5)
                            { road3[frogX] = '.'; }
                            else if (frogY == 6)
                            { road4[frogX] = '.'; }
                            else if (frogY == 7)
                            { sidewalks2[frogX] = '-'; }

                            frogX--;
                            frogDirection = "Left ";
                        }


                        else if ((frogX != 63) && (Frog.Key == ConsoleKey.RightArrow || Frog.Key == ConsoleKey.D))
                        {
                            if (frogY == 2)
                            { sidewalks1[frogY] = '-'; }
                            else if (frogY == 3)
                            { road1[frogX] = '.'; }
                            else if (frogY == 4)
                            { road2[frogX] = '.'; }
                            else if (frogY == 5)
                            { road3[frogX] = '.'; }
                            else if (frogY == 6)
                            { road4[frogX] = '.'; }
                            else if (frogY == 7)
                            { sidewalks2[frogX] = '-'; }

                            frogX++;
                            frogDirection = "Right";
                        }
                        else if (frogY != 7 && (Frog.Key == ConsoleKey.DownArrow || Frog.Key == ConsoleKey.S))
                        {
                            if (frogY == 2)
                            { sidewalks1[frogY] = '-'; }
                            else if (frogY == 3)
                            { road1[frogX] = '.'; }
                            else if (frogY == 4)
                            { road2[frogX] = '.'; }
                            else if (frogY == 5)
                            { road3[frogX] = '.'; }
                            else if (frogY == 6)
                            { road4[frogX] = '.'; }
                            else if (frogY == 7)
                            { sidewalks2[frogX] = '-'; }

                            frogY++;
                            frogDirection = "Down ";
                        }

                        if (character == 'F')
                        {
                            if (Frog.Key == ConsoleKey.Spacebar)
                            { stoptime = true; Life = Life - 1; }
                        }
                        else if (character == 'R')
                        {
                            if (Frog.Key == ConsoleKey.Spacebar)
                            { frogstop = true; Life = Life + 1; }
                        }
                        else if (character == 'K')
                        {
                            if (Frog.Key == ConsoleKey.Spacebar)
                            { Console.SetCursorPosition(frogX, frogY); Console.Write("X"); frogY = 2; Life = Life - 1; }
                        }
                    }
                }

                //Special powers
                ST2 = DateTime.Now; //frog
                TimeSpan ts4 = ST2 - ST1;
                if ((ts4.TotalMilliseconds / 5000) >= 1)
                {
                    stoptime = false;
                    ST1 = ST2;
                }

                SF2 = DateTime.Now; //rabbit
                TimeSpan ts6 = SF2 - SF1;
                if ((ts6.TotalMilliseconds / 40000) >= 1)
                {
                    frogstop = false;
                    SF1 = SF2;
                }

                //Car Moves
                if (stoptime == false)
                {
                    car1T2 = DateTime.Now;
                    TimeSpan ts2 = car1T2 - car1T1;
                    if ((ts2.TotalMilliseconds / 800) >= 1)
                    {

                        Thread.Sleep(0);
                        for (int moves = 0; moves < allCars.Length; moves++) //type-1 moves
                        {
                            Thread.Sleep(0);
                            if (allCarSpeeds[moves] == 1 && (allCarY[moves] == 3 || allCarY[moves] == 4))
                            {
                                if (allCarX[moves] == 1) //Road-end control
                                {
                                    allCarX[moves] = 54;
                                }
                                if (allCarY[moves] == 3) //Erase the back
                                    road1[allCarX[moves] + allCarLengths[moves] - 1] = '.';
                                else if (allCarY[moves] == 4)
                                    road2[allCarX[moves] + allCarLengths[moves] - 1] = '.';

                                allCarX[moves]--;
                            }
                            if (allCarSpeeds[moves] == 1 && (allCarY[moves] == 5 || allCarY[moves] == 6))
                            {
                                if (allCarX[moves] == 54)//Road-end control
                                {
                         
                                    allCarX[moves] = 1;

                                }
                                if (allCarY[moves] == 5)//Erase the back
                                    road3[allCarX[moves]] = '.';
                                else if (allCarY[moves] == 6)
                                    road4[allCarX[moves]] = '.';

                                allCarX[moves]++;
                            }

                        }
                        car1T1 = car1T2;
                    }


                    car2T2 = DateTime.Now;
                    TimeSpan ts3 = car2T2 - car2T1;
                    if ((ts3.TotalMilliseconds / 400) >= 1)
                    {
                        for (int moves = 0; moves < allCars.Length; moves++) //type-2 moves
                        {
                            Thread.Sleep(0);
                            if (allCarSpeeds[moves] == 2 && (allCarY[moves] == 3 || allCarY[moves] == 4))
                            {
                                if (allCarX[moves] == 1)
                                {
                                  
                                    allCarX[moves] = 54;
                                }
                                if (allCarY[moves] == 3)//Erase the back
                                    road1[allCarX[moves] + allCarLengths[moves] - 1] = '.';
                                else if (allCarY[moves] == 4)
                                    road2[allCarX[moves] + allCarLengths[moves] - 1] = '.';

                                allCarX[moves]--;
                            }
                            if (allCarSpeeds[moves] == 2 && (allCarY[moves] == 5 || allCarY[moves] == 6))
                            {
                                if (allCarX[moves] == 54)
                                {

                                    allCarX[moves] = 1;
                                }
                                if (allCarY[moves] == 5)//Erase the back
                                    road3[allCarX[moves]] = '.';
                                else if (allCarY[moves] == 6)
                                    road4[allCarX[moves]] = '.';

                                allCarX[moves]++;
                            }

                        }
                        car2T1 = car2T2;
                    }

                    //Control the "Sollama" Situation
                    for (int crush = 0; crush < allCars.Length; crush++)
                    {
                        if (allCarSpeeds[crush] == 2)
                        {
                            for (int crush2 = 0; crush2 < allCars.Length; crush2++)
                            {

                                if (((crush != crush2) && (allCarY[crush] == allCarY[crush2])))
                                {
                                    if ((allCarY[crush] == 3 || allCarY[crush] == 4) && ((allCarX[crush]) == (allCarX[crush2] + allCarLengths[crush2]))) //CONTROL FOR ROAD 1 AND 2
                                    {
                                        if ((allCarY[crush] == 3))
                                        {
                                            for (int controllerR2 = 0; controllerR2 < (allCarLengths[crush] + 3); controllerR2++) //İS OTHER ROAD EMPTY?
                                            {
                                                if ((road2[(allCarX[crush] - 2 + controllerR2)] == '1') || (road2[(allCarX[crush] - 1 + controllerR2)] == '2'))
                                                { roadcontrol1 = true; }

                                            }
                                            if (roadcontrol1 == true)//TURN THE SPEED=1
                                            { allCarSpeeds[crush] = 1; allCarX[crush]++; roadcontrol1 = false; }
                                            else
                                            {
                                                for (int r1 = 0; r1 < allCarLengths[crush]; r1++)
                                                {
                                                    road1[(allCarX[crush] + r1)] = '.';
                                                }
                                                allCarY[crush] = 4;
                                            }

                                        }
                                        if ((allCarY[crush] == 4))
                                        {
                                            for (int controllerR2 = 0; controllerR2 < (allCarLengths[crush] + 3); controllerR2++) //İS OTHER ROAD EMPTY?
                                            {
                                                if ((road1[(allCarX[crush] - 2 + controllerR2)] == '1') || (road1[(allCarX[crush] - 1 + controllerR2)] == '2'))
                                                { roadcontrol2 = true; }

                                            }
                                            if (roadcontrol2 == true)//TURN THE SPEED=1
                                            { allCarSpeeds[crush] = 1; allCarX[crush]++; roadcontrol2 = false; }
                                            else
                                            {
                                                for (int r1 = 0; r1 < allCarLengths[crush]; r1++)
                                                {
                                                    road2[(allCarX[crush] + r1)] = '.';
                                                }
                                                allCarY[crush] = 3;
                                            }

                                        }

                                    }
                                    else if ((allCarY[crush] == 5 || allCarY[crush] == 6) && ((allCarX[crush2]) == (allCarX[crush] + allCarLengths[crush]))) //CONTROL FOR ROAD 3 AND 4
                                    {
                                        if ((allCarY[crush] == 5))
                                        {
                                            for (int controllerR2 = 0; controllerR2 < (allCarLengths[crush] + 3); controllerR2++) //İS OTHER ROAD EMPTY?
                                            {
                                                if ((road4[(allCarX[crush] - 2 + controllerR2)] == '1') || (road4[(allCarX[crush] - 1 + controllerR2)] == '2'))
                                                { roadcontrol3 = true; }

                                            }
                                            if (roadcontrol3 == true)//TURN THE SPEED=1
                                            { allCarSpeeds[crush] = 1; allCarX[crush]--; roadcontrol3 = false; }
                                            else
                                            {
                                                for (int r1 = 0; r1 < allCarLengths[crush]; r1++)
                                                {
                                                    road3[(allCarX[crush] + r1)] = '.';
                                                }
                                                allCarY[crush] = 6;
                                            }

                                        }
                                        if ((allCarY[crush] == 6))
                                        {
                                            for (int controllerR2 = 0; controllerR2 < (allCarLengths[crush] + 3); controllerR2++) //İS OTHER ROAD EMPTY?
                                            {
                                                if ((road3[(allCarX[crush] - 2 + controllerR2)] == '1') || (road3[(allCarX[crush] - 1 + controllerR2)] == '2'))
                                                { roadcontrol4 = true; }

                                            }
                                            if (roadcontrol4 == true) //TURN THE SPEED=1
                                            { allCarSpeeds[crush] = 1; allCarX[crush]--; roadcontrol4 = false; }
                                            else
                                            {
                                                for (int r1 = 0; r1 < allCarLengths[crush]; r1++)
                                                {
                                                    road4[(allCarX[crush] + r1)] = '.';
                                                }
                                                allCarY[crush] = 5;
                                            }

                                        }
                                    }

                                }

                            }

                        }
                    }
                }


                //ERASE
                for (int c = 0; c < allCars.Length; c++)
                {
                    for (int innerC = 0; innerC < allCarLengths[c]+2; innerC++)
                    {
                        if (allCarY[c] == 3)
                        { road1[(allCarX[c] + innerC) - 1] = '.'; }
                        if (allCarY[c] == 4)
                        { road2[(allCarX[c] + innerC) - 1] = '.'; }
                        if (allCarY[c] == 5)
                        { road3[(allCarX[c] + innerC) - 1] = '.'; }
                        if (allCarY[c] == 6)
                        { road4[(allCarX[c] + innerC) - 1] = '.'; }
                    }
                }

                //CARS
                for (int c = 0; c < allCars.Length; c++)
                {
                    for (int innerC = 0; innerC < allCarLengths[c]; innerC++)
                    {
                        if (allCarY[c] == 3)
                        { road1[(allCarX[c] + innerC)] = allCarsChar[c]; }
                        if (allCarY[c] == 4)
                        { road2[(allCarX[c] + innerC)] = allCarsChar[c]; }
                        if (allCarY[c] == 5)
                        { road3[(allCarX[c] + innerC)] = allCarsChar[c]; }
                        if (allCarY[c] == 6)
                        { road4[(allCarX[c] + innerC)] = allCarsChar[c]; }
                    }
                }



                //FROG HİT CONTROL.1
                if (((road1[frogX] == '1' || road1[frogX] == '2') && (frogY == 3)) || ((road2[frogX] == '1' || road2[frogX] == '2') && (frogY == 4)) || ((road3[frogX] == '1' || road3[frogX] == '2') && (frogY == 5)) || ((road4[frogX] == '1' || road4[frogX] == '2') && (frogY == 6)))
                { Life = Life - 1; frogX = 29; frogY = 7; }

                //FROG HİT CONTROL.2
                for (int hit = 0; hit < allCars.Length; hit++)
                {
                    if ((allCarY[hit] == 3 || allCarY[hit] == 4) && (allCarX[hit] == frogX && allCarY[hit] == frogY))
                    {
                        Life = Life - 1; Thread.Sleep(0);
                        frogX = 29; frogY = 7;
                    }
                    if ((allCarY[hit] == 5 || allCarY[hit] == 6) && ((allCarX[hit] + (allCarLengths[hit] - 1)) == frogX && allCarY[hit] == frogY))
                    {
                        Life = Life - 1; Thread.Sleep(0);
                        frogX = 29; frogY = 7;
                    }
                }

                //FROG write
                if (frogY == 7)
                { sidewalks2[frogX] = character; }
                else if (frogY == 6)
                { road4[frogX] = character; }
                else if (frogY == 5)
                { road3[frogX] = character; }
                else if (frogY == 4)
                { road2[frogX] = character; }
                else if (frogY == 3)
                { road1[frogX] = character; }
                else if (frogY == 2)
                { sidewalks1[frogX] = character; }

                //pre touch for roads
                road1[0] = ' '; road1[3] = ' '; road1[4] = '.'; road1[54] = ' '; road1[58] = ' '; road1[1] = 'R'; road1[2] = '1'; road1[54] = '.'; road1[55] = '<'; road1[56] = '<'; road1[57] = '<';
                road2[0] = ' '; road2[3] = ' '; road2[4] = '.'; road2[54] = ' '; road2[58] = ' '; road2[1] = 'R'; road2[2] = '2'; road2[54] = '.'; road2[55] = '<'; road2[56] = '<'; road2[57] = '<';
                road3[0] = ' '; road3[3] = ' '; road3[4] = '.'; road3[54] = ' '; road3[58] = ' '; road3[1] = 'R'; road3[2] = '3'; road3[54] = '.'; road3[55] = '>'; road3[56] = '>'; road3[57] = '>';
                road4[0] = ' '; road4[3] = ' '; road4[4] = '.'; road4[54] = ' '; road4[58] = ' '; road4[1] = 'R'; road4[2] = '4'; road4[54] = '.'; road4[55] = '>'; road4[56] = '>'; road4[57] = '>';
                for (int d = 0; d < sidewalks1.Length; d++) //writing roads
                {
                    if (sidewalks1[d] == 'F')
                    { Console.ForegroundColor = ConsoleColor.Green; }
                    if ((sidewalks1[d] == 'R') && d > 3)
                    { Console.ForegroundColor = ConsoleColor.Yellow; }
                    if (sidewalks1[d] == 'K')
                    { Console.ForegroundColor = ConsoleColor.Magenta; }
                    if (sidewalks1[d] == '1' || sidewalks1[d] == '2')
                    { Console.ForegroundColor = ConsoleColor.Red; }
                    Thread.Sleep(0); Console.SetCursorPosition(1 + d, 2);
                    Console.Write(sidewalks1[d]);
                    Console.ResetColor();
                    if ((road1[d] == '1' || road1[d] == '2') && d > 3)
                    { Console.ForegroundColor = ConsoleColor.Red; }
                    if (road1[d] == 'F')
                    { Console.ForegroundColor = ConsoleColor.Green; }
                    if ((road1[d] == 'R') && d > 3)
                    { Console.ForegroundColor = ConsoleColor.Yellow; }
                    if (road1[d] == 'K')
                    { Console.ForegroundColor = ConsoleColor.Magenta; }
                    Thread.Sleep(0); Console.SetCursorPosition(1 + d, 3);
                    Console.Write(road1[d]);
                    Console.ResetColor();
                    if ((road2[d] == '1' || road2[d] == '2') && d > 3)
                    { Console.ForegroundColor = ConsoleColor.Red; }
                    if (road2[d] == 'F')
                    { Console.ForegroundColor = ConsoleColor.Green; }
                    if ((road2[d] == 'R') && d > 3)
                    { Console.ForegroundColor = ConsoleColor.Yellow; }
                    if (road2[d] == 'K')
                    { Console.ForegroundColor = ConsoleColor.Magenta; }
                    Thread.Sleep(0); Console.SetCursorPosition(1 + d, 4);
                    Console.Write(road2[d]);
                    Console.ResetColor();
                    if (road3[d] == '1' || road3[d] == '2')
                    { Console.ForegroundColor = ConsoleColor.Red; }
                    if (road3[d] == 'F')
                    { Console.ForegroundColor = ConsoleColor.Green; }
                    if ((road3[d] == 'R') && d > 3)
                    { Console.ForegroundColor = ConsoleColor.Yellow; }
                    if (road3[d] == 'K')
                    { Console.ForegroundColor = ConsoleColor.Magenta; }
                    Thread.Sleep(0); Console.SetCursorPosition(1 + d, 5);
                    Console.Write(road3[d]);
                    Console.ResetColor();
                    if (road4[d] == '1' || road4[d] == '2')
                    { Console.ForegroundColor = ConsoleColor.Red; }
                    if (road4[d] == 'F')
                    { Console.ForegroundColor = ConsoleColor.Green; }
                    if ((road4[d] == 'R') && d > 3)
                    { Console.ForegroundColor = ConsoleColor.Yellow; }
                    if (road4[d] == 'K')
                    { Console.ForegroundColor = ConsoleColor.Magenta; }
                    Thread.Sleep(0); Console.SetCursorPosition(1 + d, 6);
                    Console.Write(road4[d]);
                    Console.ResetColor();
                    if (sidewalks2[d] == '1' || sidewalks2[d] == '2')
                    { Console.ForegroundColor = ConsoleColor.Red; }
                    if (sidewalks2[d] == 'F')
                    { Console.ForegroundColor = ConsoleColor.Green; }
                    if ((sidewalks2[d] == 'R') && d > 3)
                    { Console.ForegroundColor = ConsoleColor.Yellow; }
                    if (sidewalks2[d] == 'K')
                    { Console.ForegroundColor = ConsoleColor.Magenta; }
                    Thread.Sleep(0); Console.SetCursorPosition(1 + d, 7);
                    Console.Write(sidewalks2[d]);
                    Console.ResetColor();
                }

                //Console
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Thread.Sleep(0); Console.SetCursorPosition(2, 0);
                Console.WriteLine("Time = " + Time + " ");
                Thread.Sleep(0); Console.SetCursorPosition(12, 0);
                Console.WriteLine("Level = " + Level);
                Thread.Sleep(0); Console.SetCursorPosition(22, 0);
                Console.WriteLine("Score = " + Score + " ");
                Thread.Sleep(0); Console.SetCursorPosition(34, 0);
                Console.WriteLine("Life = " + Life + " ");
                Thread.Sleep(0); Console.SetCursorPosition(44, 0);
                Console.WriteLine("Frog Direction " + frogDirection);
                Console.ResetColor();

                if (levelbool == true && Level<7)     //Creating levels
                {
                    for (int trc = 0; trc < Level; trc++)
                    {
                        allCarSpeeds[(12 - (trc+1))] = 2; allCarSpeeds[(trc)] = 2; //create type-2 cars
                        allCarSpeeds[(24 - (trc+1))] = 2; allCarSpeeds[(11 + (trc+1))] = 2; //create type-2 cars
                    }

                    //Define the car views
                    for (int a = 0; a < allCars.Length; a++)
                    {
                        if (allCarLengths[a] == 2 && allCarSpeeds[a] == 1)
                        { allCars[a] = "11"; allCarsChar[a] = '1'; }
                        else if (allCarLengths[a] == 3 && allCarSpeeds[a] == 1)
                        { allCars[a] = "111"; allCarsChar[a] = '1'; }
                        else if (allCarLengths[a] == 4 && allCarSpeeds[a] == 1)
                        { allCars[a] = "1111"; allCarsChar[a] = '1'; }
                        else if (allCarLengths[a] == 2 && allCarSpeeds[a] == 2)
                        { allCars[a] = "22"; allCarsChar[a] = '2'; }
                        else if (allCarLengths[a] == 3 && allCarSpeeds[a] == 2)
                        { allCars[a] = "222"; allCarsChar[a] = '2'; }
                        else if (allCarLengths[a] == 4 && allCarSpeeds[a] == 2)
                        { allCars[a] = "2222"; allCarsChar[a] = '2'; }
                    }
                    for (int c = 0; c < allCars.Length; c++)
                    {
                        for (int innerC = 0; innerC < allCarLengths[c]; innerC++)
                        {
                            if (allCarY[c] == 3)
                            { road1[(allCarX[c] + innerC)] = allCarsChar[c]; }
                            if (allCarY[c] == 4)
                            { road2[(allCarX[c] + innerC)] = allCarsChar[c]; }
                            if (allCarY[c] == 5)
                            { road3[(allCarX[c] + innerC)] = allCarsChar[c]; }
                            if (allCarY[c] == 6)
                            { road4[(allCarX[c] + innerC)] = allCarsChar[c]; }
                        }
                    }
                    for (int create = 0; create < allCars.Length; create++) //shows the created cars
                    {
                        Thread.Sleep(200); Console.SetCursorPosition(3, 8);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("vehicle" + allCars[create] + "created ");
                        Thread.Sleep(200); Console.SetCursorPosition(3, 8);
                        Console.WriteLine(space);
                        Console.ResetColor();
                    }

                    for (int l = 3; l > -1; l--)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Thread.Sleep(1000); Console.SetCursorPosition(3, 8);
                        Console.WriteLine("level " + Level + " will start in " + l + " seconds");
                        Console.ResetColor();
                    }
                    Thread.Sleep(0); Console.SetCursorPosition(3, 8);
                    Console.WriteLine(space);
                    levelbool = false;
                }

                //TİME
                timer2 = DateTime.Now;
                TimeSpan ts1 = timer2 - timer1;
                if ((ts1.TotalMilliseconds / 1000) >= 1)
                {
                    Time++;
                    Score = 60 - Time;
                    timer1 = timer2;

                }

                if (Life <= 0) //Dead?
                {
                    break;
                }

                else if (Level > 6) //Win?
                {
                    break;
                }

                //Win the level
                if (frogY == 2)
                {
                    sidewalks1[frogX] = '-';
                    Console.ForegroundColor = ConsoleColor.Green;
                    Thread.Sleep(50); Console.SetCursorPosition(3, 8);
                    Console.WriteLine("You completed level " + Level + "!!");
                    Console.ResetColor();
                    TotalScore = TotalScore + Score;
                    frogX = 29; frogY = 7;
                    Thread.Sleep(450); Console.SetCursorPosition(3, 8);
                    Console.WriteLine(space);
                    Level = Level + 1;
                    Time = 0;
                    Life = Life + 1;
                    Score = 60;
                    levelbool = true;
                }

            }

            for (int f = 0; f < 20; f++)
            {
                Thread.Sleep(250);
                Console.SetCursorPosition(0, f);
                Console.WriteLine(space);
            }
            Thread.Sleep(0); Console.SetCursorPosition(0, 5);
            if (Life <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(@"
 __    __                   ___                             
/\ \  /\ \                 /\_ \                            
\ `\`\\/'/ ___   __  __    \//\ \     ___     ____     __   
 `\ `\ /' / __`\/\ \/\ \     \ \ \   / __`\  /',__\  /'__`\ 
   `\ \ \/\ \L\ \ \ \_\ \     \_\ \_/\ \L\ \/\__, `\/\  __/ 
     \ \_\ \____/\ \____/     /\____\ \____/\/\____/\ \____\
      \/_/\/___/  \/___/      \/____/\/___/  \/___/  \/____/
");
                Console.WriteLine("Your score= " +TotalScore);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(@"
 __    __                                             
/\ \  /\ \                              __            
\ `\`\\/'/ ___   __  __      __  __  __/\_\    ___    
 `\ `\ /' / __`\/\ \/\ \    /\ \/\ \/\ \/\ \ /' _ `\  
   `\ \ \/\ \L\ \ \ \_\ \   \ \ \_/ \_/ \ \ \/\ \/\ \ 
     \ \_\ \____/\ \____/    \ \___x___/'\ \_\ \_\ \_\
      \/_/\/___/  \/___/      \/__//__/   \/_/\/_/\/_/");
                Console.WriteLine("Your score= " + TotalScore);

            }

        }
    }
}
