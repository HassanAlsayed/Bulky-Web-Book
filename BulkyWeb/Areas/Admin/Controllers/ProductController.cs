using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Infrastracture.Data;
using Web.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Web.Infrastracture.SD;
using Web.Infrastracture.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Domain.Model.ViewModel;
using System.IO;



namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHost;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHost)
        {
            _unitOfWork = unitOfWork;
            _webHost = webHost;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Product> product = _unitOfWork.Product.GetAll(includeProperty: "Category").ToList();
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            ProductVM productVM = new ProductVM()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = new Product()

            };


            return View(productVM);
        }

        [HttpPost]
        public IActionResult AddProduct(ProductVM productVM, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string wwRoot = _webHost.WebRootPath;

                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwRoot, @"images\product");

                    //if (!String.IsNullOrEmpty(productVM.Product.ImageUrl))
                    //{
                    //    // Delete old image
                    //    var old = Path.Combine(wwRoot, productVM.Product.ImageUrl.TrimStart('\\'));

                    //    if (System.IO.File.Exists(old))
                    //    {
                    //        System.IO.File.Delete(old);
                    //    }
                    //}

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    productVM.Product.ImageUrl = @"\images\product\" + fileName;
                }

                _unitOfWork.Product.Create(productVM.Product);
                _unitOfWork.Save();
                TempData["success"] = "Product Update Successfuly";

                return RedirectToAction("Index", "Product");
            }

            // If ModelState is not valid, you need to populate the CategoryList again before returning the view
            productVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            return View(productVM);
        }

        #region API CALLS
        [HttpGet]

        public IActionResult GetAll()
        {
            List<Product> objProdct = _unitOfWork.Product.GetAll(includeProperty: "Category").ToList();
            return Json(new { data = objProdct });
        }


        [HttpDelete]
        public IActionResult DeleteProduct(Guid id)
        {

            var deleteProduct = _unitOfWork.Product.Get(x => x.Id == id);
            if (deleteProduct is null)
            {
                return Json(new { success = false, message = "error while deleting" });
            }
            var oldimage = Path.Combine(_webHost.WebRootPath, deleteProduct.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldimage))
            {
                System.IO.File.Delete(oldimage);
            }
            _unitOfWork.Product.Delete(deleteProduct);
            _unitOfWork.Save();

            return Json(new { success = true, message = "deleted succsefull " });

        }


        #endregion
    }
}


