// <copyright file="Program.cs" company="WhenWhere">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WhenWhere.Infrastructure.DataContext;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(opts =>
{
    var connectionString = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("Default"));
    connectionString.Password = builder.Configuration["DbPassword"];
    connectionString.UserID = builder.Configuration["DbUserId"];
    opts.UseSqlServer(connectionString.ToString());
});
builder.Services.AddControllers();
builder.Services.AddProblemDetails();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler();
}

app.UseStatusCodePages();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
