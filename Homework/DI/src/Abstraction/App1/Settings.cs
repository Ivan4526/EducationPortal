namespace App
{
    public class Settings
    {
        public string Name { get; internal set; }

        public string Value { get; internal set; }

        #region Constant settings names

        public const string OsGlobalDirectory = "OsGlobalDirectory";

        #endregion
    }
}