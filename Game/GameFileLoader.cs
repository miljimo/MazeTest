

namespace Game
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   

    
   public  class GameFileLoader : IGameFileLoader
    {

        /// <summary>
        /// Helper function to check if the character is a new line or space.
        /// </summary>
        /// <param name="Ch"></param>
        /// <returns></returns>
        private bool IsNullSpaceOrNewLine(char Ch)
        {
            bool Result = false;
            if ((Ch == ' ') || (Ch == '\n') || (Ch == '\r') || (Ch == '\n') || (Ch == '\0'))
            {
                Result = true;
            }
            return Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        public void Load(string Filename)
        {           
            var Stream         = new System.IO.FileStream(Filename,
                                          System.IO.FileMode.Open,
                                          System.IO.FileAccess.Read,
                                          System.IO.FileShare.ReadWrite);

            using(StreamReader Reader = new StreamReader(Stream, System.Text.Encoding.ASCII, true, 128))
            {
               Size Size =  ReadBoardSize(Reader);
                
                //Read Start Position  X , Y
                StartPosition = ReadBoardPoint(Reader);
                //Read End Position  X , Y
                EndPosition =  ReadBoardPoint(Reader);
                
               //Load the actual maze site into a structure game board.
               Scene = new MazeGameScene(Size);
            //Create the maze cells
               for(int Rows  = 0; Rows < Size.Height; Rows++)
               {
                   string RowLine = Reader.ReadLine();
                   int Columns = 0;
                    for (int Index = 0; Index < RowLine.Length; Index++)
                    {
                        char ChValue = RowLine[Index] ;

                        if (IsNullSpaceOrNewLine(ChValue) != true)
                        {
                            InputType CellType = (InputType)(ChValue - '0');
                            Scene.AddCell(Columns, Rows, new GameCell(CellType));
                            Columns++;
                            
                        }
                    }
               }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Reader"></param>
        /// <returns></returns>
        private Size ReadBoardSize(StreamReader Reader)
        {
            Size size = new Size(){Width=0,Height=0};
            string[] Line = Reader.ReadLine().Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            if (Line.Length >= 2)
            {
                size.Width  = int.Parse(Line[0]);
                size.Height = int.Parse(Line[1]);
            }
            return size; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Reader"></param>
        /// <returns></returns>
        private Point ReadBoardPoint(StreamReader Reader)
        {
            Size size = ReadBoardSize(Reader);
            return new Point()
            {
                X = size.Width,
                Y = size.Height
            };
        }


        public IMazeGameScene Scene
        {
            get;
            private set;
        }

        public Point StartPosition
        {
            get;
            private set;
        }

        public Point EndPosition
        {
            get;
            private set;
        }
    }
}
