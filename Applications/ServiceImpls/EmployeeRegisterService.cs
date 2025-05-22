using Applications.Services;
using Domains.Models.Departments;
using Domains.Models.Employees;

namespace Applications.ServiceImpls;
/// <summary>
/// 社員登録サービスインターフェースの実装クラス
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/22</date>
public class EmployeeRegisterService : IEmployeeRegisterService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IDepartmentRepository _departmentRepository;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="employeeRepository">社員データのCRUD操作リポジトリインターフェース</param>
    /// <param name="departmentRepository">部署データのCRUD操作リポジトリインターフェース</param>
    public EmployeeRegisterService(
        IEmployeeRepository employeeRepository, 
        IDepartmentRepository departmentRepository)
    {
        _employeeRepository = employeeRepository;
        _departmentRepository = departmentRepository;
    }

    /// <summary>
    /// 部署一覧を取得する
    /// </summary>
    /// <returns></returns>
    public List<Department> GetDepartments()
    {
        return _departmentRepository.FindAll();
    }

    /// <summary>
    /// メールアドレスに存在確認
    /// </summary>
    /// <param name="email">メールアドレス</param>
    public bool ExistsByEmail(string email)
    {
        return _employeeRepository.ExistsByEmail(email);
    }

    /// <summary>
    /// 部署Idで部署を取得する
    /// </summary>
    /// <param name="id">部署Id</param>
    /// <returns></returns>
    public Department GetDepartmentsById(int id)
    {
        return _departmentRepository.FindById(id);
    }
    /// <summary>
    /// 社員を登録する
    /// </summary>
    /// <param name="employee">社員</param>
    public void Register(Employee employee)
    {
        _employeeRepository.Create(employee);
    }
}
