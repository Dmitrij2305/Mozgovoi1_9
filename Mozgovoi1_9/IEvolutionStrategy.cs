using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozgovoi1_9
{
    interface IEvolutionStrategy
    {
        bool HasSurvived(byte neighbors);
        bool HasBorn(byte neighbors);
    }
}
