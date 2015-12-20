using OOPExam.Interface;
using OOPExam.Models;

namespace OOPExam.Core.Factory
{
    public class BlobFactory : IBlobFactory
    {
        public IBlob CreateBlob(string name, int health, int damage, string behaviorType, string attackType,
            IAttackModifier attackModifier, IBehavior behaviorModifier)
        {
            var blob = new Blob(name, health, damage, attackType, behaviorType, attackModifier, behaviorModifier);

            return blob;
        }
    }
}
