using API.Extensions;
using AutoMapper;
using Core;
using Infrastructure.Repository;
using Infrastructure.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.OData;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OData.ModelBuilder;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
builder.Services.AddScoped<IGenericRepository<Project>, GenericRepository<Project>>();
builder.Services.AddScoped<IGenericRepository<Division>, GenericRepository<Division>>();
builder.Services.AddScoped<IGenericRepository<Property>, GenericRepository<Property>>();
builder.Services.AddScoped<IGenericRepository<SaleBatch>, GenericRepository<SaleBatch>>();
builder.Services.AddScoped<IGenericRepository<SaleBatchDetail>, GenericRepository<SaleBatchDetail>>();
builder.Services.AddScoped<IGenericRepository<Booking>, GenericRepository<Booking>>();
builder.Services.AddScoped<IGenericRepository<Contract>, GenericRepository<Contract>>();
builder.Services.AddScoped<IGenericRepository<PaymentRecord>, GenericRepository<PaymentRecord>>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ISaleBatchService, SaleBatchService>();
builder.Services.AddScoped<IPropertyService, PropertyService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IVnPayService, VnPayService>();
builder.Services.AddScoped<IContractService, ContractService>();
builder.Services.AddScoped<IPaymentRecordService, PaymentRecordService>();
builder.Services.AddScoped<ISaleBatchDetailService, SaleBatchDetailService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mapperConfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false).Build();
builder.Services.AddSwaggerGen(setup =>
{
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });

});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = config.GetSection("Jwt:Issuer").Value,
            ValidAudience = config.GetSection("Jwt:Audience").Value,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("Jwt:Key").Value))
        };
    });
var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<Agency>("Agencies");
var bookingEntitySet = modelBuilder.EntitySet<Booking>("Bookings");
bookingEntitySet.EntityType.HasKey(bk => new { bk.CustomerId, bk.SaleBatchId });
modelBuilder.EntitySet<Customer>("Customers");
modelBuilder.EntitySet<Division>("Divisions");
modelBuilder.EntitySet<Investor>("Investors");
modelBuilder.EntitySet<Project>("Projects");
modelBuilder.EntitySet<Property>("Properties");
modelBuilder.EntitySet<SaleBatch>("SaleBatches");
modelBuilder.EntitySet<SaleBatchDetail>("SaleBatchDetails");

builder.Services.AddControllers().AddOData(
    options => options.Select()
                        .Filter()
                        .OrderBy()
                        .Expand()
                        .Count()
                        .SetMaxTop(null)
                        .EnableQueryFeatures(2)
                        .AddRouteComponents("api", modelBuilder.GetEdmModel())
);
builder.Services.AddCors(option =>
{
    option.AddPolicy(name: "AllowAllOrigin", policy =>
    {
        policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowAllOrigin");

app.Run();
