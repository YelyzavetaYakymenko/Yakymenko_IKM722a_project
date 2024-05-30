using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yakymenko_IKM722a_project
{
    [Serializable]
    internal class Buffer
    {
        public string Data { get; internal set; }
        public string Result { get; internal set; }
        public int Key { get; internal set; }
    }
}