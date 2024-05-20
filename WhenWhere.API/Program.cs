using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WhenWhere.Core.Domain.IdentityEntities;
using WhenWhere.Infrastructure.DataContext;
using WhenWhere.Core.ServiceContracts;
using WhenWhere.Core.Services;
using WhenWhere.Core.Domain.RepositoryContracts;
using WhenWhere.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(opts =>
{
    var connectionString = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("Default"));
    connectionString.Password = builder.Configuration["DbPassword"];
    connectionString.UserID = builder.Configuration["DbUserId"];
    opts.UseSqlServer(connectionString.ToString());
});

builder.Services
    .AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders()
    .AddUserStore<UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, Guid>>()
    .AddRoleStore<RoleStore<ApplicationRole, ApplicationDbContext, Guid>>();
builder.Services.AddControllers();
builder.Services.AddProblemDetails();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEventsGetterService, EventsGetterService>();
builder.Services.AddScoped<IEventsRepository, EventRepository>();
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
