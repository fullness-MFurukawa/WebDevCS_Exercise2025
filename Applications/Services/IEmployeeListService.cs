using Domains.Models.Employees;
namespace Applications.Services;
/// <summary>
/// 社員一覧サービスインターフェース
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/21</date>
public interface IEmployeeListService
{
    /// <summary>
    /// 社員一覧を取得する
    /// </summary>
    /// <returns></returns>
    public List<Employee> Execute();
}
