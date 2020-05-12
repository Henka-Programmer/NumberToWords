using NumberToWords.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NumberToWords
{
  public class NumberToWordsConverterBuilder
  {
    private IConverterDictionary _Dictionary;
    private ITripletToWordsConverter _TripletToWordsConverter;
    public NumberToWordsConverterBuilder WithDictionary(IConverterDictionary converterDictionary)
    {
      _Dictionary = converterDictionary;
      return this;
    }

    public NumberToWordsConverterBuilder WithTripletConverter(ITripletToWordsConverter tripletToWordsConverter)
    {
      _TripletToWordsConverter = tripletToWordsConverter;
      return this;
    }

    public INumberToWordsConverter Build()
    {
      if (_TripletToWordsConverter == null)
      {
        throw new NullReferenceException("The TripletToWordsConverter not specified, please use WithTripletConverter(...) method");
      }
      if (_Dictionary == null)
      {
        throw new NullReferenceException("The ConverterDictionary not specified, please use WithDictionary(...) method");
      }
      return new GenericNumberToWordsConverter(_TripletToWordsConverter, _Dictionary);
    }
  }
}
