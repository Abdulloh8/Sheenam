//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace 
//==================================================


using EFxceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Sheenam.Api.Models.Foundations.Guests;
using System.Threading.Tasks;

namespace Sheenam.Api.Brokers.Storages;

public  class StorageBroker : EFxceptionsContext, IStorageBroker
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

    public async ValueTask<Guest> InsertGuestAsync(Guest guest)
    {
        using var broker = new StorageBroker(this.Configuration);

        EntityEntry<Guest> gustEntityEntry = await broker.Guests.AddAsync(guest);
        await broker.SaveChangesAsync();

        return gustEntityEntry.Entity;
    }

}
