using Applications.Services;
using Domains.Models.Employees;
using Microsoft.Extensions.Logging;
namespace Applications.ServiceImpls;
/// <summary>
/// 社員一覧サービスインターフェースの実装
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/21</date>
public class EmployeeListService : IEmployeeListService
{
    private readonly IEmployeeRepository _repository;
    private readonly ILogger<EmployeeListService> _logger;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="repository">社員データのCRUD操作リポジトリ</param>
    /// <param name="logger">ロガー</param>
    public EmployeeListService(
        IEmployeeRepository repository, 
        ILogger<EmployeeListService> logger)
    {
        _repository = repository;
        _logger = logger;
    }
    /// <summary>
    /// すべての社員と所属部署を取得する
    /// </summary>
    /// <returns></returns>
    public List<Employee> Execute()
    {
        _logger.LogInformation("社員一覧の取得処理を開始しました。");
        var result = _repository.FindAllJoinDepartment();
        _logger.LogInformation("社員一覧の取得に成功しました。取得件数: {Count}", result.Count);
        return result;
    }
}
