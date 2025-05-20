using Applications.Services;
using Domains.Models.Departments;
namespace Applications.ServiceImpls;
/// <summary>
/// 部署一覧サービスインターフェースの実装
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/20</date>
public class DepartmentListServiceImpl : IDepartmentListService
{
    /// <summary>
    /// 部署データのCRUD操作リポジトリインターフェース
    /// </summary>
    private readonly IDepartmentRepository _repository;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="repository">部署データのCRUD操作リポジトリインターフェース</param>
    public DepartmentListServiceImpl(IDepartmentRepository repository)
    {
        _repository = repository;
    }

    public List<Department> Execute()
    {
        return _repository.FindAll();
    }
}
