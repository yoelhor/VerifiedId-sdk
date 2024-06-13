using System.Text.Json.Serialization;

namespace Microsoft.Identity.VerifiedID.Callback;

public class CallbackFaceCheckResult
{
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("matchConfidenceScore")]
    public double MatchConfidenceScore { get; set; }
}
