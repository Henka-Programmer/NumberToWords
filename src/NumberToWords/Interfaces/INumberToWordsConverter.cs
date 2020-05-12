namespace NumberToWords.Interfaces
{
  public interface INumberToWordsConverter {
    string ConvertToWords(double number, IConversionOptions options = null);
  }
}
