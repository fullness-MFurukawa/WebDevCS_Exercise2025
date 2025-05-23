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
    /// 指定された部署Idで部署を取得する
    /// </summary>
    /// <param name="id">部署Id</param>
    /// <returns></returns>
    Department FindById(int id);
    /// <summary>
    /// 指定された部署を永続化する
    /// </summary>
    /// <param name="department"></param>
    void Create(Department department);
    /// <summary>
    /// 部署名の存在チェック
    /// </summary>
    /// <param name="name">部署名</param>
    /// <returns>true:存在する false:存在しない</returns>
    bool Exists(string name);
}
