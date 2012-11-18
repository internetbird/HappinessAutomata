using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappinessAutomataLib
{
    /// <summary>
    /// Represets a cell in the life board
    /// </summary>
    public class Cell
    {
        private List<Human> m_humans;

        public Cell()
        {
            m_humans = new List<Human>();
        }

        /// <summary>
        /// Gets the state of the cell (Emply, contains a man, woman or a couple).
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public CellState State
        {
            get
            {
                if (!m_humans.Any()) return CellState.Empty;

                if (m_humans.Count == 1)
                {
                    if (m_humans[0].Sex == Sex.Male)
                    {
                        return CellState.Man;
                    }
                    else
                    {
                        return CellState.Woman;
                    }
                }

                return CellState.Couple;
            }
        }

        /// <summary>
        /// Gets the happiness score of a single cell
        /// </summary>
        /// <value>
        /// The happiness score.
        /// </value>
        public int HappinessScore
        {
            get
            {
                return (BoardManager.MaxCharacterValue - CharacterDiff)*2;
            }
        }

        public int CharacterDiff
        {
            get
            {
                if(State != CellState.Couple) return BoardManager.MaxCharacterValue;

                return Math.Abs(m_humans[0].Character - m_humans[1].Character);
            }
        }

        /// <summary>
        /// Gets the humans.
        /// </summary>
        /// <value>
        /// The humans.
        /// </value>
        public List<Human> Humans
        {
            get
            {
                return m_humans;
            }
        }

        public Human Male
        {
            get
            {
                return m_humans.Find(h => h.Sex == Sex.Male);
            }
        }

        public Human Female
        {
            get
            {
                return m_humans.Find(h => h.Sex == Sex.Female);
            }
        }

        /// <summary>
        /// Gets the opposite sex human.
        /// </summary>
        /// <param name="sex">The sex.</param>
        /// <returns></returns>
        public Human GetOppositeSexHuman(Sex sex)
        {
            if (State == CellState.Empty) return null;

            if (sex == Sex.Female)
            {
                return Male;

            }
            else //Male
            {
                return Female;
            }
         
        }

    } 
}
