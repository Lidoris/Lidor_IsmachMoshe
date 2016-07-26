using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLogic
{
    public class Pawn
    {
        public ePlayer Owner { get; private set; } 

        public Pawn(ePlayer owner)
        {
            Owner = owner;
        }

        public override string ToString()
        {
            return "O";
        }
    }
}
