using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TrackYourWorkout.Controllers
{
    /// <summary>
    /// exercise controller that contains api endpoints for exercise CRUD
    /// </summary>
    /// 
    [Route("api/exercises")]
    public class ExerciseController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public ActionResult GetAllExercises()
        {
            return Ok(new
            {
                message = "exercises",
            });
        }
    }
}
