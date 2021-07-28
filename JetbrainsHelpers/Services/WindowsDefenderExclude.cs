using System;
using System.Collections.Generic;
using System.Management.Automation;
using JetbrainsHelpers.Models;

namespace JetbrainsHelpers.Services
{
    public class WindowsDefenderExclude
    {
        private readonly List<ExclusionInformation> _exclusions = new();

        public void Add(IEnumerable<ExclusionInformation> list) => _exclusions.AddRange(list);

        public void ExcludeAll()
        {
            foreach (var exclusion in _exclusions)
            {
                using var powerShellInst = PowerShell.Create();

                var type = exclusion.ExclusionType;
                var parameter = Environment.ExpandEnvironmentVariables(exclusion.Parameter);
                powerShellInst.AddScript($@"powershell -Command Add-MpPreference -Exclusion{type} '{parameter}'");
                Console.WriteLine($"Excluding {type} {parameter} from Windows Defender");
                powerShellInst.Invoke();
            }
        }
    }
}