using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller.Models
{
    public class Disadvantage : RollAction
    {
        public override bool IsSum { get { return false; } }

        public override List<int> Execute(List<int> values, ref StringBuilder output)
        {
            var max = values.Max();
            values.Remove(max);

            output.Append(" Dropped: ");
            output.Append(max);
            output.Append(" => ");
            output.Append(String.Join(',', values));

            return values;
        }
    }
}
