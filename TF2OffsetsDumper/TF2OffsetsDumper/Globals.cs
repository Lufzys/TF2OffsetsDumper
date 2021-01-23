using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NullMemory;

namespace TF2OffsetsDumper
{
    class Globals
    {
        public static NullMemory.NullMemory mem = new NullMemory.NullMemory("hl2");
        public static NullMemory.NullMemory.Module Client = default(NullMemory.NullMemory.Module);
        public static NullMemory.NullMemory.Module Engine = default(NullMemory.NullMemory.Module);

        public static StringBuilder sb = new StringBuilder();
        public static StringBuilder cs = new StringBuilder();
    }
}
