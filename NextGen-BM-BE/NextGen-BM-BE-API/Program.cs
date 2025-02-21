using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NextGen_BM_BE_Application.AuthHandlers;
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
using NextGen_BM_BE_Application.UseCases.Properties.Create;
using NextGen_BM_BE_Application.UseCases.Properties.Delete;
using NextGen_BM_BE_Application.UseCases.Requests.Create;
using NextGen_BM_BE_Application.UseCases.Requests.Delete;
using NextGen_BM_BE_Application.UseCases.Requests.Get;
using NextGen_BM_BE_Application.UseCases.Requests.Update;
using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Interfaces;
using NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces;
using NextGen_BM_BE_Domain.Services;
using NextGen_BM_BE_Infrastructure;
using NextGen_BM_BE_Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

//Setup in user secrets
string connectionString =
    $"Server={builder.Configuration["Server"]};Database={builder.Configuration["Database"]};User Id={builder.Configuration["UserId"]};Password={builder.Configuration["Password"]}; Trusted_Connection=True; TrustServerCertificate=True; integrated security=false;";
Console.WriteLine(connectionString);

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

builder.Services.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<DataContext>();

#region Dependency Injection
builder.Services.AddScoped<GetBuildingByIdUseCase>();
builder.Services.AddScoped<GetAllBuildingsUseCase>();
builder.Services.AddScoped<GetBuildingsByUserIdUseCase>();
builder.Services.AddScoped<CreateBuildingUseCase>();
builder.Services.AddScoped<UpdateBuildingUseCase>();
builder.Services.AddScoped<DeleteBuildingUseCase>();
builder.Services.AddScoped<DeleteUserBuildingLinkUseCase>();
builder.Services.AddScoped<GetUserBuildingLinkUseCase>();

builder.Services.AddScoped<GetPropertyExpenseByIdUseCase>();
builder.Services.AddScoped<GetAllPropertyPaymentsByUserIdUseCase>();
builder.Services.AddScoped<GetAllPropertyPaymentsByBuildingIdUseCase>();
builder.Services.AddScoped<GetAllPropertyPaymentsByPropertyIdUseCase>();
builder.Services.AddScoped<CreateExpensesUseCase>();
builder.Services.AddScoped<CreatePropertyPaymentsForPropertiesUseCase>();
builder.Services.AddScoped<UpdateExpensesUseCase>();
builder.Services.AddScoped<DeleteExpensesUseCase>();

builder.Services.AddScoped<CreateRepairRequestUseCase>();
builder.Services.AddScoped<CreateRequestNotesUseCase>();
builder.Services.AddScoped<CreateUserBuildingRequestUseCase>();
builder.Services.AddScoped<DeleteRepairRequestNoteUseCase>();
builder.Services.AddScoped<DeleteRepairRequestUseCase>();
builder.Services.AddScoped<GetAllRepairRequestsByBuildingIdUseCase>();
builder.Services.AddScoped<GetRequestByIdUseCase>();
builder.Services.AddScoped<GetUserBuildingRequests>();
builder.Services.AddScoped<UpdateRepairRequestUseCase>();
builder.Services.AddScoped<UpdateRequestNoteUseCase>();
builder.Services.AddScoped<UpdateRepairRequestUseCase>();

builder.Services.AddScoped<IBuildingRepository, BuildingRepository>();
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IExpensesRepository, ExpensesRepository>();
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
builder.Services.AddScoped<IBuildingService, BuildingService>();
builder.Services.AddScoped<IPropertyService, PropertyService>();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<IExpensesService, ExpensesService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJwtService, JwtService>();

builder.Services.AddScoped<GetPropertiesByIdUseCase>();
builder.Services.AddScoped<GetAllPropertiesUseCase>();
builder.Services.AddScoped<CreatePropertyUseCase>();
builder.Services.AddScoped<DeletePropertyUseCase>();
builder.Services.AddScoped<DeletePropertyResidentUseCase>();
builder.Services.AddScoped<GetPropertiesByBuildingIdUseCase>();
builder.Services.AddScoped<GetPropertiesByUserIdUseCase>();
builder.Services.AddScoped<UpdatePropertyUseCase>();
builder.Services.AddScoped<GetPropertyUserLinkUseCase>();
#endregion


#region Auth
builder
    .Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme =
            options.DefaultChallengeScheme =
            options.DefaultForbidScheme =
            options.DefaultScheme =
            options.DefaultSignInScheme =
            options.DefaultSignOutScheme =
                JwtBearerDefaults.AuthenticationScheme;
    })
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration["Authentication:Google:ClientId"] ?? "";
        options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"] ?? "";
    })
    .AddJwtBearer(x =>
    {
        x.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    context.Response.ContentType = "application/json";
                    return context.Response.WriteAsync("{\"message\": \"Token has expired.\"}");
                }
                else if (
                    context.Exception.GetType() == typeof(SecurityTokenInvalidSignatureException)
                )
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return context.Response.WriteAsync(
                        "{\"message\": \"Invalid token signature. Possible tampering detected.\"}"
                    );
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return context.Response.WriteAsync("{\"message\": \"Invalid token.\"}");
                }
            },
        };
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
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = new SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"])
            ),
        };
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("Super", policy => policy.RequireRole("Super"));
    options.AddPolicy("SuperForBuilding", policy => policy.AddRequirements(new BuildingManagerRequirement("Super")));
    options.AddPolicy("UserInBuilding", policy => policy.AddRequirements(new BuildingResidentRequirement()));
    options.AddPolicy("Property Owner", policy => policy.AddRequirements(new PropertyOwnerRequirement("Property Owner")));
    options.AddPolicy("Property User", policy => policy.AddRequirements(new PropertyOwnerRequirement("Property Owner", "Tenant")));
    options.AddPolicy("Tenant", policy => policy.RequireRole("Tenant"));
});
builder.Services.AddScoped<IAuthorizationHandler, BuildingAccessHandler>();
builder.Services.AddScoped<IAuthorizationHandler, BuildingUpdateHandler>();
builder.Services.AddScoped<IAuthorizationHandler, PropertyAccessHandler>();
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
app.MapGroup("/account").MapIdentityApi<User>();

app.Run();
