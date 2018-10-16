using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller.Models
{
    public abstract class RollAction
    {
        public abstract bool IsSum { get; }
        public abstract List<int> Execute(List<int> values, ref StringBuilder output);
    }
}
