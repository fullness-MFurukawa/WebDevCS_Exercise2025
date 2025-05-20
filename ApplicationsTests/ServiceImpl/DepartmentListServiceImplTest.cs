
using Applications.Services;
using Microsoft.Extensions.DependencyInjection;
using Presentations.Configs;

namespace ApplicationsTests.ServiceImpl;
/// <summary>
/// 部署一覧サービスインターフェース実装の単体テストクラス
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/20</date>
[TestClass]
public class DepartmentListServiceImplTest
{
    private static IDepartmentListService? _service;

    [ClassInitialize]
    public static void SetUp(TestContext context)
    {
        _service = ServiceProviderUtil
            .GetProvider().GetService<IDepartmentListService>();
    }

    [TestMethod("部署リストを取得できる")]
    public void TestExecute_Case1()
    {
        // Arrange
        var expectedCount = 5; // 期待される件数を指定
        // Act
        var result = _service!.Execute();
        // Assert
        Assert.IsNotNull(result, "結果がnullです。");
        Assert.AreEqual(expectedCount, result.Count(), "取得件数が一致しません。");
        foreach (var department in result)
        {
            Console.WriteLine(department);
        }
    }
}
