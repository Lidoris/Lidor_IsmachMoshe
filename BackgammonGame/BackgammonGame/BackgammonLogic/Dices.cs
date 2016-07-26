using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLogic
{
    public class Dices
    {
        public Dice FirstDice { get;  set; }
        public Dice SecondDice { get; private set; }
        public bool IsDouble { get; set; }

        private Random random = new Random();

        public Dices()
        {
            FirstDice = new Dice();
            SecondDice = new Dice();
            IsDouble = false;
        }

        public void RollDices()
        { 
            FirstDice.RollDice(random);
            SecondDice.RollDice(random);
            if (FirstDice.Value == SecondDice.Value)
            {
                IsDouble = true;
            }
            else
            {
                IsDouble = false;
            }
        }
    }
}
