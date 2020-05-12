namespace NumberToWords.Interfaces
{
  /// <summary>
  /// Convertion Options Interface to determine the Conversion options
  /// </summary>
  public interface IConversionOptions
  {
    LetterCase LetterCase { get; set; }
    string WordSeparator { get; set; }
    string CurrencyCode { get; set; }
    string LanguageCode { get; set; }
  }
}
