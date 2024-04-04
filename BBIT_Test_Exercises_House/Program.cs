using System.Reflection;
using BBIT_Test_Exercises_House.Components;
using BBIT_Test_Exercises_House.DbContext;
using AutoMapper;
using BBIT_Test_Exercises_House.Controllers;
using BBIT_Test_Exercises_House.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
var assembly = Assembly.GetExecutingAssembly();
builder.Services.AddAutoMapper(assembly);
builder.Services.AddSingleton<ResidentApiController>();
builder.Services.AddSingleton<HouseApiController>();
builder.Services.AddSingleton<ApartmentApiController>();
builder.Services.AddSingleton<AppDbContext>();

// Configure AutoMapper
var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<MappingProfile>();
});
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton<IMapper>(mapper);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.MapControllers();


app.Run();