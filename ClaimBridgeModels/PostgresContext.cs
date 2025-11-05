using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimBridgeModels
{
    public class PostgresContext : DbContext
    {
        public PostgresContext()
        {
        }

        public PostgresContext(DbContextOptions<PostgresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OccupationDetails> OccupationDetails { get; set; }
        public virtual DbSet<OccupationRating> OccupationRatings { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // OccupationDetails
            modelBuilder.Entity<OccupationDetails>(b =>
            {
                b.ToTable("OccupationDetails");

                b.HasKey(e => e.OccupationDetailsUId);
                b.Property(e => e.OccupationDetailsUId)
                    .HasColumnName("OccupationDetailsUId")
                    .HasMaxLength(100)
                    .IsRequired();

                b.Property(e => e.Occupation)
                    .HasColumnName("Occupation")
                    .HasMaxLength(100)
                    .IsRequired();

                b.Property(e => e.Rating)
                    .HasColumnName("Rating")
                    .HasMaxLength(50);

                b.Property(e => e.CreatedOn)
                    .HasColumnName("CreatedOn")
                    .HasColumnType("timestamp without time zone")
                    .HasDefaultValueSql("NOW()")
                    .IsRequired();

                b.Property(e => e.ModifiedOn)
                    .HasColumnName("ModifiedOn")
                    .HasColumnType("timestamp without time zone");

                b.Property(e => e.RowVersion)
                    .HasColumnName("RowVersion")
                    .HasColumnType("timestamp without time zone")
                    .IsConcurrencyToken();

                b.Property(e => e.RowStatusUId)
                    .HasColumnName("RowStatusUId");
            });

            // OccupationRating
            modelBuilder.Entity<OccupationRating>(b =>
            {
                b.ToTable("OccupationRating");


                b.HasKey(e => e.OccupationRatingUId);
                b.Property(e => e.OccupationRatingUId)
                    .HasColumnName("OccupationRatingUId")
                    .HasMaxLength(50)
                    .IsRequired();

                b.Property(e => e.Rating)
                    .HasColumnName("Rating")
                    .HasMaxLength(50)
                    .IsRequired();

                b.Property(e => e.Factor)
                    .HasColumnName("Factor")
                    .HasPrecision(18, 6)
                    .IsRequired();

                b.Property(e => e.CreatedOn)
                    .HasColumnName("CreatedOn")
                    .HasColumnType("timestamp without time zone")
                    .HasDefaultValueSql("NOW()")
                    .IsRequired();

                b.Property(e => e.ModifiedOn)
                    .HasColumnName("ModifiedOn")
                    .HasColumnType("timestamp without time zone");

                b.Property(e => e.RowVersion)
                    .HasColumnName("RowVersion")
                    .HasColumnType("timestamp without time zone")
                    .IsConcurrencyToken();

                b.Property(e => e.RowStatusUId)
                    .HasColumnName("RowStatusUId");
            });

            // User
            modelBuilder.Entity<User>(b =>
            {
                b.ToTable("User");

                b.HasKey(e => e.UserUId);
                b.Property(e => e.UserUId)
                    .HasColumnName("UserUId")
                    .IsRequired();

                b.Property(e => e.UserName)
                    .HasColumnName("UserName")
                    .HasMaxLength(100);

                b.Property(e => e.DateOfBirth)
                    .HasColumnName("DateOfBirth")
                    .HasColumnType("date");

                b.Property(e => e.Occupation)
                    .HasColumnName("Occupation")
                    .HasMaxLength(100);

                b.Property(e => e.DeathSumInsured)
                    .HasColumnName("DeathSumInsured")
                    .HasPrecision(18, 2);

                b.Property(e => e.CreatedOn)
                    .HasColumnName("CreatedOn")
                    .HasColumnType("timestamp without time zone")
                    .HasDefaultValueSql("NOW()")
                    .IsRequired();

                b.Property(e => e.ModifiedOn)
                    .HasColumnName("ModifiedOn")
                    .HasColumnType("timestamp without time zone");

                b.Property(e => e.RowVersion)
                    .HasColumnName("RowVersion")
                    .HasColumnType("timestamp without time zone")
                    .IsConcurrencyToken();

                b.Property(e => e.RowStatusUId)
                    .HasColumnName("RowStatusUId");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
