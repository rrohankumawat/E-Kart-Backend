using System;
using System.Collections.Generic;
using System.Text;

namespace EKart.Core.Enums
{
    public enum OperationStatus
    {
        Success = 0,
        Failure = 1,
        NotFound = 2,
        ValidationError = 3,
        Unauthorized = 4,
        Forbidden = 5,
        Conflict = 6,
        ServerError = 7,
        AlreadyExists = 8,
        Deleted = 9,
        Updated = 10,
        Created = 11
    }
}
