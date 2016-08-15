namespace LoggingSystem.Appenders
{
    using System.IO;
    using System.Xml;
    using Enums;

    public class XmlAppender : FileAppender
    {
        public XmlAppender(string filePath) : base(filePath)
        {
        }

        public override void Append(MessageType messageType, string message)
        {
            XmlDocument doc = new XmlDocument();
            if (!File.Exists(this.FilePath))
            {
                XmlNode productsNode = doc.CreateElement("DocumentElement");
                doc.AppendChild(productsNode);
            }
            else
            {
                doc.Load(this.FilePath);
            }

            XmlElement el = doc.CreateElement("Log");
            XmlElement typeElement = doc.CreateElement("Type");
            XmlElement messageElement = doc.CreateElement("Message");
            typeElement.InnerText = messageType.ToString();
            messageElement.InnerText = message;
            el.AppendChild(typeElement);
            el.AppendChild(messageElement);
            doc.DocumentElement.AppendChild(el);
            doc.Save(this.FilePath);
        }

    }
}
