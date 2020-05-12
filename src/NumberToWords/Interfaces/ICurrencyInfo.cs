namespace NumberToWords.Interfaces
{
  public interface ICurrencyInfo {
    /// <summary>
    /// Currency ISO-4217 Code
    /// </summary>
    string Code { get; }

    string Name { get; }
    string PluralName { get; }

    /// <summary>
    /// Decimal Part Precision
    /// for USD Pounds: 2 ( 1 USD = 100 parts)
    /// </summary>
    byte PartPrecision { get; }

    string PartName { get; }
    string PluralPartName { get; }
  }
}
