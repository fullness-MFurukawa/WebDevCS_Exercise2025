using Microsoft.AspNetCore.Mvc;

namespace Presentations.Controllers;
/// <summary>
/// メニューコントローラー
/// </summary>
public class MenuController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
