using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappinessAutomataLib
{
    public interface IBoardStrategy
    {
        Board CalculateNextBoardState(Board board);
    }
}
