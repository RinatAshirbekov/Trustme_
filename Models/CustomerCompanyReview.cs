using System;
using System.Collections.Generic;

#nullable disable

namespace Trustme_.Models
{
    public partial class CustomerCompanyReview
    {
        public CustomerCompanyReview()
        {
            Files = new HashSet<File>();
        }

        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Evaulation { get; set; }
        public bool Anonim { get; set; }
        public string Patronymic { get; set; }
        public string Plus { get; set; }
        public string Minus { get; set; }
        public int CurrencyId { get; set; }
        public string[] ServiceName { get; set; }
        public DateTime StartCooperation { get; set; }
        public DateTime StopCooperation { get; set; }
        public string Period { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<File> Files { get; set; }
    }
}
