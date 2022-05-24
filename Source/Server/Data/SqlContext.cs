namespace MyCostEstimator.Data
{
  using Microsoft.EntityFrameworkCore;
  using MyCostEstimator.Models;
  using System;

  public class SqlContext : DbContext
  {
    public SqlContext(DbContextOptions<SqlContext> options) : base(options){}
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      SeedData(modelBuilder);
    }
    public void SeedData(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<UserRole>().HasData(
           new UserRole() { Id = new Guid("88910a24-e3c7-44c0-97ef-2ffb5d3ce272"), Name = "Admin" },
           new UserRole() { Id = new Guid("39719957-e1f9-48b8-abfe-f129b29c318d"), Name = "Stuff" }
           );
      modelBuilder.Entity<User>().HasData(
           new User() { Id = new Guid("475bd2ef-61d8-4e0d-a827-a80d65e601ea"), Username = "Admin", Password = "123456", IsActive = true, CreatedOn = DateTime.Now, UserRoleId = new Guid("88910a24-e3c7-44c0-97ef-2ffb5d3ce272") },
           new User() { Id = new Guid("a64d90f1-3ecd-4485-aa55-f3c5cc71dc2b"), Username = "Stuff01", Password = "123456", IsActive = true, CreatedOn = DateTime.Now, UserRoleId = new Guid("39719957-e1f9-48b8-abfe-f129b29c318d") }
           );
    }
  }
}
