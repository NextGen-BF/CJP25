using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NextGen_BM_BE_Application.Services;
using NextGen_BM_BE_Application.UseCases.Expenses.Get;
using NextGen_BM_BE_Domain.Interfaces;
using NextGen_BM_BE_Domain.Services;
using NextGen_BM_BE_Infrastructure;
using NextGen_BM_BE_Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Dependency Injection
builder.Services.AddScoped<IBuildingRepository, BuildingRepository>();
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IExpensesRepository, ExpensesRepository>();
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();

builder.Services.AddScoped<GetPropertiesByIdUseCase>();

builder.Services.AddScoped<IPropertyService, PropertyService>();

string connectionString=builder.Configuration["ConnectionString"];

builder.Services.AddDbContext<DataContext>(options=>options.UseSqlServer(connectionString));

builder.Services.AddCors(options => {
    options.AddPolicy("CorsPolicy", builder => {
        builder.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed(host => true)
        .AllowCredentials();
    });
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

app.Run();
