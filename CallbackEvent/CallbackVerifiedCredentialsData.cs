using System.Text.Json.Serialization;

namespace Microsoft.Identity.VerifiedID.Callback;


public class CallbackVerifiedCredentialsData
{
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("issuer")]
    public string Issuer { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("type")]
    public List<string> Type { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("claims")]
    public CallbackClaims Claims { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("credentialState")]
    public CallbackCredentialState CredentialState { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("domainValidation")]
    public CallbackDomainValidation DomainValidation { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("expirationDate")]
    public DateTime ExpirationDate { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("issuanceDate")]
    public DateTime IssuanceDate { get; set; }
}