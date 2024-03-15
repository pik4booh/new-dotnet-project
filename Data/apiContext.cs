using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
		if (!optionsBuilder.IsConfigured)
		{
            optionsBuilder.UseNpgsql("Host=localhost;Database=test;Username=postgres;Password=hehe;");
            optionsBuilder.UseLazyLoadingProxies();
		}

	}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
