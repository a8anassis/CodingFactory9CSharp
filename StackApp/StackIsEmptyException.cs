namespace StackApp;

internal class StackIsEmptyException : Exception
{
    public StackIsEmptyException() : base() { }
    public StackIsEmptyException(string message) : base(message) { }
    public StackIsEmptyException(string message, Exception innerException) : base(message, innerException) { }
}
