using System;

namespace scratch_collect.API.Exceptions
{
    public class BadRequestException: Exception
    {
        public BadRequestException(string message):base(message)
        { 
        }
    }
}