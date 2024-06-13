using System.Text.Json.Serialization;

namespace Microsoft.Identity.VerifiedID.Issuance;

/// <summary>
/// Registration - used in both issuance and presentation to give the app a display name
/// </summary>
public class RequestRegistration
{
    /// <summary>
    /// A display name of the issuer of the verifiable credential.
    /// </summary>  
    [JsonPropertyName("clientName")]
    public string ClientName { get; set; }

    /// <summary>
    /// Optional. The URL for the issuer logo.
    /// </summary>  
    [JsonPropertyName("logoUrl")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string LogoUrl { get; set; }

    /// <summary>
    /// Optional. The URL for the terms of use of the verifiable credential that you are issuing.
    /// </summary>  
    [JsonPropertyName("termsOfServiceUrl")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string TermsOfServiceUrl { get; set; }
}