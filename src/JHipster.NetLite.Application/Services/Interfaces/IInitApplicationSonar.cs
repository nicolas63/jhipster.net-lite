// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using JHipster.NetLite.Domain.Entities;

namespace JHipster.NetLite.Application.Services.Interfaces;

public interface IInitApplicationSonar
{
    Task Init(Project project);
}
