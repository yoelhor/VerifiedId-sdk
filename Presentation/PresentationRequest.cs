using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.Identity.VerifiedID.Presentation
{

    /// <summary>
    /// Verified ID presentation request
    /// </summary>
    public class PresentationRequest
    {
        /// <summary>
        /// Your decentralized identifier (DID) of your verifier Microsoft Entra tenant. 
        /// </summary>  
        [JsonPropertyName("authority")]
        public string Authority { get; set; }

        /// <summary>
        /// Optional. Determines whether a QR code is included in the response of this request. 
        /// Present the QR code and ask the user to scan it. Scanning the QR code launches the authenticator app with this presentation request. 
        /// Possible values are true (default) or false. When you set the value to false, use the return url property to render a deep link.
        /// </summary>  
        [JsonPropertyName("includeQRCode")]
        public bool IncludeQRCode { get; set; }

        /// <summary>
        /// Provides information about the verifier.
        /// </summary>  
        [JsonPropertyName("registration")]
        public RequestRegistration Registration { get; set; }

        /// <summary>
        /// Mandatory. Allows the developer to update the UI during the verifiable credential presentation process. 
        /// When the user completes the process, continue the process after the results are returned to the application.
        /// </summary>  
        [JsonPropertyName("callback")]
        public Callback Callback { get; set; }

        /// <summary>
        /// Optional. Determines whether a receipt should be included in the response of this request. 
        /// Possible values are true or false (default). The receipt contains the original payload sent from the authenticator to the Verified ID service. 
        /// The receipt is useful for troubleshooting or if you have the need to ge the full details of the payload.
        /// </summary>  
        [JsonPropertyName("includeReceipt")]
        public bool IncludeReceipt { get; set; }

        /// <summary>
        /// A collection of RequestCredential objects.
        /// </summary>  
        [JsonPropertyName("requestedCredentials")]
        public List<RequestedCredential> RequestedCredentials { get; set; }

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
    }

    /// <summary>
    /// Registration - used in both issuance and presentation to give the app a display name
    /// </summary>
    public class RequestRegistration
    {

        /// <summary>
        /// A display name of the verifier of the verifiable credential. This name will be presented to the user in the authenticator app.
        /// </summary>  
        [JsonPropertyName("clientName")]
        public string ClientName { get; set; }

        /// <summary>
        /// Optional. A string that is displayed to inform the user why the verifiable credentials are being requested.
        /// </summary>  
        [JsonPropertyName("purpose")]
        public string Purpose { get; set; }

        /// <summary>
        /// Optional. A URL for a logotype of the verifier. This is not used by the Authenticator app.
        /// </summary>  
        [JsonPropertyName("logoUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string LogoUrl { get; set; }

        /// <summary>
        /// Optional. A URL to the terms of service for the verifier. This is not used by the Authenticator app.
        /// </summary>  
        [JsonPropertyName("termsOfServiceUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string TermsOfServiceUrl { get; set; }

    }


    /// <summary>
    /// Presentation can involve asking for multiple VCs
    /// </summary>
    public class RequestedCredential
    {
        /// <summary>
        /// The verifiable credential type. 
        // The type must match the type as defined in the issuer verifiable credential manifest (for example, VerifiedCredentialExpert).
        /// </summary>  
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Optional. Provide information about the purpose of requesting this verifiable credential. This is not used by the Authenticator app.
        /// </summary>  
        [JsonPropertyName("purpose")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Purpose { get; set; }

        /// <summary>
        /// Optional. A collection of issuers' DIDs that could issue the type of verifiable credential that subjects can present. 
        /// </summary>  
        [JsonPropertyName("acceptedIssuers")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string> AcceptedIssuers { get; set; }

        /// <summary>
        /// Optional settings for presentation validation.
        /// </summary>  
        [JsonPropertyName("configuration")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Configuration Configuration { get; set; }

        /// <summary>
        /// Optional. Collection of claims constraints.
        /// </summary>  
        [JsonPropertyName("constraints")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<Constraint> Constraints { get; set; }
    }

    /// <summary>
    /// Configuration - presentation validation configuration
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// Provides information about how the presented credentials should be validated.
        /// </summary>  
        [JsonPropertyName("validation")]
        public Validation Validation { get; set; }
    }
    /// <summary>
    /// Validation - presentation validation configuration
    /// </summary>
    public class Validation
    {
        /// <summary>
        /// Optional. Determines if a revoked credential should be accepted. Default is false (it shouldn't be accepted).
        /// </summary>  
        [JsonPropertyName("allowRevoked")]
        public bool AllowRevoked { get; set; } // default false

        /// <summary>
        /// Optional. Determines if the linked domain should be validated. Default is false. 
        /// Setting this flag to false means you as a Relying Party application accept credentials from an unverified linked domain. 
        /// Setting this flag to true means the linked domain will be validated and only verified domains will be accepted.
        /// </summary>  
        [JsonPropertyName("validateLinkedDomain")]
        public bool ValidateLinkedDomain { get; set; } // default false

        /// <summary>
        /// Optional. Allows requesting a liveness check during presentation.
        /// </summary>  
        [JsonPropertyName("faceCheck")]

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public FaceCheck FaceCheck { get; set; }
    }

    /// <summary>
    /// FaceCheck - if to ask for face check and what claim + score you want
    /// </summary>
    public class FaceCheck
    {
        /// <summary>
        /// Mandatory. The name of the claim in the credential that contains the photo. 
        /// </summary>  
        [JsonPropertyName("sourcePhotoClaimName")]
        public string SourcePhotoClaimName { get; set; }

        /// <summary>
        /// Optional. The confidential threshold for a successful check between the photo and the liveness data. 
        /// Must be an integer between 50 and 100. The default is 70.
        /// </summary>  
        [JsonPropertyName("matchConfidenceThreshold	")]
        public int MatchConfidenceThreshold { get; set; }
    }

    public class Constraint
    {
        /// <summary>
        /// Mandatory. Name of the claim for the constraint. This is the claim name in the verifiable credential
        /// </summary>  
        [JsonPropertyName("claimName")]
        public string ClaimName { get; set; }

        /// <summary>
        /// Set of values that should match the claim value. If you specify multiple values, like ["red", "green", "blue"] 
        /// it is a match if the claim value in the credential has any of the values in the collection.
        /// </summary>  
        [JsonPropertyName("values")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string> Values { get; set; }

        /// <summary>
        /// The constraint evaluates to true if the claim value contains the specified value.
        /// </summary>  
        [JsonPropertyName("contains")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Contains { get; set; }

        /// <summary>
        /// The constraint evaluates to true if the claim value starts with the specified value.
        /// </summary>  
        [JsonPropertyName("startsWith")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string StartsWith { get; set; }
    }
}