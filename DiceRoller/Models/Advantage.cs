using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller.Models
{
    public class Advantage : RollAction
    {
        public override bool IsSum { get { return false; } }

        public override List<int> Execute(List<int> values, ref StringBuilder output)
        {
            var min = values.Min();
            values.Remove(min);

            output.Append(" Dropped: ");
            output.Append(min);
            output.Append(" => ");
            output.Append(String.Join(',', values));

            return values;
        }
    }
}
