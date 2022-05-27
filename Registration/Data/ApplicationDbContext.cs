using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Registration.Entities;

namespace Registration.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        } public ApplicationDbContext()
        
        {
        }
        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<AuthorBook> AuthorBooks { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<BookDesc> BookDescs { get; set; } = null!;
        public virtual DbSet<BookGenre> BookGenres { get; set; } = null!;
        public virtual DbSet<DownloadLink> DownloadLinks { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<ImgLink> ImgLinks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("author");

                entity.Property(e => e.AuthorId)
                    .HasColumnName("author_id");
            });
            modelBuilder.Entity<AuthorBook>(entity =>
            {
                entity.ToTable("author_book");

                entity.Property(e => e.AuthorBookId)
                    .HasColumnName("author_book_id");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.AuthorBooks);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.AuthorBooks);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("book");

                entity.Property(e => e.BookId)
                    .HasColumnName("book_id");

                entity.HasOne(d => d.Description)
                    .WithOne(p => p.Book)
                    .HasForeignKey<Book>(b => b.BookDescId);
            });
            modelBuilder.Entity<BookDesc>(entity =>
            {
                entity.ToTable("book_desc");

                entity.Property(e => e.BookDescId)
                    .HasColumnName("book_desc_id")
                    ;
            });

            modelBuilder.Entity<BookGenre>(entity =>
            {
                entity.ToTable("book_genre");

                entity.Property(e => e.BookGenreId)
                    .HasColumnName("book_genre_id")
                    ;

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookGenres);

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.BookGenres);
            });

            modelBuilder.Entity<DownloadLink>(entity =>
            {
                entity.ToTable("download_link");

                entity.Property(e => e.DownloadLinkId)
                    .HasColumnName("download_link_id")
                    ;

                entity.HasOne(d => d.BookDesc)
                    .WithMany(p => p.DownloadLinks);
            });


            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genre");

                entity.Property(e => e.GenreId)
                    .HasColumnName("genre_id")
                    ;
            });
            modelBuilder.Entity<ImgLink>(entity =>
            {
                entity.ToTable("img_link");

                entity.Property(e => e.ImgLinkId)
                    .HasColumnName("img_link_id");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.ImgLinks);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.ImgLinks)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}