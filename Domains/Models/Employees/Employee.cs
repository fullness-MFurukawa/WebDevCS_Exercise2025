using Domains.Models.Departments;

namespace Domains.Models.Employees;
/// <summary>
/// 社員データを表すドメインモデル
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/21</date>
public class Employee
{
    /// <summary>
    /// 社員Id
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// 社員名
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// メールアドレス
    /// </summary>
    public string Emainl { get; set; } = string.Empty;
    /// <summary>
    /// 電話番号
    /// </summary>
    public string Phone { get; set; } = string.Empty;
    /// <summary>
    /// 所属部署
    /// </summary>
    public Department? department { get; set; } = null;

    public override string? ToString()
    {
        return $"" +
            $"社員Id:{Id}, " +
            $"社員名:{Name}, " +
            $"メールアドレス:{Emainl}, " +
            $"電話番号:{Phone}, " +
            $"所属部署:{department}";
    }
}
