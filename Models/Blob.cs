using OOPExam.Interface;

namespace OOPExam.Models
{
    public class Blob : IBlob
    {
        private int health;
        private int delay;
        private int attackDamage;
        private int damage;
        private string attack;
        private string behavior;
        private string name;
        private int[] attackModifier;
        private int[] behaviorModifier;

        private readonly int BaseHealth;
        private readonly int BaseDamage;

        

        public string Attack { get; }
        public string Behavior { get; }
        public string Name { get; }
        public int[] AttackModifier { get; set; }
        public int[] BehaviorModifier { get; set; }
        public bool isBehaviorTriggerd { get; set; }
        public bool isBehaviorUsed = false;

        private readonly IAttackModifier attackMod;
        private readonly IBehavior behaviorMod;

        public Blob(string name,int health, int damage, string attack, string behavior,IAttackModifier attackModifier,IBehavior behaviorModifier)
        {
            Damage = damage;
            Attack = attack;
            Behavior = behavior;
            Health = health;
            Name = name;
            BaseDamage = damage;
            BaseHealth = health;
            this.attackMod = attackModifier;
            this.behaviorMod = behaviorModifier;
            this.isBehaviorTriggerd = false;
        }

        public int AttackDamage { get; set;}


        public int Damage { get; set;}

        public int Delay
        {
            get
            {
                return this.delay;
            }

            set
            {
                this.delay = value < 0 ? 0 : value;
            }
        }


        public int Health
        {
            get
            {
                return this.health;
            }

            set
            {
                this.health = value < 0 ? 0 : value;
            }
        }

        public void ApplyAttackModifier()
        {
            this.AttackModifier = attackMod.AttackMod(this.Attack, this.Damage, this.Health);
             AttackDamage = AttackModifier[1];
             Health -= AttackModifier[0];
        }

        

        public void ApplyBehaviorModifier()
        {
            if (Health<=BaseHealth/2&&!isBehaviorUsed)
            {
                this.BehaviorModifier = this.behaviorMod.Behavior(this.Behavior, this.Damage);
                this.Health += BehaviorModifier[0];
                this.Damage += BehaviorModifier[1];
                this.isBehaviorTriggerd = true;
                this.isBehaviorUsed = true;
                if (AttackModifier != null)
                {
                    if (AttackModifier[0] >= BaseHealth / 2&&BehaviorModifier[1]!=0)
                    {
                        AttackDamage += Damage;
                    }
                }
                delay++;
            }
        }

        public void Update()
        {
            if (isBehaviorTriggerd&&delay==0)
            {
                Health -= BehaviorModifier[2];
                if (this.Damage <= this.BaseDamage)
                {
                    Damage = BaseDamage;
                }
                else
                {
                    Damage -= BehaviorModifier[3];
                }
            }
            if (delay != 0)
            {
                delay--;
            }
        }

        public override string ToString()
        {
            var result = "";
            if (health != 0)
            {
                result = string.Format(
                    "Blob {0}: {1} HP, {2} Damage",
                    Name, health, Damage
                    );
            }
            else
            {
                result = string.Format(
               "Blob {0} KILLED",
               Name
              );
            }

            return result;
        }
    }
}
