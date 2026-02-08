using Globomantics.Domain.Models;
using Globomatics.Infrastructure.Repositories;
using Globomatics.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Globomatics.Web.Controllers;

public class HomeController : Controller
{
    private readonly IRepository<Product> _productRepository;

    public HomeController(IRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }
    public IActionResult Index()
    {
        var products = _productRepository.All();
        return View(products);
    }

    public IActionResult TicketDetails(Guid productId, string slug)
    {
        throw new NotImplementedException();
    }

    public IActionResult Privacy()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}