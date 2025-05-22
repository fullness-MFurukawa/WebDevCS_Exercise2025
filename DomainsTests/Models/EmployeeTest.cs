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
        Assert.AreEqual("yamada@example.com",employee.Email);
        Assert.AreEqual("090-1234-5678", employee.Phone);
    }
}
