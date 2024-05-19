using PetHomeApp.Classes.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PetHomeApp.Classes.Utils
{
    public class FileManager
    {
        public static void WriteToJsonFile(List<PetBase> animals, string filePath)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter(), new PetBaseConverter() }
            };

            string jsonString = JsonSerializer.Serialize(animals, options);
            File.WriteAllText(filePath, jsonString);
        }

        public static List<PetBase> ReadFromJsonFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<PetBase>();
            }

            string jsonString = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter(), new PetBaseConverter() }
            };

            return JsonSerializer.Deserialize<List<PetBase>>(jsonString, options) ?? new List<PetBase>();
        }
    }
}
