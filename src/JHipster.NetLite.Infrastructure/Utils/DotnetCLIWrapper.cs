using JHipster.NetLite.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHipster.NetLite.Infrastructure.Utils;

public class DotnetCLIWrapper
{
    private ProcessStartInfo processStartInfo = new ProcessStartInfo();

    private ILogger<IInitDomainService> _logger;

    public DotnetCLIWrapper(string workingDirectory, ILogger<IInitDomainService> logger) 
    { 
        _logger = logger;
        InitializeProcessStartInfo(workingDirectory);
    }

    private void InitializeProcessStartInfo(string workingDirectory)
    {
        processStartInfo.FileName = "dotnet";
        processStartInfo.UseShellExecute = false;
        processStartInfo.WorkingDirectory = workingDirectory;
    }

    private bool HasDotnet()
    {
        try
        {
            processStartInfo.Arguments = "--version";

            Process process = new Process();
            process.StartInfo = processStartInfo;
            process.Start();
            process.WaitForExit();
        }
        catch (Exception ex)
        {
            _logger.LogWarning("Dotnet is not installed");
            return false;
        }
        return true;
    }

    public void NewSln(string solutionName, bool force)
    {
        if (HasDotnet())
        {
            if (force)
            {
                processStartInfo.Arguments = "new sln --name " + solutionName + " --force";
            }
            else
            {
                processStartInfo.Arguments = "new sln --name " + solutionName;
            }

            Process process = new Process();
            process.StartInfo = processStartInfo;
            process.Start();
            process.WaitForExit();
        }
    }

    public void SlnAdd(string solutionFile, params string[] projects)
    {
        if (HasDotnet())
        {
            processStartInfo.Arguments = "sln " + solutionFile + " add " + String.Join(" ", projects);
            Process process = new Process();
            process.StartInfo = processStartInfo;
            process.Start();
            process.WaitForExit();
        }
    }

    public void Build()
    {
        if (HasDotnet())
        {
            processStartInfo.Arguments = "build";
            Process process = new Process();
            process.StartInfo = processStartInfo;
            process.Start();
            process.WaitForExit();
        }
    }
}
