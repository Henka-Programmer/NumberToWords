namespace NumberToWords.Interfaces
{
  public interface IConverterDictionary {
    /// <summary>
    /// Language Name in English.
    /// </summary>
    string LanguageName { get; }

    string GetZero();
    /// <summary>
    /// the Conjunction word 'and' In English
    /// </summary>
    /// <returns></returns>
    string GetAnd();

    string GetMinus();

    /// <summary>
    /// Ones names
    /// </summary>
    /// <param name="unit"></param>
    /// <returns></returns>
    string GetUnit(int unit);

    string GetTen(int ten);

    string GetTeen(int teen);

    string GetHundred(int hundred);
    string GetGroup(int group);

    ICurrencyInfo GetCurrencyInfo(string currencyISO4217Code);
  }
}
