using Microsoft.EntityFrameworkCore;
using NextGen_BM_BE_Domain.Entities.BuildingAggregate;
using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.Entities.User;
using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Infrastructure.Repositories
{
    public class ExpensesRepository : IExpensesRepository
    {
        private readonly DataContext _dbContext;

        public ExpensesRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateExpenseForPropertiesAsync(List<int> propertyIds, int expenseId)
        {
            List<Property> properties = await _dbContext
                .Property.Where(p => propertyIds.Contains(p.PropertyId))
                .ToListAsync();
            if (properties.Any())
            {
                foreach (Property property in properties)
                {
                    PropertyExpense propertyExpense = await this.GetPropertyExpenseByIdAsync(
                        expenseId
                    );
                    property.Expenses?.Add(propertyExpense);
                }
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreatePropertyExpenseAsync(PropertyExpense propertyExpense)
        {
            await _dbContext.PropertyExpense.AddAsync(propertyExpense);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePropertyExpenseAsync(int propertyExpenseId)
        {
            PropertyExpense? propertyExpenseToDelete = await this.GetPropertyExpenseByIdAsync(
                propertyExpenseId
            );
            if (propertyExpenseToDelete is not null)
            {
                propertyExpenseToDelete.DeletedDate = DateOnly.FromDateTime(DateTime.Now);
                _dbContext.PropertyExpense.Update(propertyExpenseToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<PropertyExpense>> GetPropertyExpenseByBuildingIdAsync(int buildingId)
        {
            List<PropertyExpense> propertyExpensesByBuildingId = new List<PropertyExpense>();

            List<Property> propertiesByBuildingId = await _dbContext
                .Property.Where(p => p.BuildingId == buildingId)
                .ToListAsync();

            foreach (Property property in propertiesByBuildingId)
            {
                if (property.Expenses is not null)
                {
                    propertyExpensesByBuildingId.AddRange(property.Expenses);
                }
            }
            return propertyExpensesByBuildingId;
        }

        public async Task<PropertyExpense> GetPropertyExpenseByIdAsync(int propertyExpenseId)
        {
            try
            {
                PropertyExpense? foundPropertyExpense = await _dbContext.PropertyExpense.FindAsync(
                    propertyExpenseId
                );
                if (foundPropertyExpense is null)
                {
                    throw new KeyNotFoundException("The property expense was not found.");
                }
                return foundPropertyExpense;
            }
            catch (Exception ex)
            {
                throw new Exception("GetPropertyExpenseByIdAsync threw an error of: ", ex);
            }
        }

        public async Task<List<PropertyExpense>> GetPropertyExpenseByPropertyIdAsync(int propertyId)
        {
            try
            {
                Property? property = await _dbContext.Property.FindAsync(propertyId);
                if (property is null)
                {
                    throw new KeyNotFoundException("The property was not found.");
                }
                return property.Expenses.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("GetPropertyExpenseByPropertyIdAsync threw an error of: ", ex);
            }
        }

        public async Task<List<PropertyExpense>> GetPropertyExpenseByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdatePropertyExpenseAsync(PropertyExpense propertyExpense)
        {
            _dbContext.PropertyExpense.Update(propertyExpense);
            await _dbContext.SaveChangesAsync();
        }
    }
}
