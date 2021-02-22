using System;
using System.Data;

using System.Text.Json;

namespace splendor.net5.core.exceptions
{
    public class TransferObjectInvalidException : Exception
    {
        public TransferObjectInvalidException(object to) :
            base($"Transfer object data is invalid, check the detail: {JsonSerializer.Serialize(to)}")
        {

        }
    }
}