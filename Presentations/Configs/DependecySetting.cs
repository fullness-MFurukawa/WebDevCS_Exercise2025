using Applications.ServiceImpls;
using Applications.Services;
using Domains.Models.Departments;
using Infrastructures.AdapterImpl;
using Infrastructures.Contexts;
using Infrastructures.Entities;
using Infrastructures.RepositoryImpl;
using Microsoft.EntityFrameworkCore;
using Presentations.Adapters;
using Presentations.Models.Departments;

namespace Presentations.Configs;

/// <summary>
/// 依存関係設定クラス
/// </summary>
public static class DependecySetting
{
    /// <summary>
    /// 依存関係の設定
    /// </summary>
    /// <param name="builder">WebApplicationBuilder</param>
    public static void Configure(IConfiguration configuration,IServiceCollection services)
    {
        // プレゼンテーション層の依存関係設定
        ConfigurePresentations(services);
        // アプリケーション層の依存関係設定
        ConfigureApplications(services);
        // インフラストラクチャ層の依存関係設定
        ConfigureInfrastructures(configuration , services);
    }

    /// <summary>
    /// プレゼンテーション層の依存
    /// </summary>
    /// <param name="builder"></param>
    private static void ConfigurePresentations(IServiceCollection services)
    {
        services.AddScoped<IDepartmentAdapter<DepartmentForm>, DepartmentFormAdapter>();
    }

    /// <summary>
    /// アプリケーション層の依存
    /// </summary>
    /// <param name="builder"></param>
    private static void ConfigureApplications(IServiceCollection services)
    {
        // 部署一覧サービスインターフェースの実装の登録
        services.AddScoped<IDepartmentListService, DepartmentListServiceImpl>();
    }

    private static void ConfigureInfrastructures(IConfiguration configuration, IServiceCollection services)
    {
        // DbContextの登録
        services.AddDbContext<AppDbContext>(options =>
        {
            // SQL Serverの接続文字列を指定
            options.UseSqlServer(configuration.GetConnectionString("ExerciseDB"));
            options.LogTo(Console.WriteLine, LogLevel.Information);
        });

        // 部署データのCRUD操作リポジトリインターフェースの実装の登録
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        // 部署データの相互変換アダプタの登録
        services.AddScoped<IDepartmentAdapter<DepartmentEntity>, DepartmentEntityAdapter>();
    }
}
