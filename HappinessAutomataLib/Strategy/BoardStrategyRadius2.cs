using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappinessAutomataLib
{
    public class BoardStrategyRadius2 : BoardStrategyBase
    {
        public BoardStrategyRadius2(bool enableMemory, int maxCharacterDiffForCoupling) : base(enableMemory, maxCharacterDiffForCoupling)
        {
        }

        public override List<Cell> GetCellNeighbours(int i, int j, Board board)
        {
            List<Cell> neighbours = base.GetCellNeighbours(i,j,board); //Add radius 1 neighbours

            int startIndex, endIndex;
            int size = board.Size;


            //Add radius 2 neighbours

            //Add top & bottom cells
            startIndex = j > 1 ? j - 2 : 0;
            endIndex = j < size - 2 ? j + 2 : size - 1;

            if (i > 1) 
            {

                for (int x = startIndex; x <= endIndex; x++)
                {
                    neighbours.Add(board[i - 2,x]);
                }

            }
           
            if (i < size - 2)
            {
                for (int x = startIndex; x <= endIndex; x++)
                {
                    neighbours.Add(board[i + 2, x]);
                }
            }

            //Add side neighbours
            startIndex = i > 0 ? i - 1 : 0;
            endIndex = i < size - 1 ? i + 1 : size - 1;

            if (j > 1)
            {

                for (int x = startIndex; x <= endIndex; x++)
                {
                    neighbours.Add(board[x, j-2]);
                }

            }

            if (j < size - 2)
            {
                for (int x = startIndex; x <= endIndex; x++)
                {
                    neighbours.Add(board[x , j + 2]);
                }
            }

            return neighbours; 

        }
    }
}
