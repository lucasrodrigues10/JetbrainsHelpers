using System;
using System.Collections.Generic;
using JetbrainsHelpers.Models;
using JetbrainsHelpers.Services.PathLocator.Strategies;

namespace JetbrainsHelpers.Services.PathLocator
{
    public class PathLocatorContext
    {
        private readonly IPathLocatorStrategy _strategy;
        public PathLocatorContext(JetbrainsIde option) => _strategy = SetStrategy(option);
        public IEnumerable<ExclusionInformation> FindPaths() => _strategy.FindPaths();

        private static IPathLocatorStrategy SetStrategy(JetbrainsIde option) => option switch
        {
            JetbrainsIde.Rider => new RiderPathLocator(),
            _ => throw new ArgumentOutOfRangeException($"IDE not supported: {option}")
        };
    }
}