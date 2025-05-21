namespace Domains.Models.Employees;
/// <summary>
/// 社員データの相互変換インターフェース
/// </summary>
/// <typeparam name="T">変換先のデータ型</typeparam>
/// <author>古川正寿</author>
/// <date>2025/05/21</date>
public interface IEmployeeAdapter<T>
{
    /// <summary>
    /// 社員データを指定された形式のオブジェクトに変換する
    /// </summary>
    /// <param name="obj">社員データ</param>
    /// <returns></returns>
    T Convert(Employee obj);
    /// <summary>
    /// 社員データのリストを指定された形式のオブジェクトのリストに変換する
    /// </summary>
    /// <param name="obj">社員データ</param>
    /// <returns></returns>
    List<T> Convert(List<Employee> objs);

    /// <summary>
    /// 指定された形式のオブジェクトから社員データを復元する
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    Employee Restore(T obj);
    /// <summary>
    /// 指定された形式のオブジェクトリストから社員データのリストを復元する
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    List<Employee> Restore(List<T> objs);
}
