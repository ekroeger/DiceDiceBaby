using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller.Models
{
    public class RollSet
    {
        private Queue<RollAction> RollActions;

        private Roll Roll;

        public RollSet()
        {
            this.RollActions = new Queue<RollAction>();
            this.Roll = null;
        }

        public void AddRollAction(RollAction action)
        {
            if(this.RollActions.Count == 2)
            {
                throw new Exception("Only sum and one advantage or disadvantage allowed per roll.");
            }

            this.RollActions.Enqueue(action);
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
            RollAction sum = null;
            StringBuilder sb = new StringBuilder();

            sb.Append("Roll: ");
            sb.Append(String.Join(',', result));


            foreach(var action in this.RollActions)
            {
                //sum needs to be executed last
                if (action.IsSum)
                {
                    sum = action;
                    continue;
                }

                result = action.Execute(result, ref sb);
            }

            if(sum != null)
            {
                result = sum.Execute(result, ref sb);
            }

            return new Tuple<List<int>, string>(result, sb.ToString());
        }
    }
}
