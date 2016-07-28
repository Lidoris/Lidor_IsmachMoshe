using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLogic
{
    public interface IHumanPlayer
    {
        void InformPawnOnTheBar();
        void InformChooseADice();
        void InformIncorrectDice();
        void InformChooseAPoint();
        void InformIncorrectPoint();

        string GetStrInput();
    }
}
