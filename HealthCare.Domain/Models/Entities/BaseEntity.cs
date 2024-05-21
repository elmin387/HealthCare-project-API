using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Domain.Models.Entities
{
    public class BaseEntity
    {
        public DateTime? DateCreated { get; set; }
        public string? UserCreatedId { get; set; }
        public DateTime? DateModified { get; set; }
        public string? UserModifiedId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
