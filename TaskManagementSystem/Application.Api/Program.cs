using Application.Api.Extension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin() // Your React URL
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.AddStartUpService();
var app = builder.Build();
app.UseCors("AllowAll");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<Application.Infrastructure.Data.TaskManagementSystemDbContext>();
    // This creates the database and all tables defined in your DbContext
    context.Database.EnsureCreated(); 
}


app.Run();
