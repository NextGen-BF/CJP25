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
            try
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

                        if (property.Expenses is not null)
                        {
                            property.Expenses.Add(propertyExpense);
                        }
                    }
                }
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"{nameof(CreateExpenseForPropertiesAsync)} threw an error of: ",
                    ex
                );
            }
        }

        public async Task CreatePropertyExpenseAsync(PropertyExpense propertyExpense)
        {
            try
            {
                await _dbContext.PropertyExpense.AddAsync(propertyExpense);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"{nameof(CreatePropertyExpenseAsync)} threw an error of: ",
                    ex
                );
            }
        }

        public async Task DeletePropertyExpenseAsync(int propertyExpenseId)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception(
                    $"{nameof(DeletePropertyExpenseAsync)} threw an error of: ",
                    ex
                );
            }
        }

        public async Task<List<PropertyExpense>> GetPropertyExpenseByBuildingIdAsync(int buildingId)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception(
                    $"{nameof(GetPropertyExpenseByBuildingIdAsync)} threw an error of: ",
                    ex
                );
            }
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
                throw new Exception($"{GetPropertyExpenseByIdAsync} threw an error of: ", ex);
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

                if (property.Expenses is not null)
                {
                    return property.Expenses.ToList();
                }
                else
                {
                    return new List<PropertyExpense>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"{GetPropertyExpenseByPropertyIdAsync} threw an error of: ",
                    ex
                );
            }
        }

        public async Task<List<PropertyExpense>> GetPropertyExpenseByUserIdAsync(int userId)
        {
            try
            {
                PropertyUsers? user = await _dbContext.PropertyUsers.FindAsync(userId);
                List<PropertyExpense> propertyExpensesByUserId = new List<PropertyExpense>();

                if (user is not null)
                {
                    List<Property> userProperties = await _dbContext
                        .Property.Where(p => p.PropertyId == user.PropertyId)
                        .ToListAsync();

                    foreach (Property property in userProperties)
                    {
                        if (property.Expenses is not null)
                        {
                            propertyExpensesByUserId.AddRange(property.Expenses);
                        }
                    }
                }
                return propertyExpensesByUserId;
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"{nameof(GetPropertyExpenseByUserIdAsync)} threw an error of: ",
                    ex
                );
            }
        }

        public async Task UpdatePropertyExpenseAsync(PropertyExpense propertyExpense)
        {
            try
            {
                _dbContext.PropertyExpense.Update(propertyExpense);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"{nameof(UpdatePropertyExpenseAsync)} threw an error of: ",
                    ex
                );
            }
        }
    }
}
