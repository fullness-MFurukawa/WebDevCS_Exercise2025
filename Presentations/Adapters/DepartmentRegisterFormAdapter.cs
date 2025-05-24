using Domains.Models.Departments;
using Presentations.Models.Departments;

namespace Presentations.Adapters;
/// <summary>
/// ViewModelのDepartmentRegisterFormとModelのDepartmentを変換するアダプタークラス
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/26</date>
public class DepartmentRegisterFormAdapter : IDepartmentAdapter<DepartmentRegisterForm>
{
    // <summary>
    /// 部署データを指定されたDepartmentRegisterFormに変換する
    /// </summary>
    /// <param name="obj">部署データ</param>
    /// <returns></returns>
    public DepartmentRegisterForm Convert(Department obj)
    {
        // 未使用のため未実装
        throw new NotImplementedException();
    }
    /// <summary>
    /// 部署データのリストを指定されたDepartmentRegisterFormのリストに変換する
    /// </summary>
    /// <param name="obj">部署データ</param>
    /// <returns></returns>
    public List<DepartmentRegisterForm> Convert(List<Department> objs)
    {
        // 未使用のため未実装
        throw new NotImplementedException();
    }
    /// <summary>
    /// DepartmentRegisterFormから部署データを復元する
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public Department Restore(DepartmentRegisterForm obj)
    {
        return new Department(obj.Name!);
    }
    /// <summary>
    /// DepartmentFormのリストから部署データのリストを復元する
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public List<Department> Restore(List<DepartmentRegisterForm> objs)
    {
        // 未使用のため未実装
        throw new NotImplementedException();
    }
}
