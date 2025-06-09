using Microsoft.AspNetCore.Builder; 
using Microsoft.Extensions.DependencyInjection; 
using NTierTodoApp.Business; 
using NTierTodoApp.DataAccess; 
 
var builder = WebApplication.CreateBuilder(args); 
 
// ةمدخ ةفاضإ MVC 
builder.Services.AddControllersWithViews(); 
 
//  ةيراجتلا ةقبطلاو تانايبلا عدوتسم ليجست 
builder.Services.AddSingleton<TaskRepository>(); // مادختسا Singleton  ةاكاحملل ةركاذلاب 
builder.Services.AddTransient<TaskService>(); 
 
var app = builder.Build(); 
 
if (!app.Environment.IsDevelopment()) 
{ 
    app.UseExceptionHandler("/Home/Error"); 
} 
 
app.UseStaticFiles(); 
app.UseRouting(); 
 
app.MapControllerRoute( 
    name: "default", 
    pattern: "{controller=Home}/{action=Index}/{id?}"); 
 
app.Run(); 