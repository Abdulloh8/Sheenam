//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace 
//==================================================

using FluentAssertions;
using Moq;
using Sheenam.Api.Brokers.Storages;
using Sheenam.Api.Models.Foundations.Guests;
using Sheenam.Api.Services.Foundations.Guests;
using Xunit;

namespace Sheenam.Api.Tests.Unit.Services.Foundations.Guests;

public class GuestServiceTests
{
    private readonly Mock<IStorageBroker> StorageBrokerMock;
    private readonly IGuestService guestService;

    public GuestServiceTests()
    {
        this.StorageBrokerMock = new Mock<IStorageBroker>();
        this.guestService = new GuestService(storageBroker: this.StorageBrokerMock.Object);
    }

    [Fact]
    public async Task ShouldAddGuestAsync()
    {
        // Arrange
        Guest randomGuest = new Guest
        {
            Address = "Brooks Str.#12",
            DataOfBirth = new DateTime(),
            Email = "random@mail.ru",
            FirstName = "Alex",
            LastName = "Doe",
            Gender = GenderType.Male,
            Id = Guid.NewGuid(),
            PhoneNumber = "1234567890",
        };
        this.StorageBrokerMock.Setup(broker =>
        broker.InsertGuestAsync(randomGuest))
            .ReturnsAsync(randomGuest);
        // Act
        Guest actual = await this.guestService.AddGuestAsync(randomGuest);
        // Assert
        actual.Should().BeEquivalentTo(randomGuest);
    }
}
