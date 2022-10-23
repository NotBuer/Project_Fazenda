var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddDbContext<ApplicationDbContext>(optionsBuilder =>
                                optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                                options => options.MigrationsAssembly("API")));

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddFluentValidationRulesToSwagger();

Injector.RegisterInjection(services);

await using WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.MapEndpoints();
app.Run();