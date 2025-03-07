using Microsoft.EntityFrameworkCore;
using NextGen_BM_BE_Domain.DataStructures;
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

        public async Task CreatePropertyPaymentsForPropertiesAsync(
            List<int> propertyIds,
            int propertyPaymentsId
        )
        {
            try
            {
                List<Property> properties = await _dbContext
                    .Property.Where(p =>
                        propertyIds.Contains(p.PropertyId) && p.DeletedDate == null
                    )
                    .Include(p => p.Payments)
                    .ToListAsync();
                if (properties.Any())
                {
                    foreach (Property property in properties)
                    {
                        PropertyPayments? propertyPayments = await _dbContext
                            .PropertyPayments.Where(p =>
                                p.PropertyPaymentsId == propertyPaymentsId && p.DeletedDate == null
                            )
                            .FirstOrDefaultAsync();

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
                    $"{nameof(CreatePropertyPaymentsForPropertiesAsync)} threw an error of: ",
                    ex
                );
            }
        }

        public async Task CreatePropertyExpenseAsync(PropertyExpense propertyExpense)
        {
            try
            {
                if (propertyExpense.PropertyExpenseTemplateId == 0)
                {
                    propertyExpense.PropertyExpenseTemplateId = _dbContext
                        .PropertyExpenseTemplate.First()
                        .PropertyExpenseTemplateId;
                }
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

        public async Task CreatePropertyPaymentsAsync(PropertyPayments propertyPayment)
        {
            try
            {
                if (propertyPayment.PropertyExpenseId == 0)
                {
                    propertyPayment.PropertyExpenseId = _dbContext
                        .PropertyExpense.First()
                        .PropertyExpenseId;
                }
                if (propertyPayment.PropertyId == 0)
                {
                    propertyPayment.PropertyId = _dbContext.Property.First().PropertyId;
                }
                await _dbContext.PropertyPayments.AddAsync(propertyPayment);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"{nameof(CreatePropertyPaymentsAsync)} threw an error of: ",
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

        public async Task<List<PropertyPayments>> GetPropertyPaymentsByBuildingIdAsync(
            int buildingId, int? page, int? pageSize
        )
        {
            try
            {
                var query = _dbContext
                    .PropertyPayments
                    .Include(p => p.Property)
                    .Where(p => p.Property.BuildingId == buildingId && p.Property.DeletedDate == null);

                if (page!=null&&pageSize!=null)
                {
                    var pagedList=new PagedList<PropertyPayments>{Page=(int)page, PageSize=(int)pageSize};
                    await pagedList.Paginate(query);
                    return pagedList;
                }
                return await query
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"{nameof(GetPropertyPaymentsByBuildingIdAsync)} threw an error of: ",
                    ex
                );
            }
        }

        public async Task<PropertyExpense> GetPropertyExpenseByIdAsync(int propertyExpenseId)
        {
            try
            {
                PropertyExpense? foundPropertyExpense = await _dbContext
                    .PropertyExpense.Where(p =>
                        p.PropertyExpenseId == propertyExpenseId && p.DeletedDate == null
                    )
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
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

        public async Task<List<PropertyExpense>> GetPropertyExpensesByBuildingIdAsync(
            int buildingId, int? page, int? pageSize
        )
        {
            try
            {
                var query = _dbContext
                    .PropertyExpense.Where(p => p.DeletedDate == null)
                    .Include(p => p.PropertyExpenseTemplate)
                    .ThenInclude(pe => pe.Building)
                    .Where(p =>
                        p.PropertyExpenseTemplate != null
                        && p.PropertyExpenseTemplate.DeletedDate == null
                        && p.PropertyExpenseTemplate.Building != null
                        && p.PropertyExpenseTemplate.Building.DeletedDate == null
                        && p.PropertyExpenseTemplate.Building.BuildingId == buildingId
                    );
                if (page!=null&&pageSize!=null)
                {
                    var pagedList=new PagedList<PropertyExpense>{Page=(int)page, PageSize=(int)pageSize};
                    await pagedList.Paginate(query);
                    return pagedList;
                }
                return await query
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"{GetPropertyExpensesByBuildingIdAsync} threw an error of: ",
                    ex
                );
            }
        }

        public async Task<List<PropertyPayments>> GetPropertyPaymentsByPropertyIdAsync(
            int propertyId, int? page, int? pageSize
        )
        {
            try
            {
                var query = _dbContext.PropertyPayments
                    .Include(p => p.Property)
                    .Where(p => p.Property.PropertyId==propertyId);
                if (page!=null&&pageSize!=null)
                {
                    var pagedList=new PagedList<PropertyPayments>{Page=(int)page, PageSize=(int)pageSize};
                    await pagedList.Paginate(query);
                    return pagedList;
                }
                return await query
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"{GetPropertyPaymentsByPropertyIdAsync} threw an error of: ",
                    ex
                );
            }
        }

        public async Task<List<PropertyPayments>> GetPropertyPaymentsByUserIdAsync(int userId, int? page, int? pageSize)
        {
            try
            {
                var propertyPaymentsByUserIdQuery = _dbContext.PropertyPayments
                    .Include(p => p.Property)
                        .ThenInclude(p => p.Users)
                    .Where(p => p.Property.Users.Any(u => u.User.Id==userId));
                if (page!=null&&pageSize!=null)
                {
                    var pagedList=new PagedList<PropertyPayments>{Page=(int)page, PageSize=(int)pageSize};
                    await pagedList.Paginate(propertyPaymentsByUserIdQuery);
                    return pagedList;
                }
                return await propertyPaymentsByUserIdQuery
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"{nameof(GetPropertyPaymentsByUserIdAsync)} threw an error of: ",
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
