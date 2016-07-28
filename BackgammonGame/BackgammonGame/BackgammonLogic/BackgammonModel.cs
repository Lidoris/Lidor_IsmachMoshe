using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLogic
{
    public class BackgammonModel
    {
        public GameBoard Board { get; private set; }
        public bool IsGameOver { get; private set; }
        public IPlayer CurrentPlayer { get; private set; }
        public IPlayer PlayerA { get; set; }
        public IPlayer PlayerB { get; set; }
        public Dices Dices { get; private set; }

        public BackgammonModel()
        {
            Board = new GameBoard();
            Dices = new Dices();
            IsGameOver = false;
        }

        public void initCurrentPlayer()
        {
            CurrentPlayer = PlayerB;
        }

        public void SwitchPlayer()
        {
            if (CurrentPlayer == PlayerA)
            {
                CurrentPlayer = PlayerB;
            }
            else
            {
                CurrentPlayer = PlayerA;
            }
        }

        public void GameOver()
        {
            IsGameOver = true;
            foreach (Stack<Pawn> stack in Board.Points)
            {
                if (stack.Count != 0)
                {
                    if (stack.Peek().Owner == CurrentPlayer.Type)
                    {
                        IsGameOver = false;
                        break;
                    }
                }
            }
        }

        public bool AllPawnsInHomeBoard()
        {
            int j;
            int length;
            bool result = true;

            if (CurrentPlayer.Type == ePlayer.playerA)
            {
                j = 0;
                length = 18;
            }
            else
            {
                j = 6;
                length = Board.Points.Length;
            }

            for (int i = j; i < length; i++)
            {
                if (Board.Points[i].Count > 0)
                {
                    if (Board.Points[i].Peek().Owner == CurrentPlayer.Type)
                    {
                        result = false;
                    }
                }
            }
            
            if (CurrentPlayer.EatenPawns.Count  > 0)
            {
                result = false;
            }

            return result;
        }

        public bool CheckIsValidBearingOff(Move move)
        {
            bool isValidBearingOff;

            if (CurrentPlayer.Type == ePlayer.playerA)
            {
                isValidBearingOff = move.Source - 1 + move.Dice.Value > 24 ;
            }
            else
            {
                isValidBearingOff = move.Source - 1 - move.Dice.Value < 1;
            }

            return isValidBearingOff;
        }

         
        public bool CheckIsValidMove(Move move )
        { 
            bool isValidMove = false;
            int dstPoint;

            if (CurrentPlayer.Type == ePlayer.playerA)
            { 
                dstPoint = move.Source - 1 + move.Dice.Value;
            }
            else
            {
                dstPoint = move.Source - 1 - move.Dice.Value;
            }

            if (dstPoint <= 23 && dstPoint >= 0)
            {
                if(CurrentPlayer.EatenPawns.Count > 0 )
                {
                    if (Board.Points[dstPoint].Count > 0)
                    {
                        if (Board.Points[dstPoint].Peek().Owner == CurrentPlayer.Type)
                        {
                            isValidMove = true;
                        }
                        else if (Board.Points[dstPoint].Count == 1) // the possibility to "eat " an opponent pawn 
                        {
                            isValidMove = true;
                        }
                    }
                    else if (Board.Points[dstPoint].Count == 0)
                    {
                        isValidMove = true;
                    }
                }
                else if(Board.Points[move.Source - 1].Count > 0)
                {
                    if (Board.Points[move.Source - 1].Peek().Owner == CurrentPlayer.Type)
                    {
                        if (Board.Points[dstPoint].Count > 0)
                        {
                            if (Board.Points[dstPoint].Peek().Owner == CurrentPlayer.Type)
                            {
                                isValidMove = true;
                            }
                            else if (Board.Points[dstPoint].Count == 1) 
                            {
                                isValidMove = true;
                            }
                        }
                        else if (Board.Points[dstPoint].Count == 0)
                        {
                            isValidMove = true;
                        }
                    }
                }
            }
            else
            {
                if (CurrentPlayer.EatenPawns.Count == 0 && AllPawnsInHomeBoard())
                {
                    int dst = CurrentPlayer.Type == PlayerA.Type ? 25 - move.Dice.Value : move.Dice.Value;
                    if (Board.Points[dst-1].Count > 0 && Board.Points[dst - 1].Peek().Owner == CurrentPlayer.Type)
                    {
                        if (move.Source == dst)
                        {
                            isValidMove = true;
                        }
                    }
                    else
                    {
                        isValidMove = true;
                    }
                } 
            }

            return isValidMove;
        }

        public bool IsPossibleToMove()
        {
            if (AllPawnsInHomeBoard())
            {
                return IsPossibleToBearOff();
            }
            else
            {
                return IsPossibleStandardMove();
            }
        }

        public bool IsPossibleStandardMove()
        {
            Move move;
            bool isPossible = false;
            int i;

            if (CurrentPlayer.EatenPawns.Count > 0)
            {
                i = PlayerA.EatenPawns.Count > 0 ? 0 : 25;
                foreach (Dice dice in new[] { Dices.FirstDice, Dices.SecondDice })
                {
                    if (!dice.IsUsed)
                    {
                        move = new Move(i, dice);
                        if (CheckIsValidMove(move))
                        {
                            isPossible = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                for (i = 1; i <= Board.Points.Length; i++)
                {
                    foreach (Dice dice in new[] { Dices.FirstDice, Dices.SecondDice })
                    {
                        if (!dice.IsUsed)
                        {
                            move = new Move(i, dice);
                            if (CheckIsValidMove(move))
                            {
                                isPossible = true;
                                break;
                            }
                        }
                    }
                }
            }

            return isPossible;
        }

        public bool IsPossibleToBearOff()
        {
            Move move;
            bool isPossible = false;
            int j;
            int length;
            

            if (CurrentPlayer.Type == ePlayer.playerA)
            {
                j = 19;
                length = 24;
            }
            else
            {
                j = 1;
                length = 6;
            }

            for (int i = j; i <= length; i++)
            {
                foreach (Dice dice in new[] { Dices.FirstDice, Dices.SecondDice })
                {
                    if (!dice.IsUsed)
                    {
                        int dst = CurrentPlayer.Type == PlayerA.Type ? 25 - dice.Value : dice.Value;

                        if (Board.Points[dst - 1].Count > 0)
                        {
                            isPossible = true;
                        }
                        else
                        {
                            if (Board.Points[i - 1].Count > 0)
                            {
                                move = new Move(i, dice);
                                if (i - dst > 0)
                                {
                                    if (CheckIsValidMove(move))
                                    {
                                        isPossible = true;
                                    }
                                }
                                else
                                {
                                    if (CheckIsValidBearingOff(move))
                                    {
                                        isPossible = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return isPossible;
        }

       
        public void ExecuteMove(Move move)
        {
            int dstPoint;

            move.Dice.UseDice();
            if (CurrentPlayer.Type == ePlayer.playerA)
            {
                dstPoint = move.Source - 1 + move.Dice.Value;
            }
            else
            {
                dstPoint = move.Source - 1 - move.Dice.Value;
            }

            if (dstPoint < 0 || dstPoint >= 24)
            {
                Board.Points[move.Source - 1].Pop();
            }
            else
            {
                if (Board.Points[dstPoint].Count > 0) 
                {
                    if (Board.Points[dstPoint].Peek().Owner != CurrentPlayer.Type)
                    {
                        if (CurrentPlayer.Type == PlayerA.Type)
                        {
                            PlayerB.EatenPawns.Push(Board.Points[dstPoint].Pop());

                        }
                        else
                        {
                            PlayerA.EatenPawns.Push(Board.Points[dstPoint].Pop());
                        }
                    }
                }

                if (move.Source == 0 || move.Source == 25)
                {
                    Board.Points[dstPoint].Push(CurrentPlayer.EatenPawns.Pop());
                }
                else
                {
                    Board.Points[dstPoint].Push(Board.Points[move.Source - 1].Pop());
                }
            }
        }
    }
}
