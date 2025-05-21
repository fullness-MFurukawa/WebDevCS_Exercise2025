using Applications.Services;
using Domains.Models.Employees;
using Microsoft.AspNetCore.Mvc;
using Presentations.Models.Employees;

namespace Presentations.Controllers;
/// <summary>
/// 社員一覧を提供するコントローラークラス
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/21</date>
public class EmployeesListController : Controller
{
    private readonly ILogger<EmployeesListController> _logger;
    private readonly IEmployeeListService _service;
    private readonly IEmployeeAdapter<EmployeeForm> _adapter;

    public EmployeesListController(
        ILogger<EmployeesListController> logger, 
        IEmployeeListService service, 
        IEmployeeAdapter<EmployeeForm> adapter)
    {
        _logger = logger;
        _service = service;
        _adapter = adapter;
    }

    public IActionResult ShowList()
    {
        var employees = _service.Execute();
        var employeeForms = _adapter.Convert(employees);
        var model = new EmployeeListForm
        {
            Employees = employeeForms
        };
        return View(model);
    }
}
