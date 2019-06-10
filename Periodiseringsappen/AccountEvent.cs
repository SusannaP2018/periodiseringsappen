using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periodiseringsappen
{
    [Serializable]
    class AccountEvent
    {
        public string EventName { get; set; }
        public DateTime? When { get; set; }
        public decimal Value { get; set; }
        public string FormattedDate { get; set; }
        
    }
}
