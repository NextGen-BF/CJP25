using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Entities.BuildingAggregate;
using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.Entities.RequestAggregate;
using NextGen_BM_BE_Domain.Entities.User;

namespace NextGen_BM_BE_Infrastructure
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<BuildingExpense> BuildingExpense { get; set; }
        public DbSet<Enums> Enums { get; set; }
        public DbSet<UserBuildings> UserBuildings { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyExpense> PropertyExpense { get; set; }
        public DbSet<PropertyPayments> PropertyPayments { get; set; }
        public DbSet<PropertyUsers> PropertyUsers { get; set; }
        public DbSet<PropertyResidents> PropertyResidents { get; set; }
        public DbSet<RepairRequest> RepairRequest { get; set; }
        public DbSet<RequestNotes> RequestNotes { get; set; }
        public DbSet<PropertyExpenseTemplate> PropertyExpenseTemplates { get; set; }
    }
}
