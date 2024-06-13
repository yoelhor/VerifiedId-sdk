
using System.Text.Json.Serialization;

namespace Microsoft.Identity.VerifiedID.Manifest;

public partial class DisplayClaim
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("label")]
    public string Label { get; set; }
}