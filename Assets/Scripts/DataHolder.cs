using System.IO;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;


namespace TableFromJSON
{
    public static class DataHolder
    {
        public class GenDataType : Dictionary<string, string> { }

        static public string Title;
        static public List<string> ColumnHeaders;
        static public List<GenDataType> Data;


        /// <summary>
        /// Read data from fileName.
        /// </summary>
        /// <param name="fileName"></param>
        static public void ReadFromFile(string fileName)
        {
            string filePath = Application.streamingAssetsPath + "/" + fileName;
            if (!File.Exists(filePath))
                return;

            // read file and put its data on a JObject
            string dataAsJson = File.ReadAllText(filePath);
            JObject data = JObject.Parse(dataAsJson);

            // read title and columns headers
            Title = data["Title"].ToString();

            ColumnHeaders = new List<string>();
            foreach (var headerName in data["ColumnHeaders"].Children())
                ColumnHeaders.Add(headerName.ToString());

            // read data list
            Data = new List<GenDataType>();
            foreach (var rawData in data["Data"].Children())
            {
                JToken rawField;
                var itemObj = (JObject)rawData;
                var itemDict = new GenDataType();

                // for every data item, check which fields are available
                foreach (var headerName in ColumnHeaders)
                {
                    if (itemObj.TryGetValue(headerName, out rawField))
                        itemDict[headerName] = rawField.ToString();
                    else
                        itemDict[headerName] = "";
                }

                Data.Add(itemDict);
            }
        }
    }
}
