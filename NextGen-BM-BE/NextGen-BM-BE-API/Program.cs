using Microsoft.EntityFrameworkCore;
using NextGen_BM_BE_Application.Services;
using NextGen_BM_BE_Application.UseCases.Requests.Create;
using NextGen_BM_BE_Application.UseCases.Requests.Delete;
using NextGen_BM_BE_Application.UseCases.Requests.Get;
using NextGen_BM_BE_Application.UseCases.Requests.Update;
using NextGen_BM_BE_Domain.Entities.User;
using NextGen_BM_BE_Domain.Interfaces;
using NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces;
using NextGen_BM_BE_Domain.Services;
using NextGen_BM_BE_Infrastructure;
using NextGen_BM_BE_Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString=builder.Configuration["ConnectionString"];

builder.Services.AddDbContext<DataContext>(options=>options.UseSqlServer(connectionString));

builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<DataContext>();

//Dependency Injection
builder.Services.AddScoped<IBuildingRepository, BuildingRepository>();
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IExpensesRepository, ExpensesRepository>();
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
builder.Services.AddScoped<IBuildingService, BuildingService>();

builder.Services.AddScoped<IRequestService, RequestService>();

builder.Services.AddScoped<CreateRepairRequestUseCase>();
builder.Services.AddScoped<CreateRequestNotesUseCase>();
builder.Services.AddScoped<CreateUserBuildingRequestUseCase>();
builder.Services.AddScoped<DeleteRepairRequestNoteUseCase>();
builder.Services.AddScoped<DeleteRepairRequestUseCase>();
builder.Services.AddScoped<GetAllRepairRequestsByBuildingIdUseCase>();
builder.Services.AddScoped<GetRequestByIdUseCase>();
builder.Services.AddScoped<UpdateRepairRequestUseCase>();
builder.Services.AddScoped<UpdateRequestNoteUseCase>();

builder.Services.AddScoped<UpdateRepairRequestUseCase>();


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
