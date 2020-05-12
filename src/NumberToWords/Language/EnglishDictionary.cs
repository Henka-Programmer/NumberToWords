using NumberToWords.Attributes;
using NumberToWords.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NumberToWords.Language
{
  public class EnglishDictionary : IConverterDictionary
  {
    private static readonly Dictionary<string, ICurrencyInfo> currencyInfos = new Dictionary<string, ICurrencyInfo>
        {
            { "USD", new CurrencyInfo { Code = "USD",Name="dollar",PluralName="dollars", PartName="cent", PluralPartName="cents",PartPrecision=2 } },
            { "DZD", new CurrencyInfo { Code = "DZD",Name="dinar",PluralName="dinars", PartName="centim", PluralPartName="centims",PartPrecision=2 } },
        };

    public string LanguageName => "English";

    private static readonly string[] groups = new[]
    {
            "",
            "thousand",
            "million",
            "billion",
            "trillion",
            "quadrillion",
            "quintillion",
            "sextillion",
            "septillion",
            "octillion",
            "nonillion",
            "decillion",
            "undecillion",
            "duodecillion",
            "tredecillion",
            "quattuordecillion",
            "quindecillion",
            "sexdecillion",
            "septendecillion",
            "octodecillion",
            "novemdecillion",
            "vigintillion",
        };

    private static readonly string[] units = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

    private static readonly string[] teens = {
            "ten",
        "eleven",
        "twelve",
        "thirteen",
        "fourteen",
        "fifteen",
        "sixteen",
        "seventeen",
        "eighteen",
        "nineteen"};

    private static readonly string[] tens = {
      "",
      "ten",
      "twenty",
      "thirty",
      "forty",
      "fifty",
      "sixty",
      "seventy",
      "eighty",
      "ninety"
    };

    public string GetAnd()
    {
      return "and";
    }

    public string GetHundred(int hundred)
    {
      return $"{units[hundred]} hundred";
    }

    public string GetMinus()
    {
      return "minus";
    }

    public string GetTeen(int teen)
    {
      return teens[teen];
    }

    public string GetTen(int ten)
    {
      return tens[ten];
    }

    public string GetUnit(int unit)
    {
      return units[unit];
    }

    public string GetZero()
    {
      return "zero";
    }

    public string GetGroup(int group)
    {
      return groups[group];
    }

    public ICurrencyInfo GetCurrencyInfo(string currencyISO4217Code)
    {
      if (currencyInfos.TryGetValue(currencyISO4217Code, out var info))
      {
        return info;
      }

      throw new NotImplementedException($"Sorry this currency '{currencyISO4217Code}' not imlemented in '{LanguageName}' language.");
    }
  }
}
