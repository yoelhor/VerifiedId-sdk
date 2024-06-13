using System.Text.Json.Serialization;

namespace Microsoft.Identity.VerifiedID.Manifest;

public class AttestationSelfIssued
{
    [JsonPropertyName("id")]
    public string ID { get; set; }

    [JsonPropertyName("encrypted")]
    public bool Encrypted { get; set; }
    
    [JsonPropertyName("claims")]
    public AttestationClaim[] Claims { get; set; }
    
    [JsonPropertyName("required")]
    public bool required { get; set; }
}