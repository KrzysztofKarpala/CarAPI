using CarAPI.Core.Repository;
using CarAPI.Infrastructure.Mongo.Document;
using CarAPI.Infrastructure.Mongo.Repositories;
using MediatR;
using Messaging.Shared;
using Microsoft.OpenApi.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using System.Reflection;
using CarAPI.Application.Client;

var root = Directory.GetCurrentDirectory();
var dotenv = Path.Combine(root, ".env");
DotEnv.Load(dotenv);

var builder = WebApplication.CreateBuilder(args);

BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

#pragma warning disable 618
BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;
BsonDefaults.GuidRepresentationMode = GuidRepresentationMode.V3;
#pragma warning restore


builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddSingleton<IRabbitMqCarApiRepository, RabbitMqCarApiRepository>();
builder.Services.AddScoped<HttpClient, HttpClient>();

builder.Services.AddMediatR(typeof(Program));
builder.Services.AddMediatR(typeof(PostToCarServiceCommand).GetTypeInfo().Assembly);

builder.Services.Configure<CarDatabaseSettings>(
    builder.Configuration.GetSection("CarDatabase"));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Car API",
        Version = "v1.0",
        Description = "Communication with car company."
    });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.SetUpRabbitMq(builder.Configuration);
builder.Services.AddSingleton<RabbitMqCarApiRepository>();
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
