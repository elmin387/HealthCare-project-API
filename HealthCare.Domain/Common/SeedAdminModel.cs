using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Domain.Common
{
    public class SeedAdminModel
    {
        public SeedAdminModel()
        {
            Super = new List<string>();
        }
        public List<string> Super { get; set; }
    }
}
