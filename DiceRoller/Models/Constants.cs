using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiceRoller.Models
{
    public sealed class Constants
    {
        public const string Sum = "sum";

        public const string Advantage = "adv";

        public const string Disadvantage = "dis";

        public static readonly HashSet<string> Actions = new HashSet<string> { Sum, Advantage, Disadvantage };
    }
}
