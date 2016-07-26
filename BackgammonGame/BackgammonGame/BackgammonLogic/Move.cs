using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLogic
{
    public class Move
    {
        public int Source { get; private set; }
        public Dice Dice { get; private set; }
         
        public Move(int source, Dice dice)
        {
            Source = source;
            Dice = dice;
        }
    }
}
