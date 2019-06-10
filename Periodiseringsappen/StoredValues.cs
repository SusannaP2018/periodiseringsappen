using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periodiseringsappen
{
    [Serializable]
    class StoredValues
    {
        public decimal BigSum { get; set; }
        public decimal RemainingSum { get; set; }
    }
}
