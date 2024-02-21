﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class AppContext : DbContext
    {
        public AppContext() { }
        //public virtual DbSet<Agency> Agencies  { get; set; }
        //public virtual DbSet<Customer> Customers { get; set; }
        //public virtual DbSet<Investor> Investors { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Division> Divisions { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<SaleBatchDetail> SaleBatchDetails { get; set; }
        public virtual DbSet<SaleBatch> SaleBatches { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);Database=RealEstateDistribution;Uid=mquan;Pwd=wuandmSE150021@;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                         .HasKey(b => new { b.SaleBatchDetailId, b.CustomerId });
            modelBuilder.Entity<Project>()
                          .HasOne<Investor>()
                          .WithMany(i => i.Projects)
                          .HasForeignKey(p => p.InvestorId)
                          .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Division>()
                          .HasOne<Agency>()
                          .WithMany(a => a.Divisions)
                          .HasForeignKey(d => d.AgencyId)
                          .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Booking>()
                         .HasOne<Customer>()
                         .WithMany(c => c.Bookings)
                         .HasForeignKey(b => b.CustomerId)
                         .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
