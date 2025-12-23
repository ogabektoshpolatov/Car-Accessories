using CarAccessories.Application;
using CarAccessories.Infrastructure;
using CarAccessories.Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.AddPresentation();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseDefaultFiles();  // Serves index.html by default
app.UseStaticFiles(); 
app.MapControllers();
app.UseHttpsRedirection();

app.Run();

