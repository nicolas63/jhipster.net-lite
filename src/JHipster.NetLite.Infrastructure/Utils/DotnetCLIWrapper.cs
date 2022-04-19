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

    public DotnetCLIWrapper(string workingDirectory) => InitializeProcessStartInfo(workingDirectory);

    private void InitializeProcessStartInfo(string workingDirectory)
    {
        processStartInfo.FileName = "dotnet";
        processStartInfo.UseShellExecute = false;
        processStartInfo.WorkingDirectory = workingDirectory;
    }

    private void StartProcess(Process process)
    {
        try
        {
            process.Start();
        }
        catch (Win32Exception ex)
        { 
            //log de l'erreur
        }
    }

    public void NewSln(string solutionName, bool force)
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
        StartProcess(process);
        process.WaitForExit();
    }

    public void SlnAdd(string solutionFile, params string[] projects)
    {
        processStartInfo.Arguments = "sln " + solutionFile + " add " + String.Join(" ", projects);
        Process process = new Process();
        process.StartInfo = processStartInfo;
        StartProcess(process);
        process.WaitForExit();
    }

    public void Build()
    {
        processStartInfo.Arguments = "build";
        Process process = new Process();
        process.StartInfo = processStartInfo;
        StartProcess(process);
        process.WaitForExit();
    }
}
