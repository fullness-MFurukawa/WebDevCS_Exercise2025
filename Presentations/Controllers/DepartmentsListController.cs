﻿using Applications.Services;
using Domains.Models.Departments;
using Microsoft.AspNetCore.Mvc;
using Presentations.Models.Departments;

namespace Presentations.Controllers;
/// <summary>
/// 部署一覧を提供するコントローラークラス
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/20</date>
public class DepartmentsListController : ExerciseBaseController
{
    private readonly ILogger<DepartmentsListController> _logger;
    private readonly IDepartmentListService _service;
    private readonly IDepartmentAdapter<DepartmentForm> _adapter;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="logger">ロガー</param>
    /// <param name="service">部署一覧サービス</param>
    /// <param name="adapter">DepartmentとDepartmentFormの相互変換</param>
    public DepartmentsListController(
        ILogger<DepartmentsListController> logger, 
        IDepartmentListService service, 
        IDepartmentAdapter<DepartmentForm> adapter)
    {
        _logger = logger;
        _service = service;
        _adapter = adapter;
    }

    /// <summary>
    /// デフォルトアクション
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        return RedirectToAction("ShowList");
    }

    /// <summary>
    /// 部署一覧画面を表示する
    /// </summary>
    /// <returns></returns>
    public IActionResult ShowList()
    {
        var departments = _service.Execute();

        foreach (var department in departments)
        {
            _logger.LogInformation(department.ToString());
        }


        var departmentForms = _adapter.Convert(departments);
        var model = new DepartmentListForm
        {
            Departments = departmentForms
        };
        return View(model);
    }
}
