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
        public ePlayer CurrentPlayer { get; private set; }
        public IPlayer PlayerA { get; private set; }
        public IPlayer PlayerB { get; private set; }


        public BackgammonModel()
        {
            Board = new GameBoard();
            CurrentPlayer = ePlayer.playerA;
            PlayerA = new HumanPlayer();
            PlayerB = new HumanPlayer();

        }

        public void GameOver()
        {
            IsGameOver = true;
            foreach (Stack<Pawn> stack in Board.Points)
            {
                if (stack.Count != 0)
                {
                    if (stack.Peek().Owner == CurrentPlayer)
                    {
                        IsGameOver = false;
                        break;
                    }
                }
            }
        }

        public void MakeAMove()
        {
            if (CurrentPlayer == ePlayer.playerA)
            {
                PlayerA.MakeAMove();
            }
            else
            {
                PlayerB.MakeAMove();
            }
        }


    }
}
