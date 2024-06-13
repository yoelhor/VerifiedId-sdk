using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.Identity.VerifiedID.Issuance;
public class IssuanceRequest
{
    /// <summary>
    /// The issuer's decentralized identifier (DID).
    /// </summary>  
    [JsonPropertyName("authority")]
    public string Authority { get; set; }

    /// <summary>
    /// Determines whether a QR code is included in the response of this request. Present the QR code and ask the user to scan it. 
    //  Scanning the QR code launches the authenticator app with this issuance request. 
    /// Possible values are true (default) or false. When you set the value to false, use the return url property to render a deep link.
    /// </summary>  
    [JsonPropertyName("includeQRCode")]
    public bool IncludeQRCode { get; set; }

    /// <summary>
    /// Provides information about the issuer that can be displayed in the authenticator app.
    /// </summary>  
    [JsonPropertyName("registration")]
    public RequestRegistration Registration { get; set; }

    /// <summary>
    /// Allows the developer to asynchronously get information on the flow during the verifiable credential issuance process. 
    /// For example, the developer might want a call when the user has scanned the QR code or if the issuance request succeeds or fails.
    /// </summary>  
    [JsonPropertyName("callback")]
    public CallbackDefinition Callback { get; set; }

    /// <summary>
    /// The Verified ID credential type. Should match the type as defined in the verifiable credential manifest. 
    // For example: VerifiedCredentialExpert.   
    /// </summary>  
    [JsonPropertyName("type")]
    public string Type { get; set; }

    /// <summary>
    /// The URL of the verifiable credential manifest document.
    /// </summary>  
    [JsonPropertyName("manifest")]
    public string Manifest { get; set; }

    /// <summary>
    /// Optional. PIN code can only be used with the ID token hint attestation flow. 
    /// A PIN number to provide extra security during issuance. 
    /// You generate a PIN code, and present it to the user in your app. The user must provide the PIN code that you generated.
    /// </summary>  
    [JsonPropertyName("pin")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Pin PIN { get; set; }

    /// <summary>
    /// Optional. Can only be used for the ID token hint attestation flow to include a collection 
    //  of assertions made about the subject in the verifiable credential.
    /// </summary>  
    [JsonPropertyName("claims")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string> Claims { get; set; }

    /// <summary>
    /// Optional. The expirationDate can only be used with the ID token hint attestation flow. 
    /// If specified, the value needs to be a date expressed in the ISO8601 format, such as "2024-10-20T14:52:39.043Z".
    /// </summary>  
    [JsonPropertyName("expirationDate")]

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ExpirationDate { get; set; }

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
    /// Deserialize a JSON string into IssuanceRequest object
    /// </summary>
    /// <param name="JsonString">The JSON string to be loaded</param>
    /// <returns></returns>
    public static IssuanceRequest Parse(string JsonString)
    {
        return JsonSerializer.Deserialize<IssuanceRequest>(JsonString);
    }
}




