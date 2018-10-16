using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller.Models
{
    public class Roll
    {
        private List<Die> Dice;

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
        
        public List<int> Execute()
        {
            var list = new List<int>();
            
            foreach(Die die in this.Dice)
            {
                list.Add(die.Roll());
            }

            return list;
        }
    }
}
