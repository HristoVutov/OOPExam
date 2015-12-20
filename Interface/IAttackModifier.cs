

namespace OOPExam.Interface
{
    public interface IAttackModifier
    {
        int[] AttackMod(string attackType, int damage, int health);
    }
}