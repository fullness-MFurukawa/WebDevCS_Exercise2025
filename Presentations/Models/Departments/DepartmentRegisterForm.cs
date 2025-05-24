using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Presentations.Models.Departments;
/// <summary>
/// 部署登録ViewModelクラス
/// </summary>
public class DepartmentRegisterForm
{
    [DisplayName("部署名")]
    [Required(ErrorMessage = "{0}を入力して下さい")]
    [StringLength(20, ErrorMessage = "{0}は{1}文字以内で入力して下さい")]
    // 部署の存在チェック
    [Remote(action: "Exists",
            controller: "DepartmentRegister",
            ErrorMessage = "この{0}は既に登録されています。別の{0}で登録してください。")]
    public string? Name { get; set; } = string.Empty; // 部署名
}
