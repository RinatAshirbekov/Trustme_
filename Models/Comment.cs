using System;
using System.Collections.Generic;

#nullable disable

namespace Trustme_.Models
{
    public partial class Comment
    {
        public Comment()
        {
            CommentDislikes = new HashSet<CommentDislike>();
            CommentLikes = new HashSet<CommentLike>();
        }

        public Guid Id { get; set; }
        public Guid ReviewId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid? UserId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Review Review { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<CommentDislike> CommentDislikes { get; set; }
        public virtual ICollection<CommentLike> CommentLikes { get; set; }
    }
}
