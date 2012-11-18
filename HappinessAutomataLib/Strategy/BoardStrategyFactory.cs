using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappinessAutomataLib
{
    public class BoardStrategyFactory
    {
        public static IBoardStrategy CreateStrategy(BoardStrategyParameters parameters)
        {
            if (parameters.NeighbourhoodRadius == 1)
            {
                return new BoardStrategyBase(parameters.EnableMemory, parameters.MaxCharacterDiff);
            }
            else //Radius 2 strategy
            {
                return new BoardStrategyRadius2(parameters.EnableMemory, parameters.MaxCharacterDiff);
            }
        }
    }
}
