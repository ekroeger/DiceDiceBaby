using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller.Models
{
    public class RollSet
    {
        public Queue<RollAction> RollActions { get; }

        public RollSet()
        {
            this.RollActions = new Queue<RollAction>();
        }

        public void AddRollAction(RollAction action)
        {
            this.RollActions.Enqueue(action);
        }

        public Tuple<List<int>, string> ExecuteRollSet()
        {
            List<int> result = new List<int>();
            List<int> lastResult = null;
            StringBuilder output = new StringBuilder();

            foreach(var rollAction in this.RollActions)
            {
                if (lastResult != null && !rollAction.IsReducer)
                {
                    result.AddRange(lastResult);
                }

                List<int> actionResult = rollAction.Execute(lastResult, ref output);

                if (rollAction.IsReducer)
                {
                    result.AddRange(actionResult);
                } else
                {
                    lastResult = actionResult;
                }
            }

            if(lastResult != null)
            {
                result.AddRange(lastResult);
            }

            return new Tuple<List<int>, string>(result, output.ToString());
        }
    }
}
