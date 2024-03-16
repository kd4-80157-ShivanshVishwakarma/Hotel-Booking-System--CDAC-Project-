namespace MyErrorLoggerLib
{
    public sealed class ErrorLoggerFile : IErrorLogger
    {
        public ErrorLoggerFile()
        {
            FilePath = "D:\\HotelBookingProject\\HotelBooking\\Exception.txt";
        }

        public string? FilePath { get; set; }

        public bool LogEntry(Exception e)
        {
            FileStream fs=null;
            if(File.Exists(FilePath))
            {
                fs=new FileStream(FilePath,FileMode.Append,FileAccess.Write);
            }
            else
            {
                fs=new FileStream(FilePath,FileMode.Create,FileAccess.Write);
            }
            StreamWriter write = new StreamWriter(fs);
            write.WriteLine(e.Message);
            write.Close();
            fs.Close();
            return true;
        }
    }
}
