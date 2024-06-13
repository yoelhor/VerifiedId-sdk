using System.Text.Json.Serialization;

namespace Microsoft.Identity.VerifiedID.Manifest;

public partial class Display
{
    [JsonPropertyName("locale")]
    public string Locale { get; set; }

    [JsonPropertyName("contract")]
    public Uri Contract { get; set; }

    [JsonPropertyName("card")]
    public DisplayCard Card { get; set; }

    [JsonPropertyName("consent")]
    public DisplayConsent Consent { get; set; }

    [JsonPropertyName("claims")]
    public DisplayClaims Claims { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }
}