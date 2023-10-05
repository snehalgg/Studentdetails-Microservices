using Ocelot.DependencyInjection;
using Ocelot.Middleware;



var builder = WebApplication.CreateBuilder(args);



// Add services to the container.



builder.Services.AddControllers();



builder.Configuration.AddJsonFile("ocelot.json");
builder.Services.AddOcelot();





// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();





builder.Services.AddSwaggerGen();





var app = builder.Build();
app.UseOcelot().Wait();
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
//https://localhost:44329/apigateway/AttendanceService
//