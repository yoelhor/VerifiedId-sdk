
using System.Text.Json.Serialization;

namespace Microsoft.Identity.VerifiedID.Manifest;

public partial class DisplayCard
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("issuedBy")]
    public string IssuedBy { get; set; }

    [JsonPropertyName("backgroundColor")]
    public string BackgroundColor { get; set; }

    [JsonPropertyName("textColor")]
    public string TextColor { get; set; }

    [JsonPropertyName("logo")]
    public DisplayLogo Logo { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }
}
