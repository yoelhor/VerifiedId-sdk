using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.Identity.VerifiedID
{

    /// <summary>
    /// Base calls for Verified ID Client API callback for issuance and presentation 
    /// </summary>
    public class CallbackEevntBase
    {
        /// <summary>
        /// Mapped to the original request when the payload was posted to the Verified ID service.  
        /// </summary>  
        [JsonPropertyName("requestId")]
        public string RequestId { get; set; }

        /// <summary>
        /// The status returned for the request..  
        /// </summary>  
        [JsonPropertyName("requestStatus")]
        public string RequestStatus { get; set; }

        /// <summary>
        /// Returns the state value that you passed in the original payload.
        /// <summary>
        [JsonPropertyName("state")]
        public string State { get; set; }

        /// <summary>
        /// Contains information about the error
        /// </summary>
        [JsonPropertyName("error")]
        public Error Error { get; set; }


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
        /// Deserialize a JSON string into CallbackBase object
        /// </summary>
        /// <param name="JsonString">The JSON string to be loaded</param>
        /// <returns></returns>
        public static CallbackEevntBase Parse(string JsonString)
        {
            return JsonSerializer.Deserialize<CallbackEevntBase>(JsonString);
        }

    }

    /// <summary>
    /// If there's an error with the request, an error responses is returned
    /// </summary>
    public class Error
    {
        /// <summary>
        /// The return error code.
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// The error message.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }

    /// <summary>
    /// Provide details on what caused the error.
    /// </summary>
    public class Innererror
    {
        /// <summary>
        /// Contains a standardized code, based on the type of the error
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// The internal error message. Contains a detailed message of the error.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary>
        /// contains the field in the request that is causing this error. 
        /// This field is optional and may not be present, depending on the error type.
        /// </summary>
        [JsonPropertyName("target")]
        public string Target { get; set; }
    }
}