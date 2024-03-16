namespace MyErrorLoggerLib
{
    public sealed class ErrorLoggerConsole : IErrorLogger
    {
        public bool LogEntry(Exception e)
        {
            Console.WriteLine(e.Message);
            return true;
        }
    }
}
