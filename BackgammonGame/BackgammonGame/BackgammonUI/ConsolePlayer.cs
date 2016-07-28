using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackgammonLogic;

namespace BackgammonUI
{
    class ConsolePlayer : IHumanPlayer
    {
        public void InformPawnOnTheBar()
        {
            Console.WriteLine("The move will be execute with the pawn on the bar.");
        }

        public void InformChooseADice()
        {
            Console.Write("Choose a dice value : ");
        }

        public void InformIncorrectDice()
        {
            Console.Write("Incorrect input, Choose a dice value : ");
        }

        public void InformChooseAPoint()
        {
            Console.Write("From which point you want to move? Choose a number from 1 until 24 :");
        }

        public void InformIncorrectPoint()
        {
            Console.Write("Incorrect input, Choose a point from 1 until 24  : ");
        }

        public string GetStrInput()
        {
            return Console.ReadLine();
        }
    }
}
