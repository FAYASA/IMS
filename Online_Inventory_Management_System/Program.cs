using inventory.utility.HelperClass;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Inventory.repository;
using Inventory.repository.BillTypeService;
using inventory.models;
using Inventory.repository.CustomerService;
using Inventory.repository.CustomerType;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Inventory.repository")));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Online_Inventory_Management_System")));


builder.Services.AddIdentity<AppUser,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IBillTypeRepo, BillTypeRepo>();

builder.Services.AddScoped<ICustomerTypeRepo, CustomerTypeRepo>();

//////
///It reads the "SuperAdmin" section from appsettings.json.
///It maps the values to the SuperAdmin class.
///It makes the data available for injection using IOptions<SuperAdmin>.
///
builder.Services.Configure<SuperAdmin>(builder.Configuration.GetSection("SuperAdmin"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
