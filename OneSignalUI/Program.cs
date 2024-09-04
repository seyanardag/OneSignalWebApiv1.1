using OneSignalWebApiv1.Context;
using OneSignalWebApiv1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<OneSignalDbContext>();
builder.Services.AddHttpClient();

var oneSignalAppId = builder.Configuration.GetSection("OneSignalKeys")["AppId"];
var oneSignalApiKey = builder.Configuration.GetSection("OneSignalKeys")["RestApiKey"];
builder.Services.AddSingleton(new OneSignalServiceSpecificUsers(oneSignalAppId!, oneSignalApiKey!));



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
    pattern: "{controller=Homework}/{action=Index}/{id?}/{id2?}");

app.Run();
