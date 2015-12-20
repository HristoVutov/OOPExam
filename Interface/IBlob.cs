using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam.Interface
{
    public interface IBlob : IAttackable,IDestroyable
    {
        string Name { get; }

        int Delay { get; set; }

        int[] AttackModifier { get; set; }

        int[] BehaviorModifier { get; set; }

        bool isBehaviorTriggerd { get; set; }

        void ApplyAttackModifier();

        void ApplyBehaviorModifier();

        void Update();
    }
}
