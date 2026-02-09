using Globomantics.Domain.Models;
using Globomatics.Infrastructure.Repositories;
using Globomatics.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Globomatics.Web.Controllers;

public class HomeController : Controller
{
    private readonly IRepository<Product> _productRepository;
    private readonly ILogger<HomeController> _logger;

    public HomeController(IRepository<Product> productRepository, ILogger<HomeController> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }
    public IActionResult Index()
    {
        var products = _productRepository.All();
        _logger.LogInformation($"Loaded {products.Count()} products");
        return View(products);
    }

    [Route("/details/{productId:guid}/{slug:validateSlug}")]
    public IActionResult TicketDetails(Guid productId, string slug)
    {
        var product = _productRepository.Get(productId);

        return View(product);
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