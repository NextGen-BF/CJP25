using Microsoft.EntityFrameworkCore;
using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
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

        public async Task CreateExpenseForPropertiesAsync(
            List<int> propertyIds,
            int propertyPaymentsId
        )
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
                        PropertyPayments? propertyPayments =
                            await _dbContext.PropertyPayments.FindAsync(propertyPaymentsId);

                        if (property.Payments is not null && propertyPayments is not null)
                        {
                            property.Payments.Add(propertyPayments);
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

        public async Task<List<PropertyPayments>> GetPropertyExpenseByBuildingIdAsync(
            int buildingId
        )
        {
            try
            {
                List<PropertyPayments> propertyPaymentsByBuildingId = new List<PropertyPayments>();

                List<Property> propertiesByBuildingId = await _dbContext
                    .Property.Where(p => p.BuildingId == buildingId)
                    .AsNoTracking()
                    .ToListAsync();

                foreach (Property property in propertiesByBuildingId)
                {
                    if (property.Payments is not null)
                    {
                        propertyPaymentsByBuildingId.AddRange(property.Payments);
                    }
                }
                return propertyPaymentsByBuildingId;
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

        public async Task<List<PropertyPayments>> GetPropertyExpenseByPropertyIdAsync(
            int propertyId
        )
        {
            try
            {
                Property? property = await _dbContext.Property.FindAsync(propertyId);
                if (property is null)
                {
                    throw new KeyNotFoundException("The property was not found.");
                }

                if (property.Payments is not null)
                {
                    return property.Payments.ToList();
                }
                else
                {
                    return new List<PropertyPayments>();
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

        public async Task<List<PropertyPayments>> GetPropertyExpenseByUserIdAsync(int userId)
        {
            try
            {
                PropertyUsers? user = await _dbContext.PropertyUsers.FindAsync(userId);
                List<PropertyPayments> propertyPaymentsByUserId = new List<PropertyPayments>();

                if (user is not null)
                {
                    List<Property> userProperties = await _dbContext
                        .Property.Where(p => p.PropertyId == user.PropertyId)
                        .AsNoTracking()
                        .ToListAsync();

                    foreach (Property property in userProperties)
                    {
                        if (property.Payments is not null)
                        {
                            propertyPaymentsByUserId.AddRange(property.Payments);
                        }
                    }
                }
                return propertyPaymentsByUserId;
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
