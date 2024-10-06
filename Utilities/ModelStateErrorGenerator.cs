using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text;
namespace TrackYourWorkout.Utilities
{
    public class ModelStateErrorGenerator
    {
        public static string GenerateErrorMessage(ModelStateDictionary modelState)
        {
            StringBuilder errorMsgs = new StringBuilder();
            foreach (var error in modelState.Values)
            {
                foreach (var errorMessage in error.Errors)
                {
                    errorMsgs.Append(errorMessage.ErrorMessage).Append('\n');
                }
            }
            return errorMsgs.ToString();
        }
    }
}
