using CodeCareer.PostgreSQL;

var builder = WebApplication.CreateBuilder(args);
var postgreConnection = builder.Configuration
                        .GetConnectionString("PostgreSQL")
                        ?? throw new InvalidOperationException("Connection String not found");
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddPostgreSQL(postgreConnection);
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
