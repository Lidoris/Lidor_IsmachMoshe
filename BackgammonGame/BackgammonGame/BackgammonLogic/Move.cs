using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLogic
{
    class Move
    {
        public Stack<Pawn> Source { get; private set; }
        public Stack<Pawn> Destination { get; private set; }

        public Move(Stack<Pawn> source, Stack<Pawn> dest)
        {
            Source = source;
            Destination = dest;
        }
    }
}
