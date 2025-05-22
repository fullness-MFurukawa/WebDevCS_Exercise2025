using Domains.Models.Employees;
using Microsoft.Extensions.DependencyInjection;
using Presentations.Configs;

namespace InfrastructuresTests.RepositoryImpl;
/// <summary>
/// 社員データのCRUD操作リポジトリインターフェースの実装のテストクラス
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/22</date>
[TestClass]
public class EmployeeRepositoryImplTest
{
    private static IEmployeeRepository? _repository;
    [ClassInitialize]
    public static void SetUp(TestContext context)
    {
        // プロバイダからリポジトリを取得する
        _repository = ServiceProviderUtil
            .GetProvider().GetService<IEmployeeRepository>();
    }
    [TestMethod("すべての社員と所属部署を取得する")]
    public void Test_FindAllJoinDepartment_Case1()
    {
        // Arrange
        var expectedCount = 8; // 期待される件数を指定
        // Act
        var result = _repository!.FindAllJoinDepartment();
        // Assert
        Assert.IsNotNull(result, "結果がnullです。");
        Assert.AreEqual(expectedCount, result.Count(), "取得件数が一致しません。");
        foreach (var employee in result)
        {
            Console.WriteLine(employee);
        }
    }
}
