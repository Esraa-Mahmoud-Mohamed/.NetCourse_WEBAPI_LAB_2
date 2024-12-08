using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBAPI_LAB_2.Models;

namespace WEBAPI_LAB_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        CourseContext db = new CourseContext(); 
        [HttpGet]
        public ActionResult get()
        {
            List<Course> crs = db.Course.ToList();
            if (crs.Count < 1)
            {
                return NotFound();
            }
            return Ok(crs);
        }

        [HttpGet("id/{id}")]
        public ActionResult getById(int id)
        {
            Course course = db.Course.Where(n => n.ID == id).SingleOrDefault();
            if (course == null) return NotFound();
            return Ok(course);
        }

        [HttpGet("name/{name}")]
        public ActionResult getByName(string name)
        {
            Course course = db.Course.Where(n => n.Crs_name == name).SingleOrDefault();
            if (course == null) return NotFound();
            return Ok(course);
        }

        [HttpDelete("{id}")]
        public ActionResult deleteCourse(int id) 
        {
            Course course = db.Course.Where(n=>n.ID == id).FirstOrDefault();
            if (course == null)
            {
                return NotFound();
            }
            db.Course.Remove(course);
            db.SaveChanges();
            return Ok(course);
        }

        [HttpPut("{id}")]
        public ActionResult put(int id, Course course)
        {
            if (id != course.ID) return BadRequest();
            Course crs = db.Course.Where(n => n.ID == course.ID).FirstOrDefault();
            if (crs == null) return NotFound();
            crs.Crs_name = course.Crs_name;
            crs.Crs_description = course.Crs_description;
            crs.Duration = course.Duration;
            db.SaveChanges();
            return NoContent();
        }

        [HttpPost]
        public ActionResult post(Course course)
        {
            if (course == null) return BadRequest();
            db.Course.Add(course);
            db.SaveChanges();
            return CreatedAtAction("getbyid", new { id = course.ID }, course);
        }


    }
}
