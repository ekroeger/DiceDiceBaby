using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller.Models
{
    public class Roll : RollAction
    {
        public List<Die> Dice { get; }

        public override bool IsReducer { get { return false; } }

        public Roll(int quantity, int sides)
        {
            if(quantity > 0)
            {
                this.Dice = new List<Die>();

                for(int i = 0; i < quantity; i++)
                {
                    var die = new Die(sides);
                    this.Dice.Add(die);
                }
            } else
            {
                throw new Exception("Cannot roll less than 1 die.");
            }
        }
        
        public override List<int> Execute(List<int> values, ref StringBuilder output)
        {
            var list = new List<int>();
            
            foreach(Die die in this.Dice)
            {
                list.Add(die.Roll());
            }

            output.Append(" Roll: ");
            output.Append(String.Join(',', list));

            return list;
        }
    }
}
