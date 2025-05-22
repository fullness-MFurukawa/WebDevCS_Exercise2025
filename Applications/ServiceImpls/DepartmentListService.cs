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
    /// <summary>
    /// 部署データのCRUD操作リポジトリインターフェース
    /// </summary>
    private readonly IDepartmentRepository _repository;
    private readonly ILogger<DepartmentListService> _logger;

    public DepartmentListService(
        IDepartmentRepository repository, 
        ILogger<DepartmentListService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public List<Department> Execute()
    {
        var result = _repository.FindAll();
        foreach (var department in result)
        {
            _logger.LogInformation(department.ToString());
        }
        return result;
    }
}
