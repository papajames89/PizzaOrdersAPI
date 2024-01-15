using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;
using PizzaOrdersAPI.Interfaces;
using PizzaOrdersAPI.Interfaces.Implementations;

var builder = WebApplication.CreateBuilder(args);

// API versioning
builder.Services.AddApiVersioning(options => options.ReportApiVersions = true)
    .AddMvc();

// Add services to the container.
BsonSerializer.RegisterIdGenerator(typeof(string), new StringObjectIdGenerator());

builder.Services.Configure<PizzaOrdersDatabaseSettings>(
    builder.Configuration.GetSection(nameof(PizzaOrdersDatabaseSettings)));

builder.Services.AddSingleton<IPizzaOrdersDatabaseSettings>(serviceProvider =>
    serviceProvider.GetRequiredService<IOptions<PizzaOrdersDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("PizzaOrdersDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IPizzaOrderService, PizzaOrdersService>();

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();