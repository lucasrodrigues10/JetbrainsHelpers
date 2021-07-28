using System;
using JetbrainsHelpers.Services;
using JetbrainsHelpers.Services.PathLocator;

namespace JetbrainsHelpers.AppStart
{
    public static class Program
    {
        public static void Main()
        {
            var pathLocator = new PathLocatorContext(OptionTaker.Get());
            var exclude = new WindowsDefenderExclude();

            exclude.Add(pathLocator.FindPaths());
            exclude.ExcludeAll();

            Console.WriteLine("Press something to exit");
            Console.ReadKey();
        }
    }
}