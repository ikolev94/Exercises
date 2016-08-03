namespace LoggingSystem.Appenders
{
    using System;
    using System.IO;
    using Interfaces;
    using Enums;

    public abstract class FileAppender : IAppender
    {
        private string _filePath;

        protected FileAppender(string filePath)
        {
            this.FilePath = filePath;
        }

        public string FilePath
        {
            get
            {
                return this._filePath;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid configuration", "configuration");
                }

                if (!Directory.Exists(Path.GetDirectoryName(value)))
                {
                    throw new DirectoryNotFoundException("Invalid directory");
                }

                this._filePath = value;
            }
        }

        public abstract void Append(MessageType messageType, string message);
    }
}
