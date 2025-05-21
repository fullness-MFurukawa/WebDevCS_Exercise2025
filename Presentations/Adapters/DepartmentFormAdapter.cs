using Domains.Models.Departments;
using Presentations.Models.Departments;

namespace Presentations.Adapters;
/// <summary>
/// ViewModelのDepartmentFormとModelのDepartmentを変換するアダプタークラス
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/20</date>
public class DepartmentFormAdapter : IDepartmentAdapter<DepartmentForm>
{
    /// <summary>
    /// 部署データを指定されたDepartmentFormに変換する
    /// </summary>
    /// <param name="obj">部署データ</param>
    /// <returns></returns>
    public DepartmentForm Convert(Department obj)
    {
        return new DepartmentForm()
        {
            Id = obj.Id,
            Name = obj.Name
        };
    }
    /// <summary>
    /// 部署データのリストを指定されたDepartmentFormのリストに変換する
    /// </summary>
    /// <param name="obj">部署データ</param>
    /// <returns></returns>
    public List<DepartmentForm> Convert(List<Department> objs)
    {
        var results = new List<DepartmentForm>();
        foreach (var obj in objs)
        {
            results.Add(Convert(obj));
        }
        return results;
    }
    /// <summary>
    /// DepartmentFormから部署データを復元する
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public Department Restore(DepartmentForm obj)
    {
        var department = new Department(obj.Id, obj.Name);
        return department;
    }
    /// <summary>
    /// DepartmentFormのリストから部署データのリストを復元する
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public List<Department> Restore(List<DepartmentForm> objs)
    {
        var results = new List<Department>();
        foreach (var obj in objs)
        {
            results.Add(Restore(obj));
        }
        return results;
    }
}
