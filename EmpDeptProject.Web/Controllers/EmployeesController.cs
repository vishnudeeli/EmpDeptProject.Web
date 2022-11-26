using EmpDeptProject.DataAccess.Data;
using EmpDeptProject.DataAccess.Repository;
using EmpDeptProject.DataAccess.Repository.IRepository;
using EmpDeptProject.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmpDeptProject.Web.Controllers
{
    public class EmployeesController : Controller
    {
        
        private readonly IUnitOfWork _unitOfWork;
        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
          
        }



        public IActionResult Index()
        {
             var allEmployees = _unitOfWork.Employee.GetAll();


            //var allEmployees = _unitOfWork.Employee.Include(c => c.Departments);
           
            
            return View(allEmployees);
        }
        //public IActionResult Details(int? id)
        //{
        //    var employee = _unitOfWork.Employee.GetFirstOrDefault(c => c.EmployeeId == id);
        //    return View(employee);
        //}
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee catObj)
        {


            //if (catObj.DepartmentName == catObj.DepartmentName.ToString())
            //{
            //    ModelState.AddModelError("Custom Error", "DisplayOrder cannot match the name");
            //}

            if (ModelState.IsValid)
            {
                _unitOfWork.Employee.Add(catObj);
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
            var employeeFirstOrDefault = _unitOfWork.Employee.GetFirstOrDefault(c => c.EmployeeId == id);
            //var categorySingleOrDefault = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (employeeFirstOrDefault == null)
            {
                return NotFound();
            }
            return View(employeeFirstOrDefault);

        }
        //Edit-Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public IActionResult Edit(Employee catObj)
        {

            //if (catObj.Name == catObj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("Custom Error", "DisplayOrder cannot match the name");
            //}


            if (ModelState.IsValid)
            {
                _unitOfWork.Employee.Update(catObj);
                _unitOfWork.Save();
                TempData["Success"] = "Category updated succesfully";

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
            var categoryFromDb = _unitOfWork.Employee.GetFirstOrDefault(c => c.EmployeeId == id);
            //var categoryFirstOrDefault=_db.Categories.FirstOrDefault(c => c.Id == id);
            //var categorySingleOrDefault = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);

        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.Employee.GetFirstOrDefault(c => c.EmployeeId == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Employee.Remove(obj);
            _unitOfWork.Save();
            TempData["Success"] = "Category deleted succesfully";
            return RedirectToAction(nameof(Index));
        }



    }
}
