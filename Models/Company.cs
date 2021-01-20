using System;
using System.Collections.Generic;

#nullable disable

namespace Trustme_.Models
{
    public partial class Company
    {
        public Company()
        {
            CustomerCompanyReviews = new HashSet<CustomerCompanyReview>();
            EmployerCompanyReviews = new HashSet<EmployerCompanyReview>();
            ExecutorCompanyReviews = new HashSet<ExecutorCompanyReview>();
            Reviews = new HashSet<Review>();
        }
        public Guid Id { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public string Bin { get; set; }
        public string NameRu { get; set; }
        public string NameKz { get; set; }
        public string NameEn { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string Kato { get; set; }
        public DateTime DateReg { get; set; }
        public double Rating { get; set; }
        public long OkedId { get; set; }
        public int VisitCount { get; set; }
        public double CustomerRating { get; set; }
        public double EmployerRating { get; set; }
        public double ExecutorRating { get; set; }

        public virtual Oked Oked { get; set; }
        public virtual ICollection<CustomerCompanyReview> CustomerCompanyReviews { get; set; }
        public virtual ICollection<EmployerCompanyReview> EmployerCompanyReviews { get; set; }
        public virtual ICollection<ExecutorCompanyReview> ExecutorCompanyReviews { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
