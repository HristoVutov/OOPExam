

namespace OOPExam.Interface
{
    public interface IAttackable
    {
        int Damage { get; set; }

        int AttackDamage { get; set; }

        string Attack { get; }

        string Behavior { get; }
    }
}
