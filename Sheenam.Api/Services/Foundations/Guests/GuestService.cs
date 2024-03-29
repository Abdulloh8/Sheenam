﻿//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace 
//==================================================


using Sheenam.Api.Brokers.Storages;
using Sheenam.Api.Models.Foundations.Guests;
using System.Threading.Tasks;

namespace Sheenam.Api.Services.Foundations.Guests;

public class GuestService : IGuestService
{
    private readonly IStorageBroker _storageBroker;

    public GuestService(IStorageBroker storageBroker) =>
        this._storageBroker = storageBroker;
    
    public async ValueTask<Guest> AddGuestAsync(Guest guest) =>
        await this._storageBroker.InsertGuestAsync(guest);

}
