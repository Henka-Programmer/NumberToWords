using NumberToWords.Helpers;
using NumberToWords.Interfaces;
using NumberToWords.Internals;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace NumberToWords
{
  public class GenericNumberToWordsConverter : INumberToWordsConverter {
    private ITripletToWordsConverter _groupToWordsConverter;
    private IConverterDictionary _converterDictionary;

    public GenericNumberToWordsConverter(ITripletToWordsConverter groupToWordsConverter, IConverterDictionary converterDictionary) {
      _groupToWordsConverter = groupToWordsConverter ?? throw new ArgumentNullException(nameof(groupToWordsConverter));
      _converterDictionary = converterDictionary ?? throw new ArgumentNullException(nameof(converterDictionary));
    }


    protected virtual string GetDecimalValue(string decimalPart, int precision = 2) {
      string result = string.Empty;
      if (precision != decimalPart.Length) {

        decimalPart = decimalPart.PadRight(precision, '0');
        result = $"{decimalPart.Substring(0, precision)}{Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator}{ decimalPart.Substring(precision, decimalPart.Length - precision)}";

        result = (Math.Round(Convert.ToDecimal(result))).ToString();
      }
      else {
        result = decimalPart;
      }

      decimalPart = decimalPart.PadRight(precision, '0');

      return result;
    }

    /// <summary>
    /// Process a group of 3 digits
    /// </summary>
    /// <param name="number"></param>
    /// <param name="level"></param>
    /// <param name="remainingNumber"></param>
    /// <returns></returns>
    protected virtual string ProcessGroup(double number, int level, double remainingNumber) {
      return _groupToWordsConverter.ToWords(number, level, remainingNumber);
    }

    public virtual string ConvertToWords(double number, IConversionOptions options = null) {
      var wordsBuilder = new StringBuilder();
      var tempNumber = number;

      var opt = options ?? ConversionOptions.Default;

      var currencyInfo = _converterDictionary.GetCurrencyInfo(opt.CurrencyCode);
      if (number < 0) {
        wordsBuilder.Append(_converterDictionary.GetMinus());
        wordsBuilder.Append(opt.WordSeparator);
        tempNumber = Math.Abs(number);
      }

      (int IntegerValue, int decimalValue) = GetDecimalPartValue(number);

      string decimalString = ProcessGroup(decimalValue, -1, 0);

      string retVal = string.Empty;

      int group = 0;

      if (tempNumber < 1) {
        retVal = $"{_converterDictionary.GetZero()}";
      }
      else {
        while (tempNumber >= 1) {
          int numberToProcess = (int)(tempNumber % 1000);

          tempNumber /= 1000;

          string groupDescription = ProcessGroup(numberToProcess, group, Math.Floor(tempNumber));

          if (groupDescription != string.Empty) {
            if (group > 0) {
              var separator = retVal == string.Empty ? string.Empty : opt.WordSeparator;
              retVal = $"{_converterDictionary.GetGroup(group)}{separator}{retVal.TrimStart()}";
            }

            retVal = $"{groupDescription.Trim()}{opt.WordSeparator}{retVal.TrimStart()}";
          }

          group++;
        }
      }

      if (!string.IsNullOrEmpty(retVal)) {
        wordsBuilder.Append(retVal.Trim());
        var currencyName = (IntegerValue == 1 ? currencyInfo.Name : currencyInfo.PluralName);
        wordsBuilder.Append(opt.WordSeparator);
        wordsBuilder.Append(currencyName.Trim());
      }

      if (!string.IsNullOrEmpty(decimalString)) {
        wordsBuilder.Append(opt.WordSeparator);
        wordsBuilder.Append($"{_converterDictionary.GetAnd()}");
        wordsBuilder.Append(opt.WordSeparator);

        wordsBuilder.Append(decimalString.Trim());
        wordsBuilder.Append(opt.WordSeparator);

        var currencyPartName = (decimalValue == 1 ? currencyInfo.PartName : currencyInfo.PluralPartName);
        wordsBuilder.Append(currencyPartName.Trim());
      }
      var result = wordsBuilder.ToString();
      return LetterCaseHelper.ConvertLetterCaseTo(result, opt.LanguageCode, opt.LetterCase);
    }

    /// <summary>
    /// Gets the Integer and the decimal parts of the <paramref name="number"/>
    /// if the amount excited the maximum value <see cref="NotSupportedException"/> will throwed.
    /// </summary>
    /// <param name="number">number to be </param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"/>  
    private (int IntegerValue, int DecimalValue) GetDecimalPartValue(double number)
    {
      try
      {
        var splits = number.ToString().Split(new string[] { Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator }, StringSplitOptions.RemoveEmptyEntries);
        var intergerValue = Convert.ToInt32(splits[0]);

        var decimalValue = 0;
        if (splits.Length > 1)
        {
          decimalValue = Convert.ToInt32(GetDecimalValue(splits[1]));
        }

        return (intergerValue, decimalValue);
      }
      catch (OverflowException) {
        throw new NotSupportedException($"Unable to represent the number '{number}' into word representation, the maximum number can be represented is: 999 999 999,99");
      }
      catch (Exception) {
        throw;
      }
    }

  }
}
