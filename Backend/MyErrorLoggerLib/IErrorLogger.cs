namespace MyErrorLoggerLib
{
    public interface IErrorLogger
    {
        // For Error loggings
       bool LogEntry(Exception e);
    }
}
