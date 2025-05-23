using Applications.ServiceImpls;
using Applications.Services;
using Domains.Models.Departments;
using Domains.Models.Employees;
using Infrastructures.AdapterImpl;
using Infrastructures.Contexts;
using Infrastructures.Entities;
using Infrastructures.RepositoryImpl;
using Microsoft.EntityFrameworkCore;
using Presentations.Adapters;
using Presentations.Models.Departments;
using Presentations.Models.Employees;

namespace Presentations.Configs;

/// <summary>
/// 依存関係設定クラス
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/20</date>
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
        services.AddScoped<IEmployeeAdapter<EmployeeForm>, EmployeeFormAdapter>();
        services.AddScoped<IEmployeeAdapter<EmployeeRegisterForm>, EmployeeRegisterFormAdapter>();
    }

    /// <summary>
    /// アプリケーション層の依存
    /// </summary>
    /// <param name="builder"></param>
    private static void ConfigureApplications(IServiceCollection services)
    {
        // 部署一覧サービスインターフェースの実装の登録
        services.AddScoped<IDepartmentListService, DepartmentListService>();
        // 社員一覧サービスインターフェースの実装の登録
        services.AddScoped<IEmployeeListService, EmployeeListService>();
        // 社員登録サービスインターフェースの実装の登録
        services.AddScoped<IEmployeeRegisterService, EmployeeRegisterService>();
        // 部署登録サービスインターフェースの実装の登録
        services.AddScoped<IDepartmentRegisterService, DepartmentRegisterService>();
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

        // 部署データのCRUD操作リポジトリインターフェース実装の登録
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        // 部署データの相互変換アダプタの登録
        services.AddScoped<IDepartmentAdapter<DepartmentEntity>, DepartmentEntityAdapter>();
        // 社員データのCRUD操作リポジトリインターフェース実装の登録
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        // 社員データの相互変換アダプタの登録
        services.AddScoped<IEmployeeAdapter<EmployeeEntity>, EmployeeEntityAdapter>();
    }
}
