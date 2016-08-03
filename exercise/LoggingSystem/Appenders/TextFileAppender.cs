namespace LoggingSystem.Appenders
{
    using System.IO;
    using Enums;

    public class TextFileAppender : FileAppender
    {

        public TextFileAppender(string filePath) : base(filePath)
        {
        }

        public override void Append(MessageType messageType, string message)
        {
            using (var sw = new StreamWriter(this.FilePath, true))
            {
                sw.WriteLine($"{messageType}: {message}");
            }
        }
    }
}
