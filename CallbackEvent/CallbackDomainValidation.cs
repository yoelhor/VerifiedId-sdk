using System.Text.Json.Serialization;

namespace Microsoft.Identity.VerifiedID.Callback;
public class CallbackDomainValidation
{
    /// <summary>
    ///  URL of the domain validation
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; }
}
