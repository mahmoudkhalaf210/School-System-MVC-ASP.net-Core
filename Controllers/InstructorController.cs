using Microsoft.AspNetCore.Mvc;
using Day2.Models;
using Day2.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Day2.Controllers
{
    [Authorize]
    public class InstructorController : Controller
    {
        ITIContext db;
        public InstructorController(ITIContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            List<Instructor> instructors = new List<Instructor>();
            instructors = db.Instructors.ToList();

            return View("Index",instructors);
        }

        public IActionResult details(int id)
        {
            Instructor instructor = db.Instructors.Where(n => n.id == id).FirstOrDefault();

            return View("details", instructor);
        }

        public IActionResult insInformation(int id)
        {
            Instructor ins = db.Instructors.FirstOrDefault(n => n.id == id);
            return PartialView(ins);
        }

        NewInstructorDataViewModel viewModel1 = new NewInstructorDataViewModel();

        public IActionResult addNewCtr()
        {
            viewModel1.deptList = db.Departments.ToList();
            viewModel1.crsList = db.Courses.ToList();
            return View(viewModel1);
        }

        [HttpPost]
        public IActionResult saveNewCtr(Instructor ins)
        {
            viewModel1.deptList = db.Departments.ToList();
            viewModel1.crsList = db.Courses.ToList();

            viewModel1.name = ins.name;
            viewModel1.salary = ins.salary;
            viewModel1.address = ins.address;
            viewModel1.dept_id = ins.dept_id;
            viewModel1.crs_id = ins.crs_id;
            viewModel1.image = ins.image;

            if (ins.name != null && ins.salary != 0 && ins.address != null && ins.dept_id != 0 && ins.crs_id != 0 && ins.image != null)
            {
                db.Instructors.Add(ins);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
             
            return View("AddNewCtr",viewModel1);
        }

        InstructorWithDepartmentAndCourseViewModel viewModel = new InstructorWithDepartmentAndCourseViewModel();

        public IActionResult edite(int id)
        {
            Instructor ins = db.Instructors.FirstOrDefault(n => n.id == id);
            List<Department> dept = db.Departments.ToList();
            List<Course> crs = db.Courses.ToList();

            viewModel.id = ins.id;
            viewModel.name = ins.name;
            viewModel.address = ins.address;
            viewModel.image = ins.image;
            viewModel.salary = ins.salary;
            viewModel.dept_id = ins.dept_id;
            viewModel.crs_id = ins.crs_id;
            viewModel.crsList = crs;
            viewModel.deptList = dept;

            
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult saveUpdate(int id, Instructor newIns)
        {
            Instructor oldIns = db.Instructors.FirstOrDefault(n => n.id == id);
            List<Department> dept = db.Departments.ToList();
            List<Course> crs = db.Courses.ToList();

            viewModel.id = newIns.id;
            viewModel.name = newIns.name;
            viewModel.address = newIns.address;
            viewModel.image = newIns.image;
            viewModel.salary = newIns.salary;
            viewModel.dept_id = newIns.dept_id;
            viewModel.crs_id = newIns.crs_id;
            viewModel.crsList = crs;
            viewModel.deptList = dept;


            if (newIns.name != null && newIns.address != null && newIns.image != null && newIns.salary != 0)
            {
                oldIns.name = newIns.name;
                oldIns.address = newIns.address;
                oldIns.salary = newIns.salary;
                oldIns.dept_id = newIns.dept_id;
                oldIns.crs_id = newIns.crs_id;
                oldIns.image = newIns.image;

                db.SaveChanges();
                return RedirectToAction("details",new { id = oldIns.id });
            }

            return View("edite", viewModel);
        }

        public IActionResult delete(int id)
        {
            Instructor oldIns = db.Instructors.FirstOrDefault(n => n.id == id);
            db.Instructors.Remove(oldIns);
            db.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult getCourses(int dept_id)
        {
            List<Course> courses = db.Courses.Where(n => n.dept_id == dept_id).ToList();

            return Json(courses);
        }










        public IActionResult viewData(int id)
        {
            Instructor insModel = db.Instructors.FirstOrDefault(n => n.id == id);

            string msg = "hello from viewData";

            List<string> li = new List<string>()
            {
                "cairo",
                "Alex",
                "assuit",
                "qena",
                "maadi"
            };

            int temp = 33;

            ViewData.Add("message", msg);
            ViewData.Add("address", li);
            ViewData.Add("temp", temp);

            return View(insModel);
        }

        public IActionResult getStudentReslt(int id)
        {
            string name = db.Trainees.Where(n => n.id == id).Select(n => n.name).FirstOrDefault();
            List<CrsResult> result = new List<CrsResult>(); 
            result = db.CrsResults.Where(n => n.trainee_id == id).ToList();
            List<string> course = new List<string>(); 
            List<int> degree = new List<int>();
            Dictionary<int, string> d = new Dictionary<int, string>();

            // List<CrsResult> crsR = db.CrsResults.Include(n => n.course).Where(n => n.trainee_id == id).ToList();
            var crsR = db.CrsResults.Include(n => n.course).Where(n => n.trainee_id == id).Select(n => new {courseName = n.course.name, degree = n.degree}).ToList();
            
            
            foreach (var e in result)
            {
                course.Add(db.Courses.Where(n => n.id == e.crs_id).Select(n => n.name).FirstOrDefault());
                if(e.degree > 50)
                {
                    d.Add(e.degree, "#05e505");
                }
                else
                {
                    d.Add(e.degree, "red");
                }
                //degree.Add(e.degree);
            }
            
            

            TraineeWithCourseAndDegreeViewModel viewModel = new TraineeWithCourseAndDegreeViewModel();
            viewModel.name = name;
            //viewModel.degree = degree;
            viewModel.degree = d;
            viewModel.course = course;
            viewModel.count = 0;

            
            return View(viewModel);
        }

        public IActionResult partialDetails(int id)
        {
            
            Instructor ins = db.Instructors.FirstOrDefault(n => n.id == id);
            if(ins != null)
            {
                return PartialView("_CartParial", ins);
            }
            return RedirectToAction("Index");
                
        }
    }
}
