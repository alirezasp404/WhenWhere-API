using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WhenWhere.Infrastructure.DataContext;
using WhenWhere.Core.ServiceContracts;
using WhenWhere.Core.Services;
using WhenWhere.Core.Domain.RepositoryContracts;
using WhenWhere.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddDbContext<ApplicationDbContext>(opts =>
{
    var connectionString = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("Default"));
    connectionString.Password = builder.Configuration["DbPassword"];
    connectionString.UserID = builder.Configuration["DbUserId"];
    opts.UseSqlServer(connectionString.ToString());
});
builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddProblemDetails();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEventsGetterService, EventsGetterService>();
builder.Services.AddScoped<IEventsAdderService, EventsAdderService>();
builder.Services.AddScoped<IEventsRepository, EventRepository>();
var app = builder.Build();
app.MapIdentityApi<IdentityUser>();
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

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
