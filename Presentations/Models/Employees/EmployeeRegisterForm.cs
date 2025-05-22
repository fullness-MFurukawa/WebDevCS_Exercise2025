using Presentations.Models.Departments;

namespace Presentations.Models.Employees;
/// <summary>
/// 社員登録フォームのViewModelクラス
/// </summary>
public class EmployeeRegisterForm
{
    /// <summary>
    /// 社員登録フォーム
    /// </summary>
    public EmployeeForm? Employee { get; set; } = null;
    /// <summary>
    /// 所属部署一覧
    /// </summary>
    public List<DepartmentForm>? Departments { get; set; } = null;
}
