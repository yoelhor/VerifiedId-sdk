
using System.Text.Json.Serialization;

namespace Microsoft.Identity.VerifiedID.Manifest;

public partial class Input
{
    [JsonPropertyName("credentialIssuer")]
    public Uri CredentialIssuer { get; set; }

    [JsonPropertyName("issuer")]
    public string Issuer { get; set; }

    [JsonPropertyName("attestations")]
    public Attestations Attestations { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }
}