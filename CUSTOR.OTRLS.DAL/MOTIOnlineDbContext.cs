using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CUSTOR.OTRLS.Core
{
    public partial class OTRLSDbContext : DbContext
    {
        public OTRLSDbContext()
        {
        }

        public OTRLSDbContext(DbContextOptions<OTRLSDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kebele> Kebele { get; set; }
        public virtual DbSet<LookUpType> LookUpType { get; set; }
        public virtual DbSet<Lookup> Lookup { get; set; }
        public virtual DbSet<Manager> Manager { get; set; }
        public virtual DbSet<Nationality> Nationality { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Woreda> Woreda { get; set; }
        public virtual DbSet<Zone> Zone { get; set; }
        public virtual DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            //modelBuilder.Entity<Address>(entity =>
            //{
            //    entity.Property(e => e.CellPhoneNo).HasMaxLength(50);

            //    entity.Property(e => e.CreatedBy).HasMaxLength(50);

            //    entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.CreatedUserId).HasMaxLength(256);

            //    entity.Property(e => e.Email).HasMaxLength(50);

            //    entity.Property(e => e.Fax).HasMaxLength(50);

            //    entity.Property(e => e.HouseNo).HasMaxLength(50);

            //    entity.Property(e => e.IsActive)
            //        .IsRequired()
            //        .HasDefaultValueSql("((1))");

            //    entity.Property(e => e.KebeleId).HasMaxLength(50);

            //    entity.Property(e => e.ObjectId).HasDefaultValueSql("(newid())");

            //    entity.Property(e => e.OtherAddress).HasMaxLength(1000);

            //    entity.Property(e => e.Pobox).HasMaxLength(50);

            //    entity.Property(e => e.RegionId).HasMaxLength(50);

            //    entity.Property(e => e.Remark).HasMaxLength(1000);

            //    entity.Property(e => e.SpecificAreaName).HasMaxLength(250);

            //    entity.Property(e => e.TeleNo).HasMaxLength(50);

            //    entity.Property(e => e.TownId).HasMaxLength(50);

            //    entity.Property(e => e.UpdatedBy).HasMaxLength(50);

            //    entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.UpdatedUserId).HasMaxLength(256);

            //    entity.Property(e => e.WoredaId).HasMaxLength(50);

            //    entity.Property(e => e.ZoneId).HasMaxLength(50);

            //    entity.HasOne(d => d.Kebele)
            //        .WithMany(p => p.Address)
            //        .HasForeignKey(d => d.KebeleId)
            //        .HasConstraintName("FK_Address_Kebele");

            //    entity.HasOne(d => d.Region)
            //        .WithMany(p => p.Address)
            //        .HasForeignKey(d => d.RegionId);

            //    entity.HasOne(d => d.Woreda)
            //        .WithMany(p => p.Address)
            //        .HasForeignKey(d => d.WoredaId)
            //        .HasConstraintName("FK_Address_Woreda");

            //    entity.HasOne(d => d.Zone)
            //        .WithMany(p => p.Address)
            //        .HasForeignKey(d => d.ZoneId);
            //});

            //modelBuilder.Entity<Kebele>(entity =>
            //{
            //    entity.Property(e => e.KebeleId)
            //        .HasMaxLength(50)
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.CreatedBy)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.CreatedUserId)
            //        .IsRequired()
            //        .HasMaxLength(256);

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(250);

            //    entity.Property(e => e.DescriptionEnglish)
            //        .IsRequired()
            //        .HasMaxLength(250);

            //    entity.Property(e => e.IsActive)
            //        .IsRequired()
            //        .HasDefaultValueSql("((1))");

            //    entity.Property(e => e.UpdatedBy).HasMaxLength(50);

            //    entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.UpdatedUserId).HasMaxLength(256);

            //    entity.Property(e => e.WoredaId)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.HasOne(d => d.Woreda)
            //        .WithMany(p => p.Kebele)
            //        .HasForeignKey(d => d.WoredaId)
            //        .OnDelete(DeleteBehavior.ClientSetNull);
            //});

            //modelBuilder.Entity<LookUpType>(entity =>
            //{
            //    entity.Property(e => e.AfanOromo).HasMaxLength(150);

            //    entity.Property(e => e.Afar).HasMaxLength(150);

            //    entity.Property(e => e.Amharic)
            //        .IsRequired()
            //        .HasMaxLength(150);

            //    entity.Property(e => e.CreatedBy)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.CreatedUserId)
            //        .IsRequired()
            //        .HasMaxLength(256);

            //    entity.Property(e => e.Description).HasMaxLength(150);

            //    entity.Property(e => e.English)
            //        .IsRequired()
            //        .HasMaxLength(150);

            //    entity.Property(e => e.Somali).HasMaxLength(150);

            //    entity.Property(e => e.Tigrigna).HasMaxLength(150);

            //    entity.Property(e => e.UpdatedBy).HasMaxLength(50);

            //    entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.UpdatedUserId).HasMaxLength(256);
            //});

            //modelBuilder.Entity<Lookup>(entity =>
            //{
            //    entity.Property(e => e.AfanOromo).HasMaxLength(150);

            //    entity.Property(e => e.Afar).HasMaxLength(150);

            //    entity.Property(e => e.Amharic)
            //        .IsRequired()
            //        .HasMaxLength(150);

            //    entity.Property(e => e.CreatedBy)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.CreatedUserId)
            //        .IsRequired()
            //        .HasMaxLength(256);

            //    entity.Property(e => e.Description).HasMaxLength(150);

            //    entity.Property(e => e.English)
            //        .IsRequired()
            //        .HasMaxLength(150);

            //    entity.Property(e => e.Somali).HasMaxLength(150);

            //    entity.Property(e => e.Tigrigna).HasMaxLength(150);

            //    entity.Property(e => e.UpdatedBy).HasMaxLength(50);

            //    entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.UpdatedUserId).HasMaxLength(256);

            //    entity.HasOne(d => d.LookUpType)
            //        .WithMany(p => p.Lookup)
            //        .HasForeignKey(d => d.LookUpTypeId)
            //        .HasConstraintName("FK_Lookup_LookUpType");
            //});

            //modelBuilder.Entity<Manager>(entity =>
            //{
            //    entity.Property(e => e.CreatedBy)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.CreatedUserId)
            //        .IsRequired()
            //        .HasMaxLength(256);

            //    entity.Property(e => e.FatherName)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.FatherNameEng)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.FatherNameSort).HasMaxLength(100);

            //    entity.Property(e => e.FatherNameSoundx).HasMaxLength(100);

            //    entity.Property(e => e.FirstName)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.FirstNameEng)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.FirstNameSort).HasMaxLength(100);

            //    entity.Property(e => e.FirstNameSoundx).HasMaxLength(100);

            //    entity.Property(e => e.GrandName)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.GrandNameEng)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.GrandNameSort).HasMaxLength(100);

            //    entity.Property(e => e.GrandNameSoundx).HasMaxLength(100);

            //    entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

            //    entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

            //    entity.Property(e => e.Remark).HasMaxLength(100);

            //    entity.Property(e => e.Tin).HasMaxLength(100);

            //    entity.Property(e => e.UpdatedBy).HasMaxLength(50);

            //    entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.UpdatedUserId).HasMaxLength(256);
            //});

            //modelBuilder.Entity<Nationality>(entity =>
            //{
            //    entity.Property(e => e.AfanOromo).HasMaxLength(150);

            //    entity.Property(e => e.Afar).HasMaxLength(150);

            //    entity.Property(e => e.Amharic)
            //        .IsRequired()
            //        .HasMaxLength(150);

            //    entity.Property(e => e.CreatedBy)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.CreatedUserId)
            //        .IsRequired()
            //        .HasMaxLength(256);

            //    entity.Property(e => e.Description).HasMaxLength(150);

            //    entity.Property(e => e.English)
            //        .IsRequired()
            //        .HasMaxLength(150);

            //    entity.Property(e => e.Somali).HasMaxLength(150);

            //    entity.Property(e => e.Tigrigna).HasMaxLength(150);

            //    entity.Property(e => e.UpdatedBy).HasMaxLength(50);

            //    entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.UpdatedUserId).HasMaxLength(256);
            //});

            //modelBuilder.Entity<Region>(entity =>
            //{
            //    entity.Property(e => e.RegionId)
            //        .HasMaxLength(50)
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.CreatedBy).HasMaxLength(50);

            //    entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.CreatedUserId).HasMaxLength(256);

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(250);

            //    entity.Property(e => e.DescriptionEnglish)
            //        .IsRequired()
            //        .HasMaxLength(250);

            //    entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

            //    entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

            //    entity.Property(e => e.UpdatedBy).HasMaxLength(50);

            //    entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.UpdatedUserId).HasMaxLength(256);
            //});

            //modelBuilder.Entity<Woreda>(entity =>
            //{
            //    entity.Property(e => e.WoredaId)
            //        .HasMaxLength(50)
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.CreatedBy).HasMaxLength(50);

            //    entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.CreatedUserId).HasMaxLength(256);

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(250);

            //    entity.Property(e => e.DescriptionEnglish)
            //        .IsRequired()
            //        .HasMaxLength(250);

            //    entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

            //    entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

            //    entity.Property(e => e.UpdatedBy).HasMaxLength(50);

            //    entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.UpdatedUserId).HasMaxLength(256);

            //    entity.Property(e => e.ZoneId)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.HasOne(d => d.Zone)
            //        .WithMany(p => p.Woreda)
            //        .HasForeignKey(d => d.ZoneId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_Woreda_Zone");
            //});

            //modelBuilder.Entity<Zone>(entity =>
            //{
            //    entity.Property(e => e.ZoneId)
            //        .HasMaxLength(50)
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.CreatedBy).HasMaxLength(50);

            //    entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.CreatedUserId).HasMaxLength(256);

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(250);

            //    entity.Property(e => e.DescriptionEnglish)
            //        .IsRequired()
            //        .HasMaxLength(250);

            //    entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

            //    entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

            //    entity.Property(e => e.RegionId)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.UpdatedBy).HasMaxLength(50);

            //    entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.UpdatedUserId).HasMaxLength(256);

            //    entity.HasOne(d => d.Region)
            //        .WithMany(p => p.Zone)
            //        .HasForeignKey(d => d.RegionId)
            //        .OnDelete(DeleteBehavior.ClientSetNull);
            //});

            base.OnModelCreating(modelBuilder);
        }
    }
}
