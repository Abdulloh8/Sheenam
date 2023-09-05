namespace Sheenam.Api.Models.Foundations.Guests.Exceptions;

public class GuestValidationException
{
    private NullGuestException nullGuestException;

    public GuestValidationException(NullGuestException nullGuestException)
    {
        this.nullGuestException = nullGuestException;
    }
}
