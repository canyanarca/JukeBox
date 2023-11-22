using JukeBox.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JukeBox.Models.Context
{
    public class JukeBoxContext : DbContext
    {
        public JukeBoxContext(DbContextOptions<JukeBoxContext> options) : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                    .Property(s => s.Name)
                    .HasColumnName("Name")
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValue("None");


            modelBuilder.Entity<Game>()
                .Property(s => s.Description)
                .HasColumnType("text")
                .HasMaxLength(1000)
                .HasDefaultValue("There is no description.");

            modelBuilder.Entity<Game>()
                .Property(s => s.Image)
                .HasColumnName("Image")
                .HasDefaultValue("Image not provided");

            modelBuilder.Entity<Category>()
                    .Property(c => c.Name)
                    .HasColumnName("Name")
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValue("None");

            modelBuilder.Entity<User>()
                .Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(16);

            modelBuilder.Entity<User>()
                .Property(u => u.UserEmail)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(u => u.UserPassword)
                .IsRequired()
                .HasMaxLength(55)
                .IsUnicode(true);

            modelBuilder.Entity<Comment>()
                .Property(c => c.CommentText)
                .HasMaxLength(500);

            modelBuilder.Entity<Comment>()
                .Property(c => c.UserName)
                .HasMaxLength(55);
                
            modelBuilder.Entity<User>()
                    .HasMany(u => u.Games)
                    .WithOne(g => g.User)
                    .HasForeignKey(g => g.UserID);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.User)
                .WithMany(u => u.Games)
                .HasForeignKey(g => g.UserID);

            modelBuilder.Entity<GameCategory>()
                .HasKey(gc => new { gc.GameID, gc.CategoryID });

            modelBuilder.Entity<GameCategory>()
                .HasOne(gc => gc.Game)
                .WithMany(g => g.GameCategories)
                .HasForeignKey(gc => gc.GameID);

            modelBuilder.Entity<GameCategory>()
                .HasOne(gc => gc.Category)
                .WithMany(c => c.GameCategories)
                .HasForeignKey(gc => gc.CategoryID);

            modelBuilder.Entity<Game>()
                .Property(g => g.UrlName)
                .HasMaxLength(100);

            modelBuilder.Entity<Comment>()
                .Property(c => c.UrlName)
                .HasMaxLength(100);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<AuthRole> AuthRoles { get; set; }

        public DbSet<Comment> Comments { get; set; }

    }
}
