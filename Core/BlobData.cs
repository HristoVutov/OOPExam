using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPExam.Interface;

namespace OOPExam.Core
{
    public class BlobData : IBlobData
    {
        public Dictionary<string, IBlob> Blobs { get; }

        public BlobData()
        {
            Blobs = new Dictionary<string, IBlob>();
        }

        public void AddBlob(IBlob blob)
        {
            if (Blobs.ContainsKey(blob.Name))
            {
                throw new ArgumentException("Blob with that name already exists.");
            }
            else
            {
                Blobs.Add(blob.Name,blob);
            }
        }
    }
}
