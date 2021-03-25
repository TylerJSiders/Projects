using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class MyDictionary
    {
        private KeyValue[] Data = new KeyValue[7];
        private int numberOfValues;
        public MyDictionary()
        {
            Data[0] = new KeyValue("First", 1);
            Data[1] = new KeyValue("Second", 2);
            Data[2] = new KeyValue("Third", 3);
            Data[3] = new KeyValue("Fourth", 4);
            numberOfValues = 4;
        }

        public object this[string word]
        {
            get
            {
                for (int i = 0; i < numberOfValues; i++)
                {
                    if (Data[i].key == word)
                    {
                        return Data[i].value;
                    }
                }

                return new KeyNotFoundException();
            }
            set
            {
                for(int i = 0; i < numberOfValues; i++)
                {
                    if (Data[i].key == word)
                    {
                        Data[i] = new KeyValue(word, value);
                        return;
                    }
                }
                Data[numberOfValues] = new KeyValue(word, value);
                numberOfValues++;
            }
        }
    }
}
