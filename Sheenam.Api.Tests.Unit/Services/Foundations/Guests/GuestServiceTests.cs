//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace 
//==================================================

using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Sheenam.Api.Brokers.Storages;
using Sheenam.Api.Models.Foundations.Guests;
using Sheenam.Api.Services.Foundations.Guests;


namespace Sheenam.Api.Tests.Unit.Services.Foundations.Guests;

public partial class GuestServiceTests
{
    private readonly Mock<IStorageBroker> StorageBrokerMock;
    private readonly IGuestService guestService;
    

    public GuestServiceTests()
    {
        this.StorageBrokerMock = new Mock<IStorageBroker>();
        this.guestService = new GuestService(storageBroker: this.StorageBrokerMock.Object);
    }
    private  Guest CreateRandomGuest = new Guest
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

    [Fact]
    public async Task ShouldAddGuestAsync()
    {
        // given 
        Guest randomGuast = new Guest();
        Guest inputGuest = randomGuast;
        Guest returningGuest = inputGuest;
        Guest expectedGuest = returningGuest.DeepClone();


        this.StorageBrokerMock.Setup(broker =>
        broker.InsertGuestAsync(inputGuest))
            .ReturnsAsync(returningGuest);

        // when
        Guest actualGuest = 
            await this.guestService.AddGuestAsync(inputGuest);

        //then
        actualGuest.Should().BeEquivalentTo(expectedGuest);

        this.StorageBrokerMock.Verify(broker => broker.InsertGuestAsync(inputGuest), Times.Once);

        this.StorageBrokerMock.VerifyNoOtherCalls();

        // Arrange
        /*Guest randomGuest = new Guest
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
        actual.Should().BeEquivalentTo(randomGuest);*/
    }
}
