using Applications.Services;
using Domains.Models.Departments;
using Domains.Models.Employees;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Presentations.Models.Departments;
using Presentations.Models.Employees;

namespace Presentations.Controllers;
/// <summary>
/// 社員登録画面のコントローラー
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/23</date>
public class EmployeeRegisterController : Controller
{
    private readonly ILogger<EmployeeRegisterController> _logger;
    private readonly IEmployeeRegisterService _registerEmployeeService;
    private readonly IEmployeeAdapter<EmployeeRegisterForm> _employeeAdapter;
    private readonly IDepartmentAdapter<DepartmentForm> _departmentAdapter;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="logger">ロガー</param>
    /// <param name="registerEmployeeService">社員登録サービス</param>
    /// <param name="employeeAdapter">EmployeeとEmployeeFormの相互変換</param>
    /// <param name="departmentAdapter">DepartmentとDepartmentFormの相互変換</param>
    public EmployeeRegisterController(
        ILogger<EmployeeRegisterController> logger, 
        IEmployeeRegisterService registerEmployeeService, 
        IEmployeeAdapter<EmployeeRegisterForm> employeeAdapter, 
        IDepartmentAdapter<DepartmentForm> departmentAdapter)
    {
        _logger = logger;
        _registerEmployeeService = registerEmployeeService;
        _employeeAdapter = employeeAdapter;
        _departmentAdapter = departmentAdapter;
    }

    /// <summary>
    /// デフォルトリクエストハンドラ
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        // 入力画面表示ハンドラにリダイレクトする
        return RedirectToAction("Enter");
    }

    /// <summary>
    /// 入力画面へ遷移するリクエストハンドラ
    /// </summary>
    /// <returns></returns>
    public IActionResult Enter()
    {
        // 部署一覧を取得する
        var departments = _registerEmployeeService.GetDepartments();
        var departmentForms = _departmentAdapter.Convert(departments);
        /// 社員データ用のViewModelを作成する
        var form = new EmployeeRegisterForm
        {
            // 部署一覧をViewModelにセットする
            Departments = departmentForms,
        };
        return View(form);
    }

    /// <summary>
    /// 確認画面へ遷移するリクエストハンドラ
    /// </summary>
    /// <param name="form">社員登録Form</param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Confirm(EmployeeRegisterForm form)
    {
        // バリデーションチェック
        if (!ModelState.IsValid)
        {
            form.Departments = 
                _departmentAdapter.Convert(_registerEmployeeService.GetDepartments());
            return View("Enter", form);
        }
        var department =
        _registerEmployeeService.GetDepartmentsById((int)form.DepartmentId!);
        form.DepartmentName = _departmentAdapter.Convert(department).Name;
        return View(form);  
    }

    /// <summary>
    /// 確認画面の[戻る]ボタンクリック時のリクエストハンドラ
    /// </summary>
    /// <param name=""></param>
    /// <returns></returns>
    public IActionResult ReEnter(EmployeeRegisterForm form)
    {
        form.Departments = _departmentAdapter.Convert(_registerEmployeeService.GetDepartments());
        return View("Enter", form);
    }

    /// <summary>
    /// 確認画面の[登録]ボタンクリック時のリクエストハンドラ
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Register(EmployeeRegisterForm form)
    {
        // FormをJSONに変換する
        TempData["NewEmployee"] = JsonConvert.SerializeObject(form);
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
        if (TempData["NewEmployee"] is string json)
        {
            // JSONをEmployeeFormに変換する
            var employeeForm = JsonConvert.DeserializeObject<EmployeeRegisterForm>(json);
            // 社員データをドメインモデルに変換する
            var employee = _employeeAdapter.Restore(employeeForm!);
           // 社員データを登録する
            _registerEmployeeService.Register(employee);
            return View(employeeForm);
        }
        else
        {
            // TempDataが空の場合はエラーページを表示する
            return View("Error");
        }
    }

    /// <summary>
    /// メールアドレスの存在確認を行うリクエストハンドラ
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public IActionResult ExistsByEmail(string email)
    {
        // メールアドレスの存在確認を行う
        return Json(_registerEmployeeService.ExistsByEmail(email));
    }
}
