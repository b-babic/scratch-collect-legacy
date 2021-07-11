using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace scratch_collect.API.Helper
{
    public partial class Json
    {
        public static List<T> LoadFromFile<T>(string fileName)
        {
            using (StreamReader r = new StreamReader(GetFilePathJsonData(fileName)))
            {
                string json = r.ReadToEnd();
                List<T> items = JsonConvert.DeserializeObject<List<T>>(json);
                return items;
            }
        }

        private static string GetFilePathJsonData(string fileName)
        {
            string exeFile = AppDomain.CurrentDomain.BaseDirectory;
            string exeDir = Path.GetDirectoryName(exeFile);
            string seedFolder = "/Database/Seed/";

            string fullPath = exeDir.ToString() + seedFolder + fileName;

            return fullPath;
        }
    }
}
