namespace Buhtig_Issue_Tracker
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    using Buhtig_Issue_Tracker.Interfaces;

    public class Endpoint : IEndpoint
    {
        public Endpoint(string s)
        {
            this.UrlParser(s);
        }

        public string ActionName { get; set; }

        public IDictionary<string, string> Parameters { get; set; }

        private void UrlParser(string s)
        {
            int questionMark = s.IndexOf('?');
            if (questionMark != -1)
            {
                this.ActionName = s.Substring(0, questionMark);
                var pairs =
                    s.Substring(questionMark + 1)
                        .Split('&')
                        .Select(x => x.Split('=').Select(WebUtility.UrlDecode).ToArray());
                var parameters = pairs.ToDictionary(pair => pair[0], pair => pair[1]);

                this.Parameters = parameters;
            }
            else
            {
                this.ActionName = s;
            }
        }
    }
}
