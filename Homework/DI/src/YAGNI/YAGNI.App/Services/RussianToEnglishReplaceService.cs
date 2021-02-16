using System.Linq;

namespace YAGNI.App.Services
{
    public class RussianToEnglishReplaceService : ReplaceService
    {
        public RussianToEnglishReplaceService()
        {
            this.ReplacementMap.Add('й', 'q');
            this.ReplacementMap.Add('ц', 'w');
            this.ReplacementMap.Add('у', 'e');
            this.ReplacementMap.Add('к', 'r');
            this.ReplacementMap.Add('е', 't');
            this.ReplacementMap.Add('н', 'y');
            this.ReplacementMap.Add('г', 'u');
            this.ReplacementMap.Add('ш', 'i');
            this.ReplacementMap.Add('щ', 'o');
            this.ReplacementMap.Add('з', 'p');
            this.ReplacementMap.Add('х', '[');
            this.ReplacementMap.Add('ъ', ']');
            this.ReplacementMap.Add('ф', 'a');
            this.ReplacementMap.Add('ы', 's');
            this.ReplacementMap.Add('в', 'd');
            this.ReplacementMap.Add('а', 'f');
            this.ReplacementMap.Add('п', 'g');
            this.ReplacementMap.Add('р', 'h');
            this.ReplacementMap.Add('о', 'j');
            this.ReplacementMap.Add('л', 'k');
            this.ReplacementMap.Add('д', 'l');
            this.ReplacementMap.Add('ж', ';');
            this.ReplacementMap.Add('э', '\'');
            this.ReplacementMap.Add('я', 'z');
            this.ReplacementMap.Add('ч', 'x');
            this.ReplacementMap.Add('с', 'c');
            this.ReplacementMap.Add('м', 'v');
            this.ReplacementMap.Add('и', 'b');
            this.ReplacementMap.Add('т', 'n');
            this.ReplacementMap.Add('ь', 'm');
            this.ReplacementMap.Add('б', ',');
            this.ReplacementMap.Add('ю', '.');
        }

        protected override bool CanReplace(string input)
        {
            return input.Any(c => this.ReplacementMap.ContainsKey(c));
        }
    }
}