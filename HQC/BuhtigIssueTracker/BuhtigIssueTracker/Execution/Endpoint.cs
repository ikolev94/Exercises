namespace BuhtigIssueTracker.Execution
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    using BuhtigIssueTracker.Interfaces;

    public class Endpoint : IEndpoint
    {
        public Endpoint(string url)
        {
            int questionMarkIndex = url.IndexOf('?');
            if (questionMarkIndex != -1)
            {
                this.ParametersParser(url, questionMarkIndex);
            }
            else
            {
                this.ActionName = url;
            }
        }

        public string ActionName { get; set; }

        public IDictionary<string, string> Parameters { get; set; }

        private void ParametersParser(string url, int questionMark)
        {
            this.ActionName = url.Substring(0, questionMark);
            var pairs =
                url.Substring(questionMark + 1)
                    .Split('&')
                    .Select(item => item.Split('=').Select(WebUtility.UrlDecode).ToArray());
            var parameters = pairs.ToDictionary(pair => pair[0], pair => pair[1]);

            this.Parameters = parameters;
        }
    }
}