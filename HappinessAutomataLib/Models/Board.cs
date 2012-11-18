using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappinessAutomataLib
{
    /// <summary>
    /// Represents the matrix of the cell automata
    /// </summary>
    public class Board
    {
        private const int BoardMinSize = 10;
        private int m_size;
        private Cell[,] m_Cells;

        /// <summary>
        /// Gets or sets the <see cref="Cell" /> with the specified indexes.
        /// </summary>
        /// <value>
        /// The <see cref="Cell" />.
        /// </value>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <returns></returns>
        public Cell this[int i, int j]
        {
            get
            {
                ValidateIndexes(i, j);

                return m_Cells[i, j];
            }

            set
            {
                ValidateIndexes(i, j);

                m_Cells[i, j] = value;

            }

        }

        public int TotalHappinessScore
        {
            get
            {
                int total = 0;

                for (int i = 0; i < m_size; i++)
                {
                    for (int j = 0; j < m_size; j++)
                    {
                        total += m_Cells[i, j].HappinessScore;
                    }
                }

                return total;

                
            }
        }

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public int Size
        {
            get
            {
                return m_size;
            }
        }

        public Board(int size)
        {
            if (size < BoardMinSize) throw new ArgumentOutOfRangeException("size");

            m_size = size;
            m_Cells = new Cell[size, size];

            InitializeEmptyCells();

        }

        private void InitializeEmptyCells()
        {
            for (int i = 0; i < m_size; i++)
            {
                for (int j = 0; j < m_size; j++)
                {
                    m_Cells[i, j] = new Cell();
                }
            }
        }

        public Tuple<int, int> FindCellIndexes(Cell cell)
        {

            for (int i = 0; i < m_size; i++)
            {
                for (int j = 0; j < m_size; j++)
                {
                    if (m_Cells[i, j] == cell)
                    {
                        return new Tuple<int, int>(i, j);
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Validates the indexes.
        /// </summary>
        /// <param name="i">The x-axis index.</param>
        /// <param name="j">The y-axis index.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">cell indexes out of range</exception>
        private void ValidateIndexes(int i, int j)
        {
            if (i < 0 || j < 0 || i >= m_size || j >= m_size) throw new ArgumentOutOfRangeException("cell indexes out of range");
        }
    }
}
