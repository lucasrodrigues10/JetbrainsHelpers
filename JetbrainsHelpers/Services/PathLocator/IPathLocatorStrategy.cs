using System.Collections.Generic;
using JetbrainsHelpers.Models;

namespace JetbrainsHelpers.Services.PathLocator
{
    public interface IPathLocatorStrategy
    {
        IEnumerable<ExclusionInformation> FindPaths();
    }
}