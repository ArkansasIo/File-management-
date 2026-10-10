using DentalMaintenance.Core.Models;
using Microsoft.EntityFrameworkCore;
namespace DentalMaintenance.Data;
public sealed class DentalDbContext(DbContextOptions<DentalDbContext> options) : DbContext(options)
{
 public DbSet<Patient> Patients => Set<Patient>();
 protected override void OnModelCreating(ModelBuilder model)
 {
  model.Entity<Patient>().HasIndex(x=>x.MedicalRecordNumber).IsUnique();
  model.Entity<Patient>().Property(x=>x.MedicalRecordNumber).HasMaxLength(64).IsRequired();
  model.Entity<Patient>().Property(x=>x.GivenName).HasMaxLength(120).IsRequired();
  model.Entity<Patient>().Property(x=>x.FamilyName).HasMaxLength(120).IsRequired();
 }
}