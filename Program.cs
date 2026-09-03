


using Microsoft.EntityFrameworkCore;
using ShopNow2.Models;  // عدل المسار حسب مكان DbContext عندك

var builder = WebApplication.CreateBuilder(args);

// إضافة خدمة الـ DbContext وربطه بسلسلة الاتصال "DefaultConnection"
builder.Services.AddDbContext<ShopNowDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// إضافة MVC (Controllers with Views)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// تكوين Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseStaticFiles(); // لتشغيل wwwroot


// إعداد المسار الافتراضي
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();









