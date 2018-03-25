using System.Linq;

namespace CC.Models.BusinessLogic.Home
{
    public class TranslateWord
    {
        public static string GetWord(string word, string language)
        {
            var returnWord = word;

            var translateWordRow = new Database.TranslateWordEntities().TranslateWords.AsQueryable()
                .FirstOrDefault(x => x.word == word);

            if (translateWordRow == null) return returnWord;

            switch (language)
            {
                case "ro":
                    returnWord = translateWordRow.ro;
                    break;
                case "ru":
                    returnWord = translateWordRow.ru;
                    break;
                case "en":
                    returnWord = translateWordRow.en;
                    break;
                default:
                    returnWord = word;
                    break;

            }

            return returnWord;
        }
    }
}