using System.ComponentModel;
namespace Presentations.Models.Departments;
/// <summary>
/// 部署データのViewModelクラス
/// </summary>
public class DepartmentForm
{
    [DisplayName("部署Id")]
    public int Id { get; set; } = 0;
    [DisplayName("部署名")]
    public string Name { get; set; } = string.Empty;
}
