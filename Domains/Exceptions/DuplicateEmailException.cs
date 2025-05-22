namespace Domains.Exceptions;
/// <summary>
/// メールアドレスの重複登録例外
/// </summary>
/// <author>古川正寿</author>
/// <date>2025/05/23</date>
public class DuplicateEmailException : Exception
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    public DuplicateEmailException() : base("メールアドレスが重複しています。")
    {
    }
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="message">メッセージ</param>
    public DuplicateEmailException(string message) : base(message)
    {
    }
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="message">メッセージ</param>
    /// <param name="innerException">内部例外</param>
    public DuplicateEmailException(string message, Exception innerException) : base(message, innerException)
    {
    }
}