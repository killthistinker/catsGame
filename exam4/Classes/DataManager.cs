using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace exam4.Classes
{
    public class DataManager
    {
        private const string Path = "../../../cats.json";

        public static List<Cat> GetCats()
        {
            List<Cat> cats;
            if (File.Exists(Path))
            {
                string catsJson = File.ReadAllText(Path);
                cats = JsonSerializer.Deserialize<List<Cat>>(catsJson);
                return cats;
            }

            return new List<Cat>();
        }

        public static void SaveCats(List<Cat> cats)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin,UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string catsJson = JsonSerializer.Serialize(cats, options);
            File.WriteAllText(Path, catsJson);
        }
    }
}