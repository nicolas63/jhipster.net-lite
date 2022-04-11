using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHipster.NetLite.Infrastucture.Repositories.Exceptions;

public class InvalidNewPathNameException : Exception
{
    public InvalidNewPathNameException() : base() { }
    public InvalidNewPathNameException(string message) : base(message) { }
    public InvalidNewPathNameException(string message, Exception innerException) : base(message, innerException) { }
}
