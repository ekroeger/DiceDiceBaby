using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiceRoller.Models
{
    public class Die
    {
        public int Sides { get; }
        public Die(int sides)
        {
            if(sides > 1)
            {
                this.Sides = sides;
            } else
            {
                throw new Exception("Cannot create a die with less than 2 sides.");
            }
        }

        public int Roll(Random rand)
        {
            return rand.Next(1, this.Sides);
        }
    }
}
