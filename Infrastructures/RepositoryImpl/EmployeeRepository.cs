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
        _context.Employees.Add(entity);
        _context.SaveChanges();
    }
    /// <summary>
    /// すべての社員を取得する
    /// </summary>
    /// <returns></returns>
    public List<Employee> FindAllJoinDepartment()
    {
        var employees = _context.Employees
            .Include(e => e.Department) // 部署情報を含めて取得   
            .AsNoTracking()
            .ToList();
        return _adapter.Restore(employees);
    }
}
