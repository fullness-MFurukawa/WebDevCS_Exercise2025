using System;
namespace Domains.Models.Departments;
/// <summary>
/// 部署データのCRUD操作リポジトリインターフェース
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/20</date>
public interface IDepartmentRepository
{
    /// <summary>
    /// すべての部署を取得する
    /// </summary>
    /// <returns></returns>
    List<Department> FindAll();
    /// <summary>
    /// 指定された部署を永続化する
    /// </summary>
    /// <param name="department"></param>
    void Create(Department department);
}
