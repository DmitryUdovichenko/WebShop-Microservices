using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastMidofiedBy { get; set; }
        public DateTime? LastMidofiedDate { get; set; }

    }
}
