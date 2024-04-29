using AuctionChatApp.Core.Interfaces;
using AuctionChatApp.Core.Services;
using AuctionChatApp.DAL.Data;
using AuctionChatApp.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IAuctionItem, AuctionItemService>();
builder.Services.AddScoped<IBiddingService, BiddingService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

// Configure the database context and connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AuctionChatAppDbContext>(options => options.UseSqlServer(connectionString, x => x.MigrationsAssembly("AuctionChatApp.DAL")).EnableDetailedErrors(true));

//Add identity service
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AuctionChatAppDbContext>();

builder.Services.AddControllers();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

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
