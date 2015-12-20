using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPExam.Interface;

namespace OOPExam.IO
{
    public class Input : IInput
    {
        public string ReadLine()
        {
            var line = Console.ReadLine();

            return line;
        }
    }
}
