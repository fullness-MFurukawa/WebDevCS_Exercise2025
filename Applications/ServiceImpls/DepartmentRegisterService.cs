using Applications.Services;
using Domains.Models.Departments;
using Microsoft.Extensions.Logging;

namespace Applications.ServiceImpls;
/// <summary>
/// 部署登録サービスインターフェースの実装クラス
/// </summary>
/// <summary>
/// <author>古川正寿</author>
/// <date>2025/05/26</date>
public class DepartmentRegisterService : IDepartmentRegisterService
{
    private readonly IDepartmentRepository _repository;
    private readonly ILogger<DepartmentRegisterService> _logger;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="repository">部署データのCRUD操作リポジトリインターフェース</param>
    /// <param name="logger">ロガー</param>
    public DepartmentRegisterService(
        IDepartmentRepository repository, 
        ILogger<DepartmentRegisterService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    /// <summary>
    /// 指定された部署名の存在有無を返す
    /// </summary>
    /// <param name="name">部署名</param>
    /// <returns>true:存在する false:存在しない</returns>
    public bool Exists(string name)
    {
        var exists = _repository.Exists(name);
        _logger.LogInformation("部署名の存在チェック: '{DepartmentName}' => {Result}", name, exists);
        return exists;
    }

    /// <summary>
    /// 部署を登録する
    /// </summary>
    /// <param name="department">登録部署</param>
    public void Register(Department department)
    {
        _repository.Create(department);
        _logger.LogInformation("部署の登録に成功しました。部署名: {DepartmentName}", department.Name);
    }
}
