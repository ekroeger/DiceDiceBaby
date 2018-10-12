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
            if(sides > 0)
            {
                this.Sides = sides;
            }
        }
    }
}
