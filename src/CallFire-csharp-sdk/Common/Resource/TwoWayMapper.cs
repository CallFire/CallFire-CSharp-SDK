using System.Collections;
using System.Collections.Generic;

namespace CallFire_csharp_sdk.Common.Resource
{
    internal class TwoWayMapper<TKey1, TKey2> : IEnumerable<KeyValuePair<TKey1, TKey2>>
    {
        public Dictionary<TKey1, TKey2> Dictionary1 { get; set; }

        public Dictionary<TKey2, TKey1> Dictionary2 { get; set; }
        
        public TwoWayMapper()
        {
            Dictionary1 = new Dictionary<TKey1, TKey2>();
            Dictionary2 = new Dictionary<TKey2, TKey1>();
        }
        
        public void Add(TKey1 valueKey1, TKey2 valueKey2)
        {
            Dictionary1.Add(valueKey1, valueKey2);
            Dictionary2.Add(valueKey2, valueKey1);
        }
        
        public TKey2 this[TKey1 valueKey1] {
            get
            {
                return Dictionary1[valueKey1];
            }
            
            set
            {
                Dictionary1[valueKey1] = value;
            }
        }

        public TKey1 this[TKey2 valueKey2]
        {
            get
            {
                return Dictionary2[valueKey2];
            }

            set
            {
                Dictionary2[valueKey2] = value;
            }
        }

        public bool ContainsKey(TKey1 valueKey1)
        {
            return Dictionary1.ContainsKey(valueKey1);
        }

        public bool ContainsKey(TKey2 valueKey2)
        {
            return Dictionary2.ContainsKey(valueKey2);
        }

        public IEnumerator<KeyValuePair<TKey1, TKey2>> GetEnumerator()
        {
            return Dictionary1.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
