using MongoDbDemo.Models;
using MongoDbDemo.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Read configuration
builder.Services.Configure<TodoDatabaseSettings>(builder.Configuration.GetSection("TodoDatabase"));

// Add services
builder.Services.AddSingleton<ITodosRepository, TodosRepository>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers(); 
app.MapRazorPages();

app.Run();
