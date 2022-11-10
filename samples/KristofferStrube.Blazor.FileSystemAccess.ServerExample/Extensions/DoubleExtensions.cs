using System.Globalization;

namespace KristofferStrube.Blazor.FileSystemAccess.ServerExample
{
    public static class DoubleExtensions
    {
        public static string AsString(this double d)
        {
            return d.ToString(CultureInfo.InvariantCulture);
        }
    }
}
