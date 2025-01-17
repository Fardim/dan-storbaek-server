using dan_storbaek_server.Domains;
using dan_storbaek_server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", policy =>
{
    policy.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader()
           .WithExposedHeaders("Content-Disposition");
}));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DanTestDatabaseSettings>(
    builder.Configuration.GetSection("DanTestDatabase"));

builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<IBinaryStringService, BinaryStringService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
