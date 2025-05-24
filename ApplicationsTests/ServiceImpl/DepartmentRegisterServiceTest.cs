using Applications.Services;
using Domains.Models.Departments;
using Infrastructures.Contexts;
using InfrastructuresTests.Restorer;
using Microsoft.Extensions.DependencyInjection;
using Presentations.Configs;
namespace ApplicationsTests.ServiceImpl;
/// <summary>
/// 部署登録サービスインターフェースの実装クラスのテスト
/// </summary>
/// <summary>
/// <author>古川正寿</author>
/// <date>2025/05/26</date>
[TestClass]
public class DepartmentRegisterServiceTest
{
    private static AppDbContext? _dbContext;
    private static IDepartmentRegisterService? _service;
    [ClassInitialize]
    public static void SetUp(TestContext context)
    {
        // プロバイダからサービスを取得する
        _service = ServiceProviderUtil
            .GetProvider().GetRequiredService<IDepartmentRegisterService>();
        // プロバイダからAppDbContextを取得する
        _dbContext = ServiceProviderUtil
            .GetProvider().GetRequiredService<AppDbContext>();
    }

    [ClassCleanup]
    public static void TearDown()
    {
        var databaseRestrer = new DataBaseRestorer(_dbContext!);
        // データベースを復元する
        databaseRestrer.Restore();
    }

    [TestMethod("存在する部署名の場合trueを返す")]
    public void TestExists_Case1()
    {
        var name = "営業部"; // 存在する部署名を指定
        var result = _service!.Exists(name);
        Assert.IsTrue(result, "存在しない部署名でtrueが返されました。");
    }

    [TestMethod("存在しない部署名の場合falseを返す")]
    public void TestExists_Case2()
    {
        var name = "存在しない部署名"; // 存在しない部署名を指定
        var result = _service!.Exists(name);
        Assert.IsFalse(result, "存在する部署名でfalseが返されました。");
    }

    [TestMethod("部署を登録できる")]
    public void TestRegister_Case1()
    {
        var department = new Department("テスト部署");
        _service!.Register(department);
    }
}
