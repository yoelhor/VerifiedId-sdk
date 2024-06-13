
using System.Text.Json.Serialization;

namespace Microsoft.Identity.VerifiedID.Manifest;

public partial class DisplayClaims
{
    [JsonPropertyName("vc.credentialSubject.firstName")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DisplayClaim FirstName { get; set; }

    [JsonPropertyName("vc.credentialSubject.lastName")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DisplayClaim LastName { get; set; }
}