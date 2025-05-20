using Domains.Exceptions;
using Domains.Models.Departments;
namespace DomainsTests.Models;
[TestClass]
public class DepartmentTest
{
    [TestMethod("部署を生成できる")]
    public void TestCreate_Case1()
    {
        var department = new Department(101, "システム開発部"); 
        Assert.IsNotNull(department);
        Assert.AreEqual(101, department.Id);
        Assert.AreEqual("システム開発部", department.Name);
    }
    [TestMethod("1より小さい部署Idで生成するとDomainExceptionがスローされる")]
    public void TestCreate_Case2()
    {
        var exception = Assert.ThrowsException<DomainException>(() =>
        {
            new Department(0, "システム開発部");
        });
        Assert.AreEqual("部署Idは1以上の整数で入力してください。", exception.Message);
        exception = Assert.ThrowsException<DomainException>(() =>
        {
            new Department(-1, "システム開発部");
        });
        Assert.AreEqual("部署Idは1以上の整数で入力してください。", exception.Message);
    }
    [TestMethod("部署名が空文字列で生成するとDomainExceptionがスローされる")]
    public void TestCreate_Case3()
    {
        var exception = Assert.ThrowsException<DomainException>(() =>
        {
            new Department(101, "");
        });
        Assert.AreEqual("部署名は必須です。", exception.Message);
    }
    [TestMethod("部署名が20文字以上で生成するとDomainExceptionがスローされる")]
    public void TestCreate_Case4()
    {
        var exception = Assert.ThrowsException<DomainException>(() =>
        {
            new Department(101, "0123456789012345678901234567890123456789");
        });
        Assert.AreEqual("部署名は20文字以内で入力してください。", exception.Message);
    }

    [TestMethod("部署名を空文字列で変更するとDomainExceptionがスローされる")]
    public void TestChangeName_Case1()
    {
        var department = new Department(101, "システム開発部");
        var exception = Assert.ThrowsException<DomainException>(() =>
        {
            department.ChangeName("");
        });
        Assert.AreEqual("部署名は必須です。", exception.Message);
    }
    [TestMethod("部署名を20文字以上で変更するとDomainExceptionがスローされる")]
    public void TestChangeName_Case2()
    {
        var department = new Department(101, "システム開発部");
        var exception = Assert.ThrowsException<DomainException>(() =>
        {
            department.ChangeName("0123456789012345678901234567890123456789");
        });
        Assert.AreEqual("部署名は20文字以内で入力してください。", exception.Message);
    }
}
