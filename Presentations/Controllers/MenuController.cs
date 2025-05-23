using Microsoft.AspNetCore.Mvc;

namespace Presentations.Controllers;
/// <summary>
/// メニューコントローラー
/// </summary>
public class MenuController : Controller
{

    /// <summary>
    /// メニューのボタンクリックリクエストハンドラ
    /// </summary>
    /// <param name="no">機能番号</param>
    /// <returns></returns>
    [HttpGet("exercise/{no}")]
    public IActionResult Exercise([FromRoute] int no)
    {
        switch (no)
        {
            // 部署一覧
            case 1:     return RedirectToAction("", "DepartmentsList");
            // 部署登録
            case 2:     return RedirectToAction("" , "DepartmentRegister");
            // 社員一覧
            case 3:     return RedirectToAction("" , "EmployeesList");
            // 社員登録
            case 4:     return RedirectToAction("", "EmployeeRegister");
            default:    return View("Index");
        }
    }

    /// <summary>
    /// デフォルトアクション
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        return View();
    }
}
