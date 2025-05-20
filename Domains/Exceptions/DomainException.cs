namespace Domains.Exceptions;
/// <summary>
/// 業務データエラーを表す例外クラス
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/20</date>
public class DomainException : Exception
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    public DomainException()
    {
    }
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="message">メッセージ</param>
    public DomainException(string message) : base(message)
    {
    }
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="message">メッセージ</param>
    /// <param name="innerException">内部例外</param>
    public DomainException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
