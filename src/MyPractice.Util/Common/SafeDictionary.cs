using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace MyPractice.Util.Common
{
    public class SafeDictionary<TKey, TValue>
    {
        private readonly object _dictLock = new object();
        Dictionary<TKey, TValue> _dict;
        public SafeDictionary()
        {
            _dict = new Dictionary<TKey, TValue>();
        }

        public void Add(TKey key, TValue value)
        {
            lock (_dictLock)
            {
                if (!_dict.ContainsKey(key))
                    _dict.Add(key, value);
            }
        }
        public void Remove(TKey key)
        {
            lock (_dictLock)
            {
                if (_dict.ContainsKey(key))
                    _dict.Remove(key);
            }
        }
        public void Clear()
        {
            lock (_dictLock)
            {
                _dict.Clear();
            }
        }
        public bool ContainsKey(TKey key)
        {
            lock (_dictLock)
            {
                return _dict.ContainsKey(key);
            }
        }
        public bool ContainsValue(TValue value)
        {
            lock (_dictLock)
            {
                return _dict.ContainsValue(value);
            }
        }
        public TValue this[TKey key]
        {
            get
            {
                lock (_dictLock)
                {
                    if (_dict.ContainsKey(key))
                        return _dict[key];
                    else
                        return default(TValue);
                }
            }
            set
            {
                lock (_dictLock)
                {
                    _dict[key] = value;
                }
            }
        }
        public List<TValue> Values
        {
            get
            {
                lock (_dictLock)
                {
                    return _dict.Values.ToList();
                }
            }
        }
        public List<TKey> Keys
        {
            get
            {
                lock (_dictLock)
                {
                    return _dict.Keys.ToList();
                }
            }
        }
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            lock (_dictLock)
            {
                foreach (var a in _dict)
                {
                    yield return new KeyValuePair<TKey, TValue>(a.Key, a.Value);
                }
            }
        }
        public int Count
        {
            get
            {
                lock (_dictLock)
                {
                    return _dict.Count;
                }
            }
        }
    }
}
