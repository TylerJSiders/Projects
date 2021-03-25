using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public struct KeyValue
    {
        public readonly string key;
        public readonly object value;

        public KeyValue(string key, object value)
        {
            this.key = key;
            this.value = value;
        }
        
    }
}
