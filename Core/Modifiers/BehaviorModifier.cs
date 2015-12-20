using System;

using OOPExam.Interface;

namespace OOPExam.Core.Modifiers
{
    public class BehaviorModifier : IBehavior
    {
        public int[] Behavior(string behaviorType, int damage)
        {
            int[] behaviorkArray = new int[4];
            switch (behaviorType)
            {
                case "Aggressive":
                    behaviorkArray[1] = damage;
                    behaviorkArray[2] = 0;
                    behaviorkArray[3] = 5;
                    break;
                 case "Inflated":
                    behaviorkArray[0] = 50;
                    behaviorkArray[2] = 10;
                    behaviorkArray[3] = 0;
                    break;
                default: throw new ArgumentException("Behavior dont exist.");
            }
            return behaviorkArray;
        }
    }
}
