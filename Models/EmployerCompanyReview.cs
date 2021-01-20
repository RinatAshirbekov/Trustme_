using System;
using System.Collections.Generic;

#nullable disable

namespace Trustme_.Models
{
    public partial class EmployerCompanyReview
    {
        public EmployerCompanyReview()
        {
            Files = new HashSet<File>();
        }

        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Anonimus { get; set; }
        public int Evaulation { get; set; }
        public string WorkPlace { get; set; }
        public string Peoples { get; set; }
        public DateTime DateStartWork { get; set; }
        public DateTime DateStopWork { get; set; }
        public bool DateNow { get; set; }
        public string Position { get; set; }
        public string TypeOfEmployment { get; set; }
        public int ScheduleId { get; set; }
        public int Wage { get; set; }
        public int CurrencyId { get; set; }
        public string Plus { get; set; }
        public string Minus { get; set; }
        public string Description { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<File> Files { get; set; }
    }
}
