using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{

    public struct Point : IEquatable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public bool Equals(Point other)
        {
            return ((X == other.X) && (Y == other.Y));
        }
    }

    public struct Size
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }


    

    public enum CellStateType
    {
        NONE,
        START,
        END
    }

 
   public class GameCell:IGameCell
    {
       private bool                 __ValidPath;
       private InputType         __CellType;
       private CellStateType        __CellStateType;
       public GameCell(InputType Type)
       {
            Value = ' ';
            CellType = Type;
          
       }

       public  CellStateType CellStateType
       {
           get
           {
               return __CellStateType;
           }
           set
           {
               if (__CellStateType != value)
               {
                   __CellStateType = value;
                   switch (__CellStateType)
                   {
                       case CellStateType.START:
                           Value = 'S';
                           break;
                       case CellStateType.END:
                           Value = 'E';
                           break;
                       default:
                           break;
                   }
               }
           }
       }
       /// <summary>
       /// Get and Set the Cell Visited Status
       /// </summary>
       public bool  Visited
       {
           get;
           set;
       }
       /// <summary>
       /// 
       /// </summary>
       public InputType CellType
       {
           get
           {
               return __CellType;
           }
           set
           {
               if(__CellType != value)
               {
                   __CellType     = value;

                   if (__CellType == InputType.Path)
                   {
                       Value = ' ';
                   }
                   else
                   {
                       Value = '#';
                   }
               }
           }
       }

       /// <summary>
       /// Set and Get the passages paths.
       /// </summary>
       public bool     ValidPath
       {
           get
           {
               return __ValidPath;
           }
           set
           {
               if(__ValidPath != value)
               {
                   __ValidPath = value;

                   if(__ValidPath == true)
                   {
                       Value = 'X';
                   }
               }
           }
       }

       /// <summary>
       /// Value.
       /// </summary>
       public  char  Value { get; private set; }
    }

    /// <summary>
    /// The Maze Game Cells.
    /// </summary>
    public interface IMazeGameScene
    {
        void     AddCell(int X, int Y, GameCell Cell);
        GameCell GetCell(int X, int Y);
        void     SetCell(int X, int Y, GameCell Cell);
        int  Height { get; }
        int  Width  { get; }
    }
}
