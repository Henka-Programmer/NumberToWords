using NumberToWords.Attributes;
using NumberToWords.Interfaces;
using NumberToWords.Internals;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NumberToWords
{
  public static class Converter
  {
    private static ConcurrentDictionary<string, Type> _convertersMetadataMap;
    private static SimpleMemoryCache<Type, INumberToWordsConverter> _convertersCache;
    public static void Initialize(params Assembly[] assemblies)
    {
      if (assemblies is null)
      {
        throw new ArgumentNullException(nameof(assemblies));
      }

      if (assemblies.Length == 0)
      {
        assemblies = new Assembly[] { typeof(Converter).Assembly };
      }

      _convertersMetadataMap = new ConcurrentDictionary<string, Type>();
      _convertersCache = new SimpleMemoryCache<Type, INumberToWordsConverter>();

      var converterTypes = assemblies.SelectMany(x => x.ExportedTypes)
         .Where(x => typeof(INumberToWordsConverter).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
         .Where(x => x.GetCustomAttribute<NumberToWordsConverterAttribute>() != null)
         .ToArray();

      foreach (var convType in converterTypes)
      {
        var key = convType.GetCustomAttribute<NumberToWordsConverterAttribute>()?.LanguageCode;
        _convertersMetadataMap[key] = convType;
      }

    }

    public static string ConvertToWords(double number, Action<IConversionOptions> optionsBuilder = null)
    {
      if (_convertersMetadataMap == null)
      {
        throw new InvalidOperationException("Should initialize the Converter first, use Initialize(...)");
      }

      var options = BuildOptions(optionsBuilder);

      if (!_convertersMetadataMap.ContainsKey(options.LanguageCode.ToLower()))
      {
        throw new NotImplementedException($"The NumberToWords Converter for the '{options.LanguageCode}' Not Implemented.");
      }
      var converterType = _convertersMetadataMap[options.LanguageCode];
      var converter = _convertersCache.GetOrCreate(converterType, () =>
      {
        return (INumberToWordsConverter)Activator.CreateInstance(converterType);
      });

      return converter.ConvertToWords(number, options);
    }

    private static ConversionOptions BuildOptions(Action<IConversionOptions> optionsBuilder)
    {
      //TODO: should add a validation way for the options after invoking the builder.
      // ...
      var options = new ConversionOptions();
      optionsBuilder?.Invoke(options);
      return options;
    }
  }
}
