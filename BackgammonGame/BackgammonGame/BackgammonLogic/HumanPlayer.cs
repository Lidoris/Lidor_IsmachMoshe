using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLogic
{
    public class HumanPlayer : IPlayer 
    {
        public ePlayer Type { get; }
        public Stack<Pawn> EatenPawns { get; }
        public int HomeBoardIndex { get; }
        public IHumanPlayer PlugableHumanPlayer { get; private set; }

        public HumanPlayer(ePlayer type , IHumanPlayer plugableHumanPlayer)
        {
            Type = type;
            PlugableHumanPlayer = plugableHumanPlayer;
            EatenPawns = new Stack<Pawn>();
        }

        public Move GetAMove(Dices dices)
        {
            Dice chosenDice;
            int srcPoint;
            int diceValue;

            if (EatenPawns.Count != 0)
            {
               PlugableHumanPlayer.InformPawnOnTheBar();
            }
            PlugableHumanPlayer.InformChooseADice();
            int.TryParse(PlugableHumanPlayer.GetStrInput(), out diceValue);
            while ((diceValue != dices.FirstDice.Value && diceValue != dices.SecondDice.Value) ||
                (diceValue == dices.FirstDice.Value && dices.FirstDice.IsUsed && !dices.IsDouble) ||
                (diceValue == dices.SecondDice.Value && dices.SecondDice.IsUsed && !dices.IsDouble))
            {
                PlugableHumanPlayer.InformIncorrectDice();
                int.TryParse(PlugableHumanPlayer.GetStrInput(), out diceValue);
            }

            if (diceValue == dices.FirstDice.Value)
            {
                chosenDice = dices.FirstDice;
            }
            else
            {
                chosenDice = dices.SecondDice;
            }

            if (EatenPawns.Count == 0)
            {
                PlugableHumanPlayer.InformChooseAPoint();
                bool parseSucceed = int.TryParse(PlugableHumanPlayer.GetStrInput(), out srcPoint);
                while ((!parseSucceed) || (srcPoint < 1 || srcPoint > 24))
                {
                    PlugableHumanPlayer.InformIncorrectPoint();
                    parseSucceed = int.TryParse(PlugableHumanPlayer.GetStrInput(), out srcPoint);
                }

                return new Move(srcPoint, chosenDice);
            }
            else
            {
                if (Type == ePlayer.playerA)
                {
                    return new Move(0, chosenDice);
                }
                else
                {
                    return new Move(25, chosenDice);
                }
            }
        }
    }
}
