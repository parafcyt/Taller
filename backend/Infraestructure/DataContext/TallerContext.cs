using System;
using System.Collections.Generic;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infraestructure.DataContext
{
    public partial class TallerContext : DbContext
    {
        //public TallerContext()
        //{
        //}

        public TallerContext(DbContextOptions<TallerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookingType> BookingTypes { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Destination> Destinations { get; set; } = null!;
        public virtual DbSet<DestinationPhoto> DestinationPhotos { get; set; } = null!;
        public virtual DbSet<Excursion> Excursions { get; set; } = null!;
        public virtual DbSet<Favorite> Favorites { get; set; } = null!;
        public virtual DbSet<Hotel> Hotels { get; set; } = null!;
        public virtual DbSet<HotelPhoto> HotelPhotos { get; set; } = null!;
        public virtual DbSet<Offer> Offers { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Origin> Origins { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductExcursion> ProductExcursions { get; set; } = null!;
        public virtual DbSet<ProductTransport> ProductTransports { get; set; } = null!;
        public virtual DbSet<RatingScale> RatingScales { get; set; } = null!;
        public virtual DbSet<Transport> Transports { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS;Database=Taller;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingType>(entity =>
            {
                entity.ToTable("BookingType");

                entity.Property(e => e.BookingTypeId).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasMaxLength(350)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.Dni)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DNI");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Destination>(entity =>
            {
                entity.ToTable("Destination");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(350)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DestinationPhoto>(entity =>
            {
                entity.ToTable("DestinationPhoto");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .IsUnicode(false)
                    .HasColumnName("URL");

                entity.HasOne(d => d.Destination)
                    .WithMany(p => p.DestinationPhotos)
                    .HasForeignKey(d => d.DestinationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Destinati__Desti__37A5467C");
            });

            modelBuilder.Entity<Excursion>(entity =>
            {
                entity.ToTable("Excursion");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.HasOne(d => d.Destination)
                    .WithMany(p => p.Excursions)
                    .HasForeignKey(d => d.DestinationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Excursion__Desti__3A81B327");
            });

            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.ToTable("Favorite");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Favorite__Custom__4E88ABD4");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Favorite__Produc__4D94879B");
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.ToTable("Hotel");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.HasOne(d => d.Destination)
                    .WithMany(p => p.Hotels)
                    .HasForeignKey(d => d.DestinationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Hotel__Destinati__31EC6D26");
            });

            modelBuilder.Entity<HotelPhoto>(entity =>
            {
                entity.ToTable("HotelPhoto");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .IsUnicode(false)
                    .HasColumnName("URL");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.HotelPhotos)
                    .HasForeignKey(d => d.HotelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HotelPhot__Hotel__34C8D9D1");
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.ToTable("Offer");

                entity.Property(e => e.BannerText)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("date");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Offers)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Offer__ProductId__4AB81AF0");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DateOrder).HasColumnType("date");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__CustomerI__5EBF139D");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__ProductId__5DCAEF64");

                entity.HasOne(d => d.RatingScale)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.RatingScaleId)
                    .HasConstraintName("FK__Order__RatingSca__5FB337D6");
            });

            modelBuilder.Entity<Origin>(entity =>
            {
                entity.ToTable("Origin");

                entity.Property(e => e.Name)
                    .HasMaxLength(350)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.DepartureDate).HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentationDes)
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.ReturnDate).HasColumnType("date");

                entity.HasOne(d => d.BookingType)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BookingTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product__Booking__3D5E1FD2");

                entity.HasOne(d => d.Destination)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.DestinationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product__Destina__3F466844");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.HotelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product__HotelId__403A8C7D");

                entity.HasOne(d => d.Origin)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.OriginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product__OriginI__3E52440B");
            });

            modelBuilder.Entity<ProductExcursion>(entity =>
            {
                entity.ToTable("ProductExcursion");

                entity.HasOne(d => d.Excursion)
                    .WithMany(p => p.ProductExcursions)
                    .HasForeignKey(d => d.ExcursionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductEx__Excur__47DBAE45");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductExcursions)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductEx__Produ__46E78A0C");
            });

            modelBuilder.Entity<ProductTransport>(entity =>
            {
                entity.ToTable("ProductTransport");

                entity.Property(e => e.Information)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductTransports)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductTr__Produ__4316F928");

                entity.HasOne(d => d.Transport)
                    .WithMany(p => p.ProductTransports)
                    .HasForeignKey(d => d.TransportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductTr__Trans__440B1D61");
            });

            modelBuilder.Entity<RatingScale>(entity =>
            {
                entity.ToTable("RatingScale");

                entity.Property(e => e.RatingScaleId).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasMaxLength(350)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Transport>(entity =>
            {
                entity.ToTable("Transport");

                entity.Property(e => e.Name)
                    .HasMaxLength(350)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
