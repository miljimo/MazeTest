using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class MazeWalker : IMazeWalker
    {
        private IGameScenePresenter   __Presenter;
        private Point                 __EndPosition;

        public MazeWalker(IGameScenePresenter Presenter)
        {
            __Presenter = Presenter;
        }

        /// <summary>
        ///  The algorithm to walk the maze and 
        ///  it will return the success paths only.
        ///  
        /// </summary>
        /// <param name="StartPositon"></param>
        /// <param name="EndPosition"></param>
        /// <returns></returns>
        public IGameScenePresenter Walk(Point StartPositon, Point EndPosition)
        {
            __EndPosition = EndPosition;

            if (FindPathRecursively(StartPositon) != true)
            {
                GameCell StartCell = __Presenter.Scene.GetCell(StartPositon.X, StartPositon.Y);
                StartCell.CellStateType = CellStateType.START;
                __Presenter.Scene.SetCell(StartPositon.X, StartPositon.Y, StartCell);
               //No Solution to the maze;
            }
            return __Presenter;
        }

        /// <summary>
        /// A helper function that will trace the waking path.
        /// </summary>
        /// <param name="Positon"></param>
        /// <returns></returns>
        private bool FindPathRecursively(Point Positon)
        {
            bool Found  = false;
            GameCell Cell = __Presenter.Scene.GetCell(Positon.X, Positon.Y);

            if( (Positon.X == __EndPosition.X)  && (Positon.Y == __EndPosition.Y))
            {
                Found = true;
                Cell.CellStateType = CellStateType.END;
                __Presenter.Scene.SetCell(Positon.X, Positon.Y, Cell);
            }
            else if ( (Cell.CellType != InputType.Wall)
                 && (Cell.Visited != CellVisitation.Visited))
            {
                Cell.Visited = CellVisitation.Visited;
                __Presenter.Scene.SetCell(Positon.X, Positon.Y, Cell);

                if(Positon.X != 0)
                {
                    Found = HasMoveAndUpdateCell(new Point() { X = (Positon.X - 1), Y = Positon.Y });
                }

                if (Positon.X != (__Presenter.Scene.Width - 1))
                {
                    Found = HasMoveAndUpdateCell(new Point() { X = (Positon.X + 1), Y = Positon.Y });
                }

                if(Positon.Y != 0)
                {
                  Found = HasMoveAndUpdateCell(new Point() { X = Positon.X, Y = (Positon.Y - 1) });
                }

                if (Positon.Y != (__Presenter.Scene.Height - 1))
                {
                    Found = HasMoveAndUpdateCell(new Point() { X = Positon.X, Y = (Positon.Y + 1) });
                }
            }
            return Found;
        }


        /// <summary>
        /// Helper function to update the Cell when th position is valid passages path
        /// </summary>
        /// <param name="Position"></param>
        /// <returns></returns>
        private bool HasMoveAndUpdateCell(Point  Position)
        {
            bool Updated = false;

            if (Updated = FindPathRecursively(Position))
            {
                GameCell Cell  = __Presenter.Scene.GetCell(Position.X, Position.Y);
                Cell.ValidPath = true;
                __Presenter.Scene.SetCell(Position.X, Position.Y, Cell);
            }
            return Updated;
        }
    }
}
