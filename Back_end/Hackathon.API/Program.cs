using Google.Maps;
using Hackathon.EF_Core;
using Hackathon.EF_Core.Context;
using Hackathon.EF_Core.Seed;
using Hackathon.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEFCore(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);

var policyName = "defaultReactCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(policyName, builder =>
    {
        builder.WithOrigins("http://localhost:5713")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    using (var db = scope.ServiceProvider.GetRequiredService<ApplicationContext>())
    {
        await db.SeedDB();
    }
}
var appConfig = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

if (string.IsNullOrEmpty(appConfig["API_Key"]))
{
    throw new Exception("Google api key was not found.");
}

GoogleSigned.AssignAllServices(new GoogleSigned(appConfig["API_Key"]));

app.Run();
