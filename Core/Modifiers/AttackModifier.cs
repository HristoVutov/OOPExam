using System;

using OOPExam.Interface;

namespace OOPExam.Core.Modifiers
{
    public class AttackModifier : IAttackModifier
    {
        public int[] AttackMod(string attackType, int damage, int health)
        {
            int[] attackArray = new int[4];
            switch (attackType)
            {
                case "Blobplode":
                    attackArray[0] = health / 2;
                    if (attackArray[0] <= 0)
                    {
                        attackArray[0] = 1;
                    }
                    attackArray[1] = damage * 2;
                    break;
                case "PutridFart":
                    attackArray[0] = 0;
                    attackArray[1] = damage;
                    break;
                default: throw new ArgumentException("Attack dont exist.");
            }

            return attackArray;
        }
    }
}
