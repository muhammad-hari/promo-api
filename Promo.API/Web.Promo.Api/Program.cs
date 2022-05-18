using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Web.Promo.Application.Commands;
using Web.Promo.Application.Queries;
using Web.Promo.Data.Context;
using Web.Promo.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region JWT Auth

//var jwtTokenConfiguration = builder.Configuration.GetSection("JwtTokenConfig").Get<JwtTokenConfig>();
//builder.Services.AddSingleton(jwtTokenConfiguration);
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer("Bearer", options =>
//{
//    //options.Authority = builder.Configuration["IdentityServerUrl"];
//    options.RequireHttpsMetadata = false;
//    options.SaveToken = true;
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidIssuer = jwtTokenConfiguration.Issuer,
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtTokenConfiguration.Secret)),
//        ValidAudience = jwtTokenConfiguration.Audience,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ClockSkew = TimeSpan.FromMinutes(1.0)
//    };
//});

//builder.Services.AddSingleton<IJwtAuthentication, JwtAuthentication>();
//builder.Services.AddHostedService<JwtRefreshTokenCache>();

#endregion

#region Files 

//app.UseStaticFiles();
//app.UseStaticFiles(new StaticFileOptions()
//{
//    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
//    RequestPath = new PathString("/Resources")
//});

#endregion

// Database Config
builder.Services.AddDbContext<PromoDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DEV")));

// Services
builder.Services.AddTransient<IPromoQuery, PromoQuery>();
builder.Services.AddTransient<IPromoCommand, PromoCommand>();

// Repositories
builder.Services.AddTransient<IPromoRepository, PromoRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
