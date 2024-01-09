using AuctionService.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{

    // Add services to the container.

    builder.Services.AddControllers();
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    // add ef
    builder.Services.AddDbContext<AuctionDbContext>(opt =>
    {
        opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));

    });
}



var app = builder.Build();

{
    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
    try
    {
        DbInitializer.InitDb(app);
    }
    catch(Exception e)
    {
        Console.WriteLine(e);
    }

    app.Run();
}

