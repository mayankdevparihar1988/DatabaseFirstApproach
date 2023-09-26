using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using dbFirstApi.Models;

namespace dbFirstApi.DataConnections;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookAuthor> BookAuthors { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<User> Users { get; set; }

    /*
     * Not required will be set in Program.cs
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");
    */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("PK__Author__86516BCF4250DCC5");

            entity.Property(e => e.Phone)
                .HasDefaultValueSql("('UNKNOWN')")
                .IsFixedLength();
            entity.Property(e => e.State).IsFixedLength();
            entity.Property(e => e.Zip).IsFixedLength();
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__Book__490D1AE1BAFB46BA");

            entity.Property(e => e.PublishedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("('UNDECIDED')")
                .IsFixedLength();

            entity.HasOne(d => d.Pub).WithMany(p => p.Books).HasConstraintName("FK__Book__pub_id__5165187F");
        });

        modelBuilder.Entity<BookAuthor>(entity =>
        {
            entity.HasOne(d => d.Author).WithMany(p => p.BookAuthors).HasConstraintName("FK__BookAutho__autho__52593CB8");

            entity.HasOne(d => d.Book).WithMany(p => p.BookAuthors).HasConstraintName("FK__BookAutho__book___534D60F1");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.JobId).HasName("PK__Job__6E32B6A52A6B69F1");

            entity.Property(e => e.JobDesc).HasDefaultValueSql("('New Position - title not formalized yet')");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.PubId).HasName("PK__Publishe__2515F22210AE97D9");

            entity.Property(e => e.Country).HasDefaultValueSql("('USA')");
            entity.Property(e => e.State).IsFixedLength();
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasOne(d => d.User).WithMany(p => p.RefreshTokens).HasConstraintName("FK__RefreshTo__user___5441852A");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__760965CCD0CFB36D");

            entity.Property(e => e.RoleDesc).HasDefaultValueSql("('New Position - title not formalized yet')");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.SaleId).HasName("PK_Sale2");

            entity.Property(e => e.StoreId).IsFixedLength();

            entity.HasOne(d => d.Book).WithMany(p => p.Sales).HasConstraintName("FK__Sale__book_id__5535A963");

            entity.HasOne(d => d.Store).WithMany(p => p.Sales).HasConstraintName("FK__Sale__store_id__5629CD9C");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.StoreId).HasName("UPK_storeid");

            entity.Property(e => e.StoreId).IsFixedLength();
            entity.Property(e => e.State).IsFixedLength();
            entity.Property(e => e.Zip).IsFixedLength();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId)
                .HasName("PK_user_id_2")
                .IsClustered(false);

            entity.Property(e => e.HireDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.MiddleName).IsFixedLength();
            entity.Property(e => e.PubId).HasDefaultValueSql("((1))");
            entity.Property(e => e.RoleId).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Pub).WithMany(p => p.Users).HasConstraintName("FK__User__pub_id__5812160E");

            entity.HasOne(d => d.Role).WithMany(p => p.Users).HasConstraintName("FK__User__role_id__571DF1D5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
