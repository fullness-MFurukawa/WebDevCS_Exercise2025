namespace Presentations.Configs;
/// <summary>
/// サービスプロバイダを生成するユーティリティクラス
/// </summary>
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
        // DIコンテナに登録されたインスタンスを提供するServiceProviderを生成する
        var provider = services.BuildServiceProvider(); 
        return provider;
    }
}
