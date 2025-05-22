using Applications.Services;
using Microsoft.Extensions.DependencyInjection;
using Presentations.Configs;

namespace ApplicationsTests.ServiceImpl;
/// <summary>
/// 社員登録サービスインターフェースの実装テストクラス
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/23</date>
[TestClass]
public class EmployeeRegisterServiceTest
{
    private static IEmployeeRegisterService? _service;
    [ClassInitialize]
    public static void SetUp(TestContext context)
    {
        var provider = ServiceProviderUtil.GetProvider();
        // プロバイダからリポジトリを取得する
        _service = provider.GetRequiredService<IEmployeeRegisterService>();
    }

    [TestMethod("部署一覧を取得できる")]
    public void Test_GetDepartments_Case1()
    {
        var expectedCount = 5; // 期待される件数を指定
        var result = _service!.GetDepartments();
        Assert.IsNotNull(result, "結果がnullです。");
        Assert.AreEqual(expectedCount, result.Count(), "取得件数が一致しません。");
        foreach (var department in result)
        {
            Console.WriteLine(department);
        }
    }
    [TestMethod("メールアドレスが存在しない場合falseを返す")]
    public void TestExistsEmail_Case1()
    {
        var result = _service!.ExistsByEmail("sample@sample.com");
        Assert.IsFalse(result, "メールアドレスが存在しないのにtrueが返されました。");
    }
    [TestMethod("メールアドレスが存在する場合trueを返す")]
    public void TestExistsEmail_Case2()
    {
        var result = _service!.ExistsByEmail("h.sato@example.com");
        Assert.IsTrue(result, "メールアドレスが存在するのにfalseが返されました。");
    }
}
