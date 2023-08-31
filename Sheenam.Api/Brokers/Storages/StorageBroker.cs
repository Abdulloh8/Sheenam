using EFxceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sheenam.Api.Models.Foundations.Guests;

namespace Sheenam.Api.Brokers.Storages;

public  class StorageBroker : EFxceptionsContext
{
    private readonly IConfiguration Configuration;

    public StorageBroker(IConfiguration configuration)
    {
        this.Configuration = configuration;
        this.Database.Migrate();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = this.Configuration.GetConnectionString(name: "DefaultConnection");

        optionsBuilder.UseSqlServer(connectionString);
    }

    public override void Dispose() { }

    public DbSet<Guest> Guests { get; set; }

}
