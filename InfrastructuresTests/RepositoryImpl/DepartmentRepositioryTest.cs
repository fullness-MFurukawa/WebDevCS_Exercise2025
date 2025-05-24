using Domains.Models.Departments;
using Infrastructures.Contexts;
using InfrastructuresTests.Restorer;
using Microsoft.Extensions.DependencyInjection;
using Presentations.Configs;
namespace InfrastructuresTests.RepositoryImpl;
/// <summary>
/// 部署データのCRUD操作リポジトリインターフェースの実装のテストクラス
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/22</date>
[TestClass]
public class DepartmentRepositioryTest
{
    private static IServiceScope? _scope = null;
    private static IDepartmentRepository? _repository;
    private static AppDbContext? _context;
    [ClassInitialize]
    public static void SetUp(TestContext context)
    {
        var provider = ServiceProviderUtil.GetProvider();
        // スコープを作成する
        _scope = provider.CreateScope();
        // プロバイダからリポジトリを取得する
        _repository = _scope!.ServiceProvider
            .GetRequiredService<IDepartmentRepository>();
        // プロバイダからDbContextを取得する
        _context = _scope.ServiceProvider.GetRequiredService<AppDbContext>();

        var databaseRestrer = new DataBaseRestorer(_context!);
        // データベースを復元する
        databaseRestrer.Restore();
    }

    [ClassCleanup]
    public static void TearDown()
    {
        var databaseRestrer = new DataBaseRestorer(_context!);
        // データベースを復元する
        databaseRestrer.Restore();
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

    [TestMethod("存在する部署名の場合trueを返す")]
    public void Test_Exists_Case1()
    {
        var name = "営業部"; // 存在する部署名を指定
        var result = _repository!.Exists(name);
        Assert.IsTrue(result, "存在しない部署名でtrueが返されました。");
    }
    [TestMethod("存在しない部署名の場合falseを返す")]
    public void Test_Exists_Case2()
    {
        var name = "存在しない部署名"; // 存在しない部署名を指定
        var result = _repository!.Exists(name);
        Assert.IsFalse(result, "存在する部署名でfalseが返されました。");
    }

    [TestMethod("部署を登録できる")]
    public void Test_Create_Case1()
    {
        var department = new Department("テスト部");
        _repository!.Create(department);
    }

}