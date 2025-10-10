using jobs_api.Persistency;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddSwaggerGen();


// Get the connection string from configuration (appsettings.json)
var connectionString = builder.Configuration.GetConnectionString("JobsApiCs");
builder.Services.AddDbContext<JobsDbContext>(
    o => o.UseSqlServer(connectionString));


// Configure Entity Framework to use an in-memory database
//builder.Services.AddDbContext<JobsDbContext>(
//    o => o.UseInMemoryDatabase("JobsDb")
//    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
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
