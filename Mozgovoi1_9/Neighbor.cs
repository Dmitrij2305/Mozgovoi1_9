using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozgovoi1_9
{
    enum Neighbor : byte
    {
        NW = 128,
        N = 64,
        NE = 32,
        W = 16,
        E = 8,
        SW = 4,
        S = 2,
        SE = 1
    }
}
