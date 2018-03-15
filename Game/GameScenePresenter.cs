using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameScenePresenter : IGameScenePresenter
    {
        public GameScenePresenter (IMazeGameScene Scene)
        {
            this.Scene = Scene;
        }
        /// <summary>
        ///  Draw the game paths.
        /// </summary>
        public void Render()
        {
            if(Scene != null)
            {
                for (int Row = 0; Row  < Scene.Height; Row++)
                {
                    for (int Column = 0; Column < Scene.Width; Column++)
                    {
                        GameCell Cell = Scene.GetCell(Row, Column);
                        Console.Write("{0} ", Scene.GetCell(Column, Row).Value);
                    }
                    Console.WriteLine("");
                }
            }
        }

        public IMazeGameScene Scene
        {
            get;
            private set;
        }
    }
}
