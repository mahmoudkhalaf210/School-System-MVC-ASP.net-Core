using Microsoft.AspNetCore.Mvc;
using Day2.Models;
using Day2.ViewModel;
using Day2.Repository;
using Microsoft.AspNetCore.Authorization;

namespace Day2.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        ICourseRepository crsRepository;
        IDepartmentRepository deptRepository;

        public CourseController(ICourseRepository crsRep, IDepartmentRepository deptRep)
        {
            crsRepository = crsRep;
            deptRepository = deptRep;
        }

        public IActionResult testService()
        {
            ViewBag.id = crsRepository.id;
            return View();
        }
        public IActionResult Index()
        {
            List<Course> courseModel = crsRepository.getAll();

            return View(courseModel);
        }

        CourseWithDepartmentIDAndNameViewModdel viewModel = new CourseWithDepartmentIDAndNameViewModdel();

        public IActionResult addNewCrs()
        {
            viewModel.dept = deptRepository.getAll();

            return View(viewModel);
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult saveNew(Course newCrs)
        {
            if (ModelState.IsValid)
            {
                crsRepository.add(newCrs);

                return RedirectToAction("Index");
            }
            else
            {
                viewModel.name = newCrs.name;
                viewModel.degree = newCrs.degree;
                viewModel.minDegree = newCrs.minDegree;
                viewModel.dept = deptRepository.getAll();

                return View("addNewCrs", viewModel);
            }
        }

        public IActionResult edit(int id)
        {
            Course crs = crsRepository.getById(id);

            viewModel.name = crs.name;
            viewModel.degree = crs.degree;
            viewModel.minDegree = crs.minDegree;
            viewModel.id = id;
            viewModel.dept_id = crs.dept_id;
            viewModel.dept = deptRepository.getAll();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult saveEdite(int id, Course newCrs)
        {
            if (newCrs.name != null && newCrs.degree != 0 && newCrs.minDegree > 40 && newCrs.dept_id > 0)
            {
                crsRepository.update(id, newCrs);
            
                return RedirectToAction("Index");
            }
            else
            {
                viewModel.name = newCrs.name;
                viewModel.degree = newCrs.degree;
                viewModel.minDegree = newCrs.minDegree;
                viewModel.dept_id = newCrs.dept_id;
                viewModel.dept = deptRepository.getAll();

                return View("edit", viewModel);
            }
        }

        public IActionResult Delete(int id)
        {
            crsRepository.delete(id);

            return RedirectToAction("Index");
        }

        public IActionResult checkminDegree(int minDegree, int degree)
        {
            if (minDegree < degree)
            {
                return Json(true);
            }
            return Json(false);
        }

    }
}
