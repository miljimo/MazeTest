using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public interface IGameScenePresenter
    {
        IMazeGameScene Scene { get; }
        /// <summary>
        /// Display the paths points;
        /// </summary>
        void Render();

    }

    public interface IMazeWalker
    {
        IGameScenePresenter Walk(Point StartPositon, Point EndPosition);
    }


    /// <summary>
    ///  The Interface loader to the game.
    /// </summary>
    public interface IGameFileLoader
    {
       void  Load(string filename);
       IMazeGameScene Scene          { get; }
       Point          StartPosition { get; }
       Point          EndPosition   { get; }  
    }
}
