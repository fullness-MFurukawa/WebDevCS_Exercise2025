using Domains.Models.Departments;
using Domains.Models.Employees;
using Infrastructures.Contexts;
using InfrastructuresTests.Restorer;
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
    private static IServiceScope? _scope = null;
    private static IEmployeeRepository? _repository;
    private static AppDbContext? _context;
    [ClassInitialize]
    public static void SetUp(TestContext context)
    {
        var provider = ServiceProviderUtil.GetProvider();
        // スコープを作成する
        _scope = provider.CreateScope();
        // プロバイダからリポジトリを取得する
        _repository = _scope!.ServiceProvider
            .GetRequiredService<IEmployeeRepository>();
        // プロバイダからDbContextを取得する
        _context = _scope.ServiceProvider.GetRequiredService<AppDbContext>();
    }

    [ClassCleanup]
    public static void TearDown()
    {
        var databaseRestrer = new DataBaseRestorer(_context!);
        // データベースを復元する
        databaseRestrer.Restore();
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

    [TestMethod("社員を永続化する")]
    public void Test_Create_Case1()
    {
        var department = new Department(101, "総務部");
        var employee = new Employee(
            "山田太郎",
            "tamada@sample.com",
            "090-111-2222", department);
        // トランザクションを開始する
        using var transaction = _context!.Database.BeginTransaction();
        try
        {
            _repository!.Create(employee);
            Assert.IsTrue(true , "登録が失敗しました。");
            Console.WriteLine($"テスト成功:{employee}");
        }
        finally
        {
            // トランザクションをロールバックする
            transaction.Rollback();
        }
    }
}
