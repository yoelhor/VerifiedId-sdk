using System.Text.Json.Serialization;

namespace Microsoft.Identity.VerifiedID.Issuance;

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
