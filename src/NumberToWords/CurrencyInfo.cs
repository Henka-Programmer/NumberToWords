using NumberToWords.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NumberToWords {
  public class CurrencyInfo : ICurrencyInfo {
    public string Code { get; set; }

    public string Name { get; set; }

    public string PluralName { get; set; }

    public byte PartPrecision { get; set; }

    public string PartName { get; set; }

    public string PluralPartName { get; set; }
  }
}
