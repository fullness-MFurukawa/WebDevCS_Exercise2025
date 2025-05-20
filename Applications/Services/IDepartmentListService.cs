using Domains.Models.Departments;

namespace Applications.Services;
/// <summary>
/// 部署一覧サービスインターフェース
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/20</date>
public interface IDepartmentListService
{
    public List<Department> Execute();
}
