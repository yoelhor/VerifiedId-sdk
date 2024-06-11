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
    public Callback Callback { get; set; }

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
    /// Deserialize a JSON string into CallbackEvent object
    /// </summary>
    /// <param name="JsonString">The JSON string to be loaded</param>
    /// <returns></returns>
    public static IssuanceRequest Parse(string JsonString)
    {
        return JsonSerializer.Deserialize<IssuanceRequest>(JsonString);
    }
}

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


/// <summary>
/// Pin - if issuance involves the use of a pin code. The 'value' attribute is a string so you can have values like "0907"
/// </summary>
public class Pin
{

    /// <summary>
    /// Contains the PIN value in plain text. When you're using a hashed PIN, the value property contains the salted hash, base64 encoded.
    /// </summary>  
    [JsonPropertyName("value")]
    public string Value { get; set; }


    /// <summary>
    /// The length of the PIN code. The default length is 6, the minimum is 4, and the maximum is 16.
    /// </summary>  
    [JsonPropertyName("length")]
    public int Length { get; set; } = 6;

    /// <summary>
    /// The type of the PIN code. Possible value: numeric (default).
    /// </summary>  
    [JsonPropertyName("type")]
    public string Type { get; set; } = "numeric";

    /// <summary>
    /// The salt of the hashed PIN code. The salt is prepended during hash computation. Encoding: UTF-8.
    /// </summary>  
    [JsonPropertyName("salt")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Salt { get; set; }

    /// <summary>
    /// The hashing algorithm for the hashed PIN. Supported algorithm: sha256
    /// </summary>  
    [JsonPropertyName("alg")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Algorithm { get; set; }


    /// <summary>
    /// number of hashing iterations. Possible value: 1.
    /// </summary>  
    [JsonPropertyName("iterations")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Iterations { get; set; }
}
