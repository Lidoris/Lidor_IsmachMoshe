using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLogic
{
    public interface IPlayer 
    {
        ePlayer Type { get;  }
        Stack<Pawn> EatenPawns { get; }

        Move GetAMove( Dices dices);
    }
}
