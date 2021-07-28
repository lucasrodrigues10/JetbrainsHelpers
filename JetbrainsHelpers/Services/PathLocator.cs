using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace JetbrainsHelpers.Services
{
    public static class PathLocator
    {
        public static IEnumerable<string> FindMsBuild()
        {
            using var powerShellInst = PowerShell.Create();
            powerShellInst.AddScript(
                @"Resolve-Path HKLM:\SOFTWARE\Microsoft\MSBuild\ToolsVersions\* | Get-ItemProperty -Name MSBuildToolsPath");
            return powerShellInst.Invoke()
                                 .SelectMany(c => c.Properties)
                                 .Where(c => c.Name == "MSBuildToolsPath")
                                 .Select(c => (string) c.Value + "MSBuild.exe");
        }
    }
}