using Domains.Exceptions;
using Domains.Models.Employees;
using Infrastructures.Contexts;
using Infrastructures.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructures.RepositoryImpl;
/// <summary>
/// 社員データのCRUD操作リポジトリインターフェースの実装
/// EntityFramework Core
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/21</date>
public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext _context;
    private readonly IEmployeeAdapter<EmployeeEntity> _adapter;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="context">DbContextの拡張</param>
    /// <param name="adapter">EmployeeとEmployeeEntityの相互変換</param>
    public EmployeeRepository(AppDbContext context, IEmployeeAdapter<EmployeeEntity> adapter)
    {
        _context = context;
        _adapter = adapter;
    }

    /// <summary>
    /// 指定された社員を永続化する
    /// </summary>
    /// <param name="employee"></param>
    public void Create(Employee employee)
    {
        var entity = _adapter.Convert(employee);
        try
        {
            _context.Employees.Add(entity);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new InternalServerException("社員の永続化に失敗しました。", ex);
        }
    }

    /// <summary>
    /// すべての社員を取得する
    /// </summary>
    /// <returns></returns>
    public List<Employee> FindAllJoinDepartment()
    {
        try
        {
            var employees = _context.Employees
                .Include(e => e.Department) // 部署情報を含めて取得   
                .AsNoTracking()
                .ToList();
            return _adapter.Restore(employees);
        }
        catch (Exception ex)
        {
            throw new InternalServerException("社員の取得に失敗しました。", ex);
        }
    }
    /// <summary>
    /// 指定された社員Idで社員を取得する
    /// </summary>
    /// <param name="id">社員Id</param>
    /// <returns></returns>
    public Employee? FindById(int id)
    {
        try
        {
            var entity = _context.Employees.Find(id);
            if (entity != null)
            {
                return _adapter.Restore(entity);
            }
            return null;
        }
        catch (Exception ex)
        {
            throw new InternalServerException("社員の取得に失敗しました。", ex);
        }
    }

    /// <summary>
    /// 引数で指定された社員Idの社員を削除する
    /// </summary>
    /// <param name="Id">社員Id</param>
    public void DeleteById(int Id)
    {
        try
        {
            var entity = _context.Employees.Find(Id);
            if (entity == null)
            {
                throw new NotFoundException(
                $"社員Id:{Id}の社員は存在しないため、削除できませんでした。");
            }
            _context.Employees.Remove(entity);
            _context.SaveChanges();
        }
        catch (NotFoundException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new InternalServerException("社員の削除に失敗しました。", ex);
        }
    }
    /// <summary>
    /// メールアドレスの有無を返す
    /// </summary>
    /// <param name="email"></param>
    /// <returns>true:存在する,false:存在しない</returns>
    public bool ExistsByEmail(string email)
    {
        try
        {
            var result = _context.Employees
            .Any(e => e.Email == email);
            return result;
        }
        catch (Exception ex)
        {
            throw new InternalServerException("メールアドレスの取得に失敗しました。", ex);
        }
    }
}
