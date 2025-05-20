using Domains.Models.Departments;
using Infrastructures.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Presentations.Configs;
namespace InfrastructuresTests.RepositoryImpl;
[TestClass]
public class DepartmentRepositioryFindAllTest
{
   
    private static IDepartmentRepository? _repository;
    [ClassInitialize]
    public static void SetUp(TestContext context)
    {
        // プロバイダからリポジトリを取得する
        _repository = ServiceProviderUtil
            .GetProvider().GetService<IDepartmentRepository>();
    }

    [TestMethod("全件取得できる")]
    public void Test_FindAll_Case1()
    {
        // Arrange
        var expectedCount = 5; // 期待される件数を指定
        // Act
        var result = _repository!.FindAll();
        // Assert
        Assert.IsNotNull(result, "結果がnullです。");
        Assert.AreEqual(expectedCount, result.Count(), "取得件数が一致しません。");
        foreach (var department in result)
        {
            Console.WriteLine(department);
        }
    }
}