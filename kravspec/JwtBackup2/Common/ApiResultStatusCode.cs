using System.ComponentModel.DataAnnotations;

namespace Common
{
    public enum ApiResultStatusCode
    {
        [Display(Name = "mission accomplished")]
        Success = 0,

        [Display(Name = "Server error occurred")]
        ServerError = 1,

        [Display(Name = "Submitted parameters are not valid")]
        BadRequest = 2,

        [Display(Name = "not found")]
        NotFound = 3,

        [Display(Name = "The list is empty")]
        ListEmpty = 4,

        [Display(Name = "Processing error occurred")]
        LogicError = 5,

        [Display(Name = "Authentication error")]
        UnAuthorized = 6
    }
}
