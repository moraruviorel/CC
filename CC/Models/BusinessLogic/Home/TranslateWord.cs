using System.Linq;
using CC.Models.Classes;
using CC.Models.Enums;

namespace CC.Models.BusinessLogic.Home
{
    public class TranslateWord
    {
        public static string GetWord(string word)
        {
            
            var translateWordRow = new Database.TranslateWordEntities().TranslateWords.AsQueryable()
                .FirstOrDefault(x => x.word == word);

            if (translateWordRow == null) return word;

            switch (MySession.Current.Language)
            {
                case LanguageTypes.Romanian:
                    word = translateWordRow.ro;
                    break;
                case LanguageTypes.Russian:
                    word = translateWordRow.ru;
                    break;
                case LanguageTypes.English:
                    word = translateWordRow.en;
                    break;
            }

            return word;
        }
    }
}