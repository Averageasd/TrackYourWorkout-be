using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TrackYourWorkout.Controllers
{
    /// <summary>
    /// workout controller that contains api endpoints
    /// for workout CRUD
    /// </summary>
    public class WorkoutController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public ActionResult GetAllWorkouts()
        {
            return Ok(new
            {
                message = "Workouts",
            });
        }
    }
}
