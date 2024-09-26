
using CourseManager.Services;
using CourseManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseManager.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext context;

        public CoursesController(ApplicationDbContext context)
        {
            this.context = context;

        }

        public IActionResult Index()
        {
            var courses = context.Courses.ToList();
            return View(courses);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CourseToDb courseToDb)
        {
            if (!ModelState.IsValid)
            {
                return View(courseToDb);
            }
            Course course = new Course()
            {
                Name = courseToDb.Name,
                ModuleName = courseToDb.ModuleName,
                Description = courseToDb.Description,
            };

            context.Courses.Add(course);
            context.SaveChanges();
            return RedirectToAction("Index", "Courses");
        }


        public IActionResult Edit(int id)
        {
            var course = context.Courses.Find(id);

            //if doesnt find the id
            if (course == null)
            {
                return RedirectToAction("Index", "Courses"); ; //View and Controller
            }
            else
            {

                //fetching
                var courseDb = new CourseToDb() // "CourseToDb cousrseDb = new new CourseToDb()"
                {
                    Name = course.Name,
                    ModuleName = course.ModuleName,
                    Description = course.Description,
                };

                ViewData["CourseId"] = course.Id;

                //POPULATI
                return View(courseDb);
            }

        }

        //CREATED TO SEND NEW INFOMATION TO OUR DATABASE "WHEN CLICKED SAVE"
        [HttpPost]
        public IActionResult Edit(int id, CourseToDb courseToDb)
        {
            var course = context.Courses.Find(id);

            if (course == null)
            {
                return RedirectToAction("Index", "Courses");
            }
            else if (!ModelState.IsValid)
            {
                ViewData["CourseId"] = course.Id;
                return View(courseToDb);
            }
            else
            {
                course.Name = courseToDb.Name;
                course.ModuleName = courseToDb.ModuleName;
                course.Description = courseToDb.Description;

                context.SaveChanges(); //Save to database
                return RedirectToAction("Index", "Courses");

                /*
                var courseModel = new Course()
                { 
                
                }*/
            }




        }

        public IActionResult Delete(int id) //ID AS TO BE PASSED TO DELETE THE UNIQUE IDENTIFIER
        {
            var course = context.Courses.Find(id);

            if (course == null)
            {
                return RedirectToAction("Index", "Courses");
            }
            else
            {
                context.Courses.Remove(course);
                context.SaveChanges(true);
                return RedirectToAction("Index", "Courses");
            }
        }
    }
}
