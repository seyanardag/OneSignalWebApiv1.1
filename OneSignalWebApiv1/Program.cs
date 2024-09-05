using OneSignalWebApiv1.Context;
using OneSignalWebApiv1.Services;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
               .AllowAnyMethod()
               .SetIsOriginAllowed((host) => true)
               .AllowCredentials();

    });
});




builder.Services.AddDbContext<OneSignalDbContext>();
builder.Services.AddControllers();

builder.Services.AddHttpClient();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//OneSignald AppId ve RestApiKey in eklenmesi
var oneSignalAppId = builder.Configuration.GetSection("OneSignalKeys")["AppId"];
var oneSignalApiKey = builder.Configuration.GetSection("OneSignalKeys")["RestApiKey"];
builder.Services.AddSingleton(new OneSignalService(oneSignalAppId!, oneSignalApiKey!));
builder.Services.AddSingleton(new OneSignalServiceSpecificUsers(oneSignalAppId!, oneSignalApiKey!));
builder.Services.AddSingleton(new OneSignalServiceGetUserInfo(oneSignalAppId!));
builder.Services.AddSingleton(new OneSignalServiceSendByEmail(oneSignalAppId!, oneSignalApiKey!));
builder.Services.AddSingleton(new OneSignalServiceCreateOrUpdatePlayer(oneSignalAppId!, oneSignalApiKey!));

builder.Services.AddSingleton(new OneSignalServiceOK(oneSignalAppId!, oneSignalApiKey!));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
