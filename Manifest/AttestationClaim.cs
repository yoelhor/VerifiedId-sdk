using System.Text.Json.Serialization;

namespace Microsoft.Identity.VerifiedID.Manifest;

public partial class AttestationClaim
{
    [JsonPropertyName("claim")]
    public string ClaimClaim { get; set; }

    [JsonPropertyName("required")]
    public bool ClaimRequired { get; set; }

    [JsonPropertyName("indexed")]
    public bool Indexed { get; set; }
}
