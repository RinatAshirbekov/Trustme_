using System;
using System.Collections.Generic;

#nullable disable

namespace Trustme_.Models
{
    public partial class File
    {
        public Guid Id { get; set; }
        public Guid PageId { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public Guid? CustomerCompanyReviewsId { get; set; }
        public Guid? EmployerCompanyReviewsId { get; set; }
        public Guid? ExecutorCompanyReviewsId { get; set; }
        public Guid? ReviewId { get; set; }

        public virtual CustomerCompanyReview CustomerCompanyReviews { get; set; }
        public virtual EmployerCompanyReview EmployerCompanyReviews { get; set; }
        public virtual ExecutorCompanyReview ExecutorCompanyReviews { get; set; }
        public virtual Review Review { get; set; }
    }
}
