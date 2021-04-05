using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Giros.Model
{
    public partial class GyroDb : DbContext
    {
        public GyroDb()
            : base("name=GyroDb")
        {
        }

        public virtual DbSet<drink> drinks { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<side> sides { get; set; }
        public virtual DbSet<staff> staffs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<drink>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<drink>()
                .HasMany(e => e.orders)
                .WithMany(e => e.drinks)
                .Map(m => m.ToTable("order_drink").MapLeftKey("drinkId").MapRightKey("orderId"));

            modelBuilder.Entity<order>()
                .Property(e => e.size)
                .IsUnicode(false);

            modelBuilder.Entity<order>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<order>()
                .HasMany(e => e.sides)
                .WithMany(e => e.orders)
                .Map(m => m.ToTable("order_side").MapLeftKey("orderId").MapRightKey("sideId"));

            modelBuilder.Entity<side>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .HasMany(e => e.orders)
                .WithRequired(e => e.staff)
                .WillCascadeOnDelete(false);
        }
    }
}
