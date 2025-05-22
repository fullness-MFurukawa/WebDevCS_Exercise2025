using Applications.Services;
using Domains.Models.Employees;
namespace Applications.ServiceImpls;
/// <summary>
/// 社員一覧サービスインターフェースの実装
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/21</date>
public class EmployeeListService : IEmployeeListService
{
    private readonly IEmployeeRepository _repository;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="repository"> 社員データのCRUD操作リポジトリ</param>
    public EmployeeListService(IEmployeeRepository repository)
    {
        _repository = repository;
    }
    /// <summary>
    /// すべての社員と所属部署を取得する
    /// </summary>
    /// <returns></returns>
    public List<Employee> Execute()
    {
        return _repository.FindAllJoinDepartment();
    }
}
