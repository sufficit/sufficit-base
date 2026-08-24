using System.Collections.Generic;

namespace Sufficit.EndPoints.Documentation
{
    public class ClassDocumentation
    {
        public string ClassName { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Namespace { get; set; } = string.Empty;

        public string AssemblyName { get; set; } = string.Empty;

        public string Summary { get; set; } = string.Empty;

        public string Remarks { get; set; } = string.Empty;

        public string Example { get; set; } = string.Empty;

        public List<PropertyDocumentation> Properties { get; set; } = new List<PropertyDocumentation>();

        public List<MethodDocumentation> Methods { get; set; } = new List<MethodDocumentation>();
    }

    public class PropertyDocumentation
    {
        public string Name { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public bool CanRead { get; set; }

        public bool CanWrite { get; set; }

        public string Summary { get; set; } = string.Empty;

        public string Remarks { get; set; } = string.Empty;

        public string Example { get; set; } = string.Empty;
    }

    public class MethodDocumentation
    {
        public string Name { get; set; } = string.Empty;

        public string ReturnType { get; set; } = string.Empty;

        public List<string> Parameters { get; set; } = new List<string>();

        public string Summary { get; set; } = string.Empty;

        public string Remarks { get; set; } = string.Empty;
    }
}
