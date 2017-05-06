using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozgovoi1_9
{
    class LifeEvolutionStrategy : IEvolutionStrategy
    {
        private static LifeEvolutionStrategy instance = new LifeEvolutionStrategy();
        public static LifeEvolutionStrategy Instance
        {
            get { return instance; }
        }

        private LifeEvolutionStrategy()
        {
        }

        public bool HasSurvived(byte neighbors)
        {
            int count = 0;
            while (neighbors > 0)
            {
                count += neighbors & 1;
                neighbors >>= 1;
            }

            return 2 <= count && count <= 3;
        }

        public bool HasBorn(byte neighbors)
        {
            int count = 0;
            while (neighbors > 0)
            {
                count += neighbors & 1;
                neighbors >>= 1;
            }

            return count == 3;
        }
    }
}
