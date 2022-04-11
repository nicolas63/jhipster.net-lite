// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

namespace JHipster.NetLite.Web.DTO;

public class ProjectDto
{
    public ProjectDto(string folder) => Folder = folder;

    public string Folder { get; set; }
}
