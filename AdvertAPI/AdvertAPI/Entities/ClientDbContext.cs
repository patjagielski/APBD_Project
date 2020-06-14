using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertAPI.Entities
{
    public class ClientDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }


        public ClientDbContext()
        {

        }
        public ClientDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdClient);
                entity.Property(e => e.IdClient).ValueGeneratedOnAdd();
                entity.Property(e => e.FirstName).IsRequired();

                entity.ToTable("Client");

                entity.HasMany(d => d.Campaigns)
                              .WithOne(d => d.Clients)
                              .HasForeignKey(d => d.IdClient)
                              .IsRequired();

            });
            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.HasKey(e => e.IdCampaign);
                entity.Property(e => e.IdCampaign).ValueGeneratedOnAdd();
                entity.Property(e => e.StartDate).IsRequired();

                entity.ToTable("Campaign");

                entity.HasMany(d => d.Banners)
                              .WithOne(d => d.Campaign)
                              .HasForeignKey(d => d.IdCampaign)
                              .IsRequired();

            });
            modelBuilder.Entity<Building>(entity =>
            {
                entity.HasKey(e => e.IdBuilding);
                entity.Property(e => e.IdBuilding).ValueGeneratedOnAdd();
                entity.Property(e => e.Street).IsRequired();

                entity.ToTable("Building");

                entity.HasMany(d => d.Campaigns)
                              .WithOne(d => d.Buildings)
                              .HasForeignKey(d => d.FromIdBuilding)
                              .IsRequired();
                entity.HasMany(d => d.Campaigns)
                              .WithOne(d => d.Buildings)
                              .HasForeignKey(d => d.ToIdBuilding)
                              .IsRequired();

            });
            modelBuilder.Entity<Banner>(entity =>
            {
                entity.HasKey(e => e.IdAdvertisement);
                entity.Property(e => e.IdAdvertisement).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired();

                entity.ToTable("Banner");

            });
        }

    }
}
