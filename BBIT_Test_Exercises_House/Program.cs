using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using BBIT_Test_Exercises_House.Components;
using BBIT_Test_Exercises_House.DbContext;
using BBIT_Test_Exercises_House.Controllers;
using BBIT_Test_Exercises_House.Mapper;
using BBIT_Test_Exercises_House.Storage;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Load configuration
var configuration = LoadConfiguration();
builder.Services.AddSingleton(configuration);

// Register IConfiguration
builder.Services.AddSingleton<IConfiguration>(configuration);

builder.Services.AddSingleton<IMapper>(CreateMapper());

RegisterServices(builder.Services);

var app = builder.Build();

ConfigurePipeline(app);

app.Run();

// Load configuration
IConfiguration LoadConfiguration() =>
    new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .Build();

IMapper CreateMapper()
{
    var mapperConfig = new MapperConfiguration(cfg =>
    {
        cfg.AddProfile<MappingProfile>();
    });
    return mapperConfig.CreateMapper();
}

// container
void RegisterServices(IServiceCollection services)
{
    var assembly = Assembly.GetExecutingAssembly();
    services.AddAutoMapper(assembly);
    services.AddSingleton<ResidentApiController>();
    services.AddSingleton<HouseApiController>();
    services.AddSingleton<ApartmentApiController>();
    services.AddSingleton<AppDbContext>();
    services.AddSingleton<IResidentService,ResidentService>();
    services.AddSingleton<IApartmentService,ApartmentService>();
    services.AddSingleton<IHouseService,HouseService>();
}

void ConfigurePipeline(WebApplication app)
{
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error", createScopeForErrors: true);
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseAntiforgery();

    app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
    app.MapControllers();
}
