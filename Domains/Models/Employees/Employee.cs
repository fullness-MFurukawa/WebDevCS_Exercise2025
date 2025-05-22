using Domains.Exceptions;
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
    public string Email { get; set; } = string.Empty;
    /// <summary>
    /// 電話番号
    /// </summary>
    public string Phone { get; set; } = string.Empty;
    /// <summary>
    /// 所属部署
    /// </summary>
    public Department? Department { get; set; } = null;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="id">社員Id</param>
    /// <param name="name">社員名</param>
    /// <param name="emainl">メールアドレス</param>
    /// <param name="phone">電話番号</param>
    /// <param name="department">取得する</param>
    public Employee(int id, string name, string email, string phone, Department? department)
    {
        // バリデーションチェック
        validateEmployeeId(id);
        validateEmployeeName(name);
        validateEmployeeEmail(email);
        validateEmployeePhone(phone);
        Id = id;
        Name = name;
        Email = email;
        Phone = phone;
        this.Department = department;
    }
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="id">社員Id</param>
    /// <param name="name">社員名</param>
    /// <param name="emainl">メールアドレス</param>
    /// <param name="phone">電話番号</param>
    /// <param name="department">取得する</param>
    public Employee(int id, string name, string email, string phone)
        :this(id, name, email, phone, null)
    {
    }


    /// <summary>
    /// バリデーションチェックメソッド
    /// </summary>
    /// <param name="id">社員Id</param>
    /// <exception cref="DomainException"></exception>
    private void validateEmployeeId(int id)
    {
        if (id < 1)
        {
            throw new DomainException("社員Idは1以上の整数です。");
        }
    }

    /// <summary>
    /// バリデーションチェックメソッド
    /// </summary>
    /// <param name="name">社員名</param>
    /// <exception cref="DomainException"></exception>
    private void validateEmployeeName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new DomainException("社員名は必須です。");
        }
        if (name.Length > 20)
        {
            throw new DomainException("社員名は20文字以内です。");
        }
    }

    /// <summary>
    /// バリデーションチェックメソッド
    /// </summary>
    /// <param name="email">メールアドレス</param>
    /// <exception cref="DomainException"></exception>
    private void validateEmployeeEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            throw new DomainException("メールアドレスは必須です。");
        }
        if (email.Length > 30)
        {
            throw new DomainException("メールアドレスは30文字以内です。");
        }
    }

    /// <summary>
    /// バリデーションチェックメソッド
    /// </summary>
    /// <param name="phone">電話番号</param>
    /// <exception cref="DomainException"></exception>
    private void validateEmployeePhone(string phone)
    {
        if (string.IsNullOrEmpty(phone))
        {
            throw new DomainException("電話番号は必須です。");
        }
        if (phone.Length > 15)
        {
            throw new DomainException("電話番号は15文字以内です。");
        }
    }
    /// <summary>
    /// 社員名を変更するメソッド
    /// </summary>
    /// <param name="name"></param>
    public void ChangeName(string name)
    {
        validateEmployeeName(name);
        Name = name;
    }
    /// <summary>
    /// メールアドレスの変更メソッド
    /// </summary>
    /// <param name="email"></param>
    public void ChangeEmail(string email)
    {
        validateEmployeeEmail(email);
        Email = email;
    }
    /// <summary>
    /// 電話番号の変更メソッド
    /// </summary>
    /// <param name="phone"></param>
    public void ChangePhone(string phone)
    {
        validateEmployeePhone(phone);
        Phone = phone;
    }
    /// <summary>
    /// 所属部署の変更メソッド
    /// </summary>
    /// <param name="department"></param>
    public void ChangeDepartment(Department department)
    {
        this.Department = department;
    }
    public override string? ToString()
    {
        return $"" +
            $"社員Id:{Id}, " +
            $"社員名:{Name}, " +
            $"メールアドレス:{Email}, " +
            $"電話番号:{Phone}, " +
            $"所属部署:{Department}";
    }
}
