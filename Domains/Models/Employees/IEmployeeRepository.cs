namespace Domains.Models.Employees;
/// <summary>
/// 社員データのCRUD操作リポジトリインターフェース
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/21</date>
public interface IEmployeeRepository
{
    /// <summary>
    /// すべての社員を取得する
    /// </summary>
    /// <returns></returns>
    List<Employee> FindAll();
    /// <summary>
    /// 指定された社員を永続化する
    /// </summary>
    /// <param name="employee"></param>
    void Create(Employee employee);
}
