using System.Text.Json.Serialization;

namespace Microsoft.Identity.VerifiedID.Manifest;

public partial class DisplayLogo
{
    [JsonPropertyName("uri")]
    public Uri Uri { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }
}