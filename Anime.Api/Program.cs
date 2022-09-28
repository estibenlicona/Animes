using Anime.Infrastructure.Extensions;
using MediatR;
using Naruto.Infrastructure.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddMediatR(Assembly.Load("Anime.Application"), typeof(Program).Assembly);
builder.Services.AddAutoMapper(Assembly.Load("Anime.Application"));
string[] origins = config.GetSection("Cors:UrlOrigins").Get<IEnumerable<string>>().ToArray();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builderx => builderx.WithOrigins(origins)
                            .AllowAnyHeader()
                            .WithMethods("GET")
                            .AllowCredentials());
});
builder.Services.AddRepositories().AddDomainServices().AddConfigurations(config);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Animes Api", Version = "v1" });
});

builder.Services.AddHttpClient();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
