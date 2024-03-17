using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public partial class apiContext : DbContext
{
    public apiContext()
    {
    }

    public apiContext(DbContextOptions<apiContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
	
        optionsBuilder.UseNpgsql("Host=localhost;Database=Gallery;Username=postgres;Password=root;");
        optionsBuilder.UseLazyLoadingProxies();
    

	}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
        modelBuilder.Entity<User>()
            .HasMany(u => u.pictures)
            .WithOne(p => p.user)
            .HasForeignKey(p => p.idUser);  
/*
        modelBuilder.Entity<Picture>()
            .HasOne(p => p.user)
            .WithMany(u => u.pictures)
            .HasForeignKey(p => p.idUser);*/

        modelBuilder.Entity<CategoryPicture>()
            .HasOne(cp => cp.picture)
            .WithMany(p => p.categoryPictures)
            .HasForeignKey(cp => cp.idPicture);

        modelBuilder.Entity<CategoryPicture>()
            .HasOne(cp => cp.category)
			.WithMany(c => c.categoryPictures)
			.HasForeignKey(cp => cp.idCategory);

        modelBuilder.Entity<Picture>()
            .HasMany(p => p.likes)
			.WithOne(l => l.picture)
			.HasForeignKey(l => l.idPicture);

        modelBuilder.Entity<Picture>()
            .HasMany(p => p.comments)
            .WithOne(c => c.picture)
            .HasForeignKey(c => c.idPicture);

        modelBuilder.Entity<Comments>()
            .HasOne(c => c.User)
			.WithMany(u => u.comments)
			.HasForeignKey(c => c.idUser);

        modelBuilder.Entity<Like>()
			.HasOne(l => l.user)
			.WithMany(u => u.likes)
			.HasForeignKey(l => l.idUser);
			
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<WebApplication1.Models.Like> Like { get; set; }
    public DbSet<WebApplication1.Models.Picture> Picture { get; set; }
    public DbSet<WebApplication1.Models.User> Users { get; set; }
    public DbSet<WebApplication1.Models.CategoryPicture> CategoryPicture { get; set; }
    public DbSet<WebApplication1.Models.Category> Category { get; set; }
    public DbSet<WebApplication1.Models.Comments> Comment { get; set; }

}
