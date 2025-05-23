namespace Presentations.Configs;
/// <summary>
/// サービスプロバイダを生成するユーティリティクラス
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/20</date>
public static class ServiceProviderUtil
{
    public static IServiceProvider GetProvider()
    {
        // appsettings.jsonを読み込む
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        // DIコンテナのServiceCollectionを生成する
        var services = new ServiceCollection();
        // 依存定義をする
        DependecySetting.Configure(configuration, services);
        // ログ機能の追加 2025/05/23
        services.AddLogging();
        // DIコンテナに登録されたインスタンスを提供するServiceProviderを生成する
        var provider = services.BuildServiceProvider(); 
        return provider;
    }
}
