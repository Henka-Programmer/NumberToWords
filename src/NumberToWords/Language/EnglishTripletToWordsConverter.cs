using NumberToWords.Interfaces;
using System.Collections.Generic;

namespace NumberToWords.Language
{
  public class EnglishTripletToWordsConverter : ITripletToWordsConverter
  {
    private readonly EnglishDictionary _dictionary;

    public EnglishTripletToWordsConverter(EnglishDictionary dictionary)
    {
      _dictionary = dictionary;
    }

    public string ToWords(double number, int level, double remainingNumber)
    {
      var units = (int)(number % 10);
      var tens = (int)(number / 10 % 10);
      var hundreds = (int)(number / 100 % 10);
      var words = new List<string>();
      if (hundreds > 0)
      {
        words.Add(_dictionary.GetHundred(hundreds));
      }

      words.Add(GetSubHundred(tens, units));
      return string.Join(" ", words.ToArray());
    }

    private string GetSubHundred(int tens, int units)
    {
      if (tens == 0 && units == 0)
      {
        return string.Empty;
      }

      var words = new List<string>();
      if (tens == 1)
      {
        words.Add(_dictionary.GetTeen(units));
      }
      else
      {
        if (tens > 0)
        {
          words.Add(_dictionary.GetTen(tens));
        }
        if (units > 0)
        {
          words.Add(_dictionary.GetUnit(units));
        }
      }
      return string.Join("-", words.ToArray());
    }
  }
}
