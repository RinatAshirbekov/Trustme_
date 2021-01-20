using System;
using System.Collections.Generic;

#nullable disable

namespace Trustme_.Models
{
    public partial class Organization
    {
        public Organization()
        {
            Contacts = new HashSet<Contact>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool Verified { get; set; }
        public string AddressComment { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Payments { get; set; }
        public string PostCode { get; set; }
        public string WebSite { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
