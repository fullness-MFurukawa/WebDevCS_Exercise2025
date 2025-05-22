using Domains.Models.Departments;
using Domains.Models.Employees;
using Presentations.Models.Employees;

namespace Presentations.Adapters;
/// <summary>
/// ViewModelのEmployeeRegisterFormとModelのEmployeeを変換するアダプタークラス
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/23</date>
public class EmployeeRegisterFormAdapter : IEmployeeAdapter<EmployeeRegisterForm>
{
    public EmployeeRegisterForm Convert(Employee obj)
    {
        throw new NotImplementedException();
    }

    public List<EmployeeRegisterForm> Convert(List<Employee> objs)
    {
        throw new NotImplementedException();
    }

    public Employee Restore(EmployeeRegisterForm obj)
    {
        var department = new Department(
                (int)obj!.DepartmentId!, obj.DepartmentName!);
        var employee = new Employee(
            obj.Name, obj.Email, obj.Phone, department);
        return employee;
    }

    public List<Employee> Restore(List<EmployeeRegisterForm> objs)
    {
        throw new NotImplementedException();
    }
}
