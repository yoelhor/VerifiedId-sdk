
using System.Text.Json.Serialization;

namespace Microsoft.Identity.VerifiedID.Manifest;

public class AttestationIssuer
{
    [JsonPropertyName("iss")]
    public string Iss { get; set; }
}