using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappinessAutomataLib
{
    public class BoardStrategyBase : IBoardStrategy
    {

        private const int MaxRandomMoveTries = 3;
        private bool m_enableMemory;
        private int? m_maxCharacterDiffForCoupling;
        private Random m_rand;

        public BoardStrategyBase()
        {
            m_rand = new Random(DateTime.Now.Millisecond);
        }

        public BoardStrategyBase(bool enableMemory)
            : this()
        {
            m_enableMemory = enableMemory;
        }

        public BoardStrategyBase(bool enableMemory, int maxCharacterDiffForCoupling)
            : this(enableMemory)
        {
            m_maxCharacterDiffForCoupling = maxCharacterDiffForCoupling;
        }

        /// <summary>
        /// Gets the cell neighbours.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <param name="board">The board.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Indexes must be a positive integer</exception>
        public virtual List<Cell> GetCellNeighbours(int i, int j, Board board)
        {
            int size = board.Size;

            if (i < 0 || j < 0)
            {
                throw new ArgumentException("Indexes must be a positive integer");
            }

            if (i >= size || j >= size)
            {
                throw new ArgumentException("Indexes must be less than board size:" + size);
            }

            var neighbours = new List<Cell>();

            if (i > 0) //Add top neighbours
            {
                neighbours.Add(board[i - 1, j]);

                if (j < size - 1)
                {
                    neighbours.Add(board[i - 1, j + 1]);
                }

                if (j > 0)
                {
                    neighbours.Add(board[i - 1, j - 1]);

                }
            }

            if (i < size - 1) //Add bottom neighbours
            {
                neighbours.Add(board[i + 1, j]);

                if (j < size - 1)
                {
                    neighbours.Add(board[i + 1, j + 1]);
                }

                if (j > 0)
                {
                    neighbours.Add(board[i + 1, j - 1]);

                }

            }

            //Add side neighbours
            if (i > 0)
            {
                neighbours.Add(board[i - 1, j]);
            }

            if (i < size - 1)
            {
                neighbours.Add(board[i + 1, j]);
            }

            return neighbours;
        }

        /// <summary>
        /// Calculates the state of the next board.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <returns></returns>
        public Board CalculateNextBoardState(Board board)
        {

            var nextGenerationBoard = new Board(board.Size);

            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    Cell currGenerationCell = board[i, j];
                    Cell nextGenerationCell = nextGenerationBoard[i, j];

                    if (nextGenerationCell.State != CellState.Empty /*Already calculated*/ || currGenerationCell.State == CellState.Empty) continue;

                    if (currGenerationCell.State != CellState.Couple) //A single cell, try to find spouses
                    {

                        Cell spouseCell = FindSpouseForSingleHumanCell(i, j, board, nextGenerationBoard);

                        if (spouseCell != null) // Found a spouse, create a couple
                        {
                            Human spouse = spouseCell.GetOppositeSexHuman(currGenerationCell.Humans[0].Sex);

                            Human human = currGenerationCell.Humans[0].Clone();

                            if (m_enableMemory) //If memory is enable, save spouses memory
                            {
                                human.BestCharacterDiffMemory = Math.Abs(spouse.Character - human.Character);
                            }

                            nextGenerationCell.Humans.Add(human);
                            nextGenerationCell.Humans.Add(spouse.Clone());

                            Tuple<int, int> spouseIndexes = board.FindCellIndexes(spouseCell);

                            if (spouseCell.State == CellState.Couple) //Create the single human cell in the next state board
                            {
                                spouseCell.Humans.Remove(spouse);
                                nextGenerationBoard[spouseIndexes.Item1, spouseIndexes.Item2].Humans.Add(spouseCell.Humans[0].Clone());
                            }


                            board[spouseIndexes.Item1, spouseIndexes.Item2] = new Cell();
                            board[i, j] = new Cell();

                        }
                        else //Didn't find a spouse, try to move the human
                        {
                            MoveCell(board, nextGenerationBoard, i, j);

                        }

                    }
                    else //The cell has a couple
                    {
                        Cell spouse = FindBetterSpouseForCoupleCell(i, j, board);

                        if (spouse != null) //Found a better spouse, generate the new couple and new single
                        {
                            Tuple<int, int> spouseIndexes = board.FindCellIndexes(spouse);

                            if (spouse.State == CellState.Man)
                            {
                                //The new couple
                                nextGenerationBoard[spouseIndexes.Item1, spouseIndexes.Item2].Humans.Add(spouse.Male.Clone());
                                nextGenerationBoard[spouseIndexes.Item1, spouseIndexes.Item2].Humans.Add(board[i, j].Female.Clone());

                                //The new single
                                nextGenerationBoard[i, j].Humans.Add(board[i, j].Male.Clone());

                            }
                            else //Woman
                            {
                                //The new couple
                                nextGenerationBoard[spouseIndexes.Item1, spouseIndexes.Item2].Humans.Add(spouse.Female.Clone());
                                nextGenerationBoard[spouseIndexes.Item1, spouseIndexes.Item2].Humans.Add(board[i, j].Male.Clone());

                                //The new single
                                nextGenerationBoard[i, j].Humans.Add(board[i, j].Female.Clone());
                            }


                            //Clear the couple and the new spouse cells from the original board
                            board[i, j] = new Cell();
                            board[spouseIndexes.Item1, spouseIndexes.Item2] = new Cell();

                        }

                        else //Didn't find a better spouse, try to move the couple
                        {
                            MoveCell(board, nextGenerationBoard, i, j);

                        }

                    }

                }

            }

            return nextGenerationBoard;
        }

        /// <summary>
        /// Randomly Moves a cell on the board5.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="nextGenBoard">The next state board.</param>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        private void MoveCell(Board board, Board nextGenBoard, int i, int j)
        {
            Tuple<int, int> coordinates = GenerateRandomMoveCoordinates(i, j, board, nextGenBoard);

            if (coordinates != null)
            {
                nextGenBoard[coordinates.Item1, coordinates.Item2] = board[i, j].Clone();
            }
            else
            {
                nextGenBoard[i, j] = board[i, j].Clone(); ;
            }

            board[i, j] = new Cell();
        }

        /// <summary>
        /// Finds the better spouse for couple cell.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <param name="board">The board.</param>
        /// <returns></returns>
        private Cell FindBetterSpouseForCoupleCell(int i, int j, Board board)
        {
            Cell cell = board[i, j];
            List<Cell> neighbours = GetCellNeighbours(i, j, board);

            //Consider only non-empty cells
            neighbours = neighbours.Where(n => n.State != CellState.Empty).ToList();

            int coupleCharDiff = Math.Abs(cell.Humans[0].Character - cell.Humans[1].Character);

            var betterSpouses = from neighbour in neighbours
                                let charDiff = neighbour.Humans[0].Sex == Sex.Female ? Math.Abs(cell.Male.Character - neighbour.Humans[0].Character) : Math.Abs(cell.Female.Character - neighbour.Humans[0].Character)
                                where (neighbour.State == CellState.Man || neighbour.State == CellState.Woman) && charDiff < coupleCharDiff
                                select neighbour;

            return betterSpouses.FirstOrDefault();

        }

        /// <summary>
        /// Finds the spouse for single human cell.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <param name="board">The board.</param>
        /// <returns></returns>
        private Cell FindSpouseForSingleHumanCell(int i, int j, Board board, Board nextGenerationBoard)
        {
            Human human = board[i, j].Humans[0];
            List<Cell> neighbours = GetCellNeighbours(i, j, board);

            //Filter only optional spouses
            neighbours = neighbours.Where(n => n.State != CellState.Empty &&
                                          n.GetOppositeSexHuman(human.Sex) != null).ToList();

            //Choose the best spouse
            var spouses = from neighbour in neighbours
                          let charDiff = Math.Abs(neighbour.GetOppositeSexHuman(human.Sex).Character - human.Character)
                          where (!m_enableMemory || charDiff < human.BestCharacterDiffMemory) &&
                                (m_maxCharacterDiffForCoupling == null || 
                                (charDiff <= m_maxCharacterDiffForCoupling && charDiff < neighbour.CharacterDiff))
                          orderby charDiff ascending
                          select neighbour;

            //Filter couple spouse where the couple cell was already calculated in the next generation board, to avoid override
            spouses = from spouse in spouses
                      let spouseIndexes = board.FindCellIndexes(spouse)
                      where spouse.State != CellState.Couple || nextGenerationBoard[spouseIndexes.Item1, spouseIndexes.Item2].State == CellState.Empty
                      select spouse;

            return spouses.FirstOrDefault(); //The best spouse


        }

        /// <summary>
        /// Generates the random move coordinates.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <param name="board">The board.</param>
        /// <returns>Returns the new random coordinates or null if couldn't find any</returns>
        public Tuple<int, int> GenerateRandomMoveCoordinates(int i, int j, Board board, Board nextGenBoard)
        {
            int iRnd, jRnd;

            int tries = 0;

            do
            {
                iRnd = GenerateRandomMoveCoordinate(i, board.Size);
                jRnd = GenerateRandomMoveCoordinate(j, board.Size);

                tries++;

            } while ((board[iRnd, jRnd].State != CellState.Empty || nextGenBoard[iRnd, jRnd].State != CellState.Empty) && tries < MaxRandomMoveTries);

            if (tries == MaxRandomMoveTries) //Couldn't find an empty cell, so stay at the same cell.
            {
                return null;
            }
            else
            {
                return new Tuple<int, int>(iRnd, jRnd);
            }

        }

        /// <summary>
        /// Generates the random move coordinate.
        /// </summary>
        /// <param name="coordinate">The coordinate.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        private int GenerateRandomMoveCoordinate(int coordinate, int size)
        {

            if (coordinate > 0)
            {
                if (coordinate < size - 1)
                {
                    return coordinate - 1 + m_rand.Next(3);
                }
                else
                {
                    return coordinate - m_rand.Next(2);
                }
            }
            else
            {
                return m_rand.Next(2);
            }
        }

    }


}
