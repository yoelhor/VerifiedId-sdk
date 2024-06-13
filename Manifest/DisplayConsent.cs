
using System.Text.Json.Serialization;

namespace Microsoft.Identity.VerifiedID.Manifest;

public partial class DisplayConsent
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("instructions")]
    public string Instructions { get; set; }
}