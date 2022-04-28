// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHipster.NetLite.Infrastructure.Repositories.Exceptions;

public class GenerationAPIException : Exception
{
    public GenerationAPIException() : base() { }
    public GenerationAPIException(string message) : base(message) { }
    public GenerationAPIException(string message, Exception innerException) : base(message, innerException) { }
}
