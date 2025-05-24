using Microsoft.AspNetCore.Mvc;
namespace Presentations.Controllers;
/// <summary>
/// 開発演習のベースコントローラクラス
/// </summary>
public class ExerciseBaseController : Controller
{
    /// <summary>
    /// [メニュー]ボタンクリックリクエストハンドラ
    /// </summary>
    /// <returns></returns>
    [AcceptVerbs("GET", "POST")]
    public IActionResult Menu()
    {
        TempData.Clear(); // TempDataをクリアする
        // メニュー画面へリダイレクトする
        return RedirectToAction("Index", "Menu");
    }
}
