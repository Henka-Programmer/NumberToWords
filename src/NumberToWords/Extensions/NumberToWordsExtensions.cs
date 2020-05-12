using NumberToWords.Interfaces;
using NumberToWords.Internals;
using System;
using System.Collections.Generic;
using System.Text;

namespace NumberToWords.Extensions {
  public static class NumberToWordsExtensions {
    public static string ConvertToWords(this INumberToWordsConverter converter, double number, Action<IConversionOptions> optionsBuilder) {
      if (converter is null) {
        throw new ArgumentNullException(nameof(converter));
      }

      if (optionsBuilder is null) {
        throw new ArgumentNullException(nameof(optionsBuilder));
      }

      var options = ConversionOptions.Default;
      optionsBuilder?.Invoke(options);
      return converter.ConvertToWords(number, options);
    }
  }
}
