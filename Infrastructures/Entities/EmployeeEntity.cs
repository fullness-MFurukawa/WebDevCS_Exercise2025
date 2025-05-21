using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Infrastructures.Entities;
/// <summary>
/// employeeテーブルのエンティティクラス
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/21</date>
[Table("Employee")]
public class EmployeeEntity
{
    /// <summary>
    /// 社員Id
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("EMP_NO")]
    public int Id { get; set; } = 0;
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
    /// 部署Id(外部キー)
    /// </summary>
    [Column("dept_id")]
    public int? DeptId { get; set; } = null;

    /// <summary>
    /// 所属部署
    /// </summary>
    [ForeignKey("DeptId")]
    public DepartmentEntity? Department { get; set; } = null;

    public override string? ToString()
    {
        return $"Id: {Id}, Name: {Name}, Email: {Email}, Phone: {Phone}, DeptId: {DeptId}";
    }
}
