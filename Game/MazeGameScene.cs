using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{

    /// <summary>
    /// 
    /// </summary>
    public class MazeGameScene: IMazeGameScene
    {
        private GameCell[,] __Cells;

        private static readonly GameCell EmptyCellWall = new GameCell(InputType.Wall) { CellStateType = CellStateType.NONE };
        private int __Height;
        private int __Width;

        public MazeGameScene(Size Size)
        {
            __Height   = Size.Height;
            __Width    = Size.Width;
            __Cells    = new GameCell[__Height, __Width];
        }

        /// <summary>
        /// Add the current cell in the right location
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Cell"></param>
        public void AddCell(int Column, int Row, GameCell Cell)
        {
            if ((Column >= 0 && Column < __Width) && ((Row >= 0) && ((Row < __Height))))
            {
                __Cells[Row, Column] = Cell;
            }
        }

        /// <summary>
        /// Add the Height
        /// </summary>
        public int Height
        {
            get { return __Height; }
        }
        /// <summary>
        /// Get The Width
        /// </summary>
        public int Width
        {
            get { return __Width; }
        }


        public void SetCell(int Column, int Row , GameCell Cell)
        {
            if ((Column >= 0 && Column < __Width) && ((Row >= 0) && ((Row < __Height))))
            {
                __Cells[Row, Column] = Cell;
            }
           
        }
        /// <summary>
        ///  Get the Cell in the given position;
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Row"></param>
        /// <returns></returns>
        public GameCell GetCell(int Column, int Row)
        {
            GameCell Cell = null;
            if ((Column >= 0 && Column < __Width) && ((Row >= 0) && ((Row < __Height))))
            {
                Cell = __Cells[Row, Column];
            }
            return Cell;
        }
    }
}
