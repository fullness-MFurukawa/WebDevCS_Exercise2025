using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Infrastructures.Entities;
/// <summary>
/// departmentテーブルのエンティティクラス
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/20</date>
[Table("Department")]
public class DepartmentEntity
{
    /// <summary>
    /// 部署Id
    /// </summary>  
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("DEPT_NO")]
    public int Id { get; set; }
    /// <summary>
    /// 部署名
    /// </summary>
    [Column("DEPT_NAME")]
    public string Name { get; set; } = string.Empty;

    public override string? ToString()
    {
        return $"Id: {Id}, Name: {Name}";
    }
}
