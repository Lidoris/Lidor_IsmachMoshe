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
        public IPlayer PlayerA { get; set; } // set is public!?!?!
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
            CurrentPlayer = PlayerA;
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
                j = 6;
                length = Board.Points.Length;
            }
            else
            {
                j = 0;
                length = 18;
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
                if (Board.Points[move.Source - 1].Count > 0)
                {
                    if (Board.Points[move.Source - 1].Peek().Owner == CurrentPlayer.Type)
                    {
                        if (Board.Points[dstPoint].Count > 0)
                        {
                            if (Board.Points[dstPoint].Peek().Owner == CurrentPlayer.Type)
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

            for (int i = 1; i <= Board.Points.Length; i++)
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
                j = 0;
                length = 5;
            }
            else
            {
                j = 19;
                length = 24;
            }

            for (int i = j; i <= length; i++)
            {
                foreach (Dice dice in new[] { Dices.FirstDice, Dices.SecondDice })
                {
                    if (!dice.IsUsed)
                    {
                        move = new Move(i, dice);
                        if (CheckIsValidBearingOff(move))
                        {
                            isPossible = true;
                            break;
                        }
                    }
                }
            }

            return isPossible;
        }

       
        public void ExecuteMove(Move move)
        {
            int dstPoint;

            if (CurrentPlayer.Type == ePlayer.playerA)
            {
                dstPoint = move.Source - 1 + move.Dice.Value;
            }
            else
            {
                dstPoint = move.Source - 1 - move.Dice.Value;
            }

            move.Dice.UseDice();
            Board.Points[dstPoint].Push(Board.Points[move.Source -1].Pop()); 
        }
    }
}
