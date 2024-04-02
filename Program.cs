



var builder = WebApplication.CreateBuilder(args);

#region ConnectToSQLDataBase
var CS = builder.Configuration.GetConnectionString("CS")
                                ?? throw new InvalidOperationException("No connection string was found");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(CS));
#endregion


// Add services to the container.
builder.Services.AddControllersWithViews();

#region Dependency Injections
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IDeviceService, DeviceService>();
builder.Services.AddScoped<IGameService, GameService>();
#endregion

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
