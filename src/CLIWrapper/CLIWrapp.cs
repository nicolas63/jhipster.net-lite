using System.Diagnostics;
using System.Linq;

namespace CLIWrapper;

public class CLIWrapp
{
    private ProcessStartInfo processStartInfo = new ProcessStartInfo();

    public CLIWrapp(string workingDirectory) => InitializeProcessStartInfo(workingDirectory);

    private void InitializeProcessStartInfo(string workingDirectory)
    {
        processStartInfo.FileName = "otnet";
        processStartInfo.UseShellExecute = false;
        processStartInfo.WorkingDirectory = workingDirectory;
    }

    public void NewSln(string solutionName, bool force)
    {
        if (force)
        {
            processStartInfo.Arguments = $"new sln --name {solutionName} --force";
        }
        else
        {
            processStartInfo.Arguments = $"new sln --name {solutionName}";
        }
        Process process = new Process();
        process.StartInfo = processStartInfo;
        process.Start();
    }

    public void SlnAdd(string solutionFile, params string[] projects)
    {
        processStartInfo.Arguments = $"sln {solutionFile} add {String.Join(" ", projects)}";
        Process process = new Process();
        process.StartInfo = processStartInfo;
        process.Start();
    }

    public void Build()
    {
        processStartInfo.Arguments = "build";
        Process process = new Process();
        process.StartInfo = processStartInfo;
        process.Start();
    }
}
