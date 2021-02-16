namespace DRY.Solution.ViewModels
{
    public static class StringExtensions
    {
        public static string AdjustName(this string name)
            =>
                name.Trim(' ').ToUpperInvariant();
    }
}