using System.Collections.Generic;
using System.Text;

namespace YAGNI.App.Services
{
    public abstract class ReplaceService
    {
        protected Dictionary<char, char> ReplacementMap = new Dictionary<char, char>();

        protected abstract bool CanReplace(string input);

        public string Replace(string input)
        {
            if (!this.CanReplace(input)) return input;

            var stringBuilder = new StringBuilder(input);

            foreach (var kvp in this.ReplacementMap)
            {
                stringBuilder.Replace(kvp.Key, kvp.Value);
            }

            return stringBuilder.ToString();
        }
    }
}