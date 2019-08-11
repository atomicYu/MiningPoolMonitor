using Newtonsoft.Json;
using System.IO;

namespace PoolApiClientLibrary
{
    public static class FileProcessor
    {
        public static void WriteFile<T>(T obj, string filePath)
        {
            var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            
            using(StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteAsync(json);
                sw.Close();
            }

            //File.WriteAllText(filePath, json);
        }

        public static T ReadFile<T>(T obj, string filePath) where T: class
        {            
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                obj = JsonConvert.DeserializeObject<T>(json);                
            }
            return obj;

        }
    }
}
