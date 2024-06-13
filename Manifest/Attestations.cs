
using System.Text.Json.Serialization;

namespace Microsoft.Identity.VerifiedID.Manifest;

public partial class Attestations
{
    [JsonPropertyName("idTokens")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AttestationIdToken[] IdTokens { get; set; }

    [JsonPropertyName("accessTokens")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AttestationAccessToken[] AccessTokens { get; set; }

    [JsonPropertyName("presentations")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AttestationPresentation[] Presentations { get; set; }

    [JsonPropertyName("selfIssued")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AttestationSelfIssued SelfIssued { get; set; }
}