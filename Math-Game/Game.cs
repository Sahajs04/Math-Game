using System.Threading;
class Game
{
    int op;
    int range;

    string[] operations = { "+", "-", "*", "/" };
    int[] difRange = { GameRunner.EASY, GameRunner.MEDIUM, GameRunner.HARD };

    int[] numbers = new int[2];

    Random rnd = new Random();

    public Game(int op, int range)
    {
        this.op = op;
        this.range = range;
    }

    public void operation()
    {
        int firstRandom = rnd.Next(1, difRange[range - 1]);

        int secondRandom = rnd.Next(1, difRange[range - 1]);

        while (true)
        {
            if (firstRandom % secondRandom != 0)
            {
                //minus 1 because arrays are 0 indexed  
                firstRandom = rnd.Next(1, difRange[range - 1]);
                secondRandom = rnd.Next(1, difRange[range - 1]);
                continue;
            }
            break;
        }

        numbers[0] = firstRandom;
        numbers[1] = secondRandom;

        int answer = completeOp(op, firstRandom, secondRandom);

        while (true)
        {
            System.Console.Clear();
            System.Console.WriteLine("Solve the Following Math Problem");
            System.Console.WriteLine($"{firstRandom} {operations[op - 1]} {secondRandom}");
            string userInput = System.Console.ReadLine();
            int input;
            bool worked = int.TryParse(userInput, out input);

            if (!worked)
            {
                System.Console.WriteLine("Enter an INTEGER Number Only");
                Thread.Sleep(800);
                continue;
            }

            else if (input != answer)
            {
                System.Console.WriteLine("Try Again");
                Thread.Sleep(800);
                continue;
            }
            else
            {
                System.Console.WriteLine("Congragulations");
                Thread.Sleep(800);
            }

            GameRunner.ProblemSolved += 1;
            return;
        }
    }

    private int completeOp(int op, int firstRandom, int secondRandom)
    {
        switch (op)
        {
            case 1:
                return firstRandom + secondRandom;


            //subtraction case
            case 2:
                return firstRandom - secondRandom;

            //multiplication case
            case 3:
                return firstRandom * secondRandom;
            //division case
            case 4:
                return firstRandom / secondRandom;
            //random op Case           
            case 5:
                int newCase = rnd.Next(1, 4);
                this.op = newCase;
                return completeOp(newCase, firstRandom, secondRandom);
        }

        return -1;

    }

    //getter methods for GameRunner to use   
    public string getOperation()
    {
        return operations[op - 1];
    }

    public int[] getNumbers()
    {
        return numbers;
    }


}
