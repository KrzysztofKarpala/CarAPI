using ConsumerApi2.Core.Repository;
using ConsumerApi2.Infrastructure.Mongo.Document;
using ConsumerApi2.Infrastructure.Mongo.Repositories;
using ConsumerApi2.Service;
using MediatR;
using Messaging.Shared;
using Microsoft.OpenApi.Models;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using System.Reflection;

var root = Directory.GetCurrentDirectory();
var dotenv = Path.Combine(root, ".env");
DotEnv.Load(dotenv);

var builder = WebApplication.CreateBuilder(args);


BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

#pragma warning disable 618
BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;
BsonDefaults.GuidRepresentationMode = GuidRepresentationMode.V3;
#pragma warning restore
// Add services to the container.

builder.Services.AddMediatR(typeof(Program));
builder.Services.Configure<ConsumerDatabaseSettings>(
    builder.Configuration.GetSection("Consumer2Db"));
builder.Services.AddSingleton<IConsumerRepository, ConsumerRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Consumer2",
        Version = "v1.0",
        Description = "Consumer to communicate with RabbitMQ"
    });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.SetUpRabbitMq(builder.Configuration);
builder.Services.AddHostedService<ConsumerService>();

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
