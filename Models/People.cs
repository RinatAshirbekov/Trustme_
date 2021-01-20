using System;
using System.Collections.Generic;

#nullable disable

namespace Trustme_.Models
{
    public partial class People
    {
        public Guid Id { get; set; }
        public string Fio { get; set; }
        public Guid CompanyId { get; set; }
    }
}
