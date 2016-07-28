﻿using System;
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

        public void CreatePlayers()
        {
            Model.PlayerA = new ConsolePlayer(ePlayer.playerA);
            Model.PlayerB = new ConsolePlayer(ePlayer.playerB);
            Model.initCurrentPlayer();
        }

        public void StartGame()
        {
            Move move;
            int numOfMovesToPlay = 2;
            bool IsDoubleMove = false;
            CreatePlayers();
            while (!Model.IsGameOver)
            {
                Model.SwitchPlayer();
                Model.Dices.RollDices();
                
                IsDoubleMove = Model.Dices.IsDouble;
                while (numOfMovesToPlay > 0)
                { 
                    UpdateBoardUI();
                    PrintUpdatedGameBoard();
                    PrintTurnMessage();
                    PrintDicesValue();
                    if (Model.IsPossibleToMove() && !Model.IsGameOver)
                    {
                        move = Model.CurrentPlayer.GetAMove(Model.Dices);
                        while (!Model.CheckIsValidMove(move))
                        {
                            Console.WriteLine("The move can not be performed"); 
                            move = Model.CurrentPlayer.GetAMove(Model.Dices);
                        }

                        Model.ExecuteMove(move);
                        numOfMovesToPlay--;
                        Model.GameOver();
                    }
                    else
                    {
                        Console.WriteLine("There is no possible moves, {0} Press any key to continue.", Environment.NewLine);
                        Console.ReadLine();
                        numOfMovesToPlay = 0;
                    }

                    
                    if (numOfMovesToPlay == 0 && !Model.IsGameOver)
                    {
                        if (IsDoubleMove)
                        {
                            numOfMovesToPlay = 2;
                            IsDoubleMove = false;
                        }
                    }
                }

                
                numOfMovesToPlay = 2;
               // Model.GameOver();
            }

            UpdateBoardUI();
            PrintUpdatedGameBoard();
            Model.SwitchPlayer();
            PrintGameOverMsg();
            Console.ReadLine();
        }

        public void PrintGameOverMsg()
        {
            Console.WriteLine(" !!! THE GAME IS OVER, {0} WON !!!", Model.CurrentPlayer.Type);
        }

        public void PrintDicesValue()
        {
            if (Model.Dices.FirstDice.IsUsed)
            {
                Console.Write("Dices : ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("[{0}]", Model.Dices.FirstDice.Value);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(", [{0}]", Model.Dices.SecondDice.Value);
            }
            else if (Model.Dices.SecondDice.IsUsed)
            {
                Console.Write("Dices : [{0}] ,", Model.Dices.FirstDice.Value);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("[{0}]", Model.Dices.SecondDice.Value);
                Console.ForegroundColor = ConsoleColor.Gray;
                
            }
            else
            {
                Console.WriteLine("Dices : [{0}] , [{1}]", Model.Dices.FirstDice.Value, Model.Dices.SecondDice.Value);
            }
        }

        public void UpdateBoardUI()
        {
            for (int i = 0; i < Model.Board.Points.Length; i++)
            {
                UpdatePointInBoard(Model.Board.Points[i], i);
            }
        }

        public void UpdatePointInBoard(Stack<Pawn> stack, int index)
        {
            int x, y;
            index++;
            if (stack.Count == 0)
            {
                if (index <= 12)
                {
                    x = 11;
                    y = 12 - index;
                    for (int i = 0; i < 6; i++)
                    {
                        BoardUI[x--, y] = null;
                    }
                }
                else
                {
                    x = 0;
                    y = index - 13;
                    for (int i = 0; i < 6; i++)
                    {
                        BoardUI[x++, y] = null;
                    }
                }
            }
            else if (stack.Count > 0)
            {
                if (index <= 12)
                {
                    x = 11;
                    y = 12 - index;
                    for (int i = 0;  i < 6; i++)
                    {
                        if (i < stack.Count)
                        {
                            BoardUI[x--, y] = stack.Peek();
                        }
                        else
                        {
                            BoardUI[x--, y] = null;
                        }
                    }
                }
                else
                {
                    x = 0;
                    y = index - 13;
                    for (int i = 0; i < 6; i++)
                    {
                        if (i < stack.Count)
                        {
                            BoardUI[x++, y] = stack.Peek();
                        }
                        else
                        {
                            BoardUI[x++, y] = null;
                        }
                    }
                }
            }
        }

        public void PrintUpdatedGameBoard()
        {
            char divider = '-';
            StringBuilder dividerBuilder = new StringBuilder("-");
            string barDivider = string.Format("|                       |BAR|                       |{0}", Environment.NewLine);

            dividerBuilder.Append(divider, 13 * 4);
            Console.Clear();
            for (int i = 13; i < 25; i++)
            {
                Console.Write("{0,4}", i);
                if (i == 18)
                {
                    Console.Write("    ");
                }
            }
            
            Console.Write("{0}{1}", Environment.NewLine, dividerBuilder);

            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine();

                if (i == 6)
                {
                    Console.Write(barDivider);
                    //Console.WriteLine();

                }

                for (int j = 0; j < 12; j++)
                {
                    if (j != 6)
                    {
                        Console.Write("|");
                    }
                    else
                    {
                        Console.Write("| ");
                        if (i == 5 &&  Model.PlayerB.EatenPawns.Count > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("{0}", Model.PlayerB.EatenPawns.Peek());
                        }
                        else if (i == 6 && Model.PlayerA.EatenPawns.Count > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("{0}", Model.PlayerA.EatenPawns.Peek());
                        }
                        else
                        {
                            Console.Write(" ");
                        }

                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(" |");
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
                if (i == 7)
                {
                    Console.Write("   ");
                }
            }

            Console.WriteLine();
        }

        public void PrintTurnMessage()
        {
            Console.WriteLine("{0} ({1}), is playing now", Model.CurrentPlayer.Type,  Model.CurrentPlayer.Type == ePlayer.playerA ? "red" : "blue");
        }
    }
}
