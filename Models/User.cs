using System;
using System.Collections.Generic;

#nullable disable

namespace Trustme_.Models
{
    public partial class User
    {
        public User()
        {
            CommentDislikes = new HashSet<CommentDislike>();
            CommentLikes = new HashSet<CommentLike>();
            Comments = new HashSet<Comment>();
            ReviewLikes = new HashSet<ReviewLike>();
            Reviews = new HashSet<Review>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public int TypeUser { get; set; }
        public long TrustPoint { get; set; }
        public DateTime CreatedAt { get; set; }
        public int RoleId { get; set; }
        public string Phone { get; set; }
        public bool PhoneVerification { get; set; }
        public string VerificationCode { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public long Reputation { get; set; }
        public string Address { get; set; }
        public DateTime Birthdate { get; set; }
        public string Citizenship { get; set; }
        public string City { get; set; }
        public string Education { get; set; }
        public int Gender { get; set; }
        public string Hobby { get; set; }
        public string Photo { get; set; }
        public string Profession { get; set; }
        public int UserStatus { get; set; }
        public string WorkExperience { get; set; }
        public string Iin { get; set; }
        public bool VerifiedIin { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<CommentDislike> CommentDislikes { get; set; }
        public virtual ICollection<CommentLike> CommentLikes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<ReviewLike> ReviewLikes { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
