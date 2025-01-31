using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Entities.BuildingAggregate;
using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.Entities.RequestAggregate;

namespace NextGen_BM_BE_Infrastructure
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<BuildingExpense> BuildingExpenses { get; set; }
        public DbSet<Enums> Enums { get; set; }
        public DbSet<UserBuildings> UserBuildings { get; set; }
        public DbSet<Property> Property { get; set; }
        public DbSet<PropertyExpense> PropertyExpense { get; set; }
        public DbSet<PropertyPayments> PropertyPayments { get; set; }
        public DbSet<PropertyUsers> PropertyUsers { get; set; }
        public DbSet<PropertyResidents> PropertyResident { get; set; }
        public DbSet<RepairRequest> RepairRequests { get; set; }
        public DbSet<RequestNotes> RequestNotes { get; set; }
        public DbSet<PropertyExpenseTemplate> PropertyExpenseTemplate { get; set; }
    }
}
