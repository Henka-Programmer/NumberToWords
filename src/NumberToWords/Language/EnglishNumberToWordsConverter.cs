using NumberToWords.Attributes;
using NumberToWords.Interfaces;

namespace NumberToWords.Language
{
  [NumberToWordsConverter(languageCode: "en", languageName: "English")]
  public class EnglishNumberToWordsConverter : INumberToWordsConverter
  {
    public string ConvertToWords(double number, IConversionOptions options = null)
    {
      var dictionary = new EnglishDictionary();
      var groupsToWordsConverter = new EnglishTripletToWordsConverter(dictionary);

      var converter = new NumberToWordsConverterBuilder()
          .WithDictionary(dictionary)
          .WithTripletConverter(groupsToWordsConverter)
          .Build();

      return converter.ConvertToWords(number, options);
    }
  }
}
