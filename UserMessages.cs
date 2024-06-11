namespace Microsoft.Identity.VerifiedID;

public static class UserMessages
{
    public static string ERROR_STATE_ID_NOT_FOUND { get; set; } = "Error the state ID couldn't be found in the system. Please try to refresh the page as start again.";
    public static string ERROR_STATE_OBJECT_NOT_FOUND { get; set; } = "Error status object couldn't be found in the system. Please try to refresh the page as start again.";
    public static string ERROR_STATE_ID_CANNOT_DESERIALIZE { get; set; } = "Error while trying to deserialize the status object.";
    public static string ERROR_API_ERROR { get; set; } = "Microsoft Entra verified ID API returned an error.";
    public static string ERROR_API_CALLBACK_ENTRA_ERROR { get; set; } = "Microsoft Entra verified ID returned an error to callback endpoint.";
    public static string ERROR_API_CALLBACK_INTERANL_ERROR { get; set; } = "Callback endpoint internal error.";

    public static string REQUEST_CREATED = "To start, scan the QR code.";
    public static string REQUEST_RETRIEVED = "The QR code was successfully scanned. Waiting for you to complete the steps in your authenticator app.";
    public static string ISSUANCE_ERROR = "Issuance failed: ";
    public static string ISSUANCE_SUCCESSFUL = "The issuance successfully completed.";
    public static string PRESENTATION_ERROR = "Presentation failed: ";
    public static string PRESENTATION_VERIFIED = "The credential successfully verified.";
    public static string SELFIE_TAKEN = "The selfie successfully taken.";
    public static string INVALID_REQUEST_STATUS = "Cannot complete the process due to invalid request status.";

}