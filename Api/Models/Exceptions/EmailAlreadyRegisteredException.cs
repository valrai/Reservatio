﻿using System;

namespace Reservatio.Models.Exceptions
{
    public class EmailAlreadyRegisteredException : Exception
    {
        public EmailAlreadyRegisteredException()
        { }
        public EmailAlreadyRegisteredException(string message)
            : base(message)
        { }

        public EmailAlreadyRegisteredException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
