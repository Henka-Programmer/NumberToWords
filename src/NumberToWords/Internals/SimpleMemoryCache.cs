using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace NumberToWords.Internals
{
  internal class SimpleMemoryCache<TKey, TItem>
  {
    private static readonly ConcurrentDictionary<TKey, TItem> _cache = new ConcurrentDictionary<TKey, TItem>();
    public TItem GetOrCreate(TKey key, Func<TItem> factory)
    {
      if (_cache.ContainsKey(key))
      {
        return _cache[key];
      }
      return _cache[key] = factory();
    }
  }
}
