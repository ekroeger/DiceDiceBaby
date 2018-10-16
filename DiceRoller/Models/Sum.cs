using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller.Models
{
    public class Sum : RollAction
    {
        public override bool IsReducer { get { return true; } }

        public override List<int> Execute(List<int> values, ref StringBuilder output)
        {
            var sum = values.Sum();

            output.Append(" => Sum: ");
            output.Append(sum);

            return new List<int> { sum };
        }
    }
}
