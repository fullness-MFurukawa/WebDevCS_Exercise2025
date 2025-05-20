namespace Domains.Models.Departments;
/// <summary>
/// 部署データの相互変換インターフェース
/// </summary>
/// <typeparam name="T">変換先のデータ型</typeparam>
/// <author>古川正寿</author>
/// <date>2025/05/20</date>
public interface IDepartmentAdapter<T>
{
    /// <summary>
    /// 部署データを指定された形式のオブジェクトに変換する
    /// </summary>
    /// <param name="obj">部署データ</param>
    /// <returns></returns>
    T Convert(Department obj);
    /// <summary>
    /// 部署データのリストを指定された形式のオブジェクトのリストに変換する
    /// </summary>
    /// <param name="obj">部署データ</param>
    /// <returns></returns>
    List<T> Convert(List<Department> objs);

    /// <summary>
    /// 指定された形式のオブジェクトから部署データを復元する
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    Department Restore(T obj);
    /// <summary>
    /// 指定された形式のオブジェクトリストから部署データのリストを復元する
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    List<Department> Restore(List<T> objs);
}
