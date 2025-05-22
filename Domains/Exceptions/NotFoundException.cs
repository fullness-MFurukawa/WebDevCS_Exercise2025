namespace Domains.Exceptions;
/// <summary>
/// データが見つからない場合の例外クラス  
/// </summary>
public class NotFoundException : Exception
{
    /// <summary>
    /// 指定された社員Idで社員が見つからない場合の例外クラス
    /// </summary>
    /// <param name="message">エラーメッセージ</param>
    public NotFoundException(string message) : base(message)
    {
    }
    /// <summary>
    /// 指定された社員Idで社員が見つからない場合の例外クラス
    /// </summary>
    /// <param name="message">エラーメッセージ</param>
    /// <param name="innerException">内部例外</param>
    public NotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
