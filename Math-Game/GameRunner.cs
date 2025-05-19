using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;


//Main method
class GameRunner
{

    public const int EASY = 10;

    public const int MEDIUM = 100;

    public const int HARD = 500;

    public static int ProblemSolved = 0;


    static int Main(string[] args)
    {
        //timer
        Stopwatch stopWatch = new Stopwatch();
        //creating a new list to store previous games
        List<Game> gameList = new List<Game>();

        //Game keeps running until user quits
        while (true)
        {
            //write out options for games to play / quiting the game
            System.Console.Clear();
            System.Console.WriteLine("Choose One of the Following Options:");
            System.Console.WriteLine("---------------------|");

            System.Console.WriteLine("1: Addition          |");
            System.Console.WriteLine("2: Subtraction       |");
            System.Console.WriteLine("3: Multiplication    |");
            System.Console.WriteLine("4: Division          |");
            System.Console.WriteLine("5: Random            |");
            System.Console.WriteLine("S: Get Total Score   |");
            System.Console.WriteLine("V: View Past Games   |");
            System.Console.WriteLine("Q: Quit              |");
            System.Console.WriteLine("---------------------|");

            //read user input for fist section
            int operation;
            string userInput = System.Console.ReadLine().ToLower();


            //if q we know user wants to quit.
            if (userInput == "q")
            {
                return 0;
            }
            if (userInput == "s")
            {
                System.Console.Clear();
                System.Console.WriteLine($"Score: {ProblemSolved}");
                Thread.Sleep(2000);
                continue;
            }

            if (userInput == "v")
            {
                System.Console.Clear();
                System.Console.WriteLine("Previous Games:");
                int count = gameList.Count;


                for (int i = 0; i < gameList.Count; i++)
                {
                    int[] numbers = gameList[i].getNumbers();
                    string op = gameList[i].getOperation();
                    System.Console.WriteLine($"Game {count}: {numbers[0]} {op} {numbers[1]}");
                    count--;
                }

                System.Console.WriteLine("Type anything to Exit");

                System.Console.ReadLine();

                continue;
            }

            //If user doesnt enter an Int then throw an exception.
            bool opSuccess = int.TryParse(userInput, out operation);
            if (!(opSuccess))
            {
                throw new Exception("Incorrect Input. Enter number for Selection");
            }

            //console code to get the difficulty
            System.Console.WriteLine("---------------------|");
            System.Console.WriteLine("Choose Difficulty    |");
            System.Console.WriteLine("1: Easy              |");
            System.Console.WriteLine("2: Medium            |");
            System.Console.WriteLine("3: Hard              |");
            System.Console.WriteLine("---------------------|");
            //read input from user
            string Difficulty = System.Console.ReadLine();
            int dif;


            //check if we can parse the int for dificulty
            bool difSuccess = int.TryParse(Difficulty, out dif);

            if (!(difSuccess))
            {
                throw new Exception("Incorrect Input");
            }

            if (!((operation >= 1 && operation <= 5) && (dif >= 1 && dif <= 3)))
            {
                throw new Exception("Integer Range not correct");
            }

            //create a new game and add it to the list of games
            Game newGame = new Game(operation, dif);
            gameList.Add(newGame);

            stopWatch.Start();
            newGame.operation();
            stopWatch.Stop();
            Console.Clear();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine($"You Took {ts.Seconds} Seconds to Complete the Problem");
            Thread.Sleep(1000);
        }



    }




}
