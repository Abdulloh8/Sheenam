﻿//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace 
//==================================================

using System;
using Xeptions;

namespace Sheenam.Api.Models.Foundations.Guests.Exceptions;

public class NullGuestException : Xeption
{
    public NullGuestException() : base(message: "Guest is null") 
    {

    }
}
