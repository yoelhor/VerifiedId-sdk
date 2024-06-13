using System.Text.Json.Serialization;

namespace Microsoft.Identity.VerifiedID.Manifest;

public class AttestationAccessToken
{
    [JsonPropertyName("id")]
    public string ID { get; set; }

    [JsonPropertyName("encrypted")]
    public bool Encrypted { get; set; }
    //public List<object> claims { get; set; }

    [JsonPropertyName("required")]
    public bool Required { get; set; }

    [JsonPropertyName("configuration")]
    public string Configuration { get; set; }

    [JsonPropertyName("resourceId")]
    public string ResourceId { get; set; }

    [JsonPropertyName("oboScope")]
    public string OboScope { get; set; }
}