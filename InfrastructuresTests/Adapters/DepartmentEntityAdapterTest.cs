using Domains.Models.Departments;
using Infrastructures.Entities;
using Microsoft.Extensions.DependencyInjection;
using Presentations.Configs;

namespace InfrastructuresTests.Adapters;

[TestClass]
public class DepartmentEntityAdapterTest
{
    private static IDepartmentAdapter<DepartmentEntity>? _adapter;

    [ClassInitialize]
    public static void SetUp(TestContext context)
    {
        _adapter = ServiceProviderUtil
            .GetProvider().GetService<IDepartmentAdapter<DepartmentEntity>>();
    }

    [TestMethod("DepartmentからDepartmentEntityへ変換できる")]
    public void Test_Convert_Case1()
    {
        var department = new Department(101, "システム開発部");
        var entity = _adapter!.Convert(department);
        Assert.IsNotNull(entity, "変換結果がnullです。");
        Assert.AreEqual(department.Id, entity.Id, "Idが一致しません。");
        Assert.AreEqual(department.Name, entity.Name, "Nameが一致しません。");
    }

    [TestMethod("DepartmentのリストからDepartmentEntityのリストへ変換できる")]
    public void Test_Convert_Case2()
    {
        var departmets = new List<Department>
        {
            new Department(101, "システム開発部"),
            new Department(102, "営業部"),
        };
        var entities = _adapter!.Convert(departmets);
        Assert.IsNotNull(entities, "変換結果がnullです。");
        Assert.AreEqual(departmets.Count, entities.Count, "変換結果の件数が一致しません。");
        foreach (var entity in entities)
        {
            Console.WriteLine(entity);
        }
    }

    [TestMethod("DepartmentEntityからDepartmentを復元できる")]
    public void Test_Restore_Case1()
    {
       var entity = new DepartmentEntity
        {
            Id = 101,
            Name = "システム開発部",
        };
        var department = _adapter!.Restore(entity);
        Assert.IsNotNull(department, "復元結果がnullです。");
        Assert.AreEqual(entity.Id, department.Id, "Idが一致しません。");
        Assert.AreEqual(entity.Name, department.Name, "Nameが一致しません。");
    }

    [TestMethod("DepartmentEntityのリストからDepartmentのリストへ復元できる")]
    public void Test_Restore_Case2()
    {
        var entities = new List<DepartmentEntity>
        {
            new DepartmentEntity { Id = 101, Name = "システム開発部" },
            new DepartmentEntity { Id = 102, Name = "営業部" },
        };
        var departments = _adapter!.Restore(entities);
        Assert.IsNotNull(departments, "復元結果がnullです。");
        Assert.AreEqual(entities.Count, departments.Count, "復元結果の件数が一致しません。");
        foreach (var department in departments)
        {
            Console.WriteLine(department);
        }
    }
}