using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using Web.Domain.Model;
using Web.Infrastracture.Repository;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace BulkyWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration configuration;

        public HomeController(ILogger<HomeController> logger,IUnitOfWork unitOfWork,IConfiguration configuration)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            this.configuration = configuration;
        }

        public IActionResult Index()
        {

            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperty: "Category");
            return View(productList);
        
        }

        public IActionResult Details(Guid ProId)
        {

            Product product = _unitOfWork.Product.Get(u =>u.Id == ProId,includeProperty: "Category");
            return View(product);

        }


      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}


