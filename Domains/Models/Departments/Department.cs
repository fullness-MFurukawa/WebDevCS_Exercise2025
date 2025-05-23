using Domains.Exceptions;
namespace Domains.Models.Departments;
/// <summary>
/// 部署データを表すドメインモデル
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/20</date>
public class Department
{
    /// <summary>
    /// 部署Id
    /// </summary>
    public int? Id { get; private set; } = 0;
    /// <summary>
    /// 部署名
    /// </summary>
    public string Name { get; private set; } = string.Empty;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="id">部署Id</param>
    /// <param name="name">部署名</param>
    public Department(int id, string name)
    {
        // バリデーションチェック
        validateDepartmentId(id);
        validateDepartmentName(name);
        Id = id;
        Name = name;
    }
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="name">部署名</param>
    public Department(string name)
    {
        validateDepartmentName(name);
        Name = name;
    }

    /// <summary>
    /// バリデーションチェックメソッド
    /// </summary>
    /// <param name="name"></param>
    /// <exception cref="DomainException"></exception>
    private void validateDepartmentId(int id)
    {
        if (id < 1)
        {
            throw new DomainException("部署Idは1以上の整数です。");
        }
    }
    /// <summary>
    /// バリデーションチェックメソッド
    /// </summary>
    /// <param name="name"></param>
    /// <exception cref="DomainException"></exception>
    private void validateDepartmentName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new DomainException("部署名は必須です。");
        }
        if (name.Length > 20)
        {
            throw new DomainException("部署名は20文字以内です。");
        }
    }
    
    public void ChangeName(string name)
    {
        // バリデーションチェックメソッド
        validateDepartmentName(name);
        Name = name;
    }

    /// <summary>
    /// オブジェクトの文字列表現を返すメソッド
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"部署Id: {Id}, 部署名: {Name}";
    }   
}
