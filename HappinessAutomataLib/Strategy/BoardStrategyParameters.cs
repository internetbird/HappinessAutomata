using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappinessAutomataLib
{
    public class BoardStrategyParameters
    {
        public int NeighbourhoodRadius { get; set; }
        public bool EnableMemory { get; set; }
        public int MaxCharacterDiff { get; set; }
    }
}
