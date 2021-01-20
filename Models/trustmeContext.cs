using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Trustme_.Models
{
    public partial class trustmeContext : DbContext
    {
        public trustmeContext()
        {
        }

        public trustmeContext(DbContextOptions<trustmeContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<BookMarksReview> BookMarksReviews { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<CommentDislike> CommentDislikes { get; set; }
        public virtual DbSet<CommentLike> CommentLikes { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Complaint> Complaints { get; set; }
        public virtual DbSet<ComplaintComment> ComplaintComments { get; set; }
        public virtual DbSet<ComplaintCompany> ComplaintCompanies { get; set; }
        public virtual DbSet<ComplaintPerson> ComplaintPersons { get; set; }
        public virtual DbSet<ComplaintReview> ComplaintReviews { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<CustomerCompanyReview> CustomerCompanyReviews { get; set; }
        public virtual DbSet<EmployerCompanyReview> EmployerCompanyReviews { get; set; }
        public virtual DbSet<ExecutorCompanyReview> ExecutorCompanyReviews { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<IntegrationConfiguration> IntegrationConfigurations { get; set; }
        public virtual DbSet<IntegrationLog> IntegrationLogs { get; set; }
        public virtual DbSet<Oked> Okeds { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<People> Peoples { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<ReviewLike> ReviewLikes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=trustme;Username=postgres;Password=postgres");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<BookMarksReview>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasIndex(e => e.ReviewId, "IX_Comments_ReviewId");

                entity.HasIndex(e => e.UserId, "IX_Comments_UserId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.ReviewId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<CommentDislike>(entity =>
            {
                entity.HasIndex(e => e.CommentId, "IX_CommentDislikes_CommentId");

                entity.HasIndex(e => e.UserId, "IX_CommentDislikes_UserId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.CommentDislikes)
                    .HasForeignKey(d => d.CommentId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CommentDislikes)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<CommentLike>(entity =>
            {
                entity.HasIndex(e => e.CommentId, "IX_CommentLikes_CommentId");

                entity.HasIndex(e => e.UserId, "IX_CommentLikes_UserId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.CommentLikes)
                    .HasForeignKey(d => d.CommentId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CommentLikes)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasIndex(e => e.OkedId, "IX_Companies_OkedId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Bin).HasColumnName("BIN");

                entity.Property(e => e.Kato).HasColumnName("KATO");

                entity.Property(e => e.NameEn).HasColumnName("NameEN");

                entity.Property(e => e.NameKz).HasColumnName("NameKZ");

                entity.Property(e => e.NameRu).HasColumnName("NameRU");

                entity.HasOne(d => d.Oked)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.OkedId);
            });

            modelBuilder.Entity<ComplaintComment>(entity =>
            {
                entity.HasIndex(e => e.ComplaintId, "IX_ComplaintComments_ComplaintId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Complaint)
                    .WithMany(p => p.ComplaintComments)
                    .HasForeignKey(d => d.ComplaintId);
            });

            modelBuilder.Entity<ComplaintCompany>(entity =>
            {
                entity.HasIndex(e => e.ComplaintId, "IX_ComplaintCompanies_ComplaintId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Complaint)
                    .WithMany(p => p.ComplaintCompanies)
                    .HasForeignKey(d => d.ComplaintId);
            });

            modelBuilder.Entity<ComplaintPerson>(entity =>
            {
                entity.HasIndex(e => e.ComplaintId, "IX_ComplaintPersons_ComplaintId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Complaint)
                    .WithMany(p => p.ComplaintPeople)
                    .HasForeignKey(d => d.ComplaintId);
            });

            modelBuilder.Entity<ComplaintReview>(entity =>
            {
                entity.HasIndex(e => e.ComplaintId, "IX_ComplaintReviews_ComplaintId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Complaint)
                    .WithMany(p => p.ComplaintReviews)
                    .HasForeignKey(d => d.ComplaintId);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasIndex(e => e.OrganizationId, "IX_Contacts_OrganizationId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.OrganizationId);
            });

            modelBuilder.Entity<CustomerCompanyReview>(entity =>
            {
                entity.HasIndex(e => e.CompanyId, "IX_CustomerCompanyReviews_CompanyId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.CustomerCompanyReviews)
                    .HasForeignKey(d => d.CompanyId);
            });

            modelBuilder.Entity<EmployerCompanyReview>(entity =>
            {
                entity.HasIndex(e => e.CompanyId, "IX_EmployerCompanyReviews_CompanyId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.EmployerCompanyReviews)
                    .HasForeignKey(d => d.CompanyId);
            });

            modelBuilder.Entity<ExecutorCompanyReview>(entity =>
            {
                entity.HasIndex(e => e.CompanyId, "IX_ExecutorCompanyReviews_CompanyId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.ExecutorCompanyReviews)
                    .HasForeignKey(d => d.CompanyId);
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.HasIndex(e => e.CustomerCompanyReviewsId, "IX_Files_CustomerCompanyReviewsId");

                entity.HasIndex(e => e.EmployerCompanyReviewsId, "IX_Files_EmployerCompanyReviewsId");

                entity.HasIndex(e => e.ExecutorCompanyReviewsId, "IX_Files_ExecutorCompanyReviewsId");

                entity.HasIndex(e => e.ReviewId, "IX_Files_ReviewId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.CustomerCompanyReviews)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.CustomerCompanyReviewsId);

                entity.HasOne(d => d.EmployerCompanyReviews)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.EmployerCompanyReviewsId);

                entity.HasOne(d => d.ExecutorCompanyReviews)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.ExecutorCompanyReviewsId);

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.ReviewId);
            });

            modelBuilder.Entity<IntegrationLog>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("'0001-01-01 00:00:00'::timestamp without time zone");

                entity.Property(e => e.ModifiedAt).HasDefaultValueSql("'0001-01-01 00:00:00'::timestamp without time zone");
            });

            modelBuilder.Entity<People>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Fio).HasColumnName("FIO");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasIndex(e => e.CompanyId, "IX_Reviews_CompanyId");

                entity.HasIndex(e => e.UserId, "IX_Reviews_UserId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.CompanyId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<ReviewLike>(entity =>
            {
                entity.HasIndex(e => e.ReviewId, "IX_ReviewLikes_ReviewId");

                entity.HasIndex(e => e.UserId, "IX_ReviewLikes_UserId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.ReviewLikes)
                    .HasForeignKey(d => d.ReviewId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ReviewLikes)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_Users_RoleId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Birthdate).HasDefaultValueSql("'0001-01-01 00:00:00'::timestamp without time zone");

                entity.Property(e => e.Iin).HasColumnName("IIN");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
