﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLookupTool.Entities
{
    public class DataObject
    {
        public List<Dictionary<string, string>>  _data {get; set;}

        public List<string> DictionaryKeys { get; set;}

        public DataObject(List<Dictionary<string, string>> data) {
            
            _data = data;
            DictionaryKeys = ExtractDictKeys(_data[0]);
        }

        public static List<string> ExtractDictKeys(Dictionary<string, string> dict)
        {
            List<string> list = new List<string>();

            foreach (string key in dict.Keys)
            {
                list.Add(key);
            }

            return list;
        }
    }
}
