internal class TicTacToe
{
    public static string[,] fieldArray = new string[3, 3]    {{ " ", " ", " " },
                                                              { " ", " ", " " },
                                                              { " ", " ", " " } };

    static readonly string[,] fieldArray2 = new string[3, 3] { {fieldArray[0,0], fieldArray[1,0], fieldArray[2,0]},
                                                               {fieldArray[0,1], fieldArray[1,1], fieldArray[2,1]},
                                                               {fieldArray[0,2], fieldArray[1,2], fieldArray[2,2]} };
    internal protected static int counter = 1;

    static void Main(string[] args)
    {
        StartGame();
        DrawField();
        Console.WriteLine();
        EnterYourPosition();
    }

    static void StartGame()
    {
        Console.WriteLine("Game has started, enter your positions are following: _1_|_2_|_3_");
        Console.WriteLine("                                                      _4_|_5_|_6_");
        Console.WriteLine("                                                      _7_|_8_|_9_");

    }

    static void DrawField()
    {
        Console.WriteLine("\t");
        Console.WriteLine("\t     |     |     ");
        Console.WriteLine("\t  {0}  |  {1}  |  {2}  ", fieldArray[0, 0], fieldArray[0, 1], fieldArray[0, 2]);
        Console.WriteLine("\t_____|_____|_____");
        Console.WriteLine("\t     |     |     ");
        Console.WriteLine("\t  {0}  |  {1}  |  {2}  ", fieldArray[1, 0], fieldArray[1, 1], fieldArray[1, 2]);
        Console.WriteLine("\t_____|_____|_____");
        Console.WriteLine("\t     |     |     ");
        Console.WriteLine("\t  {0}  |  {1}  |  {2}  ", fieldArray[2, 0], fieldArray[2, 1], fieldArray[2, 2]);
        Console.WriteLine("\t     |     |     ");
    }
    static void EnterYourPosition()
    {
        int getPosition;

        do
        {
            getPosition = Int32.Parse(Console.ReadLine());
            if (getPosition >= 1 && getPosition <= 9)
            {
                SetField(getPosition);
                DrawField();

                if (counter >= 5)
                {
                    CheckRowsAndColumns();
                }
                counter++;
            }
        } while (counter <= 9);
    }
    static void SetField(int getPosition)
    {
        switch (getPosition)
        {
            case 1:
                fieldArray[0, 0] = GetSymbol();
                fieldArray2[0, 0] = GetSymbol();
                break;
            case 2:
                fieldArray[0, 1] = GetSymbol();
                fieldArray2[1, 0] = GetSymbol();
                break;
            case 3:
                fieldArray[0, 2] = GetSymbol();
                fieldArray2[2, 0] = GetSymbol();
                break;
            case 4:
                fieldArray[1, 0] = GetSymbol();
                fieldArray2[0, 1] = GetSymbol();
                break;
            case 5:
                fieldArray[1, 1] = GetSymbol();
                fieldArray2[1, 1] = GetSymbol();
                break;
            case 6:
                fieldArray[1, 2] = GetSymbol();
                fieldArray2[2, 1] = GetSymbol();
                break;
            case 7:
                fieldArray[2, 0] = GetSymbol();
                fieldArray2[0, 2] = GetSymbol();
                break;
            case 8:
                fieldArray[2, 1] = GetSymbol();
                fieldArray2[1, 2] = GetSymbol();
                break;
            case 9:
                fieldArray[2, 2] = GetSymbol();
                fieldArray2[2, 2] = GetSymbol();
                break;
            default:
                Console.WriteLine("You have entered the wrong position number...");
                break;
        }
    }

    static void CheckRowsAndColumns()
    {
        if ((fieldArray[0, 0] == "X" && fieldArray[0, 1] == "X" && fieldArray[0, 2] == "X") ||
            (fieldArray[1, 0] == "X" && fieldArray[1, 1] == "X" && fieldArray[1, 2] == "X") ||
            (fieldArray[2, 0] == "X" && fieldArray[2, 1] == "X" && fieldArray[2, 2] == "X"))
        {
            GetFirstPlayerWin();
        }
        else if ((fieldArray[0, 0] == "O" && fieldArray[0, 1] == "O" && fieldArray[0, 2] == "O") ||
                 (fieldArray[1, 0] == "O" && fieldArray[1, 1] == "O" && fieldArray[1, 2] == "O") ||
                 (fieldArray[2, 0] == "O" && fieldArray[2, 1] == "O" && fieldArray[2, 2] == "O"))
        {
            GetSecondPlayerWin();
        }
        else if ((fieldArray2[0, 0] == "X" && fieldArray2[0, 1] == "X" && fieldArray2[0, 2] == "X") ||
                 (fieldArray2[1, 0] == "X" && fieldArray2[1, 1] == "X" && fieldArray2[1, 2] == "X") ||
                 (fieldArray2[2, 0] == "X" && fieldArray2[2, 1] == "X" && fieldArray2[2, 2] == "X"))
        {
            GetFirstPlayerWin();
        }
        else if ((fieldArray2[0, 0] == "O" && fieldArray2[0, 1] == "O" && fieldArray2[0, 2] == "O") ||
                 (fieldArray2[1, 0] == "O" && fieldArray2[1, 1] == "O" && fieldArray2[1, 2] == "O") ||
                 (fieldArray2[2, 0] == "O" && fieldArray2[2, 1] == "O" && fieldArray2[2, 2] == "O"))
        {
            GetSecondPlayerWin();
        }
        else
        {
            CheckfirstDiagonal();
        }
    }

    static void CheckfirstDiagonal()
    {

        if (fieldArray[0, 0] == "X" && fieldArray[1, 1] == "X" && fieldArray[2, 2] == "X")
        {
            GetFirstPlayerWin();
        }
        else if (fieldArray[0, 0] == "O" && fieldArray[1, 1] == "O" && fieldArray[2, 2] == "O")
        {
            GetSecondPlayerWin();
        }
        else
        {
            CheckSecondDiagonal();
        }
    }

    static void CheckSecondDiagonal()
    {
        if (fieldArray[0, 2] == "O" && fieldArray[1, 1] == "O" && fieldArray[2, 0] == "O")
        {
            GetSecondPlayerWin();
        }
        else if (fieldArray[0, 2] == "X" & fieldArray[1, 1] == "X" && fieldArray[2, 0] == "X")
        {
            GetFirstPlayerWin();
        }
        else
        {
            GetDrawMessage();
        }
    }

    static string GetSymbol()
    {
        if (counter % 2 == 1)
        {
            return "X";
        }
        else
        {
            return "O";
        }
    }

    static void GetFirstPlayerWin()
    {
        Console.WriteLine("pl 1 win");
        counter = 9;
    }
    static void GetSecondPlayerWin()
    {
        Console.WriteLine("pl 2 win");
        counter = 9;
    }
    static void GetDrawMessage()
    {
        if (counter == 9)
        {
            Console.WriteLine("Draw");
        }
    }
}


