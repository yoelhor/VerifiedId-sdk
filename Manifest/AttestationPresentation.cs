using System.Text.Json.Serialization;

namespace Microsoft.Identity.VerifiedID.Manifest;

public class AttestationPresentation
{
    [JsonPropertyName("id")]
    public string ID { get; set; }

    [JsonPropertyName("encrypted")]
    public bool Encrypted { get; set; }

    [JsonPropertyName("claims")]
    public AttestationClaim[] Claims { get; set; }

    [JsonPropertyName("equired")]
    public bool Required { get; set; }

    [JsonPropertyName("credentialType")]
    public string CredentialType { get; set; }

    [JsonPropertyName("issuers")]
    public AttestationIssuer[] issuers { get; set; }

    [JsonPropertyName("contracts")]
    public List<string> Contracts { get; set; }
}