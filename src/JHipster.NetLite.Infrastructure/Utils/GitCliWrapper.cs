// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using JHipster.NetLite.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHipster.NetLite.Infrastructure.Utils;

public class GitCliWrapper
{
    private readonly ProcessStartInfo processStartInfo = new ProcessStartInfo();

    private readonly ILogger<IInitDomainService> _logger;

    public GitCliWrapper(string workingDirectory, ILogger<IInitDomainService> logger)
    {
        _logger = logger;
        InitializeProcessStartInfo(workingDirectory);
    }

    private void InitializeProcessStartInfo(string workingDirectory)
    {
        processStartInfo.FileName = "git";
        processStartInfo.UseShellExecute = false;
        processStartInfo.RedirectStandardOutput = true;
        processStartInfo.RedirectStandardError = true;
        processStartInfo.WorkingDirectory = workingDirectory;
    }

    private bool HasGit()
    {
        try
        {
            processStartInfo.Arguments = "--version";

            Process process = new Process();
            process.StartInfo = processStartInfo;
            process.Start();
            process.WaitForExit();
        }
        catch (Exception)
        {
            _logger.LogError("Git is not installed");
            return false;
        }
        return true;
    }

    public void GitInit()
    {
        if (HasGit())
        {
            processStartInfo.Arguments = "init";

            Process process = new Process();
            process.StartInfo = processStartInfo;
            process.Start();
            process.WaitForExit();
        }
    }

    public void GitAddAll()
    {
        if (HasGit())
        {
            Process process = new Process();
            processStartInfo.Arguments = $"add -A";
            process.StartInfo = processStartInfo;
            process.Start();
            process.WaitForExit();

        }
    }

    public void GitCommit(string message)
    {

    }
}
