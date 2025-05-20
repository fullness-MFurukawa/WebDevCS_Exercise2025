namespace Domains.Exceptions;
/// <summary>
/// 内部エラーを表す例外クラス
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/20</date>
public class InternalServerException : Exception
{
    /// <summary>
    /// 内部エラーを表す例外クラス
    /// </summary>
    public InternalServerException(string message) : base(message)
    {
    }
    /// <summary>
    /// 内部エラーを表す例外クラス
    /// </summary>
    public InternalServerException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
