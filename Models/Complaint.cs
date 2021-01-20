using System;
using System.Collections.Generic;

#nullable disable

namespace Trustme_.Models
{
    public partial class Complaint
    {
        public Complaint()
        {
            ComplaintComments = new HashSet<ComplaintComment>();
            ComplaintCompanies = new HashSet<ComplaintCompany>();
            ComplaintPeople = new HashSet<ComplaintPerson>();
            ComplaintReviews = new HashSet<ComplaintReview>();
        }

        public int Id { get; set; }
        public string Text { get; set; }

        public virtual ICollection<ComplaintComment> ComplaintComments { get; set; }
        public virtual ICollection<ComplaintCompany> ComplaintCompanies { get; set; }
        public virtual ICollection<ComplaintPerson> ComplaintPeople { get; set; }
        public virtual ICollection<ComplaintReview> ComplaintReviews { get; set; }
    }
}
