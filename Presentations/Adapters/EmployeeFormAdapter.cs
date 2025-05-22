using Domains.Models.Departments;
using Domains.Models.Employees;
using Presentations.Models.Departments;
using Presentations.Models.Employees;
namespace Presentations.Adapters;
/// <summary>
/// ViewModelのDepartmentFormとModelのDepartmentを変換するアダプタークラス
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/21</date>
public class EmployeeFormAdapter : IEmployeeAdapter<EmployeeForm>
{
    private readonly IDepartmentAdapter<DepartmentForm> _adapter;

    public EmployeeFormAdapter(IDepartmentAdapter<DepartmentForm> adapter)
    {
        _adapter = adapter;
    }
    /// <summary>
    /// 社員データをEmployeeFormに変換する
    /// </summary>
    /// <param name="obj">社員データ</param>
    /// <returns></returns>
    public EmployeeForm Convert(Employee obj)
    {
        var form = new EmployeeForm()
        {
            Id = (int)obj.Id!,
            Name = obj.Name,
            Email = obj.Email,
            Phone = obj.Phone,
        };
        if (obj.Department != null)
        {
            form.Department = _adapter.Convert(obj.Department);
        }
        return form;
    }
    /// <summary>
    /// 部署データのリストをEmployeeFormのリストに変換する
    /// </summary>
    /// <param name="obj">部署データ</param>
    /// <returns></returns>
    public List<EmployeeForm> Convert(List<Employee> objs)
    {
        var forms = new List<EmployeeForm>();
        foreach (var obj in objs)
        {
            var form = Convert(obj);
            forms.Add(form);
        }
        return forms;
    }
    /// <summary>
    /// EmployeeFormから社員データを復元する
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public Employee Restore(EmployeeForm obj)
    {
        var employee = new Employee(obj.Id, obj.Name, obj.Email, obj.Phone);
        if (obj.Department != null)
        {
            employee.Department = _adapter.Restore(obj.Department);
        }
        return employee;
    }
    /// <summary>
    /// EmployeeFormのリストから社員データのリストを復元する
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public List<Employee> Restore(List<EmployeeForm> objs)
    {
        var results = new List<Employee>(); 
        foreach (var obj in objs)
        {
            results.Add(Restore(obj));
        }
        return results;
    }
}
