using App.Application.Interfaces;
using App.Application.Services;
using App.Infra.Data.Context;
using App.Infra.Data.Factory;
using App.Infra.Data.Interfaces;
using App.Infra.Data.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PosTechFiapImagensWebApi.Factory;
using PosTechFiapImagensWebApi.Interfaces;
using PosTechFiapImagensWebApi.Models.Provider;
using PosTechFiapImagensWebApi.Services;
using PosTechFiapImagensWebApi.Util.Azure;
using PosTechFiapImagensWebApi.Util.JWT;

#nullable disable

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<ImagemContext>(o => o.UseSqlServer(configuration.GetConnectionString("AzureBdContext")), ServiceLifetime.Scoped, ServiceLifetime.Scoped);

builder.Services.AddScoped<IConteinerAzureConfigProvider, ConteinerAzureConfigProvider>();

builder.Services.Configure<ConteinerAzureConfig>(configuration.GetSection("ConteinerAzure"));

builder.Services.AddScoped<IAzureStorageBlobService, AzureStorageBlobService>();
builder.Services.AddSingleton<IImagemContextFactory, ImagemContextFactory>();

builder.Services.AddScoped(provider =>
{
    var factory = provider.GetRequiredService<IImagemContextFactory>();
    return factory.Create();
});

builder.Services.AddSingleton<IRsaSecurityKeyFactory, RsaSecurityKeyFactory>();
builder.Services.AddScoped(provider =>
{
    var factory = provider.GetRequiredService<IRsaSecurityKeyFactory>();
    return factory.Create();
});

builder.Services.AddScoped<IArquivoRepository, ArquivoRepository>();
builder.Services.AddScoped<ISistemaRepository, SistemaRepository>();
builder.Services.AddScoped<IImagemRepository, ImagemRepository>();
builder.Services.AddScoped<ISistemaService, SistemaService>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddScoped(typeof(ImagemService));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });

    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Pós Tech FIAP - Api para imagens",
        Version = "v1",
        Description = "Api para gravação e obtenção de imagens",
        Contact = new OpenApiContact
        {
            Name = "Name",
            Email = string.Empty,
            Url = new Uri("https://www.fiap.com.br")
        }
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            }, Array.Empty<string>()
        }
    });
});

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.ConfigureRsaSecurityKeyFactory(configuration);
    });

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();