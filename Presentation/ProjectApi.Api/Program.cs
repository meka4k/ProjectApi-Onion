using ProjectApi.Persistence;
using ProjectApi.Application;
using ProjectApi.Infrastructure;
using ProjectApi.Mapper;
using ProjectApi.Application.Exceptions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var env = builder.Environment;

builder.Configuration.SetBasePath(env.ContentRootPath)
	.AddJsonFile("appsettings.json",false)
	.AddJsonFile($"appsettings.{env.EnvironmentName}.json",true);

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddCustomMapper();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1",new OpenApiInfo { Title="Projec API",Version="v1",Description="Project API swagger client"});
	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
	{
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer",
		BearerFormat = "Jwt",
		In = ParameterLocation.Header,
		Description = "'Bearer' yazýp boþluk býraktýktan sonra Token'ý girebilirsiniz \r\n\r\n Örneðin: 'Bearer ewpESMSpihSCitle4REwzMhhKJWJjH7CEU4FiGKqedhIgacqDrQ7sKUoQB7usxvM'"
	});
	c.AddSecurityRequirement(new OpenApiSecurityRequirement()
	{
		{
		 new OpenApiSecurityScheme
		 {
			 Reference=new OpenApiReference
			 {
				 Type=ReferenceType.SecurityScheme,
				 Id="Bearer"
			 }
		 },
		 Array.Empty<string>()
		}
	});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}


app.ConfigureExceptionHandlingMiddleware();
app.UseAuthorization();

app.MapControllers();

app.Run();
