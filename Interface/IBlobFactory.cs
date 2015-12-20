namespace OOPExam.Interface
{
    public interface IBlobFactory
    {
        IBlob CreateBlob(string name, int health, int damage, string behaviorType, string attackType, IAttackModifier attackModifier,
            IBehavior behaviorModifier);
    }
}
