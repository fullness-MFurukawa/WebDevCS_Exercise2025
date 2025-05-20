using Domains.Models.Departments;
using Infrastructures.Entities;

namespace Infrastructures.AdapterImpl;
/// <summary>
/// DepartmentとDepartmentEntityの相互変換クラス
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/20</date>
public class DepartmentEntityAdapter : IDepartmentAdapter<DepartmentEntity>
{
    /// <summary>
    /// 部署データを指定されたDepartmentEntityに変換する
    /// </summary>
    /// <param name="obj">部署データ</param>
    /// <returns></returns>
    public DepartmentEntity Convert(Department obj)
    {
        var result = new DepartmentEntity
        {
            Id = obj.Id,
            Name = obj.Name,
        };
        return result;
    }
    /// <summary>
    /// DepartmentEntityから部署データを復元する
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public Department Restore(DepartmentEntity obj)
    {
        var result = new Department(obj.Id, obj.Name);
        return result;
    }

    /// <summary>
    /// 部署データのリストをDepartmentEntityのリストに変換する
    /// </summary>
    /// <param name="obj">部署データ</param>
    /// <returns></returns>
    List<DepartmentEntity> IDepartmentAdapter<DepartmentEntity>.Convert(List<Department> objs)
    {
        var results = new List<DepartmentEntity>();
        foreach (var obj in objs)
        {
            var entity = Convert(obj);
            results.Add(entity);
        }
        return results;
    }
    /// <summary>
    /// DepartmentEntityリストから部署データのリストを復元する
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    List<Department> IDepartmentAdapter<DepartmentEntity>.Restore(List<DepartmentEntity> objs)
    {
        var results = new List<Department>();
        foreach (var obj in objs)
        {
            var department = Restore(obj);
            results.Add(department);
        }
        return results;
    }
}
