using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLogic
{
    class Dice
    {
        public int Value { get; private set; }
        private Random random;

        public Dice()
        {
            random = new Random();
        }

        public void RollDice()
        {
            Value = random.Next(1, 6);
        }


    }
}
