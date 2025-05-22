using Domains.Exceptions;
using Domains.Models.Departments;
using Domains.Models.Employees;

namespace DomainsTests.Models;
/// <summary>
/// 社員モデルの単体テストクラス
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/22</date>
[TestClass]
public class EmployeeTest
{
    [TestMethod("社員を生成できる(所属部署なし)")]
    public void TestCreate_Case1()
    {
        var employee = new Employee(
            101,
            "山田太郎",
            "yamada@example.com",
            "090-1234-5678",
            null);
        Assert.IsNotNull(employee);
        Assert.AreEqual(101, employee.Id);
        Assert.AreEqual("山田太郎", employee.Name);
        Assert.AreEqual("yamada@example.com", employee.Email);
        Assert.AreEqual("090-1234-5678", employee.Phone);
    }
    [TestMethod("社員を生成できる(所属部署あり)")]
    public void TestCreate_Case2()
    {
        var department = new Department(101, "システム開発部");
        var employee = new Employee(
           101,
           "山田太郎",
           "yamada@example.com",
           "090-1234-5678",
           department);
        Assert.IsNotNull(employee);
        Assert.AreEqual(101, employee.Id);
        Assert.AreEqual("山田太郎", employee.Name);
        Assert.AreEqual("yamada@example.com", employee.Email);
        Assert.AreEqual("090-1234-5678", employee.Phone);
        Assert.IsNotNull(employee.Department);
    }
    [TestMethod("1より小さい社員Idで生成するとDomainExceptionがスローされる")]
    public void TestCreate_Case3()
    {
        var exception = Assert.ThrowsException<DomainException>(() =>
        {
            var employee = new Employee(
            0,
            "山田太郎",
            "yamada@example.com",
            "090-1234-5678",
            null);
        });
        Assert.AreEqual("社員Idは1以上の整数です。", exception.Message);
        exception = Assert.ThrowsException<DomainException>(() =>
        {
            var employee = new Employee(
            -1,
            "山田太郎",
            "yamada@example.com",
            "090-1234-5678",
            null);
        });
        Assert.AreEqual("社員Idは1以上の整数です。", exception.Message);
    }
    [TestMethod("社員名が空文字列で生成するとDomainExceptionがスローされる")]
    public void TestCreate_Case4()
    {
        var exception = Assert.ThrowsException<DomainException>(() =>
        {
            var employee = new Employee(
           101,
           "",
           "yamada@example.com",
           "090-1234-5678",
           null);
        });
        Assert.AreEqual("社員名は必須です。", exception.Message);
    }
    [TestMethod("メールアドレスが空文字列で生成するとDomainExceptionがスローされる")]
    public void TestCreate_Case5()
    {
        var exception = Assert.ThrowsException<DomainException>(() =>
        {
            var employee = new Employee(
           101,
           "山田太郎",
           "",
           "090-1234-5678",
           null);
        });
        Assert.AreEqual("メールアドレスは必須です。", exception.Message);
    }
    [TestMethod("電話番号が空文字列で生成するとDomainExceptionがスローされる")]
    public void TestCreate_Case6()
    {
        var exception = Assert.ThrowsException<DomainException>(() =>
        {
            var employee = new Employee(
           101,
           "山田太郎",
           "yamada@example.com",
           "",
           null);
        });
        Assert.AreEqual("電話番号は必須です。", exception.Message);
    }

    [TestMethod("社員名が20文字以上で生成するとDomainExceptionがスローされる")]
    public void TestCreate_Case7()
    {
        var exception = Assert.ThrowsException<DomainException>(() =>
        {
            var employee = new Employee(
            101,
            "0123456789012345678901234567890123456789",
            "yamada@example.com",
            "090-1234-5678",
            null);
        });
        Assert.AreEqual("社員名は20文字以内です。", exception.Message);
    }
    [TestMethod("メールアドレスが30文字以上で生成するとDomainExceptionがスローされる")]
    public void TestCreate_Case8()
    {
        var exception = Assert.ThrowsException<DomainException>(() =>
        {
            var employee = new Employee(
            101,
            "山田太郎",
            "01234567890123456789012345678901234567890123456789",
            "090-1234-5678",
            null);
        });
        Assert.AreEqual("メールアドレスは30文字以内です。", exception.Message);
    }
    [TestMethod("電話番号が15文字以上で生成するとDomainExceptionがスローされる")]
    public void TestCreate_Case9()
    {
        var exception = Assert.ThrowsException<DomainException>(() =>
        {
            var employee = new Employee(
            101,
            "山田太郎",
            "yamada@example.com",
            "090-1234-56780000000000000",
            null);
        });
        Assert.AreEqual("電話番号は15文字以内です。", exception.Message);
    }
}