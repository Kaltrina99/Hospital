using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Modals
{
    public class PerscribedMedicine
    {
        public int Id { get; set; }
        public Medicine Medicine { get; set; }
        public PatientReport PatientReport { get; set; }
    }
}
