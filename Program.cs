using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPExam.Core;
using OOPExam.Core.Factory;
using OOPExam.Core.Modifiers;
using OOPExam.IO;

namespace OOPExam
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new Input();
            var writer = new Output();
            var attackModifier = new AttackModifier();
            var behaviorModifier = new BehaviorModifier();
            var blobFactory = new BlobFactory();
            var blobdata = new BlobData();

            var engine = new Engine(reader,writer,attackModifier,behaviorModifier,blobFactory,blobdata);
            engine.Run();
        }
    }
}
