using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackgammonLogic;

namespace BackgammonUI
{
    class GameManagmentUI
    {
        public BackgammonModel Model { get; private set; }
        public Pawn[,] BoardUI { get; private set; }

        public GameManagmentUI()
        {
            Model = new BackgammonModel();
            BoardUI = new Pawn[12, 12];
        }

        public void StartGame()
        {

            while (Model.IsGameOver)
            {
                InitBoardUI();
                PrintGameBoard();
                
                Model.MakeAMove();

            }
        }

        public Move GetAMove()
        {

        }



        public void InitBoardUI()
        {
            for (int i = 0; i < Model.Board.Points.Length; i++)
            {
                InitPointInBoard(Model.Board.Points[i], i);
            }
        }

        public void InitPointInBoard(Stack<Pawn> stack, int index)
        {
            int x, y;
            index++;
            if (stack.Count > 0)
            {
                if (index <= 12)
                {
                    x = 6;
                    y = 12 - index;
                }
                else
                {
                    x = 0;
                    y = index - 13;
                }

                for (int i = 0; i < stack.Count && i < 6; i++)
                {
                    BoardUI[x++, y] = stack.Peek();
                }
            }
        }

        public void PrintGameBoard()
        {
            char divider = '-';
            StringBuilder dividerBuilder = new StringBuilder("--");
            

            dividerBuilder.Append(divider, 12 * 4);
            Console.Clear();
            for (int i = 13; i < 25; i++)
            {
                Console.Write("{0,4}", i); 
            }
            
            Console.Write("{0}{1}", Environment.NewLine, dividerBuilder);

            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine();

                if (i == 6)
                {
                    Console.Write(dividerBuilder);
                    Console.WriteLine();

                }

                for (int j = 0; j < 12; j++)
                {
                    if (j != 6)
                    {
                        Console.Write("|");
                    }
                    else
                    {
                        Console.Write("||");
                    }

                    if (BoardUI[i, j] != null)
                    {
                        if (BoardUI[i, j].Owner.Equals(ePlayer.playerA))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else if (BoardUI[i, j].Owner.Equals(ePlayer.playerB))
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                    }

                    Console.Write(" {0,-2}", BoardUI[i, j]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                Console.Write("|");
            }
            
            Console.Write("{0}{1}{2}", Environment.NewLine, dividerBuilder, Environment.NewLine);
            for (int i = 12; i > 0; i--)
            {
                Console.Write("{0,4}", i); 
            }

            Console.WriteLine();
        }
    }
}
