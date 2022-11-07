using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGB
{

    public class Rootobject
    {
        public Class1[] Property1 { get; set; }
    }

    public class Class1
    {
        public string msisdn { get; set; }
        public int act { get; set; }
        public int cat { get; set; }
        public int cid { get; set; }
        public int lac { get; set; }
        public int mcc { get; set; }
        public int mnc { get; set; }
        public string org { get; set; }
        public string cod { get; set; }
        public string name { get; set; }
        public bool fix { get; set; }
        public bool ign { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
        public int dir { get; set; }
        public float spd { get; set; }
        public bool his { get; set; }
        public int alt { get; set; }
        public int bl { get; set; }
        public int hmt { get; set; }
        public int dis { get; set; }
        public int gsm { get; set; }
    }

}
