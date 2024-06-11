using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.Identity.VerifiedID;

/// <summary>
/// Base calls for Verified ID Client API callback for issuance and presentation 
/// </summary>
public class CallbackEvent : CallbackEevntBase
{
    /// <summary>
    /// The verifiable credential user DID.
    /// </summary>
    [JsonPropertyName("subject")]
    public string Subject { get; set; }

    /// <summary>
    /// Returns an array of Verified IDs requested. For each Verified ID, it provides:
    /// The Verified ID type(s).
    /// The issuer's DID
    /// The claims retrieved.
    /// The Verified ID issuer's domain.
    /// The Verified ID issuer's domain validation status.
    /// <summary>
    [JsonPropertyName("verifiedCredentialsData")]
    public List<VerifiedCredentialsData> VerifiedCredentialsData { get; set; }

    /// <summary>
    /// Optional. The receipt contains the original payload sent from the wallet to the Verifiable Credentials service. The receipt should be used for troubleshooting/debugging only. 
    /// The format in the receipt isn't fix and can change based on the wallet and version used.
    /// </summary>
    [JsonPropertyName("receipt")]
    public Receipt Receipt { get; set; }


    /// <summary>
    /// Serialize this object into a string
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
    }

    /// <summary>
    /// Serialize this object into HTML string
    /// </summary>
    /// <returns></returns>
    public string ToHtml()
    {
        return this.ToString().Replace("\r\n", "<br>").Replace(" ", "&nbsp;");
    }

    /// <summary>
    /// Deserialize a JSON string into CallbackEvent object
    /// </summary>
    /// <param name="JsonString">The JSON string to be loaded</param>
    /// <returns></returns>
    public static CallbackEvent Parse(string JsonString)
    {
        return JsonSerializer.Deserialize<CallbackEvent>(JsonString);
    }

}

/// <summary>
/// Receipt - returned when VC presentation is verified. The id_token contains the full VC id_token
/// the state is not to be confused with the VCCallbackEvent.state and is something internal to the VC Client API
/// </summary>
public class Receipt
{
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("id_token")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string IdToken { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("vp_token")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string VpToken { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("state")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string State { get; set; }
}



public class VerifiedCredentialsData
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
    public Claims Claims { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("credentialState")]
    public CredentialState CredentialState { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("domainValidation")]
    public DomainValidation DomainValidation { get; set; }

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

public class CredentialState
{

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("revocationStatus")]
    public string RevocationStatus { get; set; }


    [JsonIgnore]
    public bool isValid { get { return RevocationStatus == "VALID"; } }
}

public class DomainValidation
{
    /// <summary>
    ///  URL of the domain validation
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; }
}

public class FaceCheckResult
{

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("matchConfidenceScore")]
    public double MatchConfidenceScore { get; set; }
}

public class Claims
{

    /// <summary>
    /// First name
    /// </summary>
    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }

    /// <summary>
    /// Last name
    /// </summary>
    [JsonPropertyName("lastName")]
    public string LastName { get; set; }

    /// <summary>
    /// ID
    /// </summary>
    [JsonPropertyName("id")]
    public string ID { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("sum")]
    public string Sum { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("displayName")]
    public string DisplayName { get; set; }
}