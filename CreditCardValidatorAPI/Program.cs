using CreditCardValidatorAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add services to the container.
builder.Services.AddControllers();  // Add controller services to the DI container
builder.Services.AddScoped<ICreditCardValidator, CreditCardValidator>();  // Register the credit card validator service

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // Check if the environment is development
{
    app.UseSwagger(); // Use swagger
    app.UseSwaggerUI(); // Use swagger UI
    app.UseDeveloperExceptionPage();  // Use developer exception page for detailed error information
}

app.UseHttpsRedirection();  // Use HTTPS redirection for all requests

app.UseAuthorization();  // Use authorization middleware

app.MapControllers();  // Map controller routes

app.Run(); // Run the application


