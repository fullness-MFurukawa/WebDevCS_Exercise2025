using Applications.Services;
using Domains.Models.Employees;
namespace Applications.ServiceImpls;
/// <summary>
/// 社員一覧サービスインターフェースの実装
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/21</date>
public class EmployeeListServiceImpl : IEmployeeListService
{
    private readonly IEmployeeRepository _repository;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="repository"> 社員データのCRUD操作リポジトリ</param>
    public EmployeeListServiceImpl(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public List<Employee> Execute()
    {
        return _repository.FindAll();
    }
}
