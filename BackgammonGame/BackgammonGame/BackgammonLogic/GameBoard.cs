using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLogic
{
    public class GameBoard
    {
        public Stack<Pawn>[] Points { get; private set; }

        public GameBoard()
        {
            Points = new Stack<Pawn>[24];

            for (int i = 0; i < Points.Length ; i++)
            {
                Points[i] = new Stack<Pawn>();
            }

            initializationBoard();
        }

        public void initializationBoard()
        {
            for (int i = 0; i < 2; i++)
            {
                Points[0].Push(new Pawn(ePlayer.playerA));
                Points[23].Push(new Pawn(ePlayer.playerB));
            }

            for (int i = 0; i < 5; i++)
            {
                Points[11].Push(new Pawn(ePlayer.playerA));
                Points[18].Push(new Pawn(ePlayer.playerA));
                Points[5].Push(new Pawn(ePlayer.playerB));
                Points[12].Push(new Pawn(ePlayer.playerB));
            }

            for (int i = 0; i < 3; i++)
            {
                Points[16].Push(new Pawn(ePlayer.playerA));
                Points[7].Push(new Pawn(ePlayer.playerB));
            }
        }
    }
}
