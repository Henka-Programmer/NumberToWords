using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace NumberToWords.Helpers {
  internal static class LetterCaseHelper {
    public static string ConvertLetterCaseTo(this string str, string langCode, LetterCase letterCase) {
      var cultureInfo = CultureInfo.GetCultureInfo(langCode);
      switch (letterCase) {
        case LetterCase.Lowercase:
          return str.ToLower(cultureInfo);
        case LetterCase.Uppercase:
          return str.ToUpper(cultureInfo);
        case LetterCase.TitleCase:
          return cultureInfo.TextInfo.ToTitleCase(str);
        case LetterCase.SentenceCase:
          var r = new Regex(@"(^[a-z])|\.\s+(.)", RegexOptions.ExplicitCapture);
          var result = r.Replace(str.ToLower(), s => s.Value.ToUpper());
          return result;
        default:
          throw new NotImplementedException();
      }
    }
  }
}
