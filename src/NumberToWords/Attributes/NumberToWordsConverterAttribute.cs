using System;
using System.Collections.Generic;
using System.Text;

namespace NumberToWords.Attributes {
  [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
  public sealed class NumberToWordsConverterAttribute : Attribute {
    /// <summary>
    /// ISO 639-1 Language code.
    /// </summary>
    public string LanguageCode { get; private set; }
    public string LanguageName { get; private set; }
    public NumberToWordsConverterAttribute(string languageCode, string languageName) {
      if (string.IsNullOrEmpty(languageCode) || languageCode.Length != 2) {
        throw new ArgumentException($"languageCode Argument value: '{languageCode}', not a valid ISO 639-1 code, Code length should be 2 letters.");
      }

      LanguageCode = languageCode.ToLower();
      LanguageName = languageName;
    }
  }
}
