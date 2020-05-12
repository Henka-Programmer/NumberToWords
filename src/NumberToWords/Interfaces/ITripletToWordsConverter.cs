namespace NumberToWords.Interfaces
{
  /// <summary>
  /// Convrts a 3 digits triplet to Words
  /// </summary>
  public interface ITripletToWordsConverter
  {
    string ToWords(double number, int groupLevel, double remainingNumber);
  }
}
