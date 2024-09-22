using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nexgen.Domain.Entities
{
    public class BaseDbEntity
    {
        public int CreatedBy { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime? LastUpdatedDate { get; private set; }

        public void SetCreated(int createdBy, DateTime createdDate)
        {
            CreatedBy = createdBy;
            CreatedDate = createdDate;
        }

        public void SetLastUpdatedDate(DateTime? lastUpdateddate)
        {
            LastUpdatedDate = lastUpdateddate;
        }

        public BaseDbEntity(int createdBy, DateTime createdDate, DateTime? lastUpdateddate) {
            CreatedBy = createdBy;
            CreatedDate = createdDate;
            LastUpdatedDate = lastUpdateddate;
        }
        public BaseDbEntity(int createdBy, DateTime createdDate)
        {
            CreatedBy = createdBy;
            CreatedDate = createdDate;
        }
        public BaseDbEntity()
        {
            CreatedBy = 1;
            CreatedDate = DateTime.Now;
            LastUpdatedDate = null;
        }

        public BaseDbEntity(DateTime? lastUpdateddate)
        {
            LastUpdatedDate = lastUpdateddate;
        }

    }
}
