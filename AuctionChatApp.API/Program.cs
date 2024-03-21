using AuctionChatApp.Core.Interfaces;
using AuctionChatApp.Core.Services;
using AuctionChatApp.DAL.Data;
using AuctionChatApp.DAL.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IAuctionItem, AuctionItemService>();
builder.Services.AddScoped<IBiddingService, BiddingService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

// Configure the database context and connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AuctionChatAppDbContext>(options => options.UseSqlServer(connectionString, x => x.MigrationsAssembly("AuctionChatApp.DAL")).EnableDetailedErrors(true));

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
