using LibTec.Domain.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opcoes =>
{
    opcoes.SwaggerDoc("v1", new OpenApiInfo()
    {
        Version = "v1",
        Title = "LibTech",
        Description = "LibTech",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
    var filePath = Path.Combine(builder.Environment.ContentRootPath, @"Documents\LibTechApi.xml");
    opcoes.IncludeXmlComments(filePath);
});

string str = builder.Configuration.GetConnectionString("LibTec");
builder.Services.AddDbContext<LibTecContexto>(options => options.UseSqlServer(str));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opcoes => opcoes.DocExpansion(DocExpansion.None)); // DocExpansion.None faz com que os verbos http permaneçam fechados ao executar a API.
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
