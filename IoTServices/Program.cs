using IoTServices.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(x => 
    x.AddDefaultPolicy(config => 
        config.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
    )
);

//string connStr = builder.Configuration.GetConnectionString("Default");
//builder.Services.AddSqlServer<IotDbContext>(connStr);
string connStrSqlLite = builder.Configuration.GetConnectionString("SqlLite");
builder.Services.AddSqlite<IotDbContext>(connStrSqlLite);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using(var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetService<IotDbContext>();
    ctx.Database.Migrate();
}

app.UseCors();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
