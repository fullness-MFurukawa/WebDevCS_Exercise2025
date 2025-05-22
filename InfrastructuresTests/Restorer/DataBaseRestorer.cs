using Infrastructures.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace InfrastructuresTests.Restorer;
/// <summary>
/// 演習用のデータベースを復元するクラス  
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/23</date>
public class DataBaseRestorer
{
    private readonly ILogger<DataBaseRestorer> _logger;
    private readonly AppDbContext _context;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="context"></param>
    public DataBaseRestorer(AppDbContext context)
    {
        _context = context;
        // ロガーの初期化
        using var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
            .AddConsole()
            .SetMinimumLevel(LogLevel.Information);
        });
        _logger = loggerFactory.CreateLogger<DataBaseRestorer>();
    }


    /// <summary>
    /// データベースの復元
    /// </summary>
    public void Restore()
    {
       var sql = @"
            -- データの削除
            DELETE FROM EMPLOYEE;
            DELETE FROM DEPARTMENT;
            -- IDENTITYのリセット
            DBCC CHECKIDENT ('DEPARTMENT', RESEED, 100);
            DBCC CHECKIDENT ('EMPLOYEE', RESEED, 1000);
            -- 部署データの登録
            INSERT INTO DEPARTMENT (DEPT_NAME) VALUES (N'総務部');
            INSERT INTO DEPARTMENT (DEPT_NAME) VALUES (N'経理部');
            INSERT INTO DEPARTMENT (DEPT_NAME) VALUES (N'人事部');
            INSERT INTO DEPARTMENT (DEPT_NAME) VALUES (N'開発部');
            INSERT INTO DEPARTMENT (DEPT_NAME) VALUES (N'営業部');
            -- 社員データの登録
            INSERT INTO EMPLOYEE (NAME, EMAIL, PHONE, DEPT_NO) 
            VALUES (N'田中太郎', N't.tanaka@example.com', N'080-1234-1001', 102);

            INSERT INTO EMPLOYEE (NAME, EMAIL, PHONE, DEPT_NO) 
            VALUES (N'鈴木三郎', N's.suzuki@example.com', N'080-1234-1002', 101);

            INSERT INTO EMPLOYEE (NAME, EMAIL, PHONE, DEPT_NO) 
            VALUES (N'佐藤花子', N'h.sato@example.com', N'080-1234-1003', 104);

            INSERT INTO EMPLOYEE (NAME, EMAIL, PHONE, DEPT_NO) 
            VALUES (N'中田彩子', N'a.nakata@example.com', N'080-1234-1004', 105);

            INSERT INTO EMPLOYEE (NAME, EMAIL, PHONE, DEPT_NO) 
            VALUES (N'加藤圭太', N'k.kato@example.com', N'080-1234-1005', 103);

            INSERT INTO EMPLOYEE (NAME, EMAIL, PHONE, DEPT_NO) 
            VALUES (N'松本良太', N'r.matsumoto@example.com', N'080-1234-1006', 104);

            INSERT INTO EMPLOYEE (NAME, EMAIL, PHONE, DEPT_NO) 
            VALUES (N'山下孝輔', N'k.yamashita@example.com', N'080-1234-1007', 105);

            INSERT INTO EMPLOYEE (NAME, EMAIL, PHONE, DEPT_NO) 
            VALUES (N'渡辺大輔', N'd.watanabe@example.com', N'080-1234-1008', 104);
        ";
        try
        {
            _context.Database.ExecuteSqlRaw(sql);
            _logger.LogInformation("データベースの復元しました。");
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "データベースの復元に失敗しました。");
            ex.StackTrace!.ToString();
        }
        
    }
}
