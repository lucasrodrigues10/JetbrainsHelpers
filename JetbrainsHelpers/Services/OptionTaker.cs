using System;
using System.Linq;
using JetbrainsHelpers.Models;

namespace JetbrainsHelpers.Services
{
    public static class OptionTaker
    {
        public static JetbrainsIde Get()
        {
            var options = string.Concat(Enum.GetValues<JetbrainsIde>()
                                            .Select(item => $"{(int) item} - {item}\n"));
            Console.Write($"{options}Choose JetBrains IDE: ");

            var option = Console.ReadLine();

            if (!int.TryParse(option, out var intOption))
                throw new ArgumentException($"Only numbers options are allowed {option}");

            return (JetbrainsIde) intOption;
        }
    }
}