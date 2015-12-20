using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPExam.Interface;

namespace OOPExam.IO
{
    public class Output : IOutput
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
