using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPExam.Interface;

namespace OOPExam.Core
{
    public class Engine : IEngine,IAttack
    {

        private StringBuilder output;
        private readonly IInput reader;
        private readonly IOutput writer;
        private readonly IAttackModifier attackModifier;
        private readonly IBehavior behaviorModifier;
        private readonly IBlobFactory blobFactory;
        private readonly IBlobData blobData;
        private bool loop = true;
        public Engine(IInput reader, IOutput writer, IAttackModifier attackModifier, IBehavior behaviorModifier, IBlobFactory blobFactory, IBlobData blobData)
        {
            this.reader = reader;
            this.writer = writer;
            this.attackModifier = attackModifier;
            this.behaviorModifier = behaviorModifier;
            this.blobFactory = blobFactory;
            this.blobData = blobData;
            output = new StringBuilder();
        }

        public void Run()
        {
            while (loop)
            {
                string[] input = this.reader.ReadLine().Split();

                
                this.ExecuteCommand(input);
                this.UpdateBlobs();
            }
        }

        private void UpdateBlobs()
        {
            foreach (var blob in blobData.Blobs)
            {
                blob.Value.Update();
            }
        }

        private void ExecuteCommand(string[] input)
        {
            switch (input[0])
            {
                case "create":
                    this.CreateBlob(input[1], input[2], input[3], input[4], input[5]);
                    break;
                case "attack":
                    var attacker = blobData.Blobs[input[1]];
                    var target = blobData.Blobs[input[2]];
                    this.Attack(target,attacker);
                    break;
                case "status":
                    this.ExecuteStatusCommand();
                    break;
                case "drop":
                    writer.Print(output.ToString().Trim());
                    Environment.Exit(0);
                    break;
            }
        }

        private void ExecuteStatusCommand()
        {

            foreach (var unit in this.blobData.Blobs)
            {
                var blob = unit.Value;
                output.AppendLine(blob.ToString());
            }
        }

        private void CreateBlob(string name, string health, string damage, string Behavior, string Attack)
        {
            
            var blob = this.blobFactory.CreateBlob(name
                , Int32.Parse(health), Int32.Parse(damage),
                Behavior,
                Attack,
                this.attackModifier,this.behaviorModifier);

            blobData.AddBlob(blob);

        }

        public void Attack(IBlob target, IBlob attacker)
        {
            if (target.Health == 0 || attacker.Health == 0)
            {
                return;
            }
            attacker.ApplyAttackModifier();
            attacker.ApplyBehaviorModifier();
            int damage = attacker.AttackDamage;
            target.Health -= damage;
            target.ApplyBehaviorModifier();
        }
    }
}
