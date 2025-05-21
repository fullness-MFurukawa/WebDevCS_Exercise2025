namespace Presentations.Configs;

/// <summary>
/// サービスプロバイダを生成するユーティリティクラス
/// </summary>
public static class ServiceProviderUtil
{
    public static IServiceProvider GetProvider()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        var services = new ServiceCollection();

        DependecySetting.Configure(configuration, services);

        var provider = services.BuildServiceProvider(); 

        return provider;
    }
}
