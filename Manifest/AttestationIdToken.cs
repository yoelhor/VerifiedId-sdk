
using System.Text.Json.Serialization;

namespace Microsoft.Identity.VerifiedID.Manifest;

public partial class AttestationIdToken
{
    [JsonPropertyName("id")]
    public Uri Id { get; set; }

    [JsonPropertyName("encrypted")]
    public bool Encrypted { get; set; }

    [JsonPropertyName("claims")]
    public AttestationClaim[] Claims { get; set; }

    [JsonPropertyName("required")]
    public bool IdTokenRequired { get; set; }

    [JsonPropertyName("configuration")]
    public Uri Configuration { get; set; }

    [JsonPropertyName("client_id")]
    public string ClientId { get; set; }

    [JsonPropertyName("redirect_uri")]
    public string RedirectUri { get; set; }

    [JsonPropertyName("scope")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Scope { get; set; }

}