﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Presentations.Models.Departments;
using System.ComponentModel;

namespace Presentations.Models.Employees;
/// <summary>
/// 社員データのViewModelクラス
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/21</date>
public class EmployeeForm
{
    public EmployeeForm()
    {
        Department = new DepartmentForm();
    }

    [DisplayName("社員Id")]
    public int Id { get; set; } = 0;
    
    [DisplayName("社員名")]
    public string Name { get; set; } = string.Empty;

    [DisplayName("メールアドレス")]
    public string Email { get; set; } = string.Empty;
    
    [DisplayName("電話番号")]
    public string Phone { get; set; } = string.Empty;

    public DepartmentForm? Department { get; set; } = null;
}
