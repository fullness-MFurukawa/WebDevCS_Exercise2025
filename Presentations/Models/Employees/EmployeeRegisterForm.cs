using Microsoft.AspNetCore.Mvc;
using Presentations.Models.Departments;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Presentations.Models.Employees;
/// <summary>
/// 社員登録フォームのViewModelクラス
/// </summary>
public class EmployeeRegisterForm
{
    [DisplayName("社員名")]
    [Required(ErrorMessage = "{0}を入力して下さい")]
    [StringLength(20, ErrorMessage = "{0}は{1}文字以内で入力して下さい")]
    public string Name { get; set; } = string.Empty;

    [Remote(action: "ExistsByEmail",
            controller: "EmployeeRegister",
            //AdditionalFields = nameof(Id),
            ErrorMessage = "この{0}は既に登録されています。別の{0}で登録してください。")]
    [DisplayName("メールアドレス")]
    [Required(ErrorMessage = "{0}を入力して下さい")]
    [StringLength(30, ErrorMessage = "{0}は{1}文字以内で入力して下さい")]
    [EmailAddress(ErrorMessage = "{0}はxxxx@yyyyの形式で入力して下さい")]
    public string Email { get; set; } = string.Empty;

    [DisplayName("電話番号")]
    [Required(ErrorMessage = "{0}を入力して下さい")]
    [RegularExpression("[0-9]{2,4}-[0-9]{3,4}-[0-9]{4}"
        , ErrorMessage = "{0}はxxxx－yyyy－zzzzの形式で入力して下さい")]
    public string Phone { get; set; } = string.Empty;

    [DisplayName("所属部署")]
    [Required(ErrorMessage = "{0}を選択して下さい")]
    public int? DepartmentId { get; set; } = null;

    public string? DepartmentName { get; set; } = null;

    /// <summary>
    /// 所属部署一覧
    /// </summary>
    public List<DepartmentForm>? Departments { get; set; } = null;
}
