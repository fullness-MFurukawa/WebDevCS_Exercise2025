using Applications.Services;
using Domains.Models.Employees;
using Microsoft.Extensions.DependencyInjection;
using Presentations.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsTests.ServiceImpl;
/// <summary>
/// 社員一覧サービスインターフェース実装の単体テストクラス
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/22</date>
[TestClass]
public class EmployeeListServiceImplTest
{
    private static IEmployeeListService? _service;
    [ClassInitialize]
    public static void SetUp(TestContext context)
    {
        // プロバイダからリポジトリを取得する
        _service = ServiceProviderUtil
            .GetProvider().GetService<IEmployeeListService>();
    }

    [TestMethod("社員リストを取得できる")]
    public void TestExecute_Case1()
    {
        // Arrange
        var expectedCount = 8; // 期待される件数を指定
        // Act
        var result = _service!.Execute();
        // Assert
        Assert.IsNotNull(result, "結果がnullです。");
        Assert.AreEqual(expectedCount, result.Count(), "取得件数が一致しません。");
        foreach (var employee in result)
        {
            Console.WriteLine(employee);
        }
    }
}
