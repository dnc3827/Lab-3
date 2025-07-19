using Lab_3.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Đăng ký DbContext ở đây
builder.Services.AddDbContext<Lab_3.Models.InventoryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("InventoryDB")));
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


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
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();

    // Tạo database nếu chưa có
    context.Database.EnsureCreated();

    // Seed dữ liệu nếu chưa có
    if (!context.Products.Any())
    {
        context.Products.AddRange(
            new Product { Name = "Sản phẩm A", Description = "Mô tả A", Price = 100 },
            new Product { Name = "Sản phẩm B", Description = "Mô tả B", Price = 200 }
        );
        context.SaveChanges();
    }
}

