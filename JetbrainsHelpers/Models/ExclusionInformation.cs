namespace JetbrainsHelpers.Models
{
    public class ExclusionInformation
    {
        public ExclusionInformation(ExclusionType type, string parameter)
        {
            ExclusionType = type;
            Parameter = parameter;
        }

        public ExclusionType ExclusionType { get; }
        public string Parameter { get; }
    }
}