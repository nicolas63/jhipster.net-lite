// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using JHipster.NetLite.Domain.Entities;

namespace BlazorWebClient.Services.Api;

public interface IApiService
{
    Task Post(Project project);
}
