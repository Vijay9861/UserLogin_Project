using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UserLogin_Project.Models;

public partial class MyProjectContext : DbContext
{
    public MyProjectContext()
    {
    }

    public MyProjectContext(DbContextOptions<MyProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-AU94EJS;Initial Catalog=MyProject;Integrated Security=True; 	TrustServerCertificate=True;Trusted_Connection=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserLogi__206D917098722A9B");

            entity.ToTable("UserLogin");

            entity.Property(e => e.UserId).HasColumnName("User_Id");
            entity.Property(e => e.MailId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Mail_Id");
            entity.Property(e => e.UPassword)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("U_Password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
