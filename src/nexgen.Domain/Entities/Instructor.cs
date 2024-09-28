using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nexgen.Domain.Entities
{
    public class Instructor : BaseDbEntity
    {
        public int Id { get; private set; }
        public string InstructorName { get; private set; }
        public string InstructorImage { get; private set; }

        public DateTime MembershipStartDate { get; private set; }
        public DateTime MembershipEndDate { get; private set; }

        public bool IsAuthurized { get; private set; }
    }
}
