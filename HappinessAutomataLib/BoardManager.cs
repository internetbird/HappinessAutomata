using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappinessAutomataLib
{
    public class BoardManager
    {
      
        private Board m_board;
        private IBoardStrategy m_startegy;
        private Random m_rand;
        private int m_totalGenerationsCalculated;
        private int m_totalGenerationsHappiness;
        private int m_numOfHumans;

        public const int MaxCharacterValue = 100;

        public Board Board
        {
            get
            {
                return m_board;
            }
        }

        public BoardManager(Board board, IBoardStrategy strategy)
        {
            m_board = board;
            m_startegy = strategy;
            m_rand = new Random(DateTime.Now.Millisecond);
        }

        /// <summary>
        /// Calculates the total board happiness score.
        /// </summary>
        /// <returns></returns>
        public int GetHappinessScore()
        {
            int score = 0;

            for (int i = 0; i < m_board.Size; i++)
            {
                for (int j = 0; j < m_board.Size; j++)
                {
                    score += m_board[i, j].HappinessScore;
                }

            }

            return score;
        }

        public void CalculateNextBoardState()
        {
            m_board = m_startegy.CalculateNextBoardState(m_board);
            m_totalGenerationsCalculated++;
            m_totalGenerationsHappiness += GetCurrentHappinessScore();

        }

        /// <summary>
        /// Populates the board with random humans.
        /// </summary>
        public void PopulateBoard(int numOfMen, int numOfWomen)
        {
            //Populate women

            for (int i = 0; i < numOfMen; i++)
            {
                var woman = new Human(Sex.Female, GenerateRandCharacter());

                Tuple<int, int> indexes = FindRandomEmptyCellIndexes();

                m_board[indexes.Item1, indexes.Item2].Humans.Add(woman);

            }

            //Populate men
            for (int i = 0; i < numOfWomen; i++)
            {
                var man = new Human(Sex.Male, GenerateRandCharacter());

                Tuple<int, int> indexes = FindRandomEmptyCellIndexes();

                m_board[indexes.Item1, indexes.Item2].Humans.Add(man);

            }

            m_numOfHumans = numOfMen + numOfWomen;

        }

        /// <summary>
        /// Gets a random character value between 0-MaxCharacterValue
        /// </summary>
        /// <returns></returns>
        private int GenerateRandCharacter()
        {
            return m_rand.Next(MaxCharacterValue + 1);
        }

        /// <summary>
        /// Gets the random indexes.
        /// </summary>
        /// <returns></returns>
        private Tuple<int, int> GenerateRandomIndexes()
        {
            int i, j;

            i = m_rand.Next(m_board.Size);
            j = m_rand.Next(m_board.Size);

            return new Tuple<int, int>(i, j);
        }

        private Tuple<int, int> FindRandomEmptyCellIndexes()
        {
            Tuple<int, int> indexes;

            do
            {
                indexes = GenerateRandomIndexes();

            } while (m_board[indexes.Item1, indexes.Item2].State != CellState.Empty);


            return indexes;

        }

        public int GetCurrentHappinessScore()
        {
            return m_board.TotalHappinessScore / m_numOfHumans;
        }

        public int GetAverageHappinessScore()
        {
            return m_totalGenerationsHappiness / m_totalGenerationsCalculated;
        }

       
    }
}
