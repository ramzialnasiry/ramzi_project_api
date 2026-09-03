using Microsoft.EntityFrameworkCore;
using ShopNow2.Models;

var builder = WebApplication.CreateBuilder(args);

// الاتصال بقاعدة البيانات
builder.Services.AddDbContext<ShopNowDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// Controllers + Views
builder.Services.AddControllersWithViews();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// معالجة الأخطاء في Production
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// لا تستخدم HTTPS Redirection على Render
// app.UseHttpsRedirection();

// الملفات الثابتة
app.UseStaticFiles();

app.UseRouting();

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

// المسار الافتراضي
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

// تشغيل التطبيق
app.Run();

/*
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ramzi_project_api.Models;

var builder = WebApplication.CreateBuilder(args);

// قراءة المنفذ من متغير البيئة "PORT" (مهم لـ Render)، وإلا يستخدم 5000 محليًا
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

// الاتصال بقاعدة البيانات
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Dbconnection")));

// إعداد الهوية (Identity)
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

// تفعيل CORS للسماح للجميع (يمكن تخصيصه لاحقًا)
builder.Services.AddCors(opt =>
    opt.AddPolicy("AllowAll", p =>
        p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
    )
);

// إضافة خدمات الـ API و Swagger
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// تفعيل Swagger في بيئة التطوير فقط
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// HTTPS Redirect (يُستخدم فقط إذا كنت مشغّل HTTPS محليًا)
app.UseHttpsRedirection();

// المصادقة والتفويض
app.UseAuthentication();
app.UseAuthorization();

// تطبيق CORS
app.UseCors("AllowAll");

// ربط الكنترولرز
app.MapControllers();

// محاولة فتح المتصفح (محليًا فقط - غير ضروري في Render)
if (app.Environment.IsDevelopment())
{
    try
    {
        var url = $"http://localhost:{port}/swagger";
        Process.Start(new ProcessStartInfo
        {
            FileName = url,
            UseShellExecute = true
        });
    }
    catch
    {
        // تجاهل الخطأ إذا لم ينجح فتح المتصفح
    }
}

// تشغيل التطبيق
app.Run();
*/
*/
