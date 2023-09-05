using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Modals
{
    public class Insurance
    {
        public int Id { get; set; }
        public string PolicyNumber { get; set; }
        public string StartData { get; set; }
        public string EndData { get; set; }
        public ICollection<Bill> Bills { get; set; }
    }
}
