using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHipster.NetLite.Infrastucture.Repositories.Exceptions;

public class InvalidFolderException : Exception
{
    public InvalidFolderException() : base() { }
    public InvalidFolderException(string message) : base(message) { }
    public InvalidFolderException(string message, Exception innerException) : base(message, innerException) { }


}
