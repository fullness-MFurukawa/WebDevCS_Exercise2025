using Applications.Services;
using Domains.Models.Departments;
using Domains.Models.Employees;
using Microsoft.AspNetCore.Mvc;
using Presentations.Models.Departments;
using Presentations.Models.Employees;

namespace Presentations.Controllers;
/// <summary>
/// 社員登録画面のコントローラー
/// </summary>
public class EmployeeRegisterController : Controller
{
    private readonly IRegisterEmployeeService _registerEmployeeService;
    private readonly IEmployeeAdapter<EmployeeForm> _employeeAdapter;
    private readonly IDepartmentAdapter<DepartmentForm> _departmentAdapter;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="registerEmployeeService"></param>
    /// <param name="employeeAdapter"></param>
    /// <param name="departmentAdapter"></param>
    public EmployeeRegisterController(
        IRegisterEmployeeService registerEmployeeService, 
        IEmployeeAdapter<EmployeeForm> employeeAdapter, 
        IDepartmentAdapter<DepartmentForm> departmentAdapter)
    {
        _registerEmployeeService = registerEmployeeService;
        _employeeAdapter = employeeAdapter;
        _departmentAdapter = departmentAdapter;
    }

    public IActionResult Enter()
    {
        // 部署一覧を取得する
        var departments = _registerEmployeeService.GetDepartments();
        var departmentForms = _departmentAdapter.Convert(departments);
        var form = new EmployeeRegisterForm
        {
            Departments = departmentForms,
        };
        return View(form);
    }

    public IActionResult Index()
    {
        return RedirectToAction("Enter");
    }
}
