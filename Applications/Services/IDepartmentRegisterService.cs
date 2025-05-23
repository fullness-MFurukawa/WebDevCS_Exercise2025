using Domains.Models.Departments;

namespace Applications.Services;
/// <summary>
/// 部署登録サービスインターフェース
/// </summary>
/// <summary>
/// <author>古川正寿</author>
/// <date>2025/05/26</date>
public interface IDepartmentRegisterService
{
    /// <summary>
    /// 指定された部署名の存在有無を返す
    /// </summary>
    /// <param name="name">部署名</param>
    /// <returns>true:存在する false:存在しない</returns>
    bool Exists(string name);
    /// <summary>
    /// 部署を登録する
    /// </summary>
    /// <param name="department">登録部署</param>
    void Register(Department department);
}
