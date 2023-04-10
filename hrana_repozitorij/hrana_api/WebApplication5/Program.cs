using MailKit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using System.Text.Json.Serialization;
using WebApplication5.Data;

using WebApplication5.Helper;
using WebApplication5.Helper.ErrorHandler;
using WebApplication5.Service;


var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", false)
    .Build();
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddControllersWithViews()
  .AddJsonOptions(options =>
  options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(config.GetConnectionString("db1")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.OperationFilter<AutorizacijaSwaggerHeader>();
});

builder.Services.Configure<EmailSettings>(config.GetSection("EmailSettings"));
builder.Services.AddTransient<IEmailService, MailerService>();

builder.Services.AddCors();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseCors(
          options => options
          .SetIsOriginAllowed(x => _ = true)
          .AllowAnyMethod()
          .AllowAnyHeader()
          .AllowCredentials());
app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();



app.Run();
