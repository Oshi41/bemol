using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Bemol.extensions
{
    class ObservableDict<T1, T2> : IDictionary<T1, T2>
    {
        private readonly Dictionary<T1, T2> _dict = new();
        
        public IEnumerator<KeyValuePair<T1, T2>> GetEnumerator()
        {
            return _dict.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(KeyValuePair<T1, T2> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            foreach (var key in _dict.Keys.ToList())
            {
                Remove(key);
            }
        }

        public bool Contains(KeyValuePair<T1, T2> item)
        {
            return TryGetValue(item.Key, out T2 value) && Equals(item.Value, value);
        }

        public void CopyTo(KeyValuePair<T1, T2>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<T1, T2> item)
        {
            if (!Contains(item)) return false;
            return Remove(item.Key);
        }

        public int Count => _dict.Count;
        public bool IsReadOnly => false;
        public void Add(T1 key, T2 value)
        {
            _dict[key] = value;
            Added?.Invoke(this, (key, value));
        }

        public bool ContainsKey(T1 key)
        {
            return _dict.ContainsKey(key);
        }

        public bool Remove(T1 key)
        {
            if (TryGetValue(key, out T2 value))
            {
                _dict.Remove(key);
                Removed?.Invoke(this, (key, value));
                return true;
            }
            
            return false;
        }

        public bool TryGetValue(T1 key, [MaybeNullWhen(false)] out T2 value)
        {
            return _dict.TryGetValue(key, out value);
        }

        public T2 this[T1 key]
        {
            get => _dict[key];
            set => Add(key, value);
        }

        public ICollection<T1> Keys => _dict.Keys;
        public ICollection<T2> Values => _dict.Values;
        
        public event EventHandler<(T1 key, T2 value)> Added; 
        public event EventHandler<(T1 key, T2 value)> Removed; 
    }
    
    public static class UriExtensions
    {
        public static IDictionary<string, string> Query(this UriBuilder builder)
        {
            var dict = new ObservableDict<string, string>();
            foreach (var arr in builder.Query.Split('&').Select(x => x.Split('=')))
            {
                dict[arr[0]] = arr[1];
            }

            void Recreate()
            {
                builder.Query = string.Join("&", dict.Select(x => x.Key + "=" + x.Value));
            }

            dict.Added += (_, _) => Recreate();
            dict.Added += (_, _) => Recreate();
            
            return dict;
        }
    }
}