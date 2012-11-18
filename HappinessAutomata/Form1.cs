using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HappinessAutomataLib;
using System.IO;
using System.Reflection;
using System.Threading;

namespace HappinessAutomata
{
    public partial class Form1 : Form
    {
        #region Members

        private BoardManager m_boardManager;
        private Panel[,] m_boardPanels;
        private const int BoardWidthInPixel = 550;
        private const int BoardXOffset = 180;
        private const int BoardYOffset = 25;
        private int m_numOfGenerations; 

        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the btnGenerateBoard control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnGenerateBoard_Click(object sender, EventArgs e)
        {

            int boardSize = int.Parse(txtBoardSize.Text);
            int numOfMen = int.Parse(txtNumOfMen.Text);
            int numOfWomen = int.Parse(txtNumOfWomen.Text);
            m_numOfGenerations = int.Parse(cmbNumOfGenerations.Text);

            var board = new Board(boardSize);

            BoardStrategyParameters parameters = GetStrategyParameters();
            IBoardStrategy strategy = BoardStrategyFactory.CreateStrategy(parameters);

            m_boardManager = new BoardManager(board, strategy);
            m_boardManager.PopulateBoard(numOfMen, numOfWomen);

            m_boardPanels = new Panel[boardSize, boardSize];
          
            InitializeBoardGraphics(m_boardManager.Board);

            btnRunAutomata.Enabled = true;

        }

        /// <summary>
        /// Gets the strategy parameters.
        /// </summary>
        /// <returns></returns>
        private BoardStrategyParameters GetStrategyParameters()
        {
            return new BoardStrategyParameters
            {
                NeighbourhoodRadius = int.Parse(cmbNeighbourhoodRadius.Text),
                EnableMemory = cmbEnableMemory.Text == "Yes",
                MaxCharacterDiff = int.Parse(cmbMaxCharDiff.Text)
            };
          
        }

        /// <summary>
        /// Draws the board.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void InitializeBoardGraphics(Board board)
        {

            int cellSize = BoardWidthInPixel/board.Size;

            splitContainer1.Panel2.Controls.Clear();

            for (int i = 0; i < board.Size; i++)
            {

                for (int j = 0; j < board.Size; j++)
                {
                    var panel = new Panel
                    {
                        Size = new Size(cellSize, cellSize),
                        Location = new Point(BoardXOffset + (cellSize * i) , BoardYOffset + (cellSize * j)),
                        BackgroundImage = GetCellImage(board[i, j]),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        BackColor = GelCellBackColor(board[i,j]),
                        BorderStyle = BorderStyle.FixedSingle,

                    };

                    splitContainer1.Panel2.Controls.Add(panel);
                    m_boardPanels[i, j] = panel;

                }

            }

            lblAverageHappiness.Text = "0";
            lblCurrHappiness.Text = "0";
            lblGenerationNum.Text = "0";

        }

        /// <summary>
        /// Gels the color of the cell back.
        /// </summary>
        /// <param name="cell">The cell.</param>
        /// <returns></returns>
        private Color GelCellBackColor(Cell cell)
        {
            Color backColor = Color.Silver;

            switch(cell.State)
            {
                case CellState.Man:
                    backColor = Color.FromArgb(0,0,240);
                    break;
                case CellState.Woman:
                    backColor = Color.FromArgb(0,240,0);
                    break;
                case CellState.Couple:
                    backColor = Color.FromArgb(240,0,0);
                    break;

            }

            return backColor;
        }

        /// <summary>
        /// Gets the cell image.
        /// </summary>
        /// <param name="cell">The cell.</param>
        /// <returns></returns>
        private Image GetCellImage(Cell cell)
        {
            Image image = null;

            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            switch(cell.State)
            {
                case CellState.Man:
                    image = Image.FromFile(Path.Combine(assemblyPath, "Resources/man.png"));
                    break;
                case CellState.Woman:
                    image = Image.FromFile(Path.Combine(assemblyPath, "Resources/woman.png"));
                    break;
                case CellState.Couple:
                    image = Image.FromFile(Path.Combine(assemblyPath, "Resources/couple.png"));
                    break;
            }
            

            return image;
        }

        /// <summary>
        /// Handles the Click event of the btnRunSimulation control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnRunAutomata_Click(object sender, EventArgs e)
        {
            btnRunAutomata.Enabled = false;

            for (int i = 1; i <= m_numOfGenerations; i++)
            {
                m_boardManager.CalculateNextBoardState();

                RedrawBoardGraphics(m_boardManager.Board);

                lblGenerationNum.Text = i.ToString();
                lblGenerationNum.Refresh();

                lblCurrHappiness.Text =  m_boardManager.GetCurrentHappinessScore().ToString();
                lblCurrHappiness.Refresh();

                lblAverageHappiness.Text = m_boardManager.GetAverageHappinessScore().ToString();
                lblAverageHappiness.Refresh();

                Thread.Sleep(400);
            }

        }

        /// <summary>
        /// Redraws the board graphics.
        /// </summary>
        /// <param name="board">The board.</param>
        private void RedrawBoardGraphics(Board board)
        {
            for (int i = 0; i < board.Size; i++)
            {

                for (int j = 0; j < board.Size; j++)
                {
                    m_boardPanels[i, j].BackgroundImage = GetCellImage(board[i, j]);
                    m_boardPanels[i, j].BackColor = GelCellBackColor(board[i, j]);

                }

            }
            splitContainer1.Panel2.Refresh();

        }

      
    }
}
