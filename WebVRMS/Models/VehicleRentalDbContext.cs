using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebVRMS.Models;

public partial class VehicleRentalDbContext : DbContext
{
    public VehicleRentalDbContext()
    {
    }

    public VehicleRentalDbContext(DbContextOptions<VehicleRentalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Rental> Rentals { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-AT3J2FH2;Database=VehicleRentalDb;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PK__Invoices__D796AAD5B533E0F5");

            entity.HasIndex(e => e.Riid, "RentID_InvID").IsUnique();

            entity.Property(e => e.InvoiceId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("InvoiceID");
            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.InvoiceDate).HasColumnType("datetime");
            entity.Property(e => e.Riid)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("RIID");

            entity.HasOne(d => d.Ri).WithOne(p => p.Invoice)
                .HasForeignKey<Invoice>(d => d.Riid)
                .HasConstraintName("FK__Invoices__RIID__412EB0B6");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__9B556A586E16F365");

            entity.HasIndex(e => e.Ipid, "InvID_PayID").IsUnique();

            entity.Property(e => e.PaymentId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PaymentID");
            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.Ipid)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IPID");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");

            entity.HasOne(d => d.Ip).WithOne(p => p.Payment)
                .HasForeignKey<Payment>(d => d.Ipid)
                .HasConstraintName("FK__Payments__IPID__4222D4EF");
        });

        modelBuilder.Entity<Rental>(entity =>
        {
            entity.HasKey(e => e.RentalId).HasName("PK__Rentals__9700596361F74962");

            entity.Property(e => e.RentalId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("RentalID");
            entity.Property(e => e.RentalDate).HasColumnType("datetime");
            entity.Property(e => e.ReturnDate).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(10);
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.VehicleId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("VehicleID");

            entity.HasOne(d => d.User).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rentals__UserID__4316F928");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.VehicleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rentals__Vehicle__440B1D61");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACB6C3BDB4");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.NoTelp)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(8)
                .IsFixedLength();
            entity.Property(e => e.Username).HasMaxLength(10);
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.VehicleId).HasName("PK__Vehicles__476B54B2350E4FED");

            entity.Property(e => e.VehicleId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("VehicleID");
            entity.Property(e => e.Make).HasMaxLength(50);
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.RentalPrice).HasColumnType("money");
            entity.Property(e => e.Year)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
