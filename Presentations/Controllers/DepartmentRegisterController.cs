using Applications.Services;
using Domains.Models.Departments;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Presentations.Models.Departments;
namespace Presentations.Controllers;
/// <summary>
/// 部署登録コントローラクラス
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/24</date>
public class DepartmentRegisterController : ExerciseBaseController
{
    private readonly ILogger<DepartmentRegisterController> _logger;
    private readonly IDepartmentRegisterService _service;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="logger">ロガー</param>
    /// <param name="service">部署登録サービス</param>
    public DepartmentRegisterController(
        ILogger<DepartmentRegisterController> logger, 
        IDepartmentRegisterService service)
    {
        _logger = logger;
        _service = service;
    }

    /// <summary>
    /// デフォルトアクション
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        return RedirectToAction("Enter");
    }

    /// <summary>
    /// 部署名入力画面を表示する
    /// </summary>
    /// <returns></returns>
    public IActionResult Enter()
    {
        DepartmentRegisterForm model;
        // TempDataから部署データを取得する
        if (TempData["EnterDepartment"] is string json)
        {
            // JSONをDepartmentRegisterFormに変換する
            model = JsonConvert.DeserializeObject<DepartmentRegisterForm>(json)!;
        }
        else
        {
            model = new DepartmentRegisterForm();
        }
        return View(model);
    }

    /// <summary>
    /// 確認画面へ遷移するリクエストハンドラ
    /// </summary>
    /// <returns></returns>
    public IActionResult Confirm(DepartmentRegisterForm form)
    {
        if (!ModelState.IsValid)
        {
            // 入力エラーがある場合は、入力画面に戻る
            return View("Enter", form);
        }
        return View(form);
    }

    /// <summary>
    /// 確認画面の[戻る]ボタンクリックリクエストハンドラ
    /// </summary>
    /// <returns></returns>
    public IActionResult ReEnter(DepartmentRegisterForm form)
    {
        // FormをJSONに変換する
        TempData["EnterDepartment"] = JsonConvert.SerializeObject(form);
        return RedirectToAction("Enter");
    }

    /// <summary>
    /// 確認画面の[登録]ボタンクリック時のリクエストハンドラ
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Register(DepartmentRegisterForm form)
    {
        // FormをJSONに変換する
        TempData["NewDepartment"] = JsonConvert.SerializeObject(form);
        // Completeアクションにリダイレクトする
        return RedirectToAction("Complete");
    }

    /// <summary>
    /// Completeアクション PRGパターンの実装
    /// </summary>
    /// <returns></returns>
    public IActionResult Complete()
    {
        // TempDataから新規登録社員データを取得する
        if (TempData["NewDepartment"] is string json)
        {
            // JSONをDepartmentRegisterFormに変換する
            var form = JsonConvert.DeserializeObject<DepartmentRegisterForm>(json)!;
            // 部署を登録する
            _service.Register(new Department(form.Name!));
            return View(form);
        }
        else
        {
            // TempDataが空の場合はエラーページを表示する
            return View("Error");
        }
    }
    /// <summary>
    /// 入力された部署の存在確認チェック
    /// </summary>
    /// <returns></returns>
    [AcceptVerbs("Get", "Post")]
    public IActionResult Exists(string name)
    {
        var result = _service.Exists(name);
        return Json(!result);
    }   
}
