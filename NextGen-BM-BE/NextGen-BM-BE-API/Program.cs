using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;
using NextGen_BM_BE_API;
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
using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Interfaces;
using NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces;
using NextGen_BM_BE_Infrastructure;
using NextGen_BM_BE_Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

//Setup in user secrets
string connectionString = $"Server={builder.Configuration["Server"]};Database={builder.Configuration["Database"]};User Id={builder.Configuration["UserId"]};Password={builder.Configuration["Password"]}; Trusted_Connection=True;";

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

// builder.Services.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<DataContext>();

#region Dependency Injection
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
builder.Services.AddSingleton<TokenGenerator>();
builder.Services.AddScoped<IExpensesService, ExpensesService>();
#endregion

#region Cors
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
#endregion

#region Auth
builder.Services.AddIdentity<User, IdentityRole>()
.AddEntityFrameworkStores<DataContext>()
.AddDefaultTokenProviders();
builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme =
    options.DefaultChallengeScheme =
    options.DefaultForbidScheme =
    options.DefaultScheme =
    options.DefaultSignInScheme = 
    options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(x => {
        x.IncludeErrorDetails = true;
        x.RequireHttpsMetadata = false;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            //Setup in user secrets
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JWT:Audience"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey= new SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"])
            ),
        };
    });
builder.Services.AddAuthorization(options => {
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("Super", policy => policy.RequireRole("Super"));
    options.AddPolicy("Property Owner", policy => policy.RequireRole("Owner"));
    options.AddPolicy("Tenant", policy => policy.RequireRole("Tenant"));
});
#endregion


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();
// app.MapGroup("/account").MapIdentityApi<User>();

// app.MapPost("/token/login",(LoginRequest request, TokenGenerator tokenGenerator)=> {
//     return new {
//         accessToken =tokenGenerator.GenerateToken(request.Email)
//     };
// });

app.Run();
