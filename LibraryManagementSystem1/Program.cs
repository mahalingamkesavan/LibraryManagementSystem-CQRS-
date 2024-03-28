using LibraryBAL.BAO;
using LibraryBAL.Interface;
using Library.IOC;
using Microsoft.AspNetCore.HttpLogging;
using LibraryDAL.DAO.IRepository;
using LibraryDAL.DAO.Repository;
using LibraryBAL.IOC;
using MediatR;
using LibraryDAL.DAO.Queries.UserDetailQueries;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy( options =>
                options.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod());
});
builder.Logging.AddLog4Net("Log4net.config");
builder.Services.AddHttpLogging(logging=>logging.LoggingFields=HttpLoggingFields.All);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerAuthentication();
builder.Services.AddLibraryAuthentication(builder.Configuration);
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
builder.Services.AddLibraryContext(builder.Configuration);
builder.Services.AddMediatR(typeof(GetListUserDetailQueries).Assembly);
builder.Services.AddScoped<IUnitOfWorkBAL, UnitOfWorkBAL>();
builder.Services.AddScoped<IUnitOfWorkDAL, UnitOfWorkDAO>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.ConfigureExceptionHandler();
app.UseCors();

app.UseHttpLogging();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
