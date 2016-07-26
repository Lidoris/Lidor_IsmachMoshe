﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackgammonLogic;

namespace BackgammonUI
{
    class ConsolePlayer : IPlayer
    {
        public ePlayer Type { get;  }
        public Stack<Pawn> EatenPawns { get; }

        public ConsolePlayer(ePlayer type)
        {
            Type = type;
            EatenPawns = new Stack<Pawn>();
        }

        public Move GetAMove( Dices dices)
        {
            Dice chosenDice;
            int srcPoint;
            int diceValue;
            Console.Write("Choose a dice value : ");
            int.TryParse(Console.ReadLine(), out diceValue);
            while ((diceValue != dices.FirstDice.Value && diceValue != dices.SecondDice.Value )||
                (diceValue == dices.FirstDice.Value && dices.FirstDice.IsUsed && !dices.IsDouble)||
                (diceValue == dices.SecondDice.Value && dices.SecondDice.IsUsed && !dices.IsDouble))
            {
                Console.Write("Incorrect input, Choose a dice value : ");
                int.TryParse(Console.ReadLine(), out diceValue);
            }

            if (diceValue == dices.FirstDice.Value)
            {
                chosenDice = dices.FirstDice;
            }
            else
            {
                chosenDice = dices.SecondDice;
            }

            Console.Write("From which point you want to move? Choose a number from 1 until 24 :");
            bool parseSucceed = int.TryParse(Console.ReadLine(), out srcPoint);
            while ((!parseSucceed) || (srcPoint < 1 || srcPoint > 24))
            {
                Console.Write("Incorrect input, Choose a point from 1 until 24  : ");
                parseSucceed = int.TryParse(Console.ReadLine(), out srcPoint);
            }


            return new Move(srcPoint, chosenDice);
        }
    }
}
