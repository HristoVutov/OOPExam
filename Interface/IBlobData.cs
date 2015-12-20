using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam.Interface
{
    public interface IBlobData
    {
        Dictionary<string, IBlob> Blobs { get; }

        void AddBlob(IBlob blob);
    }
}
