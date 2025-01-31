using Microsoft.EntityFrameworkCore;
using NextGen_BM_BE_Application.Mapper;
using NextGen_BM_BE_Application.Services;
using NextGen_BM_BE_Application.UseCases.Buildings.Create;
using NextGen_BM_BE_Application.UseCases.Buildings.Delete;
using NextGen_BM_BE_Application.UseCases.Buildings.Get;
using NextGen_BM_BE_Application.UseCases.Buildings.Update;
using NextGen_BM_BE_Application.UseCases.Expenses.Create;
using NextGen_BM_BE_Application.UseCases.Expenses.Delete;
using NextGen_BM_BE_Application.UseCases.Expenses.Get;
using NextGen_BM_BE_Application.UseCases.Expenses.Update;
using NextGen_BM_BE_Domain.Entities.User;
using NextGen_BM_BE_Domain.Interfaces;
using NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces;
using NextGen_BM_BE_Infrastructure;
using NextGen_BM_BE_Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration["ConnectionString"]!;

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));
// builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<DataContext>();

//Dependency Injection
builder.Services.AddScoped<GetBuildingByIdUseCase>();
builder.Services.AddScoped<GetAllBuildingsUseCase>();
builder.Services.AddScoped<CreateBuildingUseCase>();
builder.Services.AddScoped<UpdateBuildingUseCase>();
builder.Services.AddScoped<DeleteBuildingUseCase>();

builder.Services.AddScoped<GetPropertyExpenseByIdUseCase>();
builder.Services.AddScoped<GetAllPropertyExpenseByUserIdUseCase>();
builder.Services.AddScoped<GetAllPropertyExpenseByBuildingIdUseCase>();
builder.Services.AddScoped<GetAllPropertyExpenseByPropertyIdUseCase>();
builder.Services.AddScoped<CreateExpensesUseCase>();
builder.Services.AddScoped<CreateExpenseForPropertiesUseCase>();
builder.Services.AddScoped<UpdateExpensesUseCase>();
builder.Services.AddScoped<DeleteExpensesUseCase>();

builder.Services.AddScoped<IBuildingRepository, BuildingRepository>();
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IExpensesRepository, ExpensesRepository>();
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
builder.Services.AddScoped<IBuildingService, BuildingService>();
builder.Services.AddScoped<IExpensesService, ExpensesService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "CorsPolicy",
        builder =>
        {
            builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed(host => true)
                .AllowCredentials();
        }
    );
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();
app.MapGroup("/account").MapIdentityApi<User>();

app.Run();
