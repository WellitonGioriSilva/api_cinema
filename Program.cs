using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); //Passa os recursos do swagger
builder.Services.AddControllers();//Passa os recursos do controller

var frontEndUrl = Environment.GetEnvironmentVariable("FRONTEND_URL");

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontEnd", policy =>
        policy.WithOrigins(frontEndUrl)
              .AllowAnyHeader()
              .AllowAnyMethod());
});

var app = builder.Build();

// Se em desenvolvimento usa o swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("AllowFrontEnd");
app.UseHttpsRedirection();
app.MapControllers(); //Mapeia todos os controllers

app.Run();