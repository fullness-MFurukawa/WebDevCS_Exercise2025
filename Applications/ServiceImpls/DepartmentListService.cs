using Applications.Services;
using Domains.Models.Departments;
using Microsoft.Extensions.Logging;
namespace Applications.ServiceImpls;
/// <summary>
/// 部署一覧サービスインターフェースの実装
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/20</date>
public class DepartmentListService : IDepartmentListService
{
    private readonly IDepartmentRepository _repository;
    private readonly ILogger<DepartmentListService> _logger;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="repository">部署データのCRUD操作リポジトリインターフェース</param>
    /// <param name="logger">ロガー</param>
    public DepartmentListService(
        IDepartmentRepository repository, 
        ILogger<DepartmentListService> logger)
    {
        _repository = repository;
        _logger = logger;
    }
    /// <summary>
    /// 部署一覧を取得する   
    /// </summary>
    /// <returns></returns>
    public List<Department> Execute()
    {
        _logger.LogInformation("部署一覧の取得処理を開始しました。");
        var result = _repository.FindAll();
        _logger.LogInformation("部署一覧の取得に成功しました。取得件数: {Count}", result.Count);
        return result;
    }
}
