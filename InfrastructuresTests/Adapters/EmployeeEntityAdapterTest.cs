using Domains.Models.Departments;
using Domains.Models.Employees;
using Infrastructures.Entities;
using Microsoft.Extensions.DependencyInjection;
using Presentations.Configs;
namespace InfrastructuresTests.Adapters;
/// <summary>
/// EmployeeとEmployeeEntityの変換テストクラスのテストクラス
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/22</date
[TestClass]
public class EmployeeEntityAdapterTest
{
    private static IEmployeeAdapter<EmployeeEntity>? _adapter;

    [ClassInitialize]
    public static void SetUp(TestContext context)
    {
        // プロバイダからアダプタを取得する
        _adapter = ServiceProviderUtil
            .GetProvider().GetService<IEmployeeAdapter<EmployeeEntity>>();
    }

    [TestMethod("EmployeeからEmployeeEntityへ変換できる(所属部署なし)")]
    public void Test_Convert_Case1()
    {
        var employee = new Employee(
            101,
            "山田太郎",
            "yamada@sample.com",
            "090-111-2222",
            null);
        var entity = _adapter!.Convert(employee);
        Assert.IsNotNull(entity, "変換結果がnullです。");
        Assert.AreEqual(employee.Id, entity.Id, "Idが一致しません。");
        Assert.AreEqual(employee.Name, entity.Name, "Nameが一致しません。");
        Assert.IsNull(entity.Department, "DepartmentIdはnullのはずです。");
    }

    [TestMethod("EmployeeからEmployeeEntityへ変換できる(所属部署あり)")]
    public void Test_Convert_Case2()
    {
        var department = new Department(101, "システム開発部");
        var employee = new Employee(
            101,
            "山田太郎",
            "yamada@sample.com",
            "090-111-2222",
            department);
        var entity = _adapter!.Convert(employee);
        Assert.IsNotNull(entity, "変換結果がnullです。");
        Assert.AreEqual(employee.Id, entity.Id, "Idが一致しません。");
        Assert.AreEqual(employee.Name, entity.Name, "Nameが一致しません。");
        Assert.AreEqual(department.Id, entity.DeptId, "DepartmentIdが一致しません。");
    }
    [TestMethod("EmployeeEntityからEmployeeへ変換できる(所属部署なし)")]
    public void Test_Restore_Case1()
    {
        var entity = new EmployeeEntity
        {
            Id = 101,
            Name = "山田太郎",
            Phone = "090-111-2222",
            Email = "yamada@sample.com",
            DeptId = 101,
            Department = null,
        };
        var employee = _adapter!.Restore(entity);
        Assert.IsNotNull(employee, "復元結果がnullです。");
        Assert.AreEqual(entity.Id, employee.Id, "Idが一致しません。");
        Assert.AreEqual(entity.Name, employee.Name, "Nameが一致しません。");
        Assert.AreEqual(entity.Phone, employee.Phone, "Phoneが一致しません。");
        Assert.AreEqual(entity.Email, employee.Email, "Emailが一致しません。");
        Assert.IsNull(employee.Department, "Departmentはnullのはずです。");
    }

    [TestMethod("EmployeeEntityからEmployeeへ変換できる(所属部署なし)")]
    public void Test_Restore_Case2()
    {
        var department = new DepartmentEntity
        {
            Id = 101,
            Name = "システム開発部",
        };
        var entity = new EmployeeEntity
        {
            Id = 101,
            Name = "山田太郎",
            Phone = "090-111-2222",
            Email = "yamada@sample.com",
            DeptId = 101,
            Department = department,
        };
        var employee = _adapter!.Restore(entity);
        Assert.IsNotNull(employee, "復元結果がnullです。");
        Assert.AreEqual(entity.Id, employee.Id, "Idが一致しません。");
        Assert.AreEqual(entity.Name, employee.Name, "Nameが一致しません。");
        Assert.AreEqual(entity.Phone, employee.Phone, "Phoneが一致しません。");
        Assert.AreEqual(entity.Email, employee.Email, "Emailが一致しません。");
        Assert.IsNotNull(employee.Department, "Departmentはnullのはずです。");
        Assert.AreEqual(entity.DeptId, employee.Department!.Id, "DepartmentIdが一致しません。");
        Assert.AreEqual(entity.Department.Name, employee.Department.Name, "DepartmentNameが一致しません。");
    }
}
