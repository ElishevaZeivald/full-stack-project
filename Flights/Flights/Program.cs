//using BL;
//using DAL;
//using Flights.Models;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAllOrigins",
//        builder =>
//        {
//            builder.AllowAnyOrigin()
//                   .AllowAnyMethod()
//                   .AllowAnyHeader();
//        });
//});
////גישה ל DP
//builder.Services.AddDbContext<FlightsContext>();
//builder.Services.AddControllers();

//var app = builder.Build();

//app.UseCors("AllowAllOrigins");
////app.UseHttpsRedirection();
////app.UseAuthorization();

//app.MapControllers();
//app.Run();


using BL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<BLManager>();
builder.Services.AddControllers();

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();
builder.Services.AddCors(options =>
{ 
    var frontend_url = configuration.GetValue<string>("frontend_url");
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontend_url).AllowAnyMethod().AllowAnyHeader();
    });
});
var app = builder.Build();
app.UseHttpsRedirection();
app.UseCors();
app.MapControllers();
app.Run();

