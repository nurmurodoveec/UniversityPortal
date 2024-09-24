using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityPortal.Api.Data;
using UniversityPortal.Api.Interfaces;
using UniversityPortal.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo {
        Title = "University Portal", 
        Version = "v1",
        Description = "An API to perform University operations",
        TermsOfService= new Uri("https://example.com.terms"),
        Contact= new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name="Nurmurodoveec",
            Email= "nurmurodoveec@mail.ru",
           
        }
          


    });
});
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();


builder.Services.AddControllers(options =>
{
    options.Filters.Add<LogActionFilter>();      
    options.Filters.Add<GlobalExceptionFilter>();  
});

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
            .Where(e => e.Value.Errors.Count > 0)
            .Select(e => new { Field = e.Key, Error = e.Value.Errors.First().ErrorMessage });

        return new BadRequestObjectResult(new
        {
            Message = "Validation Failed",
            Errors = errors
        });
    };
});
builder.Services.AddAutoMapper(typeof(MappingProfile)); 


builder.Services.AddScoped<LogActionFilter>();
builder.Services.AddScoped<GlobalExceptionFilter>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<IGradeService, GradeService>();
builder.Services.AddScoped<ITimetableService, TimetableService>();
builder.Services.AddScoped<INewsService, NewsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "University Portal v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
