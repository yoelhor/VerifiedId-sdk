using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.Identity.VerifiedID.Manifest;

public class ManifestToken
{
    [JsonPropertyName("token")]
    public string Token { get; set; }

    /// <summary>
    /// Serialize this object into a string
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }

    /// <summary>
    /// Deserialize a JSON string into ManifestToken object
    /// </summary>
    /// <param name="JsonString">The JSON string to be loaded</param>
    /// <returns></returns>
    public static ManifestToken Parse(string JsonString)
    {
        return JsonSerializer.Deserialize<ManifestToken>(JsonString);
    }
}