using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Models
{
    public partial class VideoStreamingContext : DbContext
    {
        public VideoStreamingContext()
        {
        }

        public VideoStreamingContext(DbContextOptions<VideoStreamingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Videos> Videos { get; set; }
        public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Videos>(entity =>
            {
                entity.Property(e => e.PathName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
