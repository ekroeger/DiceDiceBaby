using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller.Models
{
    public class RollSet
    {
        private Roll Roll;
        public bool hasSum;
        public bool hasAdvantage;
        public bool hasDisadvantage;

        public RollSet()
        {
            this.hasSum = false;
            this.hasAdvantage = false;
            this.hasDisadvantage = false;
            this.Roll = null;
        }

        public void SetRoll(Roll roll)
        {
            if(this.Roll != null)
            {
                throw new Exception("Only one group of dice allowed per roll.");
            }

            this.Roll = roll;
        }

        public Tuple<List<int>, string> ExecuteRollSet()
        {
            if(this.Roll == null)
            {
                throw new Exception("No dice to be rolled.");
            }

            var result = this.Roll.Execute();
            StringBuilder sb = new StringBuilder();

            sb.Append("Roll: ");
            sb.Append(String.Join(',', result));

            if (hasAdvantage)
            {
                var min = result.Min();
                result.Remove(min);

                sb.Append(" Dropped: ");
                sb.Append(min);
                sb.Append(" => ");
                sb.Append(String.Join(',', result));
            }

            if (hasDisadvantage)
            {
                var max = result.Max();
                result.Remove(max);

                sb.Append(" Dropped: ");
                sb.Append(max);
                sb.Append(" => ");
                sb.Append(String.Join(',', result));
            }

            if (hasSum)
            {
                var sum = result.Sum();

                sb.Append(" => Sum: ");
                sb.Append(sum);

                result = new List<int> { sum };
            }

            return new Tuple<List<int>, string>(result, sb.ToString());
        }
    }
}
