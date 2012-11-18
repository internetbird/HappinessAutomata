using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappinessAutomataLib
{
    public static class Extensions
    {
        /// <summary>
        /// Clones the specified cell.
        /// </summary>
        /// <param name="cell">The cell.</param>
        /// <returns></returns>
        public static Cell Clone(this Cell cell)
        {
            var clone = new Cell();

            foreach (Human human in cell.Humans)
            {
                clone.Humans.Add(human.Clone());
            }

            return clone;
        }


        /// <summary>
        /// Clones the specified human.
        /// </summary>
        /// <param name="human">The human.</param>
        /// <returns></returns>
        public static Human Clone(this Human human)
        {
            return new Human(human.Sex, human.Character, human.BestCharacterDiffMemory);

        }
    }
}
