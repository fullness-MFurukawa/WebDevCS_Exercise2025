using Domains.Exceptions;
using Domains.Models.Departments;
using Infrastructures.Contexts;
using Infrastructures.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructures.RepositoryImpl;
/// <summary>
/// 部署データのCRUD操作リポジトリインターフェースの実装
/// EntityFramework Core
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/20</date>
public class DepartmentRepository : IDepartmentRepository
{
    private readonly AppDbContext _context;
    private readonly IDepartmentAdapter<DepartmentEntity> _adapter;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="context">アプリケーション用DbContext</param>
    /// <param name="adapter">部署データの相互変換アダプタ</param>
    public DepartmentRepository(AppDbContext context, IDepartmentAdapter<DepartmentEntity> adapter)
    {
        _context = context;
        _adapter = adapter;
    }
    /// <summary>
    /// すべての部署を取得する
    /// </summary>
    /// <returns></returns>
    public List<Department> FindAll()
    {
        // 部署データをDBから取得する
        var departments = _context.Departments
            .AsNoTracking()
            .ToList();
        var results = new List<Department>();
        foreach (var department in departments)
        {
            // 部署データをドメインモデルに復元
            results.Add(_adapter.Restore(department));
        }
        return results;
    }
    /// <summary>
    /// 指定された部署を永続化する
    /// </summary>
    /// <param name="department"></param>
    public void Create(Department department)
    {
        // 部署データをドメインモデルからDBエンティティに変換する
        var entity = _adapter.Convert(department);
        // 部署データをDBに永続化する
        _context.Departments.Add(entity);
        _context.SaveChanges();
    }

    /// <summary>
    /// 指定された部署Idで部署を取得する
    /// </summary>
    /// <param name="id">部署Id</param>
    /// <returns></returns>
    public Department FindById(int id)
    {
        try
        {
            var department = _context.Departments.Find(id);
            if (department == null)
            {
                throw new NotFoundException("指定された部署は存在しません。");
            }
            return _adapter.Restore(department);
        }
        catch (Exception ex)
        {
            throw new InternalServerException("部署の取得に失敗しました。", ex);
        }
    }

    /// <summary>
    /// 部署名の存在チェック
    /// </summary>
    /// <param name="name">部署名</param>
    /// <returns>true:存在する false:存在しない</returns>
    public bool Exists(string name)
    {
        var resutl = _context.Departments.Any(d => d.Name == name);
        return resutl;
    }
}