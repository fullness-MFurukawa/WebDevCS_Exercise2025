using Domains.Models.Departments;
using Domains.Models.Employees;

namespace Applications.Services;
/// <summary>
/// 社員登録サービスインターフェース
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/22</date>
public interface IRegisterEmployeeService
{
    /// <summary>
    /// 部署一覧を取得する
    /// </summary>
    /// <returns></returns>
    List<Department>GetDepartments();
    /// <summary>
    /// 部署Idで部署を取得する
    /// </summary>
    /// <param name="id">部署Id</param>
    /// <returns></returns>
    Department GetDepartmentsById(int id);
    /// <summary>
    /// 社員を登録する
    /// </summary>
    /// <param name="employee">社員</param>
    void Register(Employee employee);
}
