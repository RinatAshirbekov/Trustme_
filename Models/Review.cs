using System;
using System.Collections.Generic;

#nullable disable

namespace Trustme_.Models
{
    public partial class Review
    {
        public Review()
        {
            Comments = new HashSet<Comment>();
            Files = new HashSet<File>();
            ReviewLikes = new HashSet<ReviewLike>();
        }

        public Guid Id { get; set; }
        public int Evaulation { get; set; }
        public string Description { get; set; }
        public Guid? UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid PageId { get; set; }
        public Guid? CompanyId { get; set; }
        public bool IsDeleted { get; set; }
        public string UserNameTwoGis { get; set; }
        public string Minus { get; set; }
        public string Plus { get; set; }
        public int Type { get; set; }
        public bool Anonim { get; set; }

        public virtual Company Company { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<ReviewLike> ReviewLikes { get; set; }
    }
}
