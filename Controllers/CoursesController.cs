using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoursesList.Models;
using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace CoursesList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        public static List<course> Course1 = course.Fetch();
        [HttpGet]
        [Route("fetch")]
        public IActionResult Fetch()
        {
            return Ok(Course1);
        }
        [HttpPost]
        public IActionResult Insert(course C)
        {
            course.Insert(C);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(string CourseCat)
        {
            course.Delete(CourseCat);
            return Ok();
        }
        //[HttpPut]
        //public IActionResult Update(string CourseCat, [FromBody] course C1)
        //{
        //    course C = Course1.Where(x => x.CourseCat == CourseCat).SingleOrDefault();
        //    if (C != null)
        //    {
        //        course.Update(CourseCat, C1);

        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //    return Ok();

        //}

    }
}
