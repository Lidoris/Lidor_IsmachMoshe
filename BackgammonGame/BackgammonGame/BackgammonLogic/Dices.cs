using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLogic
{
    class Dices
    {
        public Dice FirstDice { get; private set; }
        public Dice SecondDice { get; private set; }

        public Dices()
        {
            FirstDice = new Dice();
            SecondDice = new Dice();
        }

        private void RollDices()
        {
            FirstDice.RollDice();
            SecondDice.RollDice();
        }
    }
}
