using System.Text.Json.Serialization;

namespace Microsoft.Identity.VerifiedID.Callback;


public class CallbackCredentialState
{

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("revocationStatus")]
    public string RevocationStatus { get; set; }


    [JsonIgnore]
    public bool isValid { get { return RevocationStatus == "VALID"; } }
}
