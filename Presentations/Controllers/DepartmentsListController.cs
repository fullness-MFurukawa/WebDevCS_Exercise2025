using Applications.Services;
using Domains.Models.Departments;
using Microsoft.AspNetCore.Mvc;
using Presentations.Models.Departments;

namespace Presentations.Controllers;
/// <summary>
/// 部署一覧を提供するコントローラークラス
/// </summary>
public class DepartmentsListController : Controller
{
    private readonly ILogger<DepartmentsListController> _logger;
    private readonly IDepartmentListService _service;
    private readonly IDepartmentAdapter<DepartmentForm> _adapter;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="service"></param>
    /// <param name="adapter"></param>
    public DepartmentsListController(
        ILogger<DepartmentsListController> logger, 
        IDepartmentListService service, 
        IDepartmentAdapter<DepartmentForm> adapter)
    {
        _logger = logger;
        _service = service;
        _adapter = adapter;
    }

    public IActionResult ShowList()
    {
        var departments = _service.Execute();
        var departmentForms = _adapter.Convert(departments);
        var model = new DepartmentListForm
        {
            Departments = departmentForms
        };
        return View(model);
    }
}
