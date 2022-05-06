using JHipster.NetLite.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
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

    public GitCliWrapper Init()
    {
        if (HasGit())
        {
            processStartInfo.Arguments = "init";

            Process process = new Process();
            process.StartInfo = processStartInfo;
            process.Start();
            process.WaitForExit();
        }

        return this;
    }

    public GitCliWrapper AddAll()
    {
        if (HasGit())
        {
            Process process = new Process();
            processStartInfo.Arguments = $"add -A";
            process.StartInfo = processStartInfo;
            process.Start();
            process.WaitForExit();
        }

        return this;
    }

    public GitCliWrapper Commit(string message)
    {
        if (HasGit())
        {
            Process process = new Process();
            processStartInfo.Arguments = $"commit -m \"{message}\"";
            process.StartInfo = processStartInfo;
            process.Start();
            process.WaitForExit();
            var test = process.ExitCode;
        }

        return this;
    }

    public ArrayList GetCommits()
    {
        ArrayList commits = new ArrayList();
        StringBuilder sb = new StringBuilder();
        int nbCommitInfo = 0;

        if (HasGit())
        {
            Process process = new Process();
            processStartInfo.Arguments = "log";
            process.StartInfo = processStartInfo;

            process.OutputDataReceived += (sender, args) =>
            {
                Console.WriteLine(args.Data);
                sb.AppendLine(args.Data);
                nbCommitInfo++;

                if (nbCommitInfo == 6)
                {
                    nbCommitInfo = 0;
                    commits.Add(sb.ToString());
                    sb = new StringBuilder();
                }
            };
            process.Start();
            process.BeginOutputReadLine();
            process.WaitForExit();
        }

        return commits;
    }
}
