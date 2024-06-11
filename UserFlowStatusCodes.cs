namespace Microsoft.Identity.VerifiedID;
public class UserFlowStatusCodes
{
    public const string REQUEST_CREATED = "request_created";
    public const string REQUEST_RETRIEVED = "request_retrieved";
    public const string ISSUANCE_ERROR = "issuance_error";
    public const string ISSUANCE_SUCCESSFUL = "issuance_successful";
    public const string PRESENTATION_ERROR = "presentation_error";
    public const string PRESENTATION_VERIFIED = "presentation_verified";
    public const string SELFIE_TAKEN = "selfie_taken";
    public const string INVALID_REQUEST_STATUS = "invalid_request_status";
}