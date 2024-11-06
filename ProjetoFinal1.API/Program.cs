using ProjetoFinal1.Domain.Contracts.Messages;
using ProjetoFinal1.Domain.Contracts.Repositories;
using ProjetoFinal1.Domain.Contracts.Services;
using ProjetoFinal1.Domain.Mappings;
using ProjetoFinal1.Domain.Services;
using ProjetoFinal1.Infra.Data.Repositories;
using ProjetoFinal1.Infra.Messages.Consumers;
using ProjetoFinal1.Infra.Messages.Producers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(ProfileMap));
builder.Services.AddRouting(map => { map.LowercaseUrls = true; });


//dependency injection for the project's interfaces/classes
builder.Services.AddTransient<IProductDomainService, ProductDomainService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ISupplierDomainService, SupplierDomainService>();
builder.Services.AddTransient<ISupplierRepository, SupplierRepository>();
builder.Services.AddTransient<IRabbitMQProducer, RabbitMQProducer>();

//CORS
builder.Services.AddCors(
    config => config.AddPolicy("DefaultPolicy", builder => {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyMethod()
               .AllowAnyHeader();
    })
);
//Consumer class
builder.Services.AddHostedService<RabbitMQConsumer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//CORS
app.UseCors("DefaultPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
