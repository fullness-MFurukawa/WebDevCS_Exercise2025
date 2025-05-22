namespace Domains.Models.Employees;
/// <summary>
/// 社員データのCRUD操作リポジトリインターフェース
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/21</date>
public interface IEmployeeRepository
{
    /// <summary>
    /// すべての社員と所属部署を取得する
    /// </summary>
    /// <returns></returns>
    List<Employee> FindAllJoinDepartment();
    /// <summary>
    /// 指定された社員Idで社員を取得する
    /// </summary>
    /// <param name="id">社員Id</param>
    /// <returns></returns>
    Employee? FindById(int id);
    /// <summary>
    /// メールアドレスの有無を返す
    /// </summary>
    /// <param name="email"></param>
    /// <returns>true:存在するfalse:存在しない</returns>
    bool ExistsByEmail(string email);
    /// <summary>
    /// 指定された社員を永続化する
    /// </summary>
    /// <param name="employee"></param>
    void Create(Employee employee);
    /// <summary>
    /// 引数で指定された社員Idの社員を削除する
    /// </summary>
    /// <param name="Id">社員Id</param>
    void DeleteById(int Id);
}
