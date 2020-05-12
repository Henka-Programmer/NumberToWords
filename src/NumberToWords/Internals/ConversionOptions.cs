using NumberToWords.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NumberToWords.Internals {
  internal class ConversionOptions : IConversionOptions {
    public static readonly ConversionOptions Default = new ConversionOptions();
    public ConversionOptions() {
      LetterCase = LetterCase.Lowercase;
      CurrencyCode = "USD";
      WordSeparator = " ";
      LanguageCode = "en";
    }
    public LetterCase LetterCase { get; set; }
    public string WordSeparator { get; set; }
    public string CurrencyCode { get; set; }
    public string LanguageCode { get; set; }
  }
}
