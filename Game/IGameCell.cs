using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{

    public enum InputType
    {
        Path,
        Wall,
    }

    public interface  IGameCell
    {
        bool      Visited   {get;set;}
        InputType InputType { get; }
    }
}
