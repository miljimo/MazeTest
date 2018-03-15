using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            IGameFileLoader Loader        = new GameFileLoader();
            Loader.Load(GetAbsoluteFilePath("input.txt"));
            IMazeWalker Walker            = new MazeWalker(new GameScenePresenter(Loader.Scene));
            IGameScenePresenter Paths               = Walker.Walk(Loader.StartPosition, Loader.EndPosition);
            Paths.Render();
            Console.ReadKey();
        }

        /// <summary>
        ///  Get the path to the filename
        /// </summary>
        /// <param name="Filename"></param>
        /// <returns></returns>
        private static string GetAbsoluteFilePath(string Filename)
        {
             string ProjectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
             return Path.GetFullPath(Path.Combine(ProjectPath, "Res", Filename));
        }
    }
}
