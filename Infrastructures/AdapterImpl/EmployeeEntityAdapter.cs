using Domains.Models.Departments;
using Domains.Models.Employees;
using Infrastructures.Entities;
namespace Infrastructures.AdapterImpl;
/// <summary>
/// EmployeeとEmployeeEntityの相互変換クラス
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/21</date>
public class EmployeeEntityAdapter : IEmployeeAdapter<EmployeeEntity>
{
    private readonly IDepartmentAdapter<DepartmentEntity> _adapter;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="adapter"></param>
    public EmployeeEntityAdapter(IDepartmentAdapter<DepartmentEntity> adapter)
    {
        _adapter = adapter;
    }
    /// <summary>
    /// 社員データをEmployeeEntityに変換する
    /// </summary>
    /// <param name="obj">社員データ</param>
    /// <returns></returns>
    public EmployeeEntity Convert(Employee obj)
    {
        var entity = new EmployeeEntity
        {
            Id = obj.Id,
            Name = obj.Name,
            Phone = obj.Phone,
            Email = obj.Email,
        };
        if ( obj.Department != null)
        {
            entity.DeptId = obj.Department!.Id;
        }
        return entity;
    }
    /// <summary>
    /// 社員データのリストをEmployeeEntityのリストに変換する
    /// </summary>
    /// <param name="obj">社員データのリスト</param>
    /// <returns></returns>
    public List<EmployeeEntity> Convert(List<Employee> objs)
    {
        var entities = new List<EmployeeEntity>();
        foreach (var obj in objs)
        {
            var entity = Convert(obj);
            entities.Add(entity);
        }
        return entities;
    }
    /// <summary>
    /// EmployeeEntityから社員データを復元する
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public Employee Restore(EmployeeEntity obj)
    {
        var model = new Employee(obj.Id, obj.Name, obj.Email, obj.Phone);
        if (obj.Department != null)
        {
            var department = _adapter.Restore(obj.Department);
            model.Department = department;
        }
        return model;
    }
    /// <summary>
    /// EmployeeEntityリストから部署データのリストを復元する
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public List<Employee> Restore(List<EmployeeEntity> objs)
    {
        var models = new List<Employee>();
        foreach (var obj in objs)
        {
            var model = Restore(obj);
            models.Add(model);
        }
        return models;
    }
}
