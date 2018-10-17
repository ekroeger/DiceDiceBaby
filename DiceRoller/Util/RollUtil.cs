using DiceRoller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller.Util
{
    public static class RollUtil
    {
        public static bool IsAction(string element)
        {
            return Constants.Actions.Contains(element);
        }

        public static void SetAction(string action, ref RollSet rollSet)
        {
            switch(action)
            {
                case Constants.Sum:
                    rollSet.hasSum = true;
                    break;

                case Constants.Advantage:
                    if (rollSet.hasDisadvantage)
                    {
                        throw new Exception("Cannot have both advantage and disadvantage.");
                    }

                    rollSet.hasAdvantage = true;
                    break;

                case Constants.Disadvantage:
                    if (rollSet.hasAdvantage)
                    {
                        throw new Exception("Cannot have both advantage and disadvantage.");
                    }

                    rollSet.hasDisadvantage = true;
                    break;
            }
        }

        public static RollSet CreateRollSetFromInput(string input)
        {
            string[] elements = input.ToLower().Trim().Split(' ');

            RollSet set = new RollSet();

            foreach(var element in elements)
            {
                if (IsAction(element))
                {
                    SetAction(element, ref set);
                } else
                {
                    if (!element.Contains('d'))
                    {
                        throw new Exception("Invalid roll command.");
                    }

                    var subElements = element.Split('d');

                    //not in format XdY
                    if(subElements.Length != 2)
                    {
                        throw new Exception("Invalid roll command.");
                    }

                    var quantity = Int32.Parse(subElements[0]);
                    var sides = Int32.Parse(subElements[1]);

                    var roll = new Roll(quantity, sides);
                    set.SetRoll(roll);
                }
            }

            return set;
        }

        public static List<RollSet> ProcessInput(string input)
        {
            var sets = input.Split(',');

            List<RollSet> result = new List<RollSet>();

            foreach(var setString in sets)
            {
                var set = CreateRollSetFromInput(setString);
                result.Add(set);
            }

            return result;
        }

        public static string ExecuteResults(List<RollSet> sets)
        {
            StringBuilder sb = new StringBuilder();

            foreach(var rollSet in sets)
            {
                var result = rollSet.ExecuteRollSet();
                sb.Append(result.Item2);

                if (!rollSet.Equals(sets.Last()))
                {
                    sb.Append(" | ");
                }
            }

            return sb.ToString();
        }
    }
}
