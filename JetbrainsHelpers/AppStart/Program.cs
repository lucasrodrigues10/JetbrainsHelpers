using System;
using System.Linq;
using JetbrainsHelpers.Models;
using JetbrainsHelpers.Services;

namespace JetbrainsHelpers.AppStart
{
    public static class Program
    {
        public static void Main()
        {
            var exclude = new WindowsDefenderExclude();

            PathLocator.FindMsBuild().ToList().ForEach(path => exclude.Add(ExclusionType.Process, path));
            exclude.Add(ExclusionType.Path, @"%USERPROFILE%\AppData\Local\JetBrains\Rider2021.1");
            exclude.Add(ExclusionType.Path, @"%USERPROFILE%\AppData\Local\JetBrains\Toolbox\apps\Rider");
            exclude.Add(ExclusionType.Path, @"%USERPROFILE%\RiderProjects");
            exclude.Add(ExclusionType.Path, @"%USERPROFILE%\.nuget");
            exclude.ExcludeAll();

            Console.WriteLine("Press something to exit");
            Console.ReadKey();
        }
    }
}