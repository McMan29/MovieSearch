using MovieSearch.Server.Configuration;
using MovieSearch.Server.Configuration.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MovieSearch.Server.Service.Interface;
using MovieSearch.Server.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

MovieApiConfiguration movieApiConfiguration = new();
var movieApi = builder.Configuration.GetSection("MovieApi");
movieApi.Bind(movieApiConfiguration);
builder.Services.Configure<MovieApiConfiguration>(movieApi);

await new MovieApiConfigurationValidator().ValidateAndThrowAsync(movieApiConfiguration).ConfigureAwait(false);

builder.Services.AddScoped<IMovieService, MovieService>();

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(
//        policy =>
//        {
//            policy.WithOrigins("https://localhost:5173", "https://localhost:5174")
//                .AllowAnyHeader()
//                .AllowAnyMethod();
//        });
//});

builder.Services.AddCors(options =>
{
    options.AddPolicy("LocalCorsPolicy", builder => builder
        .WithOrigins("https://localhost:5173")
        .AllowAnyMethod()
        .AllowCredentials()
        .WithHeaders("Accept", "Content-Type", "Origin", "X-My-Header"));
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

// app.UseCors();
app.UseCors("LocalCorsPolicy");

app.Run();
