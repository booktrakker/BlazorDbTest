using System;
using System.Collections.Generic;
using BlazorDbTest.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorDbTest.Data;

public partial class BttestContext : DbContext
{   
    public BttestContext()
    {
    }

    public BttestContext(DbContextOptions<BttestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    {
        var builder = WebApplication.CreateBuilder();

        var connectionString = builder.Configuration.GetConnectionString("development");
        optionsBuilder.UseSqlServer(connectionString);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("db_owner");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
