using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Infrastracture.Data;
using Web.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Web.Infrastracture.SD;
using Web.Infrastracture.Repository;



namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        [HttpGet]
        public IActionResult Index()
        {
            var categories = _unitOfWork.Category.GetAll().ToList();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> AddCategory()
        {
            return View();
        }

        [HttpPost]

        public IActionResult AddCategory(Category category)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Create(category);
                _unitOfWork.Save();
                TempData["success"] = "Category Created Successfuly";

                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateCategory(Guid CatId)
        {
            Category category =  _unitOfWork.Category.Get(x => x.Id == CatId);
            // await _db.Categories.FindAsync(CatId);

            if (category is null)
            {

                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(category);
                _unitOfWork.Save();
                TempData["success"] = "Category Update Successfuly";

                return RedirectToAction("Index", "Category");
            }

            return View();
        }

        [HttpGet]

        public IActionResult DeleteCategory(Guid CatId)
        {
            Category category = _unitOfWork.Category.Get(x => x.Id == CatId);

            if (category is null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("DeleteCategory")]

        public IActionResult Delete(Guid CatId)
        {
            Category category = _unitOfWork.Category.Get(x => x.Id == CatId);

            if (category is null)
            {
                return NotFound();
            }

            _unitOfWork.Category.Delete(category);
            _unitOfWork.Save();
            TempData["success"] = "Category Deleted Successfuly";
            return RedirectToAction("Index", "Category");
        }

    }
}

