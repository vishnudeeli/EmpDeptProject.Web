using EmpDeptProject.DataAccess.Repository;
using EmpDeptProject.DataAccess.Repository.IRepository;
using EmpDeptProject.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmpDeptProject.Web.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public IActionResult Index()
        {
            var allCategories = _unitOfWork.Department.GetAll();

            return View(allCategories);
        }
        public IActionResult Details(int? id)
        {
            var department = _unitOfWork.Department.GetFirstOrDefault(c => c.DepartmentId == id);
            return View(department);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department catObj)
        {

            //if (catObj.DepartmentName == catObj.DepartmentName.ToString())
            //{
            //    ModelState.AddModelError("Custom Error", "DisplayOrder cannot match the name");
            //}


            if (ModelState.IsValid)
            {
                _unitOfWork.Department.Add(catObj);
                _unitOfWork.Save();


                return RedirectToAction(nameof(Index));
               
            }
            else
            {
                return View(catObj);
            }
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryFromDb = _categoryRepository.;
            var departmentFirstOrDefault = _unitOfWork.Department.GetFirstOrDefault(c => c.DepartmentId == id);
            //var categorySingleOrDefault = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (departmentFirstOrDefault == null)
            {
                return NotFound();
            }
            return View(departmentFirstOrDefault);

        }

        //Edit-Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public IActionResult Edit(Department catObj)
        {

            //if (catObj.Name == catObj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("Custom Error", "DisplayOrder cannot match the name");
            //}


            if (ModelState.IsValid)
            {
                _unitOfWork.Department.Update(catObj);
                _unitOfWork.Save();
                TempData["Success"] = "Departments updated succesfully";



                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(catObj);
            }
        }
        //Delete - Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var departmentFromDb = _unitOfWork.Department.GetFirstOrDefault(c => c.DepartmentId == id);
            //var categoryFirstOrDefault=_db.Categories.FirstOrDefault(c => c.Id == id);
            //var categorySingleOrDefault = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (departmentFromDb == null)
            {
                return NotFound();
            }
            return View(departmentFromDb);


        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.Department.GetFirstOrDefault(c => c.DepartmentId == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Department.Remove(obj);
            _unitOfWork.Save();
            TempData["Success"] = "Departments deleted succesfully";
            return RedirectToAction(nameof(Index));
        }



    }
}
