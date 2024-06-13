using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.Identity.VerifiedID.Manifest;


public class Manifest
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("display")]
    public Display Display { get; set; }

    [JsonPropertyName("input")]
    public Input Input { get; set; }

    [JsonPropertyName("iss")]
    public string Iss { get; set; }

    [JsonPropertyName("iat")]
    public long Iat { get; set; }

    /// <summary>
    /// Serialize this object into a string
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
    }

    /// <summary>
    /// Serialize this object into HTML string
    /// </summary>
    /// <returns></returns>
    public string ToHtml()
    {
        return this.ToString().Replace("\r\n", "<br>").Replace(" ", "&nbsp;");
    }

    /// <summary>
    /// Deserialize a JSON string into Manifest object
    /// </summary>
    /// <param name="JsonString">The JSON string to be loaded</param>
    /// <returns></returns>
    public static Manifest Parse(string JsonString)
    {
        return JsonSerializer.Deserialize<Manifest>(JsonString);
    }
}







