using Microsoft.EntityFrameworkCore;
using Project_Credentials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Infrastructure.ContextDb
{
    public partial class Project_CredentialsContext: DbContext
    {

        public Project_CredentialsContext() { }

        public Project_CredentialsContext(DbContextOptions<Project_CredentialsContext> options) : base(options) { }


        //Models
        public virtual  DbSet<User> Users { get; set; }
        public virtual DbSet<Rol> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.Password)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false);

               
                entity.HasOne(u => u.Rol)
                   .WithMany(r => r.Users)
                   .HasForeignKey(u => u.RolId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_User_RoleId");

            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("Rol");
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                modelBuilder.Entity<Rol>()
                    .HasMany(r => r.Users)
                    .WithOne(u => u.Rol)
                    .HasForeignKey(u => u.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rol_UserId");


            });


        }


    }
}
