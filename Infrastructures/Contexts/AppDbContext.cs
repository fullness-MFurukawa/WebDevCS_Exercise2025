using Infrastructures.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructures.Contexts;
/// <summary>
/// アプリケーションで利用するDbContext継承クラス
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/20</date>
public class AppDbContext : DbContext
{
    /// <summary>
    /// departmentテーブルのDbSetプロパティ
    /// </summary>
    public DbSet<DepartmentEntity> Departments { get; set; }

    /// <summary>
    /// 接続情報などのオプションを受け取り、
    /// スーパークラスのDbContextの機能を用いて設定するコンストラクタ
    /// </summary>
    /// <param name="options"></param>
    public AppDbContext(DbContextOptions<AppDbContext> options) 
           : base(options) { }
}
