using System;
using Xunit;

namespace NumberToWords.Tests
{
  public class NumberToEnglishWordConverterUnitTest
  {
    public NumberToEnglishWordConverterUnitTest()
    {
      Converter.Initialize();
    }

    [Fact]
    public void Test_Convert_With_ZeroDollarsInput()
    {
      var output = NumberToWords.Converter.ConvertToWords(0);
      Assert.Equal("zero dollars", output.ToLower());
    }

    [Fact]
    public void Test_Convert_With_NegativeInput()
    {
      var output = NumberToWords.Converter.ConvertToWords(-25.1);
      Assert.Equal("minus twenty-five dollars and ten cents", output.ToLower());
    }

    [Fact]
    public void Test_Convert_With_OneDollarInput()
    {
      var output = NumberToWords.Converter.ConvertToWords(1);
      Assert.Equal("one dollar", output.ToLower());
    }

    [Fact]
    public void Test_Convert_With_DollarsAndCentsInput()
    {

      var output = NumberToWords.Converter.ConvertToWords(25.1);
      Assert.Equal("twenty-five dollars and ten cents", output.ToLower());

      output = NumberToWords.Converter.ConvertToWords(0.01);
      Assert.Equal("zero dollars and one cent", output.ToLower());

      output = NumberToWords.Converter.ConvertToWords(45100);
      Assert.Equal("forty-five thousand one hundred dollars", output.ToLower());

      output = NumberToWords.Converter.ConvertToWords(999999999.99);
      Assert.Equal("nine hundred ninety-nine million nine hundred ninety-nine thousand nine hundred ninety-nine dollars and ninety-nine cents", output.ToLower());
    }

    [Fact]
    public void Test_Convert_NumberBiggerThan999999999_99()
    {
      Assert.Throws<NotSupportedException>(() => NumberToWords.Converter.ConvertToWords(9999999999.99));
    }

    [Fact]
    public void Test_HundredElevens()
    {
      var output = NumberToWords.Converter.ConvertToWords(112);
      Assert.Equal("one hundred twelve dollars", output.ToLower());
    }

    [Fact]
    public void Test_Elevens()
    {
      var output = NumberToWords.Converter.ConvertToWords(12);
      Assert.Equal("twelve dollars", output.ToLower());
    }

    [Fact]
    public void Test_Tens()
    {
      var output = NumberToWords.Converter.ConvertToWords(120);
      Assert.Equal("one hundred twenty dollars", output.ToLower());

      output = NumberToWords.Converter.ConvertToWords(125);
      Assert.Equal("one hundred twenty-five dollars", output.ToLower());

      output = NumberToWords.Converter.ConvertToWords(130);
      Assert.Equal("one hundred thirty dollars", output.ToLower());

      output = NumberToWords.Converter.ConvertToWords(135);
      Assert.Equal("one hundred thirty-five dollars", output.ToLower());

      output = NumberToWords.Converter.ConvertToWords(35);
      Assert.Equal("thirty-five dollars", output.ToLower());
    }

    [Fact]
    public void Test_Hundreds()
    {
      var output = NumberToWords.Converter.ConvertToWords(100);
      Assert.Equal("one hundred dollars", output.ToLower());

      output = NumberToWords.Converter.ConvertToWords(950);
      Assert.Equal("nine hundred fifty dollars", output.ToLower());

    }
  }
}
