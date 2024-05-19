using PetHomeApp.Classes.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PetHomeApp.Classes.Utils
{
    public class PetBaseConverter : JsonConverter<PetBase>
    {
        public override PetBase? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                JsonElement root = doc.RootElement;
                string? typeDescriminator = root.GetProperty("AnimalType").GetString();

                Type type = typeDescriminator switch
                {
                    "Dog" => typeof(Dog),
                    "Cat" => typeof(Cat),
                    _ => throw new JsonException("Unknown animal type")
                };

                return (PetBase)JsonSerializer.Deserialize(root.GetRawText(), type, options);
            }
        }

        public override void Write(Utf8JsonWriter writer, PetBase value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}
