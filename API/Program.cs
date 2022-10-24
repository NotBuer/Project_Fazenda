var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddDbContext<ApplicationDbContext>(optionsBuilder =>
                                optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                                options => options.MigrationsAssembly("API")));

services.AddEndpointsApiExplorer();
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = builder.Environment.ApplicationName,
        Version = "v1"
    });
});
services.AddFluentValidationRulesToSwagger();

Injector.RegisterInjection(services);

await using WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapEndpoints();
app.Run();