using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using JetbrainsHelpers.Models;

namespace JetbrainsHelpers.Services.PathLocator.Strategies
{
    public class RiderPathLocator : IPathLocatorStrategy
    {
        private const string MsBuildScript =
            @"Resolve-Path HKLM:\SOFTWARE\Microsoft\MSBuild\ToolsVersions\* | Get-ItemProperty -Name MSBuildToolsPath";

        public IEnumerable<ExclusionInformation> FindPaths()
        {
            var msBuildPaths = FindMsBuild();
            foreach (var path in msBuildPaths)
                yield return new ExclusionInformation(ExclusionType.Process, path);

            yield return new ExclusionInformation(ExclusionType.Folder,
                @"%USERPROFILE%\AppData\Local\JetBrains\Rider2021.1");
            yield return new ExclusionInformation(ExclusionType.Folder,
                @"%USERPROFILE%\AppData\Local\JetBrains\Toolbox\apps\Rider");
            yield return new ExclusionInformation(ExclusionType.Folder, @"%USERPROFILE%\RiderProjects");
            yield return new ExclusionInformation(ExclusionType.Folder, @"%USERPROFILE%\.nuget");
        }

        private static IEnumerable<string> FindMsBuild()
        {
            using var powershell = PowerShell.Create();
            return powershell.AddScript(MsBuildScript)
                             .Invoke()
                             .SelectMany(c => c.Properties)
                             .Where(c => c.Name == "MSBuildToolsPath")
                             .Select(c => (string) c.Value + "MSBuild.exe");
        }
    }
}