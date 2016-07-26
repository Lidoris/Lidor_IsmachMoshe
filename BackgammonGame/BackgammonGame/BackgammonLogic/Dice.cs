using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLogic
{
    public class Dice
    {
        //private Random random;
        public int Value { get; private set; }
        public bool IsUsed { get;  set; }

        public Dice()
        {
            IsUsed = false;
        }

        public void RollDice(Random random)
        {
            IsUsed = false;
            Value = random.Next(1, 6);
        }

        public void UseDice()
        {
            IsUsed = true;
        }

    }
}
